using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fTableManager : Form
    {
        private KryptonButton currentButton;
        private Random random;
        private Form activateForm;

        public fTableManager()
        {
            InitializeComponent();
            random = new Random();
            CustomizeDesign();
            
        }

        

        //private Color ChonMauSac()
        //{
        //    int index = random.Next(ThemeColor.DSMau.Count);
        //    while (tempindex == index)
        //    {
        //        index = random.Next(ThemeColor.DSMau.Count);
        //    }
        //    tempindex = index;
        //    string color = ThemeColor.DSMau[index];
        //    return ColorTranslator.FromHtml(color);
        //}
        private void ActivateButton (Object btnSender)
        {
            if(btnSender != null)
            {
                if (currentButton != (KryptonButton)btnSender)
                {
                    DisableButton();
                    //Color color = ChonMauSac();
                    currentButton = btnSender as KryptonButton;
                    currentButton.BackColor = Color.Red;
                    currentButton.ForeColor = Color.White; 
                    currentButton.Font = new System.Drawing.Font("Times New Roman", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //panelLoGo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = C;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }
        }
        
        private void DisableButton()
        {
            foreach(Control previousBtn in panelSildeMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activateForm != null)
            {
                activateForm.Close();
            }
            ActivateButton(btnSender);
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPage.Controls.Add(childForm);
            this.panelDesktopPage.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void  CustomizeDesign()
        {
            HoaDonToolSubMenu.Visible = false;
        }

        private void hideMenu()
        {
            if (HoaDonToolSubMenu.Visible == true)
                HoaDonToolSubMenu.Visible = false;
        }

        private void ShowsubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }


        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void BtnNhanVienMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fNhanhVien(), sender);
            ActivateButton(sender);
        }

        private void btnKhachhangMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fKhachHang(), sender);
            ActivateButton(sender);
        }

        private void btnDoChoiMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDMDoChoi(), sender);
            ActivateButton(sender);
        }

        private void btnThongKeMenu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowsubMenu(HoaDonToolSubMenu);        
        }


        private void btnThongKeNV_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            hideMenu();
        }

        private void btnThongKeKH_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            hideMenu();
        }

        private void btnThongKeDC_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            hideMenu();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fHoaDon(), sender);
            ActivateButton(sender);
            hideMenu();
        }


        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (activateForm != null)
                activateForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            //lblTitle.Text = "TRANG CHỦ";
            //panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLoGo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
        }



        private void btnDangXuat_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnHoaDonMenu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowsubMenu(HoaDonToolSubMenu);
        }

        private void panelSildeMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTKHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fTimHDBan(), sender);
            ActivateButton(sender);
            hideMenu();
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fTheLoai(), sender);
            ActivateButton(sender);
        }
    }
}
