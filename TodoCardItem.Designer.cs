namespace GuiModul
{
    partial class TodoCardItem
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.deskripsi = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Swis721 WGL4 BT", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(2, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(115, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Nama_Item";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnViewDetail);
            this.panel1.Controls.Add(this.deskripsi);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 108);
            this.panel1.TabIndex = 1;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.White;
            this.btnViewDetail.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnViewDetail.Location = new System.Drawing.Point(20, 79);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(121, 27);
            this.btnViewDetail.TabIndex = 3;
            this.btnViewDetail.Text = "View Details";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // deskripsi
            // 
            this.deskripsi.AutoSize = true;
            this.deskripsi.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deskripsi.Location = new System.Drawing.Point(22, 46);
            this.deskripsi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deskripsi.Name = "deskripsi";
            this.deskripsi.Size = new System.Drawing.Size(93, 16);
            this.deskripsi.TabIndex = 2;
            this.deskripsi.Text = "Description : iop";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(178, 6);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status : poo";
            // 
            // TodoCardItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TodoCardItem";
            this.Size = new System.Drawing.Size(235, 111);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Label deskripsi;
    }
}
