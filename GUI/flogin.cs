using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace GUI
{
    public partial class flogin : Form
    {
        List<Image> images = new List<Image>();
        string[] location = new string[25];
        string startupPath = Application.StartupPath;
        public flogin()
        {
            InitializeComponent();

            location[0] = Path.Combine(startupPath, "img", "Animation", "textbox_user_1.jpg");
            location[1] = Path.Combine(startupPath, "img", "Animation","textbox_user_2.jpg");
            location[2] = Path.Combine(startupPath, "img", "Animation","textbox_user_4.jpg");
            location[3] = Path.Combine(startupPath, "img", "Animation","textbox_user_5.jpg");
            location[4] = Path.Combine(startupPath, "img", "Animation","textbox_user_6.jpg");
            location[5] = Path.Combine(startupPath, "img", "Animation","textbox_user_7.jpg");
            location[6] = Path.Combine(startupPath, "img", "Animation","textbox_user_8.jpg");
            location[7] = Path.Combine(startupPath, "img", "Animation","textbox_user_9.jpg");
            location[8] = Path.Combine(startupPath, "img", "Animation","textbox_user_10.jpg");
            location[9] = Path.Combine(startupPath, "img", "Animation","textbox_user_11.jpg");
            location[10] = Path.Combine(startupPath, "img", "Animation","textbox_user_12.jpg");
            location[11] = Path.Combine(startupPath, "img", "Animation","textbox_user_13.jpg");
            location[12] = Path.Combine(startupPath, "img", "Animation","textbox_user_14.jpg");
            location[13] = Path.Combine(startupPath, "img", "Animation","textbox_user_15.jpg");
            location[14] = Path.Combine(startupPath, "img", "Animation","textbox_user_16.jpg");
            location[15] = Path.Combine(startupPath, "img", "Animation","textbox_user_17.jpg");
            location[16] = Path.Combine(startupPath, "img", "Animation","textbox_user_18.jpg");
            location[17] = Path.Combine(startupPath, "img", "Animation","textbox_user_19.jpg");
            location[18] = Path.Combine(startupPath, "img", "Animation","textbox_user_20.jpg");
            location[19] = Path.Combine(startupPath, "img", "Animation","textbox_user_21.jpg");
            location[20] = Path.Combine(startupPath, "img", "Animation","textbox_user_22.jpg");
            location[21] = Path.Combine(startupPath, "img", "Animation","textbox_user_23.jpg");
            location[22] = Path.Combine(startupPath, "img", "Animation","textbox_user_24.jpg");
            tounage();

        }


        private void tounage()
        {
           for (int i = 0; i < 23; i++)
           {
                Bitmap bitmap = new Bitmap(location[i]);
                images.Add(bitmap);
           }
                images.Add(Properties.Resources.textbox_user_24);
        }



        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtUsername.Text.Length <= 15)
            {
                pictureBox1.Image = images[txtUsername.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (txtUsername.Text.Length <= 0)
                pictureBox1.Image = Properties.Resources.debut;
            else
                pictureBox1.Image = images[22];
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            Bitmap bmpass = new Bitmap(Path.Combine(startupPath, "img", "Animation","textbox_password.png"));
            pictureBox1.Image = bmpass;
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            Bitmap bmpass = new Bitmap(Path.Combine(startupPath, "img", "Animation", "textbox_password.png"));
            pictureBox1.Image = bmpass;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            Bitmap bmpdefault = new Bitmap(Path.Combine(startupPath, "img", "Animation", "textbox_default.png"));
            pictureBox1.Image = bmpdefault;
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0)
                pictureBox1.Image = images[txtUsername.Text.Length - 1];
            else
                pictureBox1.Image = Properties.Resources.debut;

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Ban chưa nhập tên đăng nhập !","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ban chưa nhập mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }else
            {
                username = txtUsername.Text;
                password = txtPassword.Text;
                LoginBLL login = new LoginBLL();
                bool check = login.login(username, password);

                if (check)
                {
                    fTableManager f = new fTableManager();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                    resetValues();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void flogin_Load(object sender, EventArgs e)
        {

        }
       
        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information ) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void resetValues()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                LoginBLL login = new LoginBLL();
                bool check = login.login(username, password);

                if (check)
                {
                    fTableManager f = new fTableManager();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                    resetValues();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
