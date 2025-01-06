using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ReportServices
    {
        private DAL.GetGroups dal;

        public ReportServices()
        {
            dal = new DAL.GetGroups(); // Khởi tạo đối tượng DAL
        }

        public DataTable GetGroupReport()
        {
            return dal.GetAllGroupsWithMembers(); // Gọi phương thức
        }
    }
}
