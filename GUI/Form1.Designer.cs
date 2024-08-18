
namespace GUI
{
    partial class fTableManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
            this.panelSildeMenu = new System.Windows.Forms.Panel();
            this.btnDangXuat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.HoaDonToolSubMenu = new System.Windows.Forms.Panel();
            this.btnTKHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDoChoiMenu = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnKhachhangMenu = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNhanVienMenu = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panelLoGo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDesktopPage = new System.Windows.Forms.Panel();
            this.btnTheLoai = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panelSildeMenu.SuspendLayout();
            this.HoaDonToolSubMenu.SuspendLayout();
            this.panelLoGo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSildeMenu
            // 
            this.panelSildeMenu.BackColor = System.Drawing.Color.Black;
            this.panelSildeMenu.Controls.Add(this.btnTheLoai);
            this.panelSildeMenu.Controls.Add(this.btnDangXuat);
            this.panelSildeMenu.Controls.Add(this.HoaDonToolSubMenu);
            this.panelSildeMenu.Controls.Add(this.kryptonButton1);
            this.panelSildeMenu.Controls.Add(this.btnDoChoiMenu);
            this.panelSildeMenu.Controls.Add(this.btnKhachhangMenu);
            this.panelSildeMenu.Controls.Add(this.btnNhanVienMenu);
            this.panelSildeMenu.Controls.Add(this.panelLoGo);
            this.panelSildeMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSildeMenu.Location = new System.Drawing.Point(3, 3);
            this.panelSildeMenu.Name = "panelSildeMenu";
            this.panelSildeMenu.Size = new System.Drawing.Size(250, 714);
            this.panelSildeMenu.TabIndex = 0;
            this.panelSildeMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSildeMenu_Paint);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 648);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(250, 66);
            this.btnDangXuat.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnDangXuat.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnDangXuat.StateCommon.Border.ColorAngle = 1F;
            this.btnDangXuat.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnDangXuat.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDangXuat.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDangXuat.StateCommon.Border.Width = 1;
            this.btnDangXuat.StateCommon.Content.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDangXuat.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDangXuat.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.TabIndex = 15;
            this.btnDangXuat.Values.Image = global::GUI.Properties.Resources.logout;
            this.btnDangXuat.Values.Text = "Đăng Xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // HoaDonToolSubMenu
            // 
            this.HoaDonToolSubMenu.Controls.Add(this.btnTKHoaDon);
            this.HoaDonToolSubMenu.Controls.Add(this.btnHoaDon);
            this.HoaDonToolSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.HoaDonToolSubMenu.Location = new System.Drawing.Point(0, 339);
            this.HoaDonToolSubMenu.Name = "HoaDonToolSubMenu";
            this.HoaDonToolSubMenu.Padding = new System.Windows.Forms.Padding(1);
            this.HoaDonToolSubMenu.Size = new System.Drawing.Size(250, 104);
            this.HoaDonToolSubMenu.TabIndex = 14;
            // 
            // btnTKHoaDon
            // 
            this.btnTKHoaDon.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.btnTKHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTKHoaDon.Location = new System.Drawing.Point(1, 51);
            this.btnTKHoaDon.Name = "btnTKHoaDon";
            this.btnTKHoaDon.Size = new System.Drawing.Size(248, 50);
            this.btnTKHoaDon.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnTKHoaDon.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnTKHoaDon.StateCommon.Border.ColorAngle = 1F;
            this.btnTKHoaDon.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnTKHoaDon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTKHoaDon.StateCommon.Border.Width = 1;
            this.btnTKHoaDon.StateCommon.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnTKHoaDon.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-50, 0, 0, 0);
            this.btnTKHoaDon.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnTKHoaDon.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKHoaDon.TabIndex = 7;
            this.btnTKHoaDon.Values.Image = global::GUI.Properties.Resources.bill__1_;
            this.btnTKHoaDon.Values.Text = "Tìm Hóa Đơn";
            this.btnTKHoaDon.Click += new System.EventHandler(this.btnTKHoaDon_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDon.Location = new System.Drawing.Point(1, 1);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(248, 50);
            this.btnHoaDon.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnHoaDon.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnHoaDon.StateCommon.Border.ColorAngle = 1F;
            this.btnHoaDon.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnHoaDon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHoaDon.StateCommon.Border.Width = 1;
            this.btnHoaDon.StateCommon.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnHoaDon.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-50, 0, 0, 0);
            this.btnHoaDon.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnHoaDon.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.TabIndex = 6;
            this.btnHoaDon.Values.Image = global::GUI.Properties.Resources.bill;
            this.btnHoaDon.Values.Text = "Lập Hóa Đơn";
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonButton1.Location = new System.Drawing.Point(0, 273);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(250, 66);
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Border.ColorAngle = 1F;
            this.kryptonButton1.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.kryptonButton1.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Width = 1;
            this.kryptonButton1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 5;
            this.kryptonButton1.Values.Image = global::GUI.Properties.Resources.billing;
            this.kryptonButton1.Values.Text = "Hóa Đơn";
            this.kryptonButton1.Click += new System.EventHandler(this.btnHoaDonMenu_Click);
            // 
            // btnDoChoiMenu
            // 
            this.btnDoChoiMenu.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.btnDoChoiMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoChoiMenu.Location = new System.Drawing.Point(0, 207);
            this.btnDoChoiMenu.Name = "btnDoChoiMenu";
            this.btnDoChoiMenu.Size = new System.Drawing.Size(250, 66);
            this.btnDoChoiMenu.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnDoChoiMenu.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnDoChoiMenu.StateCommon.Border.ColorAngle = 1F;
            this.btnDoChoiMenu.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnDoChoiMenu.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDoChoiMenu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDoChoiMenu.StateCommon.Border.Width = 1;
            this.btnDoChoiMenu.StateCommon.Content.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDoChoiMenu.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDoChoiMenu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoChoiMenu.TabIndex = 4;
            this.btnDoChoiMenu.Values.Image = global::GUI.Properties.Resources.toys;
            this.btnDoChoiMenu.Values.Text = "Đồ Chơi";
            this.btnDoChoiMenu.Click += new System.EventHandler(this.btnDoChoiMenu_Click);
            // 
            // btnKhachhangMenu
            // 
            this.btnKhachhangMenu.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.btnKhachhangMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachhangMenu.Location = new System.Drawing.Point(0, 141);
            this.btnKhachhangMenu.Name = "btnKhachhangMenu";
            this.btnKhachhangMenu.Size = new System.Drawing.Size(250, 66);
            this.btnKhachhangMenu.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnKhachhangMenu.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnKhachhangMenu.StateCommon.Border.ColorAngle = 1F;
            this.btnKhachhangMenu.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnKhachhangMenu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKhachhangMenu.StateCommon.Border.Width = 1;
            this.btnKhachhangMenu.StateCommon.Content.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnKhachhangMenu.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnKhachhangMenu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachhangMenu.TabIndex = 3;
            this.btnKhachhangMenu.Values.Image = global::GUI.Properties.Resources.customer;
            this.btnKhachhangMenu.Values.Text = "Khách Hàng";
            this.btnKhachhangMenu.Click += new System.EventHandler(this.btnKhachhangMenu_Click);
            // 
            // btnNhanVienMenu
            // 
            this.btnNhanVienMenu.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.btnNhanVienMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVienMenu.Location = new System.Drawing.Point(0, 75);
            this.btnNhanVienMenu.Name = "btnNhanVienMenu";
            this.btnNhanVienMenu.Size = new System.Drawing.Size(250, 66);
            this.btnNhanVienMenu.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnNhanVienMenu.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnNhanVienMenu.StateCommon.Border.ColorAngle = 1F;
            this.btnNhanVienMenu.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnNhanVienMenu.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnNhanVienMenu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhanVienMenu.StateCommon.Border.Width = 1;
            this.btnNhanVienMenu.StateCommon.Content.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNhanVienMenu.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnNhanVienMenu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVienMenu.TabIndex = 2;
            this.btnNhanVienMenu.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVienMenu.Values.Image")));
            this.btnNhanVienMenu.Values.Text = "Nhân viên";
            this.btnNhanVienMenu.Click += new System.EventHandler(this.BtnNhanVienMenu_Click);
            // 
            // panelLoGo
            // 
            this.panelLoGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLoGo.Controls.Add(this.label1);
            this.panelLoGo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoGo.Location = new System.Drawing.Point(0, 0);
            this.panelLoGo.Name = "panelLoGo";
            this.panelLoGo.Size = new System.Drawing.Size(250, 75);
            this.panelLoGo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toy Store";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktopPage
            // 
            this.panelDesktopPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDesktopPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPage.Location = new System.Drawing.Point(253, 3);
            this.panelDesktopPage.Name = "panelDesktopPage";
            this.panelDesktopPage.Size = new System.Drawing.Size(1271, 714);
            this.panelDesktopPage.TabIndex = 2;
            // 
            // btnTheLoai
            // 
            this.btnTheLoai.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.btnTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTheLoai.Location = new System.Drawing.Point(0, 443);
            this.btnTheLoai.Name = "btnTheLoai";
            this.btnTheLoai.Size = new System.Drawing.Size(250, 66);
            this.btnTheLoai.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.btnTheLoai.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.btnTheLoai.StateCommon.Border.ColorAngle = 1F;
            this.btnTheLoai.StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnTheLoai.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnTheLoai.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTheLoai.StateCommon.Border.Width = 1;
            this.btnTheLoai.StateCommon.Content.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTheLoai.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnTheLoai.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoai.TabIndex = 16;
            this.btnTheLoai.Values.Image = global::GUI.Properties.Resources.categories;
            this.btnTheLoai.Values.Text = "Thể loại";
            this.btnTheLoai.Click += new System.EventHandler(this.btnTheLoai_Click);
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1527, 720);
            this.Controls.Add(this.panelDesktopPage);
            this.Controls.Add(this.panelSildeMenu);
            this.MinimumSize = new System.Drawing.Size(1356, 720);
            this.Name = "fTableManager";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Quản Lý Đồ Chơi";
            this.panelSildeMenu.ResumeLayout(false);
            this.HoaDonToolSubMenu.ResumeLayout(false);
            this.panelLoGo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSildeMenu;
        private System.Windows.Forms.Panel panelLoGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDesktopPage;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNhanVienMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnKhachhangMenu;
        private System.Windows.Forms.Panel HoaDonToolSubMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTKHoaDon;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnHoaDon;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDoChoiMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDangXuat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTheLoai;
    }
}