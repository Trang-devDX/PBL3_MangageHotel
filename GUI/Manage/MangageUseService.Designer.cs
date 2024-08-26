namespace GUI.Manage
{
    partial class MangageUseService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MangageUseService));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pbEdit = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.tbFind = new Guna.UI2.WinForms.Guna2TextBox();
            this.PanelService = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tableService = new System.Windows.Forms.TableLayoutPanel();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tableUse = new System.Windows.Forms.TableLayoutPanel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PanelChange = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.tbId = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbCCCD = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbbNameOld = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).BeginInit();
            this.PanelService.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            this.PanelChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.pbEdit);
            this.guna2ShadowPanel1.Controls.Add(this.tbFind);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(21, 36);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(3)))), ((int)(((byte)(86)))));
            this.guna2ShadowPanel1.ShadowShift = 1;
            this.guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(224, 49);
            this.guna2ShadowPanel1.TabIndex = 16;
            // 
            // pbEdit
            // 
            this.pbEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbEdit.Image = global::GUI.Properties.Resources.icons8_preview_file_40;
            this.pbEdit.ImageRotate = 0F;
            this.pbEdit.Location = new System.Drawing.Point(171, 0);
            this.pbEdit.Margin = new System.Windows.Forms.Padding(5);
            this.pbEdit.Name = "pbEdit";
            this.pbEdit.Padding = new System.Windows.Forms.Padding(5);
            this.pbEdit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbEdit.Size = new System.Drawing.Size(53, 49);
            this.pbEdit.TabIndex = 1;
            this.pbEdit.TabStop = false;
            this.pbEdit.Click += new System.EventHandler(this.TransferCard);
            this.pbEdit.MouseEnter += new System.EventHandler(this.pbEdit_MouseEnter);
            this.pbEdit.MouseLeave += new System.EventHandler(this.pbEdit_MouseLeave);
            // 
            // tbFind
            // 
            this.tbFind.BorderRadius = 15;
            this.tbFind.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFind.DefaultText = "";
            this.tbFind.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFind.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFind.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbFind.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFind.IconRight = global::GUI.Properties.Resources.icons8_view_50;
            this.tbFind.IconRightSize = new System.Drawing.Size(30, 30);
            this.tbFind.Location = new System.Drawing.Point(12, 7);
            this.tbFind.Name = "tbFind";
            this.tbFind.PasswordChar = '\0';
            this.tbFind.PlaceholderText = "Enter key word";
            this.tbFind.SelectedText = "";
            this.tbFind.Size = new System.Drawing.Size(151, 34);
            this.tbFind.TabIndex = 0;
            this.tbFind.IconRightClick += new System.EventHandler(this.btnFind_IconRightClick);
            // 
            // PanelService
            // 
            this.PanelService.BackColor = System.Drawing.Color.Transparent;
            this.PanelService.Controls.Add(this.tableService);
            this.PanelService.FillColor = System.Drawing.Color.White;
            this.PanelService.Location = new System.Drawing.Point(25, 95);
            this.PanelService.Name = "PanelService";
            this.PanelService.Radius = 10;
            this.PanelService.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(3)))), ((int)(((byte)(86)))));
            this.PanelService.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.PanelService.Size = new System.Drawing.Size(221, 473);
            this.PanelService.TabIndex = 15;
            // 
            // tableService
            // 
            this.tableService.AutoScroll = true;
            this.tableService.ColumnCount = 1;
            this.tableService.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableService.Location = new System.Drawing.Point(0, 0);
            this.tableService.Name = "tableService";
            this.tableService.RowCount = 1;
            this.tableService.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableService.Size = new System.Drawing.Size(221, 473);
            this.tableService.TabIndex = 0;
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.tableUse);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(271, 95);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 10;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(3)))), ((int)(((byte)(86)))));
            this.guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(221, 473);
            this.guna2ShadowPanel2.TabIndex = 16;
            // 
            // tableUse
            // 
            this.tableUse.AutoScroll = true;
            this.tableUse.ColumnCount = 1;
            this.tableUse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableUse.Location = new System.Drawing.Point(0, 0);
            this.tableUse.Name = "tableUse";
            this.tableUse.RowCount = 1;
            this.tableUse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUse.Size = new System.Drawing.Size(221, 473);
            this.tableUse.TabIndex = 0;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(286, 50);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(180, 27);
            this.guna2HtmlLabel4.TabIndex = 17;
            this.guna2HtmlLabel4.Text = "Thông tin chi tiết ";
            // 
            // PanelChange
            // 
            this.PanelChange.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(3)))), ((int)(((byte)(86)))));
            this.PanelChange.BorderRadius = 20;
            this.PanelChange.Controls.Add(this.tbId);
            this.PanelChange.Controls.Add(this.tbName);
            this.PanelChange.Controls.Add(this.tbCCCD);
            this.PanelChange.Controls.Add(this.cbbNameOld);
            this.PanelChange.Controls.Add(this.guna2GradientButton1);
            this.PanelChange.Controls.Add(this.guna2HtmlLabel6);
            this.PanelChange.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.PanelChange.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(194)))), ((int)(((byte)(235)))));
            this.PanelChange.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(253)))));
            this.PanelChange.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(192)))), ((int)(((byte)(238)))));
            this.PanelChange.Location = new System.Drawing.Point(508, 95);
            this.PanelChange.Name = "PanelChange";
            this.PanelChange.Size = new System.Drawing.Size(230, 300);
            this.PanelChange.TabIndex = 17;
            // 
            // tbId
            // 
            this.tbId.Animated = true;
            this.tbId.AutoRoundedCorners = true;
            this.tbId.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(192)))), ((int)(((byte)(238)))));
            this.tbId.BorderRadius = 16;
            this.tbId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbId.DefaultText = "";
            this.tbId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbId.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbId.ForeColor = System.Drawing.Color.Black;
            this.tbId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbId.IconLeft = global::GUI.Properties.Resources.icons8_key_50;
            this.tbId.IconLeftSize = new System.Drawing.Size(30, 30);
            this.tbId.Location = new System.Drawing.Point(14, 69);
            this.tbId.Name = "tbId";
            this.tbId.PasswordChar = '\0';
            this.tbId.PlaceholderText = "ID";
            this.tbId.ReadOnly = true;
            this.tbId.SelectedText = "";
            this.tbId.Size = new System.Drawing.Size(200, 35);
            this.tbId.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbId.TabIndex = 23;
            // 
            // tbName
            // 
            this.tbName.Animated = true;
            this.tbName.AutoRoundedCorners = true;
            this.tbName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(192)))), ((int)(((byte)(238)))));
            this.tbName.BorderRadius = 16;
            this.tbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbName.DefaultText = "";
            this.tbName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbName.IconLeft = global::GUI.Properties.Resources.icons8_dog_tag_50;
            this.tbName.IconLeftSize = new System.Drawing.Size(30, 30);
            this.tbName.Location = new System.Drawing.Point(14, 126);
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.PlaceholderText = "Name Room";
            this.tbName.ReadOnly = true;
            this.tbName.SelectedText = "";
            this.tbName.Size = new System.Drawing.Size(200, 35);
            this.tbName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbName.TabIndex = 22;
            // 
            // tbCCCD
            // 
            this.tbCCCD.Animated = true;
            this.tbCCCD.AutoRoundedCorners = true;
            this.tbCCCD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(192)))), ((int)(((byte)(238)))));
            this.tbCCCD.BorderRadius = 16;
            this.tbCCCD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCCCD.DefaultText = "";
            this.tbCCCD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbCCCD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbCCCD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCCCD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCCCD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCCCD.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbCCCD.ForeColor = System.Drawing.Color.Black;
            this.tbCCCD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCCCD.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbCCCD.IconLeft")));
            this.tbCCCD.IconLeftSize = new System.Drawing.Size(45, 45);
            this.tbCCCD.Location = new System.Drawing.Point(14, 185);
            this.tbCCCD.Name = "tbCCCD";
            this.tbCCCD.PasswordChar = '\0';
            this.tbCCCD.PlaceholderText = "CCCD";
            this.tbCCCD.ReadOnly = true;
            this.tbCCCD.SelectedText = "";
            this.tbCCCD.Size = new System.Drawing.Size(200, 35);
            this.tbCCCD.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbCCCD.TabIndex = 21;
            // 
            // cbbNameOld
            // 
            this.cbbNameOld.BackColor = System.Drawing.Color.Transparent;
            this.cbbNameOld.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbNameOld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNameOld.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNameOld.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNameOld.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbNameOld.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbNameOld.ItemHeight = 30;
            this.cbbNameOld.Location = new System.Drawing.Point(118, 15);
            this.cbbNameOld.Name = "cbbNameOld";
            this.cbbNameOld.Size = new System.Drawing.Size(96, 36);
            this.cbbNameOld.TabIndex = 20;
            this.cbbNameOld.SelectedIndexChanged += new System.EventHandler(this.cbbNameOld_SelectedIndexChanged);
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.AutoRoundedCorners = true;
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderRadius = 18;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(62)))), ((int)(((byte)(210)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Location = new System.Drawing.Point(70, 247);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(75, 39);
            this.guna2GradientButton1.TabIndex = 16;
            this.guna2GradientButton1.Text = "OK";
            this.guna2GradientButton1.UseTransparentBackground = true;
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.DarkViolet;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(14, 25);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(98, 19);
            this.guna2HtmlLabel6.TabIndex = 10;
            this.guna2HtmlLabel6.Text = "Phòng sử dụng";
            // 
            // MangageUseService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 580);
            this.Controls.Add(this.PanelChange);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.PanelService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MangageUseService";
            this.Text = "UseService";
            this.Load += new System.EventHandler(this.CRUD_Service_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).EndInit();
            this.PanelService.ResumeLayout(false);
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.PanelChange.ResumeLayout(false);
            this.PanelChange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbEdit;
        private Guna.UI2.WinForms.Guna2TextBox tbFind;
        private Guna.UI2.WinForms.Guna2ShadowPanel PanelService;
        private System.Windows.Forms.TableLayoutPanel tableService;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.TableLayoutPanel tableUse;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel PanelChange;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNameOld;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2TextBox tbCCCD;
        private Guna.UI2.WinForms.Guna2TextBox tbId;
        private Guna.UI2.WinForms.Guna2TextBox tbName;
    }
}