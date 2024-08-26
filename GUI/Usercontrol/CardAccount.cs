using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Usercontrol
{
    public partial class CardAccount : UserControl
    {
        public CardAccount()
        {
            InitializeComponent();
        }
        public string Role
        {
            get { return lbRole.Text; }
            set { lbRole.Text = value.ToString(); }
        }
        public int ID
        {
            get { return Convert.ToInt32(lbId.Text); }
            set { lbId.Text = value.ToString(); }
        }
        public string Status
        {
            set
            {
                if(value == "Khóa")
                {
                    pbStatus.Image = Properties.Resources.icons8_lock_50;
                }
                if(value == "Mở")
                {
                    pbStatus.Image = Properties.Resources.icons8_unlock_50;
                }
            }
        }
        public bool isCardClicked = false; // Biến để kiểm tra xem có thẻ nào đã được kick hay không
        public delegate void DataSentEventHandler(CardAccount card);
        public event DataSentEventHandler CardClicked;
        private void guna2ShadowPanel1_MouseEnter(object sender, EventArgs e)
        {
            if (!isCardClicked)
            {
                guna2ShadowPanel1.FillColor = Color.LightCyan;
            }
        }

        private void guna2ShadowPanel1_MouseLeave(object sender, EventArgs e)
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
        private void guna2ShadowPanel1_Click(object sender, EventArgs e)
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
