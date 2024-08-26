using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using Util;

namespace GUI.Manage
{
    public partial class ManageInvoice : Form
    {
        private int IdStaff;
        public ManageInvoice(int idStaff)
        {
            InitializeComponent();
            IdStaff = idStaff;
        }
        private int IdRoom = -1;
        private DateTime Gioketthuc = DateTime.Now;
        private int SelectedId = 0;
        List<CardRoom> cardRooms;
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
            tableRoom.Controls.Clear();
            tableRoom.RowStyles.Clear();
            cardRooms = new List<CardRoom>();
            foreach (var i in list)
            {
                if (i.IdBooking > 0)
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
        private void ManageInvoice_Load(object sender, EventArgs e)
        {
            FillTableRoom(RoomBLL.Instance.GetRoomByStatus(1));
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedId != 0)
            {
                dgvRoom.Rows.Clear();
                dgvService.Rows.Clear();

                IdRoom = SelectedId;
                double costser = 0;
                double costroom = 0;
                int? tempbooking = (RoomBLL.Instance.GetRoomById(IdRoom)).IdBooking;
                while (tempbooking != null)
                {
                    RoomDTO r = RoomBLL.Instance.GetIdRoomPay(BookingBLL.Instance.GetIdRoom((int)tempbooking));
                    Booking book = BookingBLL.Instance.GetBookingById((int)tempbooking);
                    dgvRoom.Rows.Add(r.ID, r.Name, r.HourlyRate.ToString("N0"), book.DateIn, book.DateOut != null ? book.DateOut : Gioketthuc);
                    costroom += MoneyRoom.CalculateCost((DateTime)book.DateIn, Gioketthuc, r.HourlyRate);
                    costser += UseSerivceBLL.Instance.Money((int)tempbooking);
                    foreach (ServiceDTO ser in (UseSerivceBLL.Instance.GetAllUseService((int)tempbooking)))
                    {
                        dgvService.Rows.Add(r.Name, ser.Name, ser.Cost.ToString("N0"), ser.Quantity);
                    }
                    tempbooking = book.IdChange;
                    tbMoneyRoom.Text = costroom.ToString("N0");
                    tbMoneyService.Text = costser.ToString("N0");
                    tbTotal.Text = (costser + costroom).ToString("N0");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng thanh toán");
            }    
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {   if (tbMoneyRoom.Text != "")
            {
                Invoice temp = new Invoice
                {
                    IdBooking = (RoomBLL.Instance.GetRoomById(IdRoom)).IdBooking,
                    Total = Convert.ToDouble(tbTotal.Text),
                    IdCreater = this.IdStaff,
                    IsPaid = true
                };
                InvoiceBLL.Instance.Add(temp);
                Booking book = BookingBLL.Instance.GetBookingById((RoomBLL.Instance.GetRoomById(IdRoom)).IdBooking);
                book.DateOut = Gioketthuc;
                BookingBLL.Instance.Update(book);
                RoomBLL.Instance.ChangStatus(0, IdRoom);
                MessageBox.Show("Thanh toán thành công");
                dgvRoom.Rows.Clear();
                dgvService.Rows.Clear();
                tbMoneyRoom.Text = "";
                tbMoneyService.Text = "";
                tbTotal.Text = "";
                FillTableRoom(RoomBLL.Instance.GetRoomByStatus(1));
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng thanh toán");
            }    
        }
        private void tbFind_IconRightClick(object sender, EventArgs e)
        {
            FillTableRoom(RoomBLL.Instance.GetRoomByKeyWord(tbFind.Text));
            tbFind.Text = "";
        }
    }
}
