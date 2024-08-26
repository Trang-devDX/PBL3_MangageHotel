namespace GUI.Usercontrol
{
    partial class CardTypeRoom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbPeople = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbCost = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbName1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lbPeople);
            this.guna2ShadowPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2ShadowPanel1.Controls.Add(this.lbName);
            this.guna2ShadowPanel1.Controls.Add(this.lbCost);
            this.guna2ShadowPanel1.Controls.Add(this.lbName1);
            this.guna2ShadowPanel1.Controls.Add(this.lbId);
            this.guna2ShadowPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2ShadowPanel1.Controls.Add(this.pbAvatar);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(193)))), ((int)(((byte)(238)))));
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(215, 43);
            this.guna2ShadowPanel1.TabIndex = 3;
            this.guna2ShadowPanel1.Click += new System.EventHandler(this.CardClick);
            this.guna2ShadowPanel1.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.guna2ShadowPanel1.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // lbPeople
            // 
            this.lbPeople.BackColor = System.Drawing.Color.Transparent;
            this.lbPeople.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPeople.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(141)))), ((int)(((byte)(206)))));
            this.lbPeople.Location = new System.Drawing.Point(123, 18);
            this.lbPeople.Name = "lbPeople";
            this.lbPeople.Size = new System.Drawing.Size(10, 19);
            this.lbPeople.TabIndex = 14;
            this.lbPeople.Text = "1";
            this.lbPeople.Click += new System.EventHandler(this.CardClick);
            this.lbPeople.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.lbPeople.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(141)))), ((int)(((byte)(206)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(43, 18);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(14, 19);
            this.guna2HtmlLabel3.TabIndex = 12;
            this.guna2HtmlLabel3.Text = "$:";
            this.guna2HtmlLabel3.Click += new System.EventHandler(this.CardClick);
            this.guna2HtmlLabel3.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.guna2HtmlLabel3.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(141)))), ((int)(((byte)(206)))));
            this.lbName.Location = new System.Drawing.Point(139, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 19);
            this.lbName.TabIndex = 11;
            this.lbName.Text = "Name";
            this.lbName.Click += new System.EventHandler(this.CardClick);
            this.lbName.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.lbName.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // lbCost
            // 
            this.lbCost.BackColor = System.Drawing.Color.Transparent;
            this.lbCost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(141)))), ((int)(((byte)(206)))));
            this.lbCost.Location = new System.Drawing.Point(57, 18);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(30, 19);
            this.lbCost.TabIndex = 7;
            this.lbCost.Text = "Cost";
            this.lbCost.Click += new System.EventHandler(this.CardClick);
            this.lbCost.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.lbCost.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // lbName1
            // 
            this.lbName1.BackColor = System.Drawing.Color.Transparent;
            this.lbName1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(141)))), ((int)(((byte)(206)))));
            this.lbName1.Location = new System.Drawing.Point(91, 0);
            this.lbName1.Name = "lbName1";
            this.lbName1.Size = new System.Drawing.Size(47, 19);
            this.lbName1.TabIndex = 6;
            this.lbName1.Text = "Name : ";
            this.lbName1.Click += new System.EventHandler(this.CardClick);
            this.lbName1.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.lbName1.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // lbId
            // 
            this.lbId.BackColor = System.Drawing.Color.Transparent;
            this.lbId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(141)))), ((int)(((byte)(206)))));
            this.lbId.Location = new System.Drawing.Point(70, 0);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(10, 19);
            this.lbId.TabIndex = 5;
            this.lbId.Text = "1";
            this.lbId.Click += new System.EventHandler(this.CardClick);
            this.lbId.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.lbId.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(141)))), ((int)(((byte)(206)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(44, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(25, 19);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "ID :";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.CardClick);
            this.guna2HtmlLabel1.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.guna2HtmlLabel1.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.icons8_person_50;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(128, 17);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(39, 19);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 13;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.CardClick);
            this.guna2PictureBox1.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.guna2PictureBox1.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // pbAvatar
            // 
            this.pbAvatar.Image = global::GUI.Properties.Resources.icons8_hotel_door_60;
            this.pbAvatar.ImageRotate = 0F;
            this.pbAvatar.Location = new System.Drawing.Point(0, 0);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAvatar.Size = new System.Drawing.Size(38, 39);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAvatar.TabIndex = 3;
            this.pbAvatar.TabStop = false;
            this.pbAvatar.Click += new System.EventHandler(this.CardClick);
            this.pbAvatar.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.pbAvatar.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // CardTypeRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "CardTypeRoom";
            this.Size = new System.Drawing.Size(218, 47);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbCost;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbName1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbId;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbPeople;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
