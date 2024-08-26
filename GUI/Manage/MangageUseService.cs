using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using DTO;
using GUI.Usercontrol;
using Util;

namespace GUI.Manage
{
    public partial class MangageUseService : Form
    {
        public MangageUseService()
        {
            InitializeComponent();
        }
        private int SelectedId = 0;
        List<CardService> cardServices;
        List<bool> index;
        private void CRUD_Service_Load(object sender, EventArgs e)
        {
            FillTableService(ServiceBLL.Instance.GetAllService());
            cbbNameOld.Items.AddRange(RoomBLL.Instance.GetAllRoomUse().ToArray());
        }
        private void pbEdit_MouseEnter(object sender, EventArgs e)
        {
            pbEdit.BackColor = Color.LightSkyBlue;
        }
        private void pbEdit_MouseLeave(object sender, EventArgs e)
        {
            pbEdit.BackColor = Color.White;
        }
        private void btnFind_IconRightClick(object sender, EventArgs e)
        {
            List<CardService> list = new List<CardService>();
            foreach (var ser in ServiceBLL.Instance.GetServiceByKeyWord(tbFind.Text))
            {
                for (int i = 0; i < cardServices.Count; i++)
                {
                    if (index[i] == true && cardServices[i].ID == ser.IdService)
                    {
                        list.Add(cardServices[i]);
                    }
                }
            }    
            ChangeTable(tableService, list);    
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
        public void FillTableService(List<Service> list)
        {
            tableService.Controls.Clear();
            tableService.RowStyles.Clear();
            tableUse.Controls.Clear();
            tableUse.RowStyles.Clear();
            SelectedId = 0;
            cardServices = new List<CardService>();
            index = new List<bool> ();
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
                index.Add(false);
                tableService.Controls.Add(card);
            }
        }
        public void ChangeTable(TableLayoutPanel tablepanel, List<CardService> card)
        {
            tablepanel.Controls.Clear();
            tablepanel.RowStyles.Clear();
            foreach(CardService c in card)
            {
                tablepanel.Controls.Add(c);
            }    
        }
        private void TransferCard(object sender, EventArgs e)
        {
            List<CardService> service = new List<CardService>();
            List<CardService> use = new List<CardService>();
            for (int i = 0; i < cardServices.Count; i++)
            {
                if (cardServices[i].ID == SelectedId)
                {
                    index[i] = !index[i];
                    cardServices[i].HideQuantity(index[i]);
                };
                if (index[i] == false)
                {
                    service.Add(cardServices[i]);
                }    
                else
                {
                    use.Add(cardServices[i]);
                }    
            }
            ChangeTable(tableService, service);
            ChangeTable(tableUse, use);
        }
        private void cbbNameOld_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNameOld.SelectedIndex >= 0)
            {
                RoomDTO room = RoomBLL.Instance.GetRoomById(((CBBItem)cbbNameOld.SelectedItem).ID);
                if (room != null)
                {
                    tbId.Text = room.ID.ToString();
                    tbName.Text = room.Name;
                    tbCCCD.Text = CustomerBLL.Instance.GetCCCD(BookingBLL.Instance.GetIdCustomer(room.IdBooking));
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (cbbNameOld.SelectedIndex >= 0)
            {
                bool check = true;
                for (int i = 0; i < cardServices.Count; i++)
                {
                    if(IsNumeric.Check(cardServices[i].Quantity) == false)
                    {
                        check = false;
                        break;
                    }    
                }
                if (check == true)
                {
                    for (int i = 0; i < cardServices.Count; i++)
                    {
                        if (index[i] == true)
                        {
                            foreach (Service ser in ServiceBLL.Instance.GetAllService())
                            {
                                if (cardServices[i].ID == ser.IdService)
                                {
                                    UseSerivceBLL.Instance.Add(ser.IdService, RoomBLL.Instance.GetRoomById(((CBBItem)cbbNameOld.SelectedItem).ID).IdBooking, Convert.ToInt32((cardServices[i].Quantity)));
                                    break;
                                }
                            }
                        }
                    }
                    MessageBox.Show("Thêm thành công!");
                    FillTableService(ServiceBLL.Instance.GetAllService());
                    cbbNameOld.SelectedIndex = -1;
                    tbCCCD.Text = "";
                    tbName.Text = "";
                    tbId.Text = "";
                }
                else
                {
                    MessageBox.Show("Hãy nhập số lượng hợp lệ");
                }    
            }
            else
            {
                MessageBox.Show("Hãy chọn phòng sử dụng");
            }
        }
    }
}
