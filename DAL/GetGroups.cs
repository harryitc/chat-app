using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class GetGroups
    {
        private string connectionString;

        public GetGroups()
        {
            // Lấy connection string từ App.config
            connectionString = ConfigurationManager.ConnectionStrings["ChatAppDBContext"].ConnectionString;
        }

        public DataTable GetAllGroupsWithMembers()
        {
            string query = @"
            SELECT 
                g.GroupID,
                g.GroupName,
                u.Username AS MemberName,
                gm.Role AS MemberRole,
                gm.JoinedAt AS JoinDate
            FROM 
                Groups g
            JOIN 
                GroupMembers gm ON g.GroupID = gm.GroupID
            JOIN 
                Users u ON gm.UserID = u.UserID
            ORDER BY 
                g.GroupID, gm.JoinedAt";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (ghi log hoặc thông báo cho người dùng)
                    Console.WriteLine("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                    return null; // Hoặc trả về DataTable rỗng nếu cần
                }
            }
        }
    }
}
