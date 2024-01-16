using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class SuaNhanVien : Form
    {
        public SuaNhanVien()
        {
            InitializeComponent();
        }
        private KhachHang selectedCustomer;
        private FormKhachhang mainForm;

        ModelDB context = new ModelDB();
        public SuaNhanVien(KhachHang customer, FormKhachhang formKhachHang, ModelDB dbContext)
        {
            InitializeComponent();
            selectedCustomer = customer;
            mainForm = formKhachHang;
            context = dbContext;
            txtEmail.Text = selectedCustomer.Email;
            txtdiachi.Text = selectedCustomer.DiaChiKhachHang;
            txtsdt.Text = selectedCustomer.SDT_KhachHang;
            txttenkh.Text = selectedCustomer.HoTenKhachHang;
            datetimeNS.Value = selectedCustomer.NgaySinh ?? DateTime.Now;
            if (selectedCustomer.GioiTinh == 1)
            {
                checknam.Checked = true;
                checknu.Checked = false;
            }
            else
            {
                checknam.Checked = false;
                checknu.Checked = true;
            }
        }
        private void SuaNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Cập nhật thông tin khách hàng từ giao diện người dùng
                selectedCustomer.Email = txtEmail.Text;
                selectedCustomer.DiaChiKhachHang = txtdiachi.Text;
                selectedCustomer.SDT_KhachHang = txtsdt.Text;
                selectedCustomer.HoTenKhachHang = txttenkh.Text;
                selectedCustomer.NgaySinh = datetimeNS.Value;
                selectedCustomer.GioiTinh = checknam.Checked ? 1 : 0;

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();

                MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                this.Close();
                mainForm.resetdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thay đổi: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
