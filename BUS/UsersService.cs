using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class UsersService
    {
        ChatAppDBContext db = new ChatAppDBContext();

        public string GetUserName(int id)
        {
            return db.Users.Where(x => x.UserID == id).Select(x => x.Username).FirstOrDefault();
        }
    }
}
