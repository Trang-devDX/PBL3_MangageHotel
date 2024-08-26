using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Usercontrol
{
    public partial class CardStaff : UserControl
    {
        public CardStaff()
        {
            InitializeComponent();
        }
        public string NameStaff
        {
            get { return lbName.Text; }
            set { lbName.Text = value.ToString(); }
        }
        public string CCCD
        {
            get { return lbCCCD.Text; }
            set { lbCCCD.Text = value.ToString(); }
        }
        public string Phone
        {
            get { return lbPhone.Text; }
            set { lbPhone.Text = value.ToString(); }
        }
        public string Salary
        {
            get { return lbSalary.Text; }
            set { lbSalary.Text = value.ToString(); }
        }
        public int ID
        {
            get { return Convert.ToInt32(lbId.Text); }
            set { lbId.Text = value.ToString(); }
        }
        public string Role
        {
            set
            {
                if (value == "Quản lí")
                {
                    pbRole.Image = Properties.Resources.icons8_manager_50;
                }
                if (value == "Lễ tân")
                {
                    pbRole.Image = Properties.Resources.icons8_receptionist_50;
                }
            }
        }
        public bool isCardClicked = false; // Biến để kiểm tra xem có thẻ nào đã được kick hay không
        public delegate void DataSentEventHandler(CardStaff card);
        public event DataSentEventHandler CardClicked;
        private void CardMouseEnter(object sender, EventArgs e)
        {
            if (!isCardClicked)
            {
                guna2ShadowPanel1.FillColor = Color.LightCyan;
            }
        }
        private void CardMouseLeave(object sender, EventArgs e)
        {
            if (!isCardClicked)
            {
                guna2ShadowPanel1.FillColor = Color.White;
            }
        }
        public void CancelChoose()
        {
            isCardClicked = false;
            guna2ShadowPanel1.FillColor = Color.White;
        }
        private void CardClick(object sender, EventArgs e)
        {
            if (!isCardClicked)
            {
                isCardClicked = true;
                guna2ShadowPanel1.FillColor = Color.LightCyan;
            }
            else
            {
                isCardClicked = false;
                guna2ShadowPanel1.FillColor = Color.White;
            }
            CardClicked(this);
        }
    }
}
