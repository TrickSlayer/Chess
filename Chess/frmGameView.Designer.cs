
namespace Chess
{
    partial class frmGameView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnGamePlay = new System.Windows.Forms.Panel();
            this.pnUpdate = new System.Windows.Forms.Panel();
            this.tbIndex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbName1 = new System.Windows.Forms.Label();
            this.lbColor1 = new System.Windows.Forms.Label();
            this.lbName2 = new System.Windows.Forms.Label();
            this.lbColor2 = new System.Windows.Forms.Label();
            this.pnUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnGamePlay
            // 
            this.pnGamePlay.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnGamePlay.Location = new System.Drawing.Point(56, 41);
            this.pnGamePlay.Name = "pnGamePlay";
            this.pnGamePlay.Size = new System.Drawing.Size(552, 552);
            this.pnGamePlay.TabIndex = 2;
            // 
            // pnUpdate
            // 
            this.pnUpdate.Controls.Add(this.tbIndex);
            this.pnUpdate.Controls.Add(this.label2);
            this.pnUpdate.Controls.Add(this.label1);
            this.pnUpdate.Controls.Add(this.btnUpdate);
            this.pnUpdate.Controls.Add(this.cbRole);
            this.pnUpdate.Location = new System.Drawing.Point(632, 243);
            this.pnUpdate.Name = "pnUpdate";
            this.pnUpdate.Size = new System.Drawing.Size(196, 145);
            this.pnUpdate.TabIndex = 3;
            this.pnUpdate.Visible = false;
            // 
            // tbIndex
            // 
            this.tbIndex.Enabled = false;
            this.tbIndex.Location = new System.Drawing.Point(0, 23);
            this.tbIndex.Name = "tbIndex";
            this.tbIndex.Size = new System.Drawing.Size(196, 27);
            this.tbIndex.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Role";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Index";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(49, 110);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 29);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbRole
            // 
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(0, 76);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(196, 28);
            this.cbRole.TabIndex = 0;
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(632, 41);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(196, 29);
            this.btnShowLog.TabIndex = 4;
            this.btnShowLog.Text = "Show chessmen move";
            this.btnShowLog.UseVisualStyleBackColor = true;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(632, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(196, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save and reset";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Player 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(632, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Player 2:";
            // 
            // lbName1
            // 
            this.lbName1.AutoSize = true;
            this.lbName1.Location = new System.Drawing.Point(632, 110);
            this.lbName1.Name = "lbName1";
            this.lbName1.Size = new System.Drawing.Size(50, 20);
            this.lbName1.TabIndex = 8;
            this.lbName1.Text = "label5";
            // 
            // lbColor1
            // 
            this.lbColor1.AutoSize = true;
            this.lbColor1.Location = new System.Drawing.Point(778, 110);
            this.lbColor1.Name = "lbColor1";
            this.lbColor1.Size = new System.Drawing.Size(50, 20);
            this.lbColor1.TabIndex = 9;
            this.lbColor1.Text = "label5";
            // 
            // lbName2
            // 
            this.lbName2.AutoSize = true;
            this.lbName2.Location = new System.Drawing.Point(632, 165);
            this.lbName2.Name = "lbName2";
            this.lbName2.Size = new System.Drawing.Size(50, 20);
            this.lbName2.TabIndex = 10;
            this.lbName2.Text = "label6";
            // 
            // lbColor2
            // 
            this.lbColor2.AutoSize = true;
            this.lbColor2.Location = new System.Drawing.Point(778, 165);
            this.lbColor2.Name = "lbColor2";
            this.lbColor2.Size = new System.Drawing.Size(50, 20);
            this.lbColor2.TabIndex = 11;
            this.lbColor2.Text = "label7";
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 618);
            this.Controls.Add(this.lbColor2);
            this.Controls.Add(this.lbName2);
            this.Controls.Add(this.lbColor1);
            this.Controls.Add(this.lbName1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.pnUpdate);
            this.Controls.Add(this.pnGamePlay);
            this.Name = "GameView";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnUpdate.ResumeLayout(false);
            this.pnUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnGamePlay;
        private System.Windows.Forms.Panel pnUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.TextBox tbIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbName1;
        private System.Windows.Forms.Label lbColor1;
        private System.Windows.Forms.Label lbName2;
        private System.Windows.Forms.Label lbColor2;
    }
}
