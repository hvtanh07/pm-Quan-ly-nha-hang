namespace GUI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.monAnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nguyenLieuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nguyênLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mónĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoDichToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lậpHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lậpBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThángToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monAnToolStripMenuItem,
            this.nguyenLieuToolStripMenuItem,
            this.giaoDichToolStripMenuItem,
            this.lậpBáoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // monAnToolStripMenuItem
            // 
            this.monAnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânVienToolStripMenuItem});
            this.monAnToolStripMenuItem.Name = "monAnToolStripMenuItem";
            this.monAnToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.monAnToolStripMenuItem.Text = "Nhân lưc";
            // 
            // nhânVienToolStripMenuItem
            // 
            this.nhânVienToolStripMenuItem.Name = "nhânVienToolStripMenuItem";
            this.nhânVienToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.nhânVienToolStripMenuItem.Text = "Nhân vien";
            this.nhânVienToolStripMenuItem.Click += new System.EventHandler(this.nhânVienToolStripMenuItem_Click);
            // 
            // nguyenLieuToolStripMenuItem
            // 
            this.nguyenLieuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nguyênLiệuToolStripMenuItem,
            this.mónĂnToolStripMenuItem});
            this.nguyenLieuToolStripMenuItem.Name = "nguyenLieuToolStripMenuItem";
            this.nguyenLieuToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.nguyenLieuToolStripMenuItem.Text = "Chế biến";
            // 
            // nguyênLiệuToolStripMenuItem
            // 
            this.nguyênLiệuToolStripMenuItem.Name = "nguyênLiệuToolStripMenuItem";
            this.nguyênLiệuToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.nguyênLiệuToolStripMenuItem.Text = "Nguyên Liệu";
            this.nguyênLiệuToolStripMenuItem.Click += new System.EventHandler(this.nguyênLiệuToolStripMenuItem_Click);
            // 
            // mónĂnToolStripMenuItem
            // 
            this.mónĂnToolStripMenuItem.Name = "mónĂnToolStripMenuItem";
            this.mónĂnToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.mónĂnToolStripMenuItem.Text = "Món ăn";
            this.mónĂnToolStripMenuItem.Click += new System.EventHandler(this.mónĂnToolStripMenuItem_Click);
            // 
            // giaoDichToolStripMenuItem
            // 
            this.giaoDichToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datBanToolStripMenuItem,
            this.lậpHóaĐơnToolStripMenuItem});
            this.giaoDichToolStripMenuItem.Name = "giaoDichToolStripMenuItem";
            this.giaoDichToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.giaoDichToolStripMenuItem.Text = "Giao dich";
            // 
            // datBanToolStripMenuItem
            // 
            this.datBanToolStripMenuItem.Name = "datBanToolStripMenuItem";
            this.datBanToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.datBanToolStripMenuItem.Text = "Dat ban";
            this.datBanToolStripMenuItem.Click += new System.EventHandler(this.datBanToolStripMenuItem_Click);
            // 
            // lậpHóaĐơnToolStripMenuItem
            // 
            this.lậpHóaĐơnToolStripMenuItem.Name = "lậpHóaĐơnToolStripMenuItem";
            this.lậpHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.lậpHóaĐơnToolStripMenuItem.Text = "Lập hóa đơn";
            this.lậpHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.lậpHóaĐơnToolStripMenuItem_Click);
            // 
            // lậpBáoCáoToolStripMenuItem
            // 
            this.lậpBáoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoThángToolStripMenuItem});
            this.lậpBáoCáoToolStripMenuItem.Name = "lậpBáoCáoToolStripMenuItem";
            this.lậpBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.lậpBáoCáoToolStripMenuItem.Text = "Lập báo cáo";
            // 
            // báoCáoThángToolStripMenuItem
            // 
            this.báoCáoThángToolStripMenuItem.Name = "báoCáoThángToolStripMenuItem";
            this.báoCáoThángToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.báoCáoThángToolStripMenuItem.Text = "Báo cáo tháng";
            this.báoCáoThángToolStripMenuItem.Click += new System.EventHandler(this.báoCáoThángToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 611);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem monAnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nguyenLieuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nguyênLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mónĂnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giaoDichToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lậpHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lậpBáoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThángToolStripMenuItem;
    }
}