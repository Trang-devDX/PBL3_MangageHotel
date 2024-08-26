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
    public partial class CardService : UserControl
    {
        public CardService()
        {
            InitializeComponent();
        }
        public string NameService
        {
            get { return lbName.Text; }
            set { lbName.Text = value.ToString(); }
        }
        public int ID
        {
            get { return Convert.ToInt32(lbId.Text); }
            set { lbId.Text = value.ToString(); }
        }
        public double Cost
        {
            get { return Convert.ToInt32(lbCost.Text); }
            set { lbCost.Text = value.ToString("N0"); }
        }
        public string Quantity
        {
            get { return tbQuantity.Text; }
        }
        public bool isCardClicked = false; // Biến để kiểm tra xem có thẻ nào đã được kick hay không
        public delegate void DataSentEventHandler(CardService card);
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
        public void HideQuantity(bool temp)
        {
            tbQuantity.Visible = temp;
        }
    }
}
