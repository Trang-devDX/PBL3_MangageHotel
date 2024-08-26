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
using DTO;
using GUI.Usercontrol;
using Util;

namespace GUI
{
    public partial class CRUD_Service : Form
    {
        public CRUD_Service()
        {
            InitializeComponent();
        }
        private int SelectedId = 0;
        List<CardService> cardServices;
        private void CRUD_Service_Load(object sender, EventArgs e)
        {
            FillTableService(ServiceBLL.Instance.GetAllService());
        }
        private void pbEdit_MouseEnter(object sender, EventArgs e)
        {
            pbEdit.BackColor = Color.LightSkyBlue;
        }
        private void pbEdit_MouseLeave(object sender, EventArgs e)
        {
            pbEdit.BackColor = Color.White;
        }
        private void pbEdit_Click(object sender, EventArgs e)
        {
            if (SelectedId != 0)
            {
                Service service = ServiceBLL.Instance.GetServiceById(SelectedId);
                tbName.Text = service.Name.Trim();
                tbId.Text = service.IdService.ToString();
                tbCost.Text = service.Cost.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInformation() == true)
            {
                Service service = new Service
                {
                    Name = tbName.Text,
                    Cost = Convert.ToInt32(tbCost.Text),
                    IsUse = true
                };
                ServiceBLL.Instance.Add(service);
                Renew();
                MessageBox.Show("Add succesfully");
            }
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            Renew();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInformation() == true)
            {
                Service service = new Service
                {
                    IdService = Convert.ToInt32(tbId.Text),
                    Name = tbName.Text,
                    Cost = Convert.ToInt32(tbCost.Text),
                };
                ServiceBLL.Instance.Update(service);
                Renew();
                MessageBox.Show("Update succesfully");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateInformation() == true)
            {
                ServiceBLL.Instance.Delete(Convert.ToInt32(tbId.Text));
                Renew();
                MessageBox.Show("Delete succesfully");
            }
        }
        private void btnFind_IconRightClick(object sender, EventArgs e)
        {
            FillTableService(ServiceBLL.Instance.GetServiceByKeyWord(tbFind.Text));
            tbFind.Text = "";
        }
        private void Card_Clicked(CardService service)
        {
            if (SelectedId == service.ID)
            {
                SelectedId = 0;
            }
            else
            {
                if (SelectedId != 0)
                {
                    foreach (CardService i in cardServices)
                    {
                        if (i.ID == SelectedId)
                        {
                            i.CancelChoose();
                            break;
                        }
                    }
                }
                SelectedId = service.ID;
            }
        }
        public bool ValidateInformation()
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Name is invaild!!");
                tbName.Focus();
                return false;
            }
            if (IsNumeric.Check(tbCost.Text) == false)
            {
                MessageBox.Show("Cost is invaild!!");
                tbCost.Focus();
                return false;
            }
            return true;
        }
        public void Renew()
        {
            tbFind.Text = "";
            tbName.Text = "";
            tbId.Text = "";
            tbCost.Text = "";
            SelectedId = 0;
            FillTableService(ServiceBLL.Instance.GetAllService());
        }
        public void FillTableService(List<Service> list)
        {
            tableService.Controls.Clear();
            tableService.RowStyles.Clear();
            cardServices = new List<CardService>();
            foreach (var i in list)
            {
                CardService card = new CardService
                {
                    ID = i.IdService,
                    NameService = i.Name,
                    Cost = (double)i.Cost,
                };
                // Đăng ký sự kiện Card_Clicked
                card.CardClicked += Card_Clicked;
                card.HideQuantity(false);
                cardServices.Add(card);
                tableService.Controls.Add(card);
            }
        }
    }
}
