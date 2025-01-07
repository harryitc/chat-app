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
                    username = userService.GetUserName(item.CreatedBy),
                    MemberCount = groupService.GetgroupMemberCount(item.GroupID)
                };
                
                listGroupDTO.Add(groupDTO);
            }

            this.report_group.LocalReport.ReportPath = "./Reports/Report2.rdlc";
            var reportDataSource = new ReportDataSource("GroupDataSet", listGroupDTO); 
            this.report_group.LocalReport.DataSources.Clear();
            this.report_group.LocalReport.DataSources.Add(reportDataSource);

            this.report_group.RefreshReport();
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close_Hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = global::Client.Properties.Resources.Close;
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
