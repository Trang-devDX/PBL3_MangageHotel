using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI.Usercontrol
{
    public partial class CardTypeRoom : UserControl
    {
        public CardTypeRoom()
        {
            InitializeComponent();
        }
        public string NameType
        {
            get { return lbName.Text; }
            set { lbName.Text = value.ToString(); }
        }

        public int ID
        {
            get { return Convert.ToInt32(lbId.Text); }
            set { lbId.Text = value.ToString(); }
        }
        public int People
        {
            get { return Convert.ToInt32(lbPeople.Text); }
            set { lbPeople.Text = value.ToString(); }
        }

        public double Cost
        {
            get { return Convert.ToInt32(lbCost.Text); }
            set { lbCost.Text = value.ToString("N0"); }
        }
        public bool isCardClicked = false; // Biến để kiểm tra xem có thẻ nào đã được kick hay không
        public delegate void DataSentEventHandler(CardTypeRoom card);
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
