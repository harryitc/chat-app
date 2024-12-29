using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Comunicator.Models;
//using Json = System.Text.Json;
//using JsonSerializer = System.Text.Json.JsonSerializer;

using Comunicator;

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
                        Log($"Lỗi kết nối: {ex.Message}");
                        throw new Exception($"Lỗi kết nối: {ex.Message}");
                    }
                }

                server = new TcpListener(IPAddress.Any, 8888);
                server.Start();
                Log("Server started on port 8888...");
                Log("Server is running...");



                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    clients.Add(client);

                    // Lấy thông tin IP và port của client
                    IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                    string clientIp = clientEndPoint.Address.ToString();
                    int clientPort = clientEndPoint.Port;

                    Log($"New client connected: {clientIp}:{clientPort}");

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
            byte[] buffer = new byte[4096];

            try
            {
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        Log($"[bytesRead]: {clientIp}:{clientPort} disconnected!");
                        break; // Client disconnected
                    }

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    //Log($"[{clientIp}:{clientPort}] => {receivedData}");

                    /* Dữ liệu sau khi parse
                     var message = new
                        {
                            Type = "message",
                            Data = new
                            {
                                GroupID = 1,
                                SenderID = 10,
                                Content = "Hello, everyone!",
                                MessageType = "text"
                            }
                        };
                     */
                    JObject json = JObject.Parse(receivedData);
                    string type = json["Type"].ToString();

                    //string responseData = "";

                    //switch (type)
                    //{
                    //    case EventType.SEND_MESSAGE:
                    //        responseData = HandleMessage(json["Data"].ToObject<GroupMessage>());
                    //        break;
                    //    case EventType.JOIN_GROUP:
                    //        responseData = HandleJoinGroup(json["Data"].ToObject<GroupMember>());
                    //        break;
                    //    case "addFriend":
                    //        //HandleAddFriend(json["Data"].ToObject<FriendRequestData>());
                    //        break;
                    //    case "groupAction":
                    //        //HandleGroupAction(json["Data"].ToObject<GroupActionData>());
                    //        break;
                    //    default:
                    //        Log($"Unknown type: {type}");
                    //        break;
                    //}


                    //// Xử lý theo loại thông điệp
                    //switch (type)
                    //{
                    //    case "text":

                    //        break;

                    //    case "CreateGroup":
                    //        GroupMessage groupMessage = JsonSerializer.Deserialize<GroupMessage>(jsonMessage);
                    //        Log($"Group created: {groupMessage.Group.GroupName} by members: {string.Join(", ", groupMessage.User.Username)}");
                    //        // Xử lý tạo nhóm
                    //        break;

                    //    default:
                    //        Log($"Unknown message type: {chatMessage.MessageType}");
                    //        break;
                    //}

                    Broadcast(receivedData, client);
                    //Broadcast(responseData, client);

                    foreach (var _client in clients)
                    {
                        if (!IsSocketConnected(_client))
                        {
                            Log($"Client disconnected: {((IPEndPoint)_client.Client.RemoteEndPoint).Address}");
                            clients.Remove(_client);
                            _client.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Log($"Error with client {clientIp}:{clientPort}: {ex.Message}");
            }
            finally
            {
                Log($"Client disconnected: {clientIp}:{clientPort}");
                clients.Remove(client);
                client.Close();
            }
        }

        //private static string HandleJoinGroup(GroupMember groupMember)
        //{
        //    return JsonConvert.SerializeObject(new
        //    {
        //        Type = EventType.JOIN_GROUP,
        //        Data = groupMember
        //    });
        //}

        //private static string HandleMessage(GroupMessage groupMessage)
        //{

        //    return JsonConvert.SerializeObject(new
        //    {
        //        Type = EventType.SEND_MESSAGE,
        //        Data = groupMessage
        //    });

        //    string result = "";

        //    using (var context = new ChatAppDBContext())
        //    {
        //        try
        //        {
        //            try
        //            {
        //                var newGroupMessage = context.GroupMessages.Add(groupMessage);
        //                context.SaveChanges();

        //                result = JsonConvert.SerializeObject(new
        //                {
        //                    Type = EventType.SEND_MESSAGE,
        //                    Data = newGroupMessage
        //                });
        //            }
        //            catch (Exception ex)
        //            {
        //                Log("Lỗi insert message vào DB: " + ex.Message);
        //            }
        //            finally
        //            {
        //                //PrintJson(groupMessage);
        //            }

        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception($"Lỗi kết nối: {ex.Message}");
        //        }
        //    }
        //}

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
            var disconnectedClients = new List<TcpClient>();

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
                        // Nếu gửi thất bại, thêm client vào danh sách bị ngắt kết nối
                        disconnectedClients.Add(client);
                    }
                }
            }

            // Loại bỏ các client bị ngắt kết nối khỏi danh sách
            foreach (var disconnectedClient in disconnectedClients)
            {
                clients.Remove(disconnectedClient);
                disconnectedClient.Close();
                Log("Removed disconnected client.");
            }

            // Gửi phản hồi lại cho sender (nếu cần)
            //try
            //{
            //    NetworkStream stream = sender.GetStream();
            //    stream.Write(buffer, 0, buffer.Length);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error sending message to sender: {ex.Message}");
            //}
        }

        private static bool IsSocketConnected(TcpClient client)
        {
            try
            {
                return !(client.Client.Poll(1, SelectMode.SelectRead) && client.Client.Available == 0);
            }
            catch (SocketException)
            {
                return false;
            }
        }
    }
}
