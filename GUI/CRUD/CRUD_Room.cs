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
using Util;

namespace GUI
{
    public partial class CRUD_Room : Form
    {
        private int SelectedId = 0;
        List<CardRoom> cardRooms ;
        public CRUD_Room()
        {
            InitializeComponent();
        }
        private void guna2CirclePictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pbEdit.BackColor = Color.LightSkyBlue;
        }
        private void pbEdit_MouseLeave(object sender, EventArgs e)
        {
            pbEdit.BackColor = Color.White;
        }
        private void CRUD_Room_Load(object sender, EventArgs e)
        {
            FillTableRoom(RoomBLL.Instance.GetAllRoom());
            cbbType.Items.AddRange(TypeRoomBLL.Instance.GetTypeCBB().ToArray());
        }
        private void pbEdit_Click(object sender, EventArgs e)
        {
            if (SelectedId != 0)
            {
                RoomDTO room = RoomBLL.Instance.GetRoomById(SelectedId);
                tbName.Text = room.Name.Trim();
                tbId.Text = room.ID.ToString();
                cbbType.Text = room.Type;
                if (room.IdBooking == 0)
                     tbStatus.IconRight = Properties.Resources.icons8_status_50;
                else
                     tbStatus.IconRight = Properties.Resources.icons8_cancel_50;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng");
            }    
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(ValidateInformation() == true)
            {
                if(RoomBLL.Instance.CheckNameRoom(tbName.Text) == false)
                {
                    Room room = new Room
                    {
                        NameRoom = tbName.Text,
                        IdType = ((CBBItem)cbbType.SelectedItem).ID,
                        IdBooking = 0
                    };
                    RoomBLL.Instance.Add(room);
                    Renew();
                    MessageBox.Show("Add succesfully");
                }   
                else
                {
                    MessageBox.Show("Name is exist!!");
                }    
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
                if (RoomBLL.Instance.CheckRent(Convert.ToInt32(tbId.Text)) == false)
                {   
                    if ((RoomBLL.Instance.CheckNameRoom(tbName.Text) == false && tbName.Text.Trim() != RoomBLL.Instance.GetName(Convert.ToInt32(tbId.Text))) || tbName.Text.Trim() == RoomBLL.Instance.GetName(Convert.ToInt32(tbId.Text)) )
                    {
                        Room room = new Room
                        {
                            IdRoom = Convert.ToInt32(tbId.Text),
                            NameRoom = tbName.Text,
                            IdType = ((CBBItem)cbbType.SelectedItem).ID,
                        };
                        RoomBLL.Instance.Update(room);
                        Renew();
                        MessageBox.Show("Update succesfully");
                    }
                    else
                    {
                        MessageBox.Show("Name is exist!!");
                    }
                }
                else
                {
                    MessageBox.Show("Room is rent!!");
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateInformation() == true)
            {
                if (RoomBLL.Instance.CheckRent(Convert.ToInt32(tbId.Text)) == false)
                {
                    RoomBLL.Instance.Delete(Convert.ToInt32(tbId.Text));
                    Renew();
                    MessageBox.Show("Delete succesfully");
                }
                else
                {
                    MessageBox.Show("Room is rent!!");
                }
            }
        }
        private void guna2TextBox3_IconRightClick(object sender, EventArgs e)
        {
            FillTableRoom(RoomBLL.Instance.GetRoomByKeyWord(tbFind.Text));
            tbFind.Text = "";
        }
        private void Card_Clicked(CardRoom room)
        {
            if (SelectedId == room.ID)
            {
                SelectedId = 0;
            }
            else
            {
                if (SelectedId != 0)
                {
                    foreach (CardRoom i in cardRooms)
                    {
                        if (i.ID == SelectedId)
                        {
                            i.CancelChoose();
                            break;
                        }
                    }
                }
                SelectedId = room.ID;
            }
        }
        public bool ValidateInformation()
        {
            if(tbName.Text == "")
            {
                MessageBox.Show("Name is invaild!!");
                tbName.Focus();
                return false;
            }
            if (cbbType.SelectedIndex == -1)
            {
                MessageBox.Show("Type is invaild!!");
                cbbType.Focus();
                return false;
            }
            return true;
        }
        public void Renew()
        {
            tbFind.Text = "";
            tbName.Text = "";
            tbId.Text = "";    
            cbbType.SelectedIndex = -1;
            tbStatus.IconRight = Properties.Resources.icons8_status_50;
            SelectedId = 0;
            FillTableRoom(RoomBLL.Instance.GetAllRoom());
        }
        public void FillTableRoom(List<RoomDTO> list)
        {
            tableRoom.Controls.Clear();
            tableRoom.RowStyles.Clear();
            cardRooms = new List<CardRoom>();
            foreach (var i in list)
            {
                CardRoom card = new CardRoom
                {
                    ID = i.ID,
                    NameRoom = i.Name,
                    Cost = i.HourlyRate,
                    NameType = i.Type,
                    Status = i.IdBooking == 0 ? true : false,
                    People = i.People
                };

                // Đăng ký sự kiện Card_Clicked
                card.CardClicked += Card_Clicked;
                cardRooms.Add(card);
                tableRoom.Controls.Add(card);
            }
        }
    }
}
