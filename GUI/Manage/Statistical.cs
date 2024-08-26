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

namespace GUI.Manage
{
    public partial class Statistical : Form
    {
        public Statistical()
        {
            InitializeComponent();
        }

        private void Statistical_Load(object sender, EventArgs e)
        {
            chartTopService.DataSource = UseSerivceBLL.Instance.TopService(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTopService.Series[0].XValueMember = "Key";
            chartTopService.Series[0].YValueMembers = "Value";
            chartTopService.DataBind();

            chartTotalAmout.DataSource = InvoiceBLL.Instance.Statistical_Amount(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTotalAmout.Series[0].XValueMember = "Key";
            chartTotalAmout.Series[0].YValueMembers = "Value";
            chartTotalAmout.DataBind();

            dtpFinishTime.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            chartTopService.DataSource = UseSerivceBLL.Instance.TopService(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTopService.Series[0].XValueMember = "Key";
            chartTopService.Series[0].YValueMembers = "Value";
            chartTopService.DataBind();

            chartTotalAmout.DataSource = InvoiceBLL.Instance.Statistical_Amount(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTotalAmout.Series[0].XValueMember = "Key";
            chartTotalAmout.Series[0].YValueMembers = "Value";
            chartTotalAmout.DataBind();

            lbQuantityMoney.Text = InvoiceBLL.Instance.TotalMoney(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString("N0");
            lbQuantityBooking.Text = BookingBLL.Instance.TotalBooking(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString();
            lbQuantityService.Text = UseSerivceBLL.Instance.TotalService(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            chartTopService.DataSource = UseSerivceBLL.Instance.TopService(new DateTime(DateTime.Today.AddDays(-7).Year, DateTime.Today.AddDays(-7).Month, DateTime.Today.AddDays(-7).Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTopService.Series[0].XValueMember = "Key";
            chartTopService.Series[0].YValueMembers = "Value";
            chartTopService.DataBind();

            chartTotalAmout.DataSource = InvoiceBLL.Instance.Statistical_Amount(new DateTime(DateTime.Today.AddDays(-7).Year, DateTime.Today.AddDays(-7).Month, DateTime.Today.AddDays(-7).Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTotalAmout.Series[0].XValueMember = "Key";
            chartTotalAmout.Series[0].YValueMembers = "Value";
            chartTotalAmout.DataBind();
            lbQuantityMoney.Text = InvoiceBLL.Instance.TotalMoney(new DateTime(DateTime.Today.AddDays(-7).Year, DateTime.Today.AddDays(-7).Month, DateTime.Today.AddDays(-7).Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString("N0");
            lbQuantityBooking.Text = BookingBLL.Instance.TotalBooking(new DateTime(DateTime.Today.AddDays(-7).Year, DateTime.Today.AddDays(-7).Month, DateTime.Today.AddDays(-7).Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString();
            lbQuantityService.Text = UseSerivceBLL.Instance.TotalService(new DateTime(DateTime.Today.AddDays(-7).Year, DateTime.Today.AddDays(-7).Month, DateTime.Today.AddDays(-7).Day, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            chartTopService.DataSource = UseSerivceBLL.Instance.TopService(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTopService.Series[0].XValueMember = "Key";
            chartTopService.Series[0].YValueMembers = "Value";
            chartTopService.DataBind();

            chartTotalAmout.DataSource = InvoiceBLL.Instance.Statistical_Amount(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59));
            chartTotalAmout.Series[0].XValueMember = "Key";
            chartTotalAmout.Series[0].YValueMembers = "Value";
            chartTotalAmout.DataBind();
            lbQuantityMoney.Text = InvoiceBLL.Instance.TotalMoney(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString("N0");
            lbQuantityBooking.Text = BookingBLL.Instance.TotalBooking(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString();
            lbQuantityService.Text = UseSerivceBLL.Instance.TotalService(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)).ToString();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (dtpFinishTime.Value >= dtpStartTime.Value)
            {
                chartTopService.DataSource = UseSerivceBLL.Instance.TopService(new DateTime(dtpStartTime.Value.Year, dtpStartTime.Value.Month, dtpStartTime.Value.Day, 0, 0, 0), new DateTime(dtpFinishTime.Value.Year, dtpFinishTime.Value.Month, dtpFinishTime.Value.Day, 23, 59, 59));
                chartTopService.Series[0].XValueMember = "Key";
                chartTopService.Series[0].YValueMembers = "Value";
                chartTopService.DataBind();

                chartTotalAmout.DataSource = InvoiceBLL.Instance.Statistical_Amount(new DateTime(dtpStartTime.Value.Year, dtpStartTime.Value.Month, dtpStartTime.Value.Day, 0, 0, 0), new DateTime(dtpFinishTime.Value.Year, dtpFinishTime.Value.Month, dtpFinishTime.Value.Day, 23, 59, 59));
                chartTotalAmout.Series[0].XValueMember = "Key";
                chartTotalAmout.Series[0].YValueMembers = "Value";
                chartTotalAmout.DataBind();
                lbQuantityMoney.Text = InvoiceBLL.Instance.TotalMoney(new DateTime(dtpStartTime.Value.Year, dtpStartTime.Value.Month, dtpStartTime.Value.Day, 0, 0, 0), new DateTime(dtpFinishTime.Value.Year, dtpFinishTime.Value.Month, dtpFinishTime.Value.Day, 23, 59, 59)).ToString("N0");
                lbQuantityBooking.Text = BookingBLL.Instance.TotalBooking(new DateTime(dtpStartTime.Value.Year, dtpStartTime.Value.Month, dtpStartTime.Value.Day, 0, 0, 0), new DateTime(dtpFinishTime.Value.Year, dtpFinishTime.Value.Month, dtpFinishTime.Value.Day, 23, 59, 59)).ToString();
                lbQuantityService.Text = UseSerivceBLL.Instance.TotalService(new DateTime(dtpStartTime.Value.Year, dtpStartTime.Value.Month, dtpStartTime.Value.Day, 0, 0, 0), new DateTime(dtpFinishTime.Value.Year, dtpFinishTime.Value.Month, dtpFinishTime.Value.Day, 23, 59, 59)).ToString();
            }
            else
            {
                MessageBox.Show("Ngày chọn không hợp lý");
            }    
        }

    }
}
