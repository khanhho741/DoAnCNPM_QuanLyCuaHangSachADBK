using DevExpress.Utils.Win.Hook;
using QuanLyCuaHangSach.Model1;
using QuanLyCuaHangSach.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyCuaHangSach
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            NhapData();
            
        }
        private FormHome formHome;

     
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LuuData();
            if (txtTenTK.Text != "" && txtMatKhau.Text != "")
            {
                ModelDB model = new ModelDB();
                var find = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == txtTenTK.Text.Trim());

                if (find != null)
                {
                    if (find.VoHieuHoa == false)
                    {
                        if (find.MatKhau.Trim() == txtMatKhau.Text)
                        {
                            MessageBox.Show("Đăng nhập thành công");


                            if (formHome == null)
                            {
                                formHome = new FormHome(txtTenTK.Text);
                            }
                            // Hiển thị form Home và chuyển thông tin người dùng
                            formHome.UpdateLabelName(find.TaiKhoan1, find.TaiKhoan1, find.Email);
                            formHome.Show();
                            this.Hide();
                            formHome.SetUserInfo(find.HovaTen, txtTenTK.Text, txtMatKhau.Text, find.Email);
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu sai");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản vừa nhập đã bị vô hiệu hóa");
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai");
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin tài khoản và mật khẩu\nKhông được bỏ trống");
            }
        }



        private void linkLabelQMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormQuenMatKhau f = new FormQuenMatKhau();
            f.ShowDialog();
            this.Close();
        }

        private void checkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienThiMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
      
        private void NhapData()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if(Properties.Settings.Default.Rememberme == "yes")
                {
                    txtTenTK.Text = Properties.Settings.Default.UserName;
                    txtMatKhau.Text = Properties.Settings.Default.UserPassword;
                    checkGhiNhoTk.Checked = true;
                }
                else
                {
                    Properties.Settings.Default.UserName = "";
                    Properties.Settings.Default.UserPassword = "";
                }
        
            }
        }

        private void LuuData()
        {
           if(checkGhiNhoTk.Checked)
            {
                Properties.Settings.Default.UserName = txtTenTK.Text;
                Properties.Settings.Default.UserPassword = txtMatKhau.Text;
                Properties.Settings.Default.Rememberme = "yes";
                Properties.Settings.Default.Save();
            }
           else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.UserPassword = "";
                Properties.Settings.Default.Rememberme = "no";
                Properties.Settings.Default.Save();
            }
        }



        private void FormLogin_Load(object sender, EventArgs e)
        {
            NhapData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
