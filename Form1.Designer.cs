namespace Semenov_Curs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Registr = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.OpenFormCiti = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.OpenRegistr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonShowPassword = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // Registr
            // 
            this.Registr.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Registr.Font = new System.Drawing.Font("NSimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registr.ForeColor = System.Drawing.SystemColors.Control;
            this.Registr.Location = new System.Drawing.Point(0, 0);
            this.Registr.Name = "Registr";
            this.Registr.Size = new System.Drawing.Size(403, 65);
            this.Registr.TabIndex = 1;
            this.Registr.Text = "Вход";
            this.Registr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(130, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 144);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Username
            // 
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Username.Location = new System.Drawing.Point(101, 236);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(187, 20);
            this.Username.TabIndex = 3;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Password
            // 
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.Location = new System.Drawing.Point(101, 284);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(187, 20);
            this.Password.TabIndex = 4;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // OpenFormCiti
            // 
            this.OpenFormCiti.BackColor = System.Drawing.SystemColors.HotTrack;
            this.OpenFormCiti.Font = new System.Drawing.Font("PMingLiU-ExtB", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFormCiti.ForeColor = System.Drawing.SystemColors.Control;
            this.OpenFormCiti.Location = new System.Drawing.Point(101, 333);
            this.OpenFormCiti.Name = "OpenFormCiti";
            this.OpenFormCiti.Size = new System.Drawing.Size(187, 46);
            this.OpenFormCiti.TabIndex = 5;
            this.OpenFormCiti.Text = "Войти";
            this.OpenFormCiti.UseVisualStyleBackColor = false;
            this.OpenFormCiti.Click += new System.EventHandler(this.OpenFormCiti_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Exit.Font = new System.Drawing.Font("PMingLiU-ExtB", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.SystemColors.Control;
            this.Exit.Location = new System.Drawing.Point(292, 441);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(98, 46);
            this.Exit.TabIndex = 8;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // OpenRegistr
            // 
            this.OpenRegistr.BackColor = System.Drawing.SystemColors.HotTrack;
            this.OpenRegistr.Font = new System.Drawing.Font("PMingLiU-ExtB", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenRegistr.ForeColor = System.Drawing.SystemColors.Control;
            this.OpenRegistr.Location = new System.Drawing.Point(101, 399);
            this.OpenRegistr.Name = "OpenRegistr";
            this.OpenRegistr.Size = new System.Drawing.Size(187, 42);
            this.OpenRegistr.TabIndex = 7;
            this.OpenRegistr.Text = "Зарегистрироваться";
            this.OpenRegistr.UseVisualStyleBackColor = false;
            this.OpenRegistr.Click += new System.EventHandler(this.OpenRegistr_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU-ExtB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "если у вас нет аккаунта";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // radioButtonShowPassword
            // 
            this.radioButtonShowPassword.AutoSize = true;
            this.radioButtonShowPassword.Location = new System.Drawing.Point(144, 310);
            this.radioButtonShowPassword.Name = "radioButtonShowPassword";
            this.radioButtonShowPassword.Size = new System.Drawing.Size(113, 17);
            this.radioButtonShowPassword.TabIndex = 10;
            this.radioButtonShowPassword.TabStop = true;
            this.radioButtonShowPassword.Text = "Показать пароль";
            this.radioButtonShowPassword.UseVisualStyleBackColor = true;
            this.radioButtonShowPassword.CheckedChanged += new System.EventHandler(this.radioButtonShowPassword_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 499);
            this.ControlBox = false;
            this.Controls.Add(this.radioButtonShowPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OpenRegistr);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.OpenFormCiti);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Registr);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Registr;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button OpenFormCiti;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button OpenRegistr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonShowPassword;
    }
}

