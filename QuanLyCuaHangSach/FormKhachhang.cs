using OfficeOpenXml;
using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
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

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("ChiTietHoaDon");

                // Header
                for (int i = 1; i <= dgvKhachHang.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dgvKhachHang.Columns[i - 1].HeaderText;
                }

                // Data
                for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKhachHang.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgvKhachHang.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Lưu file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(excelFile);
                    MessageBox.Show("File đã được xuất thành công!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                // Display a confirmation dialog
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này và các phụ thuộc?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int maKhachHang = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells[0].Value);

                    KhachHang customerToDelete = context.KhachHangs
                        .Include("TheDocGias.HoaDons.ChiTietHoaDons")
                        .FirstOrDefault(c => c.MaKhachHang == maKhachHang);

                    if (customerToDelete != null)
                    {
                        // Detach related entities
                        foreach (var theDocGia in customerToDelete.TheDocGias.ToList())
                        {
                            context.Entry(theDocGia).State = EntityState.Detached;

                            foreach (var hoaDon in theDocGia.HoaDons.ToList())
                            {
                                context.Entry(hoaDon).State = EntityState.Detached;

                                foreach (var chiTietHoaDon in hoaDon.ChiTietHoaDons.ToList())
                                {
                                    context.Entry(chiTietHoaDon).State = EntityState.Detached;
                                }
                            }
                        }

                        // Remove related entities
                        context.ChiTietHoaDons.RemoveRange(customerToDelete.TheDocGias.SelectMany(td => td.HoaDons.SelectMany(hd => hd.ChiTietHoaDons)));
                        context.HoaDons.RemoveRange(customerToDelete.TheDocGias.SelectMany(td => td.HoaDons));
                        context.TheDocGias.RemoveRange(customerToDelete.TheDocGias);

                        // Remove the KhachHang
                        context.KhachHangs.Remove(customerToDelete);

                        context.SaveChanges();

                        MessageBox.Show("Xóa khách hàng và các phụ thuộc thành công!");

                        // Refresh DataGridView
                        resetdata();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
            }
        }
        private KhachHang selectedCustomer;

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                int maKhachHang = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells[0].Value);

                // Retrieve the selected customer
                selectedCustomer = context.KhachHangs
                    .Include("TheDocGias.HoaDons.ChiTietHoaDons")
                    .FirstOrDefault(c => c.MaKhachHang == maKhachHang);

                if (selectedCustomer != null)
                {
                    // Create an instance of the edit form
                    SuaNhanVien suaNhanVienForm = new SuaNhanVien(selectedCustomer, this, context);

                    // Show the edit form
                    suaNhanVienForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa.");
            }
        }
    }
}
