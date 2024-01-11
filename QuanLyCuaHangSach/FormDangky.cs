using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormDangky : Form
    {
        public FormDangky()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormLogin f = new FormLogin();
            f.ShowDialog();
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text != "" && txtMatKhau.Text != "" && txtXacThuc.Text != "" && txtEmail.Text != "" && txtHoTen.Text != "")
            {
                ModelDB model = new ModelDB();
                var find = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == txtTenTK.Text.Trim());
                if (find == null)
                {
                    if (txtMatKhau.Text == txtXacThuc.Text)
                    {
                        var fin = model.TaiKhoans.FirstOrDefault(p => p.Email.Trim() == txtEmail.Text.Trim());
                        if (fin == null)
                        {
                            TaiKhoan taiKhoan = new TaiKhoan();
                            taiKhoan.Email = txtEmail.Text.Trim();
                            taiKhoan.TaiKhoan1 = txtTenTK.Text.Trim();
                            taiKhoan.MatKhau = txtMatKhau.Text;
                            taiKhoan.HovaTen = txtHoTen.Text.Trim(); 
                            model.TaiKhoans.Add(taiKhoan);
                            model.SaveChanges();
                            MessageBox.Show("Dang Ky thanh cong");
                        }
                        else
                        {
                            MessageBox.Show("Email da ton tai");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mat Khau va Mat Khau Xac Nhan khong trung khop");
                    }
                }
                else
                {
                    MessageBox.Show("Tai Khoan Da Ton Tai");
                }
            }
            else
            {
                MessageBox.Show("Nhập đày đủ thông tin tên tài khoản và mật khẩu và xác nhận mật khẩu và Email và Họ và Tên \nkhông được bỏ trống");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
