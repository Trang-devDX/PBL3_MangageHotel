namespace GUI
{
    partial class ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            this.btnSignIn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tbPassnew = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPassold = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPassnewagain = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Animated = true;
            this.btnSignIn.AutoRoundedCorners = true;
            this.btnSignIn.BackColor = System.Drawing.Color.Transparent;
            this.btnSignIn.BorderRadius = 18;
            this.btnSignIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignIn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignIn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(62)))), ((int)(((byte)(210)))));
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(269, 320);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(150, 39);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "Đặt lại mật khẩu";
            this.btnSignIn.UseTransparentBackground = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // tbPassnew
            // 
            this.tbPassnew.AutoRoundedCorners = true;
            this.tbPassnew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(210)))));
            this.tbPassnew.BorderRadius = 16;
            this.tbPassnew.BorderThickness = 2;
            this.tbPassnew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassnew.DefaultText = "";
            this.tbPassnew.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassnew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassnew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassnew.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassnew.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassnew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPassnew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(210)))));
            this.tbPassnew.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassnew.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbPassnew.IconLeft")));
            this.tbPassnew.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.tbPassnew.IconRight = global::GUI.Properties.Resources.visible;
            this.tbPassnew.IconRightOffset = new System.Drawing.Point(5, 0);
            this.tbPassnew.IconRightSize = new System.Drawing.Size(25, 25);
            this.tbPassnew.Location = new System.Drawing.Point(259, 236);
            this.tbPassnew.Name = "tbPassnew";
        
            this.tbPassnew.PlaceholderText = "Password new";
            this.tbPassnew.SelectedText = "";
            this.tbPassnew.Size = new System.Drawing.Size(183, 34);
            this.tbPassnew.TabIndex = 3;
            this.tbPassnew.UseSystemPasswordChar = true;
            this.tbPassnew.IconRightClick += new System.EventHandler(this.HideandView);
            // 
            // tbPassold
            // 
            this.tbPassold.AutoRoundedCorners = true;
            this.tbPassold.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(210)))));
            this.tbPassold.BorderRadius = 16;
            this.tbPassold.BorderThickness = 2;
            this.tbPassold.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassold.DefaultText = "";
            this.tbPassold.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassold.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassold.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassold.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPassold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(210)))));
            this.tbPassold.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassold.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbPassold.IconLeft")));
            this.tbPassold.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.tbPassold.IconRight = global::GUI.Properties.Resources.visible;
            this.tbPassold.IconRightOffset = new System.Drawing.Point(5, 0);
            this.tbPassold.IconRightSize = new System.Drawing.Size(25, 25);
            this.tbPassold.Location = new System.Drawing.Point(259, 196);
            this.tbPassold.Name = "tbPassold";
          
            this.tbPassold.PlaceholderText = "Password old";
            this.tbPassold.SelectedText = "";
            this.tbPassold.Size = new System.Drawing.Size(183, 34);
            this.tbPassold.TabIndex = 5;
            this.tbPassold.UseSystemPasswordChar = true;
            this.tbPassold.IconRightClick += new System.EventHandler(this.HideandView);
            // 
            // tbPassnewagain
            // 
            this.tbPassnewagain.AutoRoundedCorners = true;
            this.tbPassnewagain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(210)))));
            this.tbPassnewagain.BorderRadius = 16;
            this.tbPassnewagain.BorderThickness = 2;
            this.tbPassnewagain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassnewagain.DefaultText = "";
            this.tbPassnewagain.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassnewagain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassnewagain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassnewagain.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassnewagain.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassnewagain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPassnewagain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(210)))));
            this.tbPassnewagain.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassnewagain.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbPassnewagain.IconLeft")));
            this.tbPassnewagain.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.tbPassnewagain.IconRight = global::GUI.Properties.Resources.visible;
            this.tbPassnewagain.IconRightOffset = new System.Drawing.Point(5, 0);
            this.tbPassnewagain.IconRightSize = new System.Drawing.Size(25, 25);
            this.tbPassnewagain.Location = new System.Drawing.Point(259, 276);
            this.tbPassnewagain.Name = "tbPassnewagain";
        
            this.tbPassnewagain.PlaceholderText = "Password new";
            this.tbPassnewagain.SelectedText = "";
            this.tbPassnewagain.Size = new System.Drawing.Size(183, 34);
            this.tbPassnewagain.TabIndex = 6;
            this.tbPassnewagain.UseSystemPasswordChar = true;
            this.tbPassnewagain.IconRightClick += new System.EventHandler(this.HideandView);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 560);
            this.Controls.Add(this.tbPassnewagain);
            this.Controls.Add(this.tbPassold);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.tbPassnew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResetPassword";
            this.Text = "ResetPassword";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnSignIn;
        private Guna.UI2.WinForms.Guna2TextBox tbPassnew;
        private Guna.UI2.WinForms.Guna2TextBox tbPassold;
        private Guna.UI2.WinForms.Guna2TextBox tbPassnewagain;
    }
}