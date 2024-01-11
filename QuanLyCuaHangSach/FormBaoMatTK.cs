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

        public static string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhau = txtMatkhau.Text.Trim();

            if (!string.IsNullOrWhiteSpace(matKhau))
            {
                string hashedPassword = HashPassword(matKhau);

                using (ModelDB model = new ModelDB())
                {
                    // Lấy thông tin tài khoản cần thay đổi mật khẩu từ cơ sở dữ liệu
                    string taiKhoan = txtTK.Text; // Thay "username" bằng tên tài khoản cần thay đổi mật khẩu
                    var accountToUpdate = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1 == taiKhoan);

                    if (accountToUpdate != null)
                    {
                        // Lưu mật khẩu đã mã hóa vào cơ sở dữ liệu
                        accountToUpdate.MatKhau = hashedPassword;
                        model.SaveChanges();
                        MessageBox.Show("Mật khẩu đã được mã hóa và cập nhật vào cơ sở dữ liệu.");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền mật khẩu.");
            }
        }

        private void btnGiaima_Click(object sender, EventArgs e)
        {
            string matKhauMaHoa = txtMatkhau.Text.Trim();

            if (!string.IsNullOrWhiteSpace(matKhauMaHoa))
            {
                string hashedPassword = HashPassword(matKhauMaHoa);

                // Hiển thị mật khẩu giải mã từ mật khẩu đã mã hóa (hashedPassword)
                MessageBox.Show("Mật khẩu được giải mã: " + hashedPassword);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mật khẩu đã mã hóa để giải mã.");
            }
        
         }
    }
}