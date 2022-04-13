namespace Chess
{
    partial class frmAchievement
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
            this.dgvAchievement = new System.Windows.Forms.DataGridView();
            this.tbName2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievement)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAchievement
            // 
            this.dgvAchievement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAchievement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAchievement.Location = new System.Drawing.Point(12, 73);
            this.dgvAchievement.Name = "dgvAchievement";
            this.dgvAchievement.RowHeadersWidth = 51;
            this.dgvAchievement.RowTemplate.Height = 29;
            this.dgvAchievement.Size = new System.Drawing.Size(776, 365);
            this.dgvAchievement.TabIndex = 0;
            this.dgvAchievement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAchievement_CellClick);
            // 
            // tbName2
            // 
            this.tbName2.Location = new System.Drawing.Point(160, 29);
            this.tbName2.Name = "tbName2";
            this.tbName2.Size = new System.Drawing.Size(153, 27);
            this.tbName2.TabIndex = 1;
            this.tbName2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by Player 2";
            // 
            // frmAchievement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName2);
            this.Controls.Add(this.dgvAchievement);
            this.Name = "frmAchievement";
            this.Text = "frmAchivement";
            this.Load += new System.EventHandler(this.frmAchievement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAchievement;
        private System.Windows.Forms.TextBox tbName2;
        private System.Windows.Forms.Label label1;
    }
}