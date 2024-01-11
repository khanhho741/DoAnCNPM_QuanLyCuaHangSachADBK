using QuanLyCuaHangSach.Model1;
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

namespace QuanLyCuaHangSach
{
    public partial class FormTaikhoan : Form
    {
        public FormTaikhoan()
        {
            InitializeComponent();
        }

        public void SetAccountInfo(string hoten, string taiKhoan, string matKhau, string email)
        {
            labelHoten.Text = hoten;
            labelName.Text = taiKhoan;
            string matkhau = new string('*', matKhau.Length);
            labelPassword.Text = matkhau;
            labelEmail.Text = email;
            txtHoTen.Text = hoten;
            txtTenTK.Text = taiKhoan;
            txtEmail.Text = email;

        }

        private void resetForm()
        {
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
                string hoten = txtHoTen.Text;
                string matKhau = txtMatKhau.Text;
                string taiKhoan = txtTenTK.Text;
                string email = txtEmail.Text;

                if (!string.IsNullOrWhiteSpace(taiKhoan) && !string.IsNullOrWhiteSpace(matKhau) && !string.IsNullOrWhiteSpace(email))
                {
                    if (!IsValidEmail(email))
                    {
                        MessageBox.Show("Địa chỉ email không hợp lệ.");
                        return;
                    }

                    ModelDB model = new ModelDB();
                    var existingAccount = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == taiKhoan);

                    if (existingAccount != null)
                    {

                        existingAccount.HovaTen = hoten;
                        existingAccount.MatKhau = matKhau; // Lưu mật khẩu đã mã hóa
                        existingAccount.Email = email;

                        model.SaveChanges();
                        resetForm();
                        MessageBox.Show("Cập nhật thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tên tài khoản, mật khẩu và email.");
                }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau f = new FormDoiMatKhau();
            f.ShowDialog();
        }

        private void btnBaoMat_Click(object sender, EventArgs e)
        {
            FormBaoMatTK f = new FormBaoMatTK();
            f.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is FormHome)
                    {
                        frm.Close();
                        break;
                    }
                }

                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

       
        private void FormTaikhoan_Load(object sender, EventArgs e)
        {
            ModelDB model1 = new ModelDB();
            var k = model1.NhanViens.FirstOrDefault(p => p.TaiKhoan.Trim() == labelName.Text.Trim());
            if (k != null)
            {
                if (k.HinhAnhNhanVien != null)
                {
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "AnhNV", k.HinhAnhNhanVien);
                    Image avatarImage = Image.FromFile(imagePath);
                    picAvatar.Image = avatarImage;
                }
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void FormTaikhoan_Load_1(object sender, EventArgs e)
        {
            ModelDB model1 = new ModelDB();
            var k = model1.NhanViens.FirstOrDefault(p => p.TaiKhoan.Trim() == labelName.Text.Trim());
            if (k != null)
            {
                if (k.HinhAnhNhanVien != null)
                {
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "AnhNV", k.HinhAnhNhanVien);
                    Image avatarImage = Image.FromFile(imagePath);
                    picAvatar.Image = avatarImage;
                }
            }
            else
            {
                MessageBox.Show("");
            }
        }



        private void brnReload_Click(object sender, EventArgs e)
        {
            FormTaikhoan_Load(sender, e);
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
