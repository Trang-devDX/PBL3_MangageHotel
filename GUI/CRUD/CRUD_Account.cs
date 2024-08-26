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
using System.Xml.Linq;
using GUI.Usercontrol;
using Util;

namespace GUI
{
    public partial class CRUD_Account : Form
    {
        public CRUD_Account()
        {
            InitializeComponent();
        }
        private int SelectedId = 0;
        List<CardAccount> cardAccounts;
        private void CRUD_Account_Load(object sender, EventArgs e)
        {
            FillTableAccount(AccountBLL.Instance.GetAllAccount());
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
                Account account = AccountBLL.Instance.GetAccountById(SelectedId);
                tbId.Text = account.IdSatff.ToString();
                tbId1.Text = account.IdSatff.ToString();
                cbbRole.Text = account.Role;
                cbbStatus.Text = account.Status.Trim();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản");
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
                Account account = new Account
                {
                    IdSatff = Convert.ToInt32(tbId.Text),
                    Role = cbbRole.Text,
                    Status = cbbStatus.Text,
                };
                AccountBLL.Instance.Update(account);
                Renew();
                MessageBox.Show("Update succesfully");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateInformation() == true)
            {
                AccountBLL.Instance.Delete(Convert.ToInt32(tbId.Text));
                Renew();
                MessageBox.Show("Delete succesfully");
            }
        }
        private void btnFind_IconRightClick(object sender, EventArgs e)
        {
            if (IsNumeric.Check(tbFind.Text) == true)
            {
                FillTableAccount(new List<Account>
                {
                    AccountBLL.Instance.GetAccountById(Convert.ToInt32(tbFind.Text))
                });
                tbFind.Text = "";
            }
            else
            {
                MessageBox.Show("Id Staff is invaild!!");
            }    
        }
        private void Card_Clicked(CardAccount account)
        {
            if (SelectedId == account.ID)
            {
                SelectedId = 0;
            }
            else
            {
                if (SelectedId != 0)
                {
                    foreach (CardAccount i in cardAccounts)
                    {
                        if (i.ID == SelectedId)
                        {
                            i.CancelChoose();
                            break;
                        }
                    }
                }
                SelectedId = account.ID;
            }
        }
        public bool ValidateInformation()
        {
            if (cbbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Role is invaild!!");
                cbbRole.Focus();
                return false;
            }
            if (cbbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Status is invaild!!");
                cbbStatus.Focus();
                return false;
            }
            return true;
        }
        public void Renew()
        {
            cbbRole.SelectedIndex = -1;
            cbbStatus.SelectedIndex = -1;
            tbId.Text = "";
            tbId1.Text = "";
            tbPass.Text = "";
            SelectedId = 0;
            FillTableAccount(AccountBLL.Instance.GetAllAccount());
        }
        public void FillTableAccount(List<Account> list)
        {
            tableAccount.Controls.Clear();
            tableAccount.RowStyles.Clear();
            cardAccounts = new List<CardAccount>();
            foreach (var i in list)
            {
                CardAccount card = new CardAccount
                {
                    ID = i.IdSatff,
                    Role = i.Role,
                    Status = i.Status.Trim(),
                };
                // Đăng ký sự kiện Card_Clicked
                card.CardClicked += Card_Clicked;
                cardAccounts.Add(card);
                tableAccount.Controls.Add(card);
            }
        }
        private void btnResPass_Click(object sender, EventArgs e)
        {
            if(tbPass.Text != "")
            {
                Account ac = AccountBLL.Instance.GetAccountById(Convert.ToInt32(tbId1.Text));
                ac.Password = HashPassword.GetHash(tbPass.Text);
                AccountBLL.Instance.Update(ac);
                Renew();
                MessageBox.Show("Reset password succesfully");
            }   
            else
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!!");
            }    
        }
    }
}
