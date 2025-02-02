﻿using QuanLyCuaHangSach.Model1;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTenTK.Text.Trim();
            string matKhauCu = txtMatKhau.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacThuc = txtXacThuc.Text.Trim();

            if (!string.IsNullOrWhiteSpace(taiKhoan) && !string.IsNullOrWhiteSpace(matKhauCu) &&
                !string.IsNullOrWhiteSpace(matKhauMoi) && !string.IsNullOrWhiteSpace(xacThuc))
            {
                if (matKhauMoi == xacThuc)
                {
                    if (KiemTraMatKhauCu(taiKhoan, matKhauCu))
                    {
                        using (ModelDB model = new ModelDB())
                        {
                            var accountToUpdate = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == taiKhoan);
                            if (accountToUpdate != null)
                            {
                                // Hash the new password before saving
                                accountToUpdate.MatKhau = Taikhoanmahoa.CalculateMD5Hash(matKhauMoi);
                                model.SaveChanges();
                                MessageBox.Show("Đổi mật khẩu thành công.");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy tài khoản.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng.");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới và xác thực mật khẩu không khớp.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin tên tài khoản, mật khẩu cũ, mật khẩu mới và xác thực mật khẩu.");
            }
        }

        private bool KiemTraMatKhauCu(string taiKhoan, string matKhauCu)
        {
            using (ModelDB model = new ModelDB())
            {
                var existingAccount = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == taiKhoan.Trim());

                if (existingAccount != null)
                {
                    // Hash the provided old password for comparison
                    string hashedMatKhauCu = Taikhoanmahoa.CalculateMD5Hash(matKhauCu);

                    if (string.Equals(existingAccount.MatKhau.Trim(), hashedMatKhauCu, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}