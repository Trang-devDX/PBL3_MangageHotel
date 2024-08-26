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
using Guna.UI2.WinForms;
using Util;

namespace GUI
{
    public partial class ResetPassword : Form
    {
        private int idStaff;
        public ResetPassword(int idStaff)
        {
            InitializeComponent();
            this.idStaff = idStaff;
        }
        private void HideandView(object sender, EventArgs e)
        {
            if (((Guna2TextBox)sender).UseSystemPasswordChar)
            {
                ((Guna2TextBox)sender).UseSystemPasswordChar = false;
                ((Guna2TextBox)sender).IconRight = Properties.Resources.hiden;
            }
            else
            {
                ((Guna2TextBox)sender).UseSystemPasswordChar = true;
                ((Guna2TextBox)sender).IconRight = Properties.Resources.visible;
            }
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if(ValidateIn4() == true )
            {
                Account acc = AccountBLL.Instance.GetAccountById(idStaff);
                if(acc.Password.Trim() == HashPassword.GetHash(tbPassold.Text))
                {
                    if(tbPassnew.Text == tbPassnewagain.Text)
                    {
                        acc.Password = HashPassword.GetHash(tbPassnew.Text);
                        AccountBLL.Instance.Update(acc);
                        MessageBox.Show("Đổi thành công");
                        tbPassnew.Text = "";
                        tbPassnewagain.Text = "";
                        tbPassold.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Password new is không khớp");
                    }    
                }    
                else
                {
                    MessageBox.Show("Password old is not true");
                }    
            }       
        }
        public bool ValidateIn4()
        {
            if(tbPassnew.Text == "")
            {
                MessageBox.Show("Password new is invaild!!");
                tbPassnew.Focus();
                return false;
            }
            if (tbPassold.Text == "")
            {
                MessageBox.Show("Password old is invaild!!");
                tbPassold.Focus();
                return false;
            }
            if (tbPassnewagain.Text == "")
            {
                MessageBox.Show("Password new again is invaild!!");
                tbPassnewagain.Focus();
                return false;
            }
            return true;
        }
    }
}
