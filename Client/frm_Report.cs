using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL.DTO;
using Microsoft.Reporting.WinForms;
namespace Client
{
    public partial class frm_Report : Form
    {

        public readonly GroupService groupService = new GroupService();
        public readonly UsersService userService = new UsersService();

        public frm_Report()
        {
            InitializeComponent();
        }

        private void frm_Report_Load(object sender, EventArgs e)
        {

            var listGroup = groupService.GetGroups();

            List<GroupDTO> listGroupDTO = new List<GroupDTO>();

            foreach (var item in listGroup)
            {
                GroupDTO groupDTO = new GroupDTO 
                {
                    GroupID = item.GroupID,
                    GroupName = item.GroupName,
                    username = userService.GetUserName(item.CreatedBy)
                };
                
                listGroupDTO.Add(groupDTO);
            }

            this.report_group.LocalReport.ReportPath = "./Reports/Report2.rdlc";
            var reportDataSource = new ReportDataSource("GroupDataSet", listGroupDTO); 
            this.report_group.LocalReport.DataSources.Clear();
            this.report_group.LocalReport.DataSources.Add(reportDataSource);

            this.report_group.RefreshReport();
        }
    }
}
