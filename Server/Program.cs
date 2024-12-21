using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Xml.Linq;
using Newtonsoft.Json;
using Server.Models;
//using Json = System.Text.Json;
//using JsonSerializer = System.Text.Json.JsonSerializer;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Server
{
    public class Program
    {
        private static TcpListener server;
        private static List<TcpClient> clients = new List<TcpClient>();
        private static string logFilePath = "server_log.txt";

        static void Main(string[] args)
        {
            try
            {
                using (var context = new ChatAppDBContext())
                {
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi kết nối: {ex.Message}");
                    }
                }

                server = new TcpListener(IPAddress.Any, 8888);
                server.Start();
                Log("Server started on port 8888...");
                Console.WriteLine("Server is running...");



                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    clients.Add(client);

                    // Lấy thông tin IP và port của client
                    IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                    string clientIp = clientEndPoint.Address.ToString();
                    int clientPort = clientEndPoint.Port;

                    Log($"New client connected: {clientIp}:{clientPort}");
                    Console.WriteLine($"New client connected: {clientIp}:{clientPort}");

                    Thread thread = new Thread(HandleClient);
                    thread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Log($"Server error: {ex.Message}");
            }
        }

        private static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            string clientIp = clientEndPoint.Address.ToString();
            int clientPort = clientEndPoint.Port;

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break; // Client disconnected
                    }

                    string jsonMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    GroupMessage chatMessage = JsonSerializer.Deserialize<GroupMessage>(jsonMessage);

                    Log($"Message from {clientIp}:{clientPort} (ID: {chatMessage.SenderID}): {chatMessage.Content}");
                    Console.WriteLine($"LogConsole - [{clientIp}:{clientPort}] (ID: {chatMessage.SenderID}): {chatMessage.Content}");

                    // Xử lý theo loại thông điệp
                    switch (chatMessage.MessageType)
                    {
                        case "text":
                            //Log($"Message from {chatMessage.User.Username}: {chatMessage.Content}");
                            GroupMessage newMessage = InsertMessage(chatMessage);
                            string jsonNewMessage = JsonSerializer.Serialize<GroupMessage>(newMessage);
                            Broadcast(jsonNewMessage, client);
                            break;

                        case "CreateGroup":
                            GroupMessage groupMessage = JsonSerializer.Deserialize<GroupMessage>(jsonMessage);
                            Log($"Group created: {groupMessage.Group.GroupName} by members: {string.Join(", ", groupMessage.User.Username)}");
                            // Xử lý tạo nhóm
                            break;

                        default:
                            Log($"Unknown message type: {chatMessage.MessageType}");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Error with client {clientIp}:{clientPort}: {ex.Message}");
                Console.WriteLine($"Error with client {clientIp}:{clientPort}: {ex.Message}");
            }
            finally
            {
                Log($"Client disconnected: {clientIp}:{clientPort}");
                Console.WriteLine($"Client disconnected: {clientIp}:{clientPort}");
                clients.Remove(client);
                client.Close();
            }
        }

        private static void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"[{timestamp}] {message}";

            // Append to log file
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);

            // Optionally, display in the console
            Console.WriteLine(logMessage);
        }

        private static void Broadcast(string message, TcpClient sender)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (var client in clients)
            {
                if (client != sender)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch
                    {
                        // Nếu gửi thất bại, loại bỏ client
                        clients.Remove(client);
                    }
                }
            }
            try
            {
                NetworkStream stream2 = sender.GetStream();
                stream2.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static GroupMessage InsertMessage(GroupMessage _groupMessage)
        {
            var newGroupMessage = _groupMessage;

            using (var context = new ChatAppDBContext())

                try
                {

                    try
                    {

                        GroupMessage groupMessage = new GroupMessage
                        {
                            GroupID = _groupMessage.GroupID,
                            SenderID = _groupMessage.SenderID,
                            Content = _groupMessage.Content,
                            MessageType = _groupMessage.MessageType,
                            Timestamp = _groupMessage.Timestamp
                        };

                        string jsonNewMessage = JsonSerializer.Serialize<GroupMessage>(groupMessage);
                        //Console.WriteLine("ahihi1111: " + jsonNewMessage);

                        newGroupMessage = context.GroupMessages.Add(groupMessage);

                        jsonNewMessage = JsonSerializer.Serialize<GroupMessage>(newGroupMessage);
                        //Console.WriteLine("ahihi2222: " + jsonNewMessage);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi insert message vào DB: " + ex.Message);
                    }
                    finally
                    {
                        //PrintJson(groupMessage);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi kết nối: {ex.Message}");
                }

            return newGroupMessage;

        }

        private static void PrintJson(object obj)
        {
            Console.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true }));
        }

    }
}
