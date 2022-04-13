namespace Chess
{
    partial class frmHome
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnAchievement = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword2 = new System.Windows.Forms.TextBox();
            this.tbUserName2 = new System.Windows.Forms.TextBox();
            this.tbPassword1 = new System.Windows.Forms.TextBox();
            this.tbUserName1 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.tbUserNameAchievement = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(71, 116);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(105, 29);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnAchievement
            // 
            this.btnAchievement.Location = new System.Drawing.Point(335, 116);
            this.btnAchievement.Name = "btnAchievement";
            this.btnAchievement.Size = new System.Drawing.Size(108, 29);
            this.btnAchievement.TabIndex = 1;
            this.btnAchievement.Text = "Achievement";
            this.btnAchievement.UseVisualStyleBackColor = true;
            this.btnAchievement.Click += new System.EventHandler(this.btnAchievement_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbColor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbPassword2);
            this.panel1.Controls.Add(this.tbUserName2);
            this.panel1.Controls.Add(this.tbPassword1);
            this.panel1.Controls.Add(this.tbUserName1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(38, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 278);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(3, 204);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(165, 28);
            this.cbColor.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Player 1 choose color";
            // 
            // tbPassword2
            // 
            this.tbPassword2.Location = new System.Drawing.Point(3, 151);
            this.tbPassword2.Name = "tbPassword2";
            this.tbPassword2.PasswordChar = '*';
            this.tbPassword2.PlaceholderText = "Password";
            this.tbPassword2.Size = new System.Drawing.Size(165, 27);
            this.tbPassword2.TabIndex = 9;
            // 
            // tbUserName2
            // 
            this.tbUserName2.Location = new System.Drawing.Point(3, 118);
            this.tbUserName2.Name = "tbUserName2";
            this.tbUserName2.PlaceholderText = "User Name";
            this.tbUserName2.Size = new System.Drawing.Size(165, 27);
            this.tbUserName2.TabIndex = 9;
            // 
            // tbPassword1
            // 
            this.tbPassword1.Location = new System.Drawing.Point(3, 65);
            this.tbPassword1.Name = "tbPassword1";
            this.tbPassword1.PasswordChar = '*';
            this.tbPassword1.PlaceholderText = "Password";
            this.tbPassword1.Size = new System.Drawing.Size(165, 27);
            this.tbPassword1.TabIndex = 8;
            // 
            // tbUserName1
            // 
            this.tbUserName1.Location = new System.Drawing.Point(3, 32);
            this.tbUserName1.Name = "tbUserName1";
            this.tbUserName1.PlaceholderText = "User Name";
            this.tbUserName1.Size = new System.Drawing.Size(165, 27);
            this.tbUserName1.TabIndex = 7;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(33, 238);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 29);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Player 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player 1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.tbUserNameAchievement);
            this.panel2.Location = new System.Drawing.Point(304, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 214);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(31, 65);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(108, 29);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // tbUserNameAchievement
            // 
            this.tbUserNameAchievement.Location = new System.Drawing.Point(3, 32);
            this.tbUserNameAchievement.Name = "tbUserNameAchievement";
            this.tbUserNameAchievement.PlaceholderText = "User Name";
            this.tbUserNameAchievement.Size = new System.Drawing.Size(165, 27);
            this.tbUserNameAchievement.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(155, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chess Game";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(516, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAchievement);
            this.Controls.Add(this.btnPlay);
            this.Name = "Home";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnAchievement;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPassword2;
        private System.Windows.Forms.TextBox tbUserName2;
        private System.Windows.Forms.TextBox tbPassword1;
        private System.Windows.Forms.TextBox tbUserName1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox tbUserNameAchievement;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label label4;
    }
}