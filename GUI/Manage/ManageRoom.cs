using System;
using System.Collections;
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
using Util;

namespace GUI
{
    public partial class ManageRoom : Form
    {
        private int IdStaff;
        public ManageRoom(int idStaff)
        {
            InitializeComponent();
            IdStaff = idStaff;
        }
        private void ManageRoom_Load(object sender, EventArgs e)
        {
            FillTableRoom(RoomBLL.Instance.GetAllRoom());
            cbbType.Items.AddRange(TypeRoomBLL.Instance.GetTypeCBB().ToArray());
            cbbNameOld.Items.AddRange(RoomBLL.Instance.GetAllRoomUse().ToArray());
        }
        public void SetIdStaff(int id)
        {
            IdStaff = id;
        }
        private int SelectedId = 0;
        List<CardRoom> cardRooms;
        List<bool> index;
        private void guna2TextBox3_IconRightClick(object sender, EventArgs e)
        {
            List<CardRoom> list = new List<CardRoom>();
            foreach (RoomDTO room in RoomBLL.Instance.GetRoomByKeyWord(tbFind.Text))
            {
                for (int i = 0; i < cardRooms.Count; i++)
                {
                    if (index[i] == true && cardRooms[i].ID == room.ID)
                    {
                        list.Add(cardRooms[i]);
                    }
                }
            }
            tableRoom.Controls.Clear();
            tableRoom.RowStyles.Clear();
            foreach (CardRoom card in list)
            {
                tableRoom.Controls.Add(card);
            }
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
        public void FillTableRoom(List<RoomDTO> list)
        {
            tableRoomChoose.Controls.Clear();
            tableRoomChoose.RowStyles.Clear();

            tableRoom.Controls.Clear();
            tableRoom.RowStyles.Clear();
            cardRooms = new List<CardRoom>();
            index = new List<bool>();
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
                index.Add(true);
                tableRoom.Controls.Add(card);
            }
        }
        public void ChangeTable(TableLayoutPanel tablepanel, bool local)
        {
            tablepanel.Controls.Clear();
            tablepanel.RowStyles.Clear();
            for (int i = 0; i < cardRooms.Count; i++)
            {
                if (index[i] == local)
                {
                    tablepanel.Controls.Add(cardRooms[i]);
                }
            }
        }
        private void TransferCard(object sender, EventArgs e)
        {
            for (int i = 0; i < cardRooms.Count; i++)
            {
                if (cardRooms[i].ID == SelectedId)
                {
                    index[i] = !index[i];
                    break;
                }
            }
            ChangeTable(tableRoom, true);
            ChangeTable(tableRoomChoose, false);
        }
        private void FilterCombobox(object sender, EventArgs e)
        {
            foreach (CardRoom card in GetCardByStatusAndType())
            {
                tableRoom.Controls.Add(card);
            }
        }
        public List<CardRoom> GetCardByStatusAndType()
        {
            List<CardRoom> list = new List<CardRoom>(); 
            tableRoom.Controls.Clear();
            tableRoom.RowStyles.Clear();
            if (cbbStatus.Text != "Tất cả" || cbbType.Text != "Tất cả")
            {
                foreach (RoomDTO room in RoomBLL.Instance.GetRoomByTypeAndStatus(cbbType.Text, cbbStatus.Text))
                {
                    for (int i = 0; i < cardRooms.Count; i++)
                    {
                        if (index[i] == true && cardRooms[i].ID == room.ID)
                        {
                            list.Add(cardRooms[i]);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < cardRooms.Count; i++)
                {
                    if (index[i] == true)
                    {
                        list.Add(cardRooms[i]);
                    }
                }
            }
            return list;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            List<CardRoom> list = new List<CardRoom>();
            if (IsNumeric.Check(tbPeopleMin.Text) == true && IsNumeric.Check(tbPeopleMax.Text) == true)
            {
                foreach (CardRoom card in GetCardByStatusAndType())
                { 
                    if(card.People >= Convert.ToInt32(tbPeopleMin.Text) && card.People <= Convert.ToInt32(tbPeopleMax.Text))
                    {
                        list.Add(card);
                    }    
                }
            }
            if(list.Count == 0 && tbPeopleMin.Text == "")
            {
                list = GetCardByStatusAndType();
            }
            List<CardRoom> result = new List<CardRoom>();
            if (IsNumeric.Check(tbCostMin.Text) == true && IsNumeric.Check(tbCostMax.Text) == true && list.Count != 0)
            {
                foreach (CardRoom card in list)
                {
                    if (card.Cost >= Convert.ToInt32(tbCostMin.Text) && card.Cost <= Convert.ToInt32(tbCostMax.Text))
                    {
                        result.Add(card);
                    }
                }
            }
            else
            {
                if(list.Count !=0)
                {
                    foreach(var i in list)
                    {
                        result.Add(i);
                    }    
                }    
            };

            if (result.Count != 0)
            {
                foreach (CardRoom card in result)
                {
                    tableRoom.Controls.Add(card);
                }
            }
            else
            {
                tableRoom.Controls.Clear();
                tableRoom.RowStyles.Clear();
            }    
        }
        private void btnRent_Click(object sender, EventArgs e)
        {
            PanelRent.Visible = true;
            PanelChange.Visible = false;
            if (RoomBLL.Instance.CheckRent(SelectedId) == false)
            {
                tbNameRoom.Text = SelectedId.ToString();
            }
            else
            {
                MessageBox.Show("Phòng đã được thuê");
            }    
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (ValidateInformation.CCCD(tbCCCD.Text) == true)
            {
                CustomerDTO cus = CustomerBLL.Instance.GetCustomerByCCCD(tbCCCD.Text);
                if (cus == null)
                {
                    MessageBox.Show("Chưa đăng ký thông tin khách hàng với CCCD này");
                }
                else
                {
                    tbCCCD.Text = cus.CCCD;
                    tbName.Text = cus.Name;
                    tbAddress.Text = cus.Address;
                    tbPhone.Text = cus.Phone;
                    if (cus.Gender == true)
                        rbNam.Checked = true;
                    else
                        rbNu.Checked = true;
                    dtpBirth.Value = cus.Birth;
                }
            }
            else
            {
                MessageBox.Show("CCCD is invaild!!");
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
            return true;
        }
        public void Renew()
        {
            tbFind.Text = "";
            tbName.Text = "";
            tbNameRoom.Text = "";
            tbCCCD.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            rbNam.Checked = false;
            rbNu.Checked = false;
            dtpBirth.Value = DateTime.Now;
        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (tbNameRoom.Text != "")
            {
                if (Validate4() == true)
                {
                    int idCustomer;
                    int idRoom = Convert.ToInt32(tbNameRoom.Text);
                    if (CustomerBLL.Instance.GetCustomerByCCCD(tbCCCD.Text) == null)
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
                        idCustomer = CustomerBLL.Instance.GetCustomerByCCCD(tbCCCD.Text).IdCustomer;
                    }
                    else
                    {
                        CustomerDTO customer = new CustomerDTO
                        {
                            IdCustomer = CustomerBLL.Instance.GetCustomerByCCCD(tbCCCD.Text).IdCustomer,
                            Name = tbName.Text,
                            CCCD = tbCCCD.Text,
                            Phone = tbPhone.Text,
                            Address = tbAddress.Text,
                            Gender = rbNam.Checked,
                            Birth = dtpBirth.Value
                        };
                        CustomerBLL.Instance.Update(customer);
                        idCustomer = customer.IdCustomer;
                    }
                    Booking book = new Booking
                    {
                        IdCustomer = idCustomer,
                        IdRoom = idRoom,
                        IdCreater = IdStaff,
                        DateIn = DateTime.Now,
                    };
                    BookingBLL.Instance.Add(book);
                    RoomBLL.Instance.ChangStatus(book.IdBooking, idRoom);
                    for (int i = 0; i < cardRooms.Count; i++)
                    {
                        if (cardRooms[i].ID == idRoom)
                        {
                            if (index[i] == false)
                            {
                                index[i] = !index[i];
                            }
                            break;
                        }
                    }
                    ChangeTable(tableRoom, true);
                    ChangeTable(tableRoomChoose, false);
                    foreach (CardRoom i in cardRooms)
                    {
                        if (i.ID == idRoom)
                        {
                            i.Status = false;
                            break;
                        }
                    }
                    MessageBox.Show("Thuê thành công !!!");
                    Renew();
                }
            }
            else
            {
                MessageBox.Show("Chọn phòng để thuê");
            }    
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (RoomBLL.Instance.CheckRent(SelectedId) == false)
            {
                PanelRent.Visible = false;
                PanelChange.Visible = true;
                tbIDnew.Text = SelectedId.ToString();
            }
            else
            {
                MessageBox.Show("Phòng đã được thuê");
            }
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int idroomnew = Convert.ToInt32(tbIDnew.Text);
            int idbookingold = RoomBLL.Instance.GetRoomById(((CBBItem)cbbNameOld.SelectedItem).ID).IdBooking;
            Booking bookold = BookingBLL.Instance.GetBookingById(idbookingold);
            bookold.DateOut = DateTime.Now;
            Booking book = new Booking
            {
                IdCustomer = bookold.IdCustomer,
                IdRoom = idroomnew,
                IdCreater = this.IdStaff,
                DateIn = DateTime.Now,
                IdChange = idbookingold
            };
            RoomBLL.Instance.ChangStatus(0,((CBBItem)cbbNameOld.SelectedItem).ID);
            BookingBLL.Instance.Add(book);
            RoomBLL.Instance.ChangStatus(book.IdBooking , idroomnew);
            BookingBLL.Instance.Update(bookold);
            MessageBox.Show("Đổi thành công !!!");
            for (int i = 0; i < cardRooms.Count; i++)
            {
                if (cardRooms[i].ID == idroomnew || cardRooms[i].ID == ((CBBItem)cbbNameOld.SelectedItem).ID)
                {
                    if (index[i] == false)
                    {
                        index[i] = !index[i];
                    }
                   
                }
            }
            ChangeTable(tableRoom, true);
            ChangeTable(tableRoomChoose, false);
            foreach (CardRoom i in cardRooms)
            {
                if (i.ID == idroomnew )
                {
                    i.Status = false;
                }
                if( i.ID == ((CBBItem)cbbNameOld.SelectedItem).ID)
                {
                    i.Status = true;
                }    
            }
            tbIDnew.Text = "";
            cbbNameOld.SelectedIndex = -1;
            cbbNameOld.Items.Clear();
            cbbNameOld.Items.AddRange(RoomBLL.Instance.GetAllRoomUse().ToArray());
        }
    }
}
