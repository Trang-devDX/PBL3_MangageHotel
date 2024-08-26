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
    public partial class CRUD_Customer : Form
    {
        public CRUD_Customer()
        {
            InitializeComponent();
        }
        private int SelectedId = 0;
        List<CardCustomer> cardCustomers;
        private void CRUD_Customer_Load(object sender, EventArgs e)
        {
            FillTableCustomer(CustomerBLL.Instance.GetAllCustomer());
        }
        private void pbEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.LightSkyBlue;
        }
        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.White;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedId != 0)
            {
                CustomerDTO customer = CustomerBLL.Instance.GetCustomerById(SelectedId);
                tbId.Text = customer.IdCustomer.ToString();
                tbCCCD.Text = customer.CCCD;
                tbName.Text = customer.Name;
                tbAddress.Text = customer.Address;
                tbPhone.Text = customer.Phone;
                if (customer.Gender == true)
                    rbNam.Checked = true;
                else
                    rbNu.Checked = true;
                dtpBirth.Value = customer.Birth;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate4() == true)
            {
                CustomerDTO customer = new CustomerDTO
                {
                    Name = tbName.Text,
                    CCCD = tbCCCD.Text,
                    Phone = tbPhone.Text,
                    Address = tbAddress.Text,
                    Gender = rbNam.Checked,
                    Birth = dtpBirth.Value,
                };
                CustomerBLL.Instance.Add(customer);
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
            if (Validate4() == true)
            {
                CustomerDTO customer = new CustomerDTO
                {
                    IdCustomer = Convert.ToInt32(tbId.Text),
                    Name = tbName.Text,
                    CCCD = tbCCCD.Text,
                    Phone = tbPhone.Text,
                    Address = tbAddress.Text,   
                    Gender = rbNam.Checked,
                    Birth = dtpBirth.Value
                };
                CustomerBLL.Instance.Update(customer);
                Renew();
                MessageBox.Show("Update succesfully");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Validate4() == true)
            {
                CustomerBLL.Instance.Delete(Convert.ToInt32(tbId.Text));
                Renew();
                MessageBox.Show("Delete succesfully");
            }
        }
        private void btnFind_IconRightClick(object sender, EventArgs e)
        {
            FillTableCustomer(CustomerBLL.Instance.GetCustomerByKeyWord(tbFind.Text));
            tbFind.Text = "";
        }
        private void Card_Clicked(CardCustomer customer)
        {
            if (SelectedId == customer.ID)
            {
                SelectedId = 0;
            }
            else
            {
                if (SelectedId != 0)
                {
                    foreach (CardCustomer i in cardCustomers)
                    {
                        if (i.ID == SelectedId)
                        {
                            i.CancelChoose();
                            break;
                        }
                    }
                }
                SelectedId = customer.ID;
            }
        }
        public bool Validate4()
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Name is invaild!!");
                tbName.Focus();
                return false;
            }
            if(ValidateInformation.CCCD(tbCCCD.Text) == false)
            {
                MessageBox.Show("CCCD is invaild!!");
                tbCCCD.Focus();
                return false;
            }
            if (ValidateInformation.Phone(tbPhone.Text) == false)
            {
                MessageBox.Show("Phone is invaild!!");
                tbPhone.Focus();
                return false;
            }
            if(rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Gender is invaild!!");
                return false;
            }    
            return true;
        }
        public void Renew()
        {
            tbFind.Text = "";
            tbName.Text = "";
            tbId.Text = "";
            tbCCCD.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            rbNam.Checked = false;
            rbNu.Checked = false;
            dtpBirth.Value = DateTime.Now;
            SelectedId = 0;
            FillTableCustomer(CustomerBLL.Instance.GetAllCustomer());
        }
        public void FillTableCustomer(List<CustomerDTO> list)
        {
            tableCustomer.Controls.Clear();
            tableCustomer.RowStyles.Clear();
            cardCustomers = new List<CardCustomer>();
            foreach (var i in list)
            {
                CardCustomer card = new CardCustomer
                {
                    ID = i.IdCustomer, 
                    CCCD = i.CCCD,
                    NameCustomer = i.Name,
                    Phone = i.Phone,
                    Address = i.Address,
                    Gender = i.Gender,
                    Birth = i.Birth
                };
                // Đăng ký sự kiện Card_Clicked
                card.CardClicked += Card_Clicked;
                cardCustomers.Add(card);
                tableCustomer.Controls.Add(card);
            }
        }
    }
}
