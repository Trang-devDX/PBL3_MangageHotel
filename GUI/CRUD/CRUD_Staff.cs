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
    public partial class CRUD_Staff : Form
    {
        public CRUD_Staff()
        {
            InitializeComponent();
        }
        private int SelectedId = 0;
        List<CardStaff> cardReceptionists;
        private void CRUD_Staff_Load(object sender, EventArgs e)
        {
            FillTableReceptionist(ReceptionistBLL.Instance.GetAllReceptionist());
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
                ReceptionistDTO rec = ReceptionistBLL.Instance.GetReceptionistById(SelectedId);
                tbId.Text = rec.IdReceptionist.ToString();
                tbCCCD.Text = rec.CCCD;
                tbName.Text = rec.Name;
                tbAddress.Text = rec.Address;
                tbPhone.Text = rec.Phone;
                if (rec.Gender == true)
                    rbNam.Checked = true;
                else
                    rbNu.Checked = true;
                dtpBirth.Value = rec.Birth;
                tbSalary.Text = rec.Salary.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate4() == true)
            {
                ReceptionistDTO rec = new ReceptionistDTO
                {
                    Name = tbName.Text,
                    CCCD = tbCCCD.Text,
                    Phone = tbPhone.Text,
                    Address = tbAddress.Text,
                    Gender = rbNam.Checked,
                    Birth = dtpBirth.Value,
                    Salary = Convert.ToInt32(tbSalary.Text),
                    IsWork = true
                };
                ReceptionistBLL.Instance.Add(rec);
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
                ReceptionistDTO rec = new ReceptionistDTO
                {
                    IdReceptionist = Convert.ToInt32(tbId.Text),
                    Name = tbName.Text,
                    CCCD = tbCCCD.Text,
                    Phone = tbPhone.Text,
                    Address = tbAddress.Text,
                    Gender = rbNam.Checked,
                    Birth = dtpBirth.Value,
                    Salary = Convert.ToInt32(tbSalary.Text)
                };
                ReceptionistBLL.Instance.Update(rec);
                Renew();
                MessageBox.Show("Update succesfully");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Validate4() == true)
            {
                ReceptionistBLL.Instance.Delete(Convert.ToInt32(tbId.Text));
                Renew();
                MessageBox.Show("Delete succesfully");
            }
        }
        private void btnFind_IconRightClick(object sender, EventArgs e)
        {
            FillTableReceptionist(ReceptionistBLL.Instance.GetReceptionistByKeyWord(tbFind.Text));
            tbFind.Text = "";
        }
        private void Card_Clicked(CardStaff rec)
        {
            if (SelectedId == rec.ID)
            {
                SelectedId = 0;
            }
            else
            {
                if (SelectedId != 0)
                {
                    foreach (CardStaff i in cardReceptionists)
                    {
                        if (i.ID == SelectedId)
                        {
                            i.CancelChoose();
                            break;
                        }
                    }
                }
                SelectedId = rec.ID;
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
            if (ValidateInformation.CCCD(tbCCCD.Text) == false)
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
            if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Gender is invaild!!");
                return false;
            }
            if(IsNumeric.Check(tbSalary.Text) == false)
            {
                MessageBox.Show("Salary is invaild!!");
                tbSalary.Focus();
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
            tbSalary.Text = "";
            SelectedId = 0;
            FillTableReceptionist(ReceptionistBLL.Instance.GetAllReceptionist());
        }
        public void FillTableReceptionist(List<ReceptionistDTO> list)
        {
            tableReceptionist.Controls.Clear();
            tableReceptionist.RowStyles.Clear();
            cardReceptionists = new List<CardStaff>();
            foreach (var i in list)
            {
                CardStaff card = new CardStaff
                {
                    ID = i.IdReceptionist,
                    NameStaff = i.Name,
                    CCCD = i.CCCD,
                    Phone = i.Phone,
                    Salary = i.Salary.ToString(),
                    Role = AccountBLL.Instance.GetRoleById(i.IdReceptionist)
                };
                // Đăng ký sự kiện Card_Clicked
                card.CardClicked += Card_Clicked;
                cardReceptionists.Add(card);
                tableReceptionist.Controls.Add(card);
            }
        }
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if(tbId.Text != "")
            {
                if (AccountBLL.Instance.GetAccountById(Convert.ToInt32(tbId.Text)) == null)
                {
                    AccountBLL.Instance.CreateAccount(Convert.ToInt32(tbId.Text));
                    Renew();
                    MessageBox.Show("Cấp tài khoản mặc định thành công");
                }
                else
                {
                    MessageBox.Show("Nhân viên đã có account");
                }    
            }   
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
            }    
        }
    }
}
