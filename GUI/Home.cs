using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using GUI.Manage;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class Home : Form
    {
        private int IdStaff;
        public Home(int idStaff)
        {
            InitializeComponent();
            HideAllSubMenu();
            this.IdStaff = idStaff;
            Phanquyen();
            btnHome.Visible = false;
        }
        public void Phanquyen()
        {
            if(AccountBLL.Instance.GetRoleById(IdStaff).Trim() == "Lễ tân")
            {
                btnManage.Visible= false;
                btnInfRoom.Visible = false;
                btnInfService.Visible = false;
                PanelRoom.Size = new System.Drawing.Size(163, 60);
                PanelService.Size = new System.Drawing.Size(163, 30);
            }
        }
        public void SetIdStaff(int id)
        {
            IdStaff = id;
        }
        private void HideAllSubMenu()
        {
            PanelManage.Visible = false;
            PanelRoom.Visible = false;
            PanelService.Visible = false;
        }
        private void HideSubMenu()
        {
            if (PanelManage.Visible == true)
                PanelManage.Visible = false;
            if (PanelRoom.Visible == true)
                PanelRoom.Visible = false;
            if (PanelService.Visible == true)
                PanelService.Visible = false;
        }
        private void ShowSubMenu(Guna2GradientPanel submenu)
        {
            if (submenu.Visible == false)
            {
                HideSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        private Form activeForm = null;
        private void OpenChildForm(Form ChildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(ChildForm);
            PanelChildForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        #region Các trình xử lí sự kiện các nút
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (PanelSetting.Visible == false)
            {
                PanelSetting.Visible = true;
            }
            else
                PanelSetting.Visible = false;
        }
        private void btnRoom_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelRoom);
        }
        private void btnService_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelService);
        }
        private void btnManage_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelManage);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Lobby());
        }
        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CRUD_Room());
        }
        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CRUD_TypeRoom());
        }
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CRUD_Service());
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CRUD_Customer());
        }
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CRUD_Account());
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CRUD_Staff());
        }

        #endregion

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ResetPassword(IdStaff));
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageRoom(IdStaff));
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MangageUseService());
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageInvoice(IdStaff));
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Statistical());
        }
    }
}
