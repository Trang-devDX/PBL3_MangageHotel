using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using GUI.Usercontrol;
using Util;

namespace GUI
{
    public partial class CRUD_TypeRoom : Form
    {
        private int SelectedId = 0;
        List<CardTypeRoom> cardTypeRooms;
        public CRUD_TypeRoom()
        {
            InitializeComponent();
        }
        private void CRUD_TypeRoom_Load(object sender, EventArgs e)
        {
            FillTableTypeRoom(TypeRoomBLL.Instance.GetAllTypeRoom());
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
                 TypeRoom typeroom = TypeRoomBLL.Instance.GetTypeRoomById(SelectedId);
                 tbName.Text = typeroom.NameType.Trim();
                 tbId.Text = typeroom.IdType.ToString();
                 tbCost.Text = typeroom.HourlyRate.ToString();
                 tbPeople.Text = typeroom.GuestsMax.ToString();
             }
             else
             {
                 MessageBox.Show("Vui lòng chọn loại phòng");
             }
         }
        private void btnAdd_Click(object sender, EventArgs e)
         {
             if (ValidateInformation() == true)
             {
                     TypeRoom typeroom = new TypeRoom
                     {
                         NameType = tbName.Text,
                         HourlyRate = Convert.ToInt32(tbCost.Text),
                         GuestsMax = Convert.ToInt32(tbPeople.Text),
                         IsUse = true
                     };
                     TypeRoomBLL.Instance.Add(typeroom);
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
                     TypeRoom typeroom = new TypeRoom
                     {
                         IdType = Convert.ToInt32(tbId.Text),
                         NameType = tbName.Text,
                         HourlyRate = Convert.ToInt32(tbCost.Text),
                         GuestsMax = Convert.ToInt32(tbPeople.Text)
                     };
                     TypeRoomBLL.Instance.Update(typeroom);
                     Renew();
                     MessageBox.Show("Update succesfully");
             }
        }
        private void btnDelete_Click(object sender, EventArgs e)
         {
             if (ValidateInformation() == true)
             {
                     TypeRoomBLL.Instance.Delete(Convert.ToInt32(tbId.Text));
                     Renew();
                     MessageBox.Show("Delete succesfully");
             }
         }
        private void btnFind_IconRightClick(object sender, EventArgs e)
         {
             FillTableTypeRoom(TypeRoomBLL.Instance.GetTypeRoomByKeyWord(tbFind.Text));
             tbFind.Text = "";
         }
        private void Card_Clicked(CardTypeRoom typeroom)
         {
             if (SelectedId == typeroom.ID)
             {
                 SelectedId = 0;
             }
             else
             {
                 if (SelectedId != 0)
                 {
                     foreach (CardTypeRoom i in cardTypeRooms)
                     {
                         if (i.ID == SelectedId)
                         {
                             i.CancelChoose();
                             break;
                         }
                     }
                 }
                 SelectedId = typeroom.ID;
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
             if (IsNumeric.Check(tbPeople.Text) == false)
             {
                MessageBox.Show("People is invaild!!");
                tbPeople.Focus();
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
             tbPeople.Text = "";
             FillTableTypeRoom(TypeRoomBLL.Instance.GetAllTypeRoom());
         }
        public void FillTableTypeRoom(List<TypeRoom> list)
         {
            tableTypeRoom.Controls.Clear();
            tableTypeRoom.RowStyles.Clear();
            cardTypeRooms = new List<CardTypeRoom>();
            foreach (var i in list)
             {
                 CardTypeRoom card = new CardTypeRoom
                 {
                     ID = i.IdType,
                     NameType = i.NameType,
                     Cost = (double)i.HourlyRate,
                     People = (int)i.GuestsMax,
                 };
                 // Đăng ký sự kiện Card_Clicked
                 card.CardClicked += Card_Clicked;
                 cardTypeRooms.Add(card);
                 tableTypeRoom.Controls.Add(card);
             }
         }
    }
}
