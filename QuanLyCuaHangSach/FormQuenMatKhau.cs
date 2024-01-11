using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangSach.Model1;

namespace QuanLyCuaHangSach.Resources
{
    public partial class FormQuenMatKhau : Form
    {
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }
        string temporaryAccount = "";

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelQMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormLogin f = new FormLogin();
            f.ShowDialog();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (!string.IsNullOrWhiteSpace(email) && IsValidEmail(email))
            {
                ModelDB model = new ModelDB();
                var existingAccount = model.TaiKhoans.FirstOrDefault(p => p.Email.Trim() == email);
                temporaryAccount = existingAccount.TaiKhoan1;
                if (existingAccount != null)
                {
                    string temporaryPassword = GenerateTemporaryPassword();

                    existingAccount.MatKhau = temporaryPassword;

                    model.SaveChanges();

                    SendEmail(email, temporaryPassword, temporaryAccount);
                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản với địa chỉ email đã nhập.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một địa chỉ email hợp lệ.");
            }
        }

        private void SendEmail(string toEmail, string temporaryPassword, string temporaryAccount)
        {
            string fromEmail = "khanhchii741@gmail.com"; // Thay thế bằng địa chỉ email Gmail của bạn
            string fromEmailPassword = "hvda lwnj caiq yemu"; // Thay thế bằng mật khẩu email Gmail của bạn

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromEmailPassword),
                EnableSsl = true,
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = "Khôi phục mật khẩu",
                Body = "Mật khẩu tạm thời của tài khoản " + temporaryAccount + " là: " + temporaryPassword,
                IsBodyHtml = true,
            };

            mail.To.Add(toEmail);

            try
            {
                smtpClient.Send(mail);
                MessageBox.Show("Một email chứa mật khẩu tạm thời đã được gửi đến địa chỉ email của bạn.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi gửi email: " + ex.Message);
            }
        }

        private string GenerateTemporaryPassword()
        {
            Random random = new Random();
            const string chars = "123456";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
