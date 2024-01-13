using QuanLyCuaHangSach.Model1;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormBaoMatTK : Form
    {
        public FormBaoMatTK()
        {
            InitializeComponent();
        }

        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
      

        private void btnGiaima_Click(object sender, EventArgs e)
        {
           
        }
    

        private void FormBaoMatTK_Load(object sender, EventArgs e)
        {

        }

        private void btnMahoa_Click(object sender, EventArgs e)
        {
            // Mã hóa mật khẩu (Ví dụ)
            string taiKhoan = txtTK.Text.Trim();
            string matKhau = txtMatkhau.Text.Trim();

            if (!string.IsNullOrWhiteSpace(taiKhoan) && !string.IsNullOrWhiteSpace(matKhau))
            {
                using (ModelDB model = new ModelDB())
                {
                    var accountToCheck = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1 == taiKhoan && p.MatKhau == matKhau);

                    if (accountToCheck != null)
                    {
                        // Nếu tên tài khoản và mật khẩu khớp, thì mới mã hóa và cập nhật vào cơ sở dữ liệu
                        accountToCheck.MatKhau = Taikhoanmahoa.CalculateMD5Hash(txtMatkhau.Text.Trim());
                        model.SaveChanges();
                        MessageBox.Show("Mật khẩu đã được mã hóa và cập nhật vào cơ sở dữ liệu.");
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ tên tài khoản và mật khẩu.");
            }
        
        }
    }
}