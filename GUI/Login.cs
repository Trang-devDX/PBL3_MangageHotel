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
using Util;

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            tbId.Focus();
        }
        private void tbPass_IconRightClick_1(object sender, EventArgs e)
        {
            if (tbPass.UseSystemPasswordChar)
            {
                tbPass.UseSystemPasswordChar = false;
                tbPass.IconRight = Properties.Resources.hiden;
            }
            else
            {
                tbPass.UseSystemPasswordChar = true;
                tbPass.IconRight = Properties.Resources.visible;
            }
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if(ValidateIn4() == true)
            {
                if(AccountBLL.Instance.GetAccountById(Convert.ToInt32(tbId.Text)) != null)
                {
                    if(AccountBLL.Instance.CheckPass(Convert.ToInt32(tbId.Text),HashPassword.GetHash(tbPass.Text.Trim())) == true)
                    {
                        this.Hide();
                        Home f = new Home(Convert.ToInt32(tbId.Text.Trim()));
                        f.Closed += (s, args) => this.Close();
                        f.Show();
                    }   
                    else
                    {
                        MessageBox.Show("Password is not true!!!");
                        tbId.Focus();
                    }    
                }   
                else
                {
                    MessageBox.Show("ID Staff is not exist!!!");
                    tbId.Focus();

                }    
            }    
        }
        public bool ValidateIn4()
        {
            if(IsNumeric.Check(tbId.Text) == false)
            {
                MessageBox.Show("ID Staff is invaild!!!");
                tbId.Focus();
                return false;
            }
            if (tbPass.Text == "")
            {
                MessageBox.Show("Password is invaild!!!");
                tbPass.Focus();
                return false;
            }
            return true;
        }
    }
}
