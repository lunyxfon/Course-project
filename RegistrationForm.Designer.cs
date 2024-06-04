namespace Semenov_Curs
{
    partial class RegistrationForm
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
            this.Registr = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonback = new System.Windows.Forms.Button();
            this.RepitPasswordtextBox = new System.Windows.Forms.TextBox();
            this.ShowPassword = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Registr
            // 
            this.Registr.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Registr.Font = new System.Drawing.Font("NSimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registr.ForeColor = System.Drawing.SystemColors.Control;
            this.Registr.Location = new System.Drawing.Point(-5, -6);
            this.Registr.Name = "Registr";
            this.Registr.Size = new System.Drawing.Size(422, 65);
            this.Registr.TabIndex = 0;
            this.Registr.Text = "Регистрация";
            this.Registr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstName
            // 
            this.FirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FirstName.Location = new System.Drawing.Point(143, 90);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(122, 20);
            this.FirstName.TabIndex = 1;
            // 
            // LastName
            // 
            this.LastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastName.Location = new System.Drawing.Point(143, 151);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(122, 20);
            this.LastName.TabIndex = 2;
            // 
            // Username
            // 
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Username.Location = new System.Drawing.Point(143, 207);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(122, 20);
            this.Username.TabIndex = 3;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Password
            // 
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.Location = new System.Drawing.Point(143, 268);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(122, 20);
            this.Password.TabIndex = 4;
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonRegister.Font = new System.Drawing.Font("PMingLiU-ExtB", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonRegister.Location = new System.Drawing.Point(228, 383);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(170, 47);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "Зарегистироваться ";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonback
            // 
            this.buttonback.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonback.Font = new System.Drawing.Font("PMingLiU-ExtB", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonback.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonback.Location = new System.Drawing.Point(12, 383);
            this.buttonback.Name = "buttonback";
            this.buttonback.Size = new System.Drawing.Size(170, 47);
            this.buttonback.TabIndex = 6;
            this.buttonback.Text = "Назад";
            this.buttonback.UseVisualStyleBackColor = false;
            this.buttonback.Click += new System.EventHandler(this.buttonback_Click);
            // 
            // RepitPasswordtextBox
            // 
            this.RepitPasswordtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RepitPasswordtextBox.Location = new System.Drawing.Point(143, 320);
            this.RepitPasswordtextBox.Name = "RepitPasswordtextBox";
            this.RepitPasswordtextBox.Size = new System.Drawing.Size(122, 20);
            this.RepitPasswordtextBox.TabIndex = 7;
            this.RepitPasswordtextBox.TextChanged += new System.EventHandler(this.RepitPasswordtextBox_TextChanged);
            // 
            // ShowPassword
            // 
            this.ShowPassword.Location = new System.Drawing.Point(143, 346);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(133, 31);
            this.ShowPassword.TabIndex = 8;
            this.ShowPassword.TabStop = true;
            this.ShowPassword.UseVisualStyleBackColor = true;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.ControlBox = false;
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.RepitPasswordtextBox);
            this.Controls.Add(this.buttonback);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.Registr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Registr;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonback;
        private System.Windows.Forms.TextBox RepitPasswordtextBox;
        private System.Windows.Forms.RadioButton ShowPassword;
    }
}