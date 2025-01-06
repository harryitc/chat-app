using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class GroupService
    {
        ChatAppDBContext db = new ChatAppDBContext();
        public List<Group> GetGroups()
        {
            return db.Groups.ToList();
        }
    }
}
