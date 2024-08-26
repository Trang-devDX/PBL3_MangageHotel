using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class CardRoom : UserControl
    {
        public CardRoom()
        {
            InitializeComponent();
        }
        public string NameRoom
        {
            get { return lbName.Text; }
            set { lbName.Text = value.ToString(); }
        }
        public int ID
        {
            get { return Convert.ToInt32(lbId.Text); }
            set { lbId.Text = value.ToString(); }
        }
        public string NameType
        {
            get { return lbType.Text; }
            set { lbType.Text = value.ToString(); }
        }

        public double Cost
        {
            get { return Convert.ToInt32(lbCost.Text.Replace(",", "")); }
            set { lbCost.Text = value.ToString("N0"); }
        }
        public bool Status
        {
            set { 
                  if(value == true)
                  {
                    pbStatus.Image = Properties.Resources.icons8_house_40__1_;
                  }
                  else
                  {
                    pbStatus.Image = Properties.Resources.icons8_house_40__2_;
                  }
                }
        }
        public int People
        {
            get { return Convert.ToInt32(lbPeople.Text); }
            set { lbPeople.Text = value.ToString(); }
        }
        public bool isCardClicked = false; // Biến để kiểm tra xem có thẻ nào đã được kick hay không
        public delegate void DataSentEventHandler(CardRoom card);
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
                guna2ShadowPanel1.FillColor = Color.White ;
            }
            CardClicked(this);
        }
    }
}
