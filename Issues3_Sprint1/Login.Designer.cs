namespace QuanLyBanTraiCay
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txbLoginName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbeye = new System.Windows.Forms.PictureBox();
            this.pbhide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbeye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbhide)).BeginInit();
            this.SuspendLayout();
            // 
            // txbLoginName
            // 
            this.txbLoginName.Location = new System.Drawing.Point(228, 106);
            this.txbLoginName.Margin = new System.Windows.Forms.Padding(2);
            this.txbLoginName.Name = "txbLoginName";
            this.txbLoginName.Size = new System.Drawing.Size(284, 22);
            this.txbLoginName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // txbPW
            // 
            this.txbPW.Location = new System.Drawing.Point(228, 161);
            this.txbPW.Margin = new System.Windows.Forms.Padding(2);
            this.txbPW.Name = "txbPW";
            this.txbPW.PasswordChar = '*';
            this.txbPW.Size = new System.Drawing.Size(284, 22);
            this.txbPW.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(150, 242);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(103, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(297, 242);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbeye
            // 
            this.pbeye.Image = ((System.Drawing.Image)(resources.GetObject("pbeye.Image")));
            this.pbeye.Location = new System.Drawing.Point(528, 161);
            this.pbeye.Margin = new System.Windows.Forms.Padding(2);
            this.pbeye.Name = "pbeye";
            this.pbeye.Size = new System.Drawing.Size(45, 31);
            this.pbeye.TabIndex = 7;
            this.pbeye.TabStop = false;
            this.pbeye.Click += new System.EventHandler(this.pbeye_Click);
            // 
            // pbhide
            // 
            this.pbhide.Image = ((System.Drawing.Image)(resources.GetObject("pbhide.Image")));
            this.pbhide.Location = new System.Drawing.Point(528, 161);
            this.pbhide.Margin = new System.Windows.Forms.Padding(2);
            this.pbhide.Name = "pbhide";
            this.pbhide.Size = new System.Drawing.Size(42, 28);
            this.pbhide.TabIndex = 8;
            this.pbhide.TabStop = false;
            this.pbhide.Click += new System.EventHandler(this.pbhide_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(699, 311);
            this.Controls.Add(this.pbhide);
            this.Controls.Add(this.pbeye);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txbLoginName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbPW);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing_1);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbeye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbhide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLoginName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbeye;
        private System.Windows.Forms.PictureBox pbhide;
    }
}