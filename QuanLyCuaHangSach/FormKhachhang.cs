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
    public partial class FormKhachhang : Form
    {
        public FormKhachhang()
        {
            InitializeComponent();
        }
        ModelDB context = new ModelDB();
        public void resetdata()
        {
            object sender = null;
            EventArgs e = null;
            FormKhachhang_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem_TextChanged(sender, e);
        }

        private void FormKhachhang_Load(object sender, EventArgs e)
        {
            List<KhachHang> listKH = context.KhachHangs.ToList();
            BindGrid(listKH);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            resetdata();
        }

        private void BindGrid(List<KhachHang> listKH)
        {
            dgvKhachHang.Rows.Clear();
            foreach (var item in listKH)
            {
                int index = dgvKhachHang.Rows.Add();
                dgvKhachHang.Rows[index].Cells[0].Value = item.MaKhachHang;
                dgvKhachHang.Rows[index].Cells[1].Value = item.HoTenKhachHang.Trim();
                dgvKhachHang.Rows[index].Cells[2].Value = item.SDT_KhachHang.Trim();
                dgvKhachHang.Rows[index].Cells[3].Value = item.DiaChiKhachHang.Trim();
                dgvKhachHang.Rows[index].Cells[4].Value = item.GioiTinh;
                dgvKhachHang.Rows[index].Cells[5].Value = item.NgaySinh;
                dgvKhachHang.Rows[index].Cells[6].Value = item.LoaiKhachHang;
                dgvKhachHang.Rows[index].Cells[7].Value = item.Email.Trim();
                var find = context.TheDocGias.FirstOrDefault(e => e.MaKhachHang == item.MaKhachHang);
                dgvKhachHang.Rows[index].Cells[8].Value = find.SoDiemTichLuy;



            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchCriteria = txtTimKiem.Text.Trim();


            List<KhachHang> listKH = context.KhachHangs.ToList();


            List<KhachHang> filteredList = listKH
                .Where(customer =>
                    customer.HoTenKhachHang.Trim().ToLower().Contains(searchCriteria.ToLower())
                    || customer.MaKhachHang.ToString().ToLower().Contains(searchCriteria.ToLower())
                )
                .ToList();

            BindGrid(filteredList);
        }

        private void btnquanlycapquyentk_Click(object sender, EventArgs e)
        {
            FormTheDocGia formTheDG = new FormTheDocGia(this);
            formTheDG.ShowDialog();
        }
    }
}
