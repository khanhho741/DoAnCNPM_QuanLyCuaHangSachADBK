using OfficeOpenXml;
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
    public partial class FormHoadon : Form
    {
        public FormHoadon()
        {
            InitializeComponent();
        }
        ModelDB context = new ModelDB();
        private void FormHoadon_Load(object sender, EventArgs e)
        {
            List<HoaDon> listHoadon = context.HoaDons.ToList();
            BindGrid(listHoadon);
        }

        List<int> selectedHoaDonIds = new List<int>();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (selectedHoaDonIds.Any())
            {
                ModelDB model1 = new ModelDB();
                List<ChiTietHoaDon> chiTietHoaDons = model1.ChiTietHoaDons
                    .Where(p => selectedHoaDonIds.Contains(p.MaHoaDon))
                    .ToList();

                FormChiTietHoaDon f = new FormChiTietHoaDon(chiTietHoaDons);
                f.ShowDialog();
            }
            else
            {

            }
        }
        private void BindGrid(List<HoaDon> listHoadon)
        {
            dgvHoadon.Rows.Clear();
            foreach (var item in listHoadon)
            {
                int index = dgvHoadon.Rows.Add();
                dgvHoadon.Rows[index].Cells[0].Value = item.MaHoaDon;
                dgvHoadon.Rows[index].Cells[1].Value = item.SoTienThanhToan;
                dgvHoadon.Rows[index].Cells[2].Value = item.SoLuongSachDaMua;
                dgvHoadon.Rows[index].Cells[3].Value = item.MaTheDocGia;
                dgvHoadon.Rows[index].Cells[4].Value = item.MaNhanVien;
                dgvHoadon.Rows[index].Cells[5].Value = item.NgayLapHoaDon;
            }
        }

        private void dgvHoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txthd.Text = dgvHoadon.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                int selectedHoaDonId = Convert.ToInt32(dgvHoadon.Rows[e.RowIndex].Cells[0].Value);

                if (selectedHoaDonIds.Contains(selectedHoaDonId))
                {
                    selectedHoaDonIds.Remove(selectedHoaDonId); // Nếu đã chọn, bỏ chọn
                }
                else
                {
                    selectedHoaDonIds.Add(selectedHoaDonId); // Nếu chưa chọn, thêm vào danh sách đã chọn
                }
            }
            catch { }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.ToLower();

            List<HoaDon> filteredList = context.HoaDons.Where(hd => hd.MaHoaDon.ToString().Contains(searchTerm)
                                                            || hd.SoTienThanhToan.ToString().Contains(searchTerm)
                                                            || hd.SoLuongSachDaMua.ToString().Contains(searchTerm)
                                                            || hd.MaTheDocGia.ToString().Contains(searchTerm)
                                                            || hd.MaNhanVien.ToString().Contains(searchTerm)
                                                            || hd.NgayLapHoaDon.ToString().Contains(searchTerm)
                                                        ).ToList();

            BindGrid(filteredList);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("ChiTietHoaDon");

                // Header
                for (int i = 1; i <= dgvHoadon.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dgvHoadon.Columns[i - 1].HeaderText;
                }

                // Data
                for (int i = 0; i < dgvHoadon.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvHoadon.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgvHoadon.Rows[i].Cells[j].Value?.ToString();
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
            if (selectedHoaDonIds.Any())
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach (var hoaDonId in selectedHoaDonIds)
                        {
                            var chiTietHoaDonToRemove = context.ChiTietHoaDons.Where(cthd => cthd.MaHoaDon == hoaDonId).ToList();
                            context.ChiTietHoaDons.RemoveRange(chiTietHoaDonToRemove);

                            var hoaDonToRemove = context.HoaDons.FirstOrDefault(hd => hd.MaHoaDon == hoaDonId);
                            if (hoaDonToRemove != null)
                            {
                                context.HoaDons.Remove(hoaDonToRemove);
                            }
                        }
                        context.SaveChanges();

                        List<HoaDon> updatedListHoaDon = context.HoaDons.ToList();
                        BindGrid(updatedListHoaDon);
                        selectedHoaDonIds.Clear();

                        MessageBox.Show("Đã xóa hóa đơn thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Xóa hóa đơn không thành công. Lỗi: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FormHoadon_Load(sender, e);
        }
    }
}
