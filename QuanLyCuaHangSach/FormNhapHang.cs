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
    public partial class FormNhapHang : Form
    {
        public FormNhapHang()
        {
            InitializeComponent();
        }

        ModelDB context = new ModelDB();

        private void FillCmbMaNV(List<NhanVien> listNhanvien)
        {
            this.cmbMaNV.DataSource = listNhanvien;
            this.cmbMaNV.DisplayMember = "MaNhanVien";
            this.cmbMaNV.ValueMember = "MaNhanVien";
        }

        private void FillCmbMaKS(List<KhoSach> listKhosach)
        {
            this.cmbMaKS.DataSource = listKhosach;
            this.cmbMaKS.DisplayMember = "MaKhoSach";
            this.cmbMaKS.ValueMember = "MaKhoSach";
        }

        public void ReloadData()
        {
            object sender = null;
            EventArgs e = null;
            FormNhapHang_Load(sender, e);
        }
        private void BindGrid(List<PhieuNhap> listPhieunhap)
        {
            dgvPhieuNhap.Rows.Clear();
            foreach (var item in listPhieunhap)
            {
                int index = dgvPhieuNhap.Rows.Add();
                dgvPhieuNhap.Rows[index].Cells[0].Value = item.MaPhieuNhap.ToString().Trim();
                dgvPhieuNhap.Rows[index].Cells[1].Value = item.NgayLapPhieu;
                dgvPhieuNhap.Rows[index].Cells[2].Value = item.MaNhanVien.ToString().Trim();
                dgvPhieuNhap.Rows[index].Cells[3].Value = item.MaKhoSach;
                dgvPhieuNhap.Rows[index].Cells[4].Value = item.TongTien.ToString().Trim();

            }
        }
        private void resetForm()
        {
            txtMaPN.Text = "";
            cmbMaNV.SelectedIndex = 0;
            DtpNgayPN.Value = DateTime.Now;
            cmbMaKS.SelectedIndex = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            FormChiTietNhapHang chiTietnhaphang = new FormChiTietNhapHang(this, cmbMaKS.Text, cmbMaNV.Text, DtpNgayPN.Value);
            chiTietnhaphang.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                int MaPN = int.Parse(txtMaPN.Text);
                PhieuNhap phieunhapUpt = context.PhieuNhaps.FirstOrDefault(s => s.MaPhieuNhap == MaPN);
                if (phieunhapUpt != null)
                {
                    phieunhapUpt.NgayLapPhieu = DtpNgayPN.Value;
                    phieunhapUpt.MaNhanVien = Convert.ToInt32(cmbMaNV.SelectedValue);
                    phieunhapUpt.MaKhoSach = cmbMaKS.SelectedValue.ToString();

                    context.SaveChanges();
                    List<PhieuNhap> listPhieunhap = context.PhieuNhaps.ToList();
                    BindGrid(listPhieunhap);
                    resetForm();
                    MessageBox.Show("Cập nhật phiếu nhập thành công !", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("phiếu nhập không tìm thấy!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                int MaPN = int.Parse(txtMaPN.Text);
                PhieuNhap phieunhapRmv = context.PhieuNhaps.FirstOrDefault(s => s.MaPhieuNhap == MaPN);

                if (phieunhapRmv != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa phiếu nhập này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Xóa các bản ghi liên quan trong bảng ChiTietNhapSach trước
                        var chiTietNhapRecords = context.ChiTietNhapSaches.Where(c => c.MaPhieuNhap == MaPN).ToList();
                        context.ChiTietNhapSaches.RemoveRange(chiTietNhapRecords);

                        // Sau đó xóa bản ghi PhieuNhap
                        context.PhieuNhaps.Remove(phieunhapRmv);
                        context.SaveChanges();

                        List<PhieuNhap> listPhieunhap = context.PhieuNhaps.ToList();
                        BindGrid(listPhieunhap);
                        resetForm();
                        MessageBox.Show("Xóa phiếu nhập thành công !", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("phiếu nhập không tìm thấy !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            List<PhieuNhap> listPhieunhap = context.PhieuNhaps.ToList();
            List<NhanVien> listNhanvien = context.NhanViens.ToList();
            List<KhoSach> listKhosach = context.KhoSaches.ToList();
            FillCmbMaNV(listNhanvien);
            FillCmbMaKS(listKhosach);
            BindGrid(listPhieunhap);
        }

        private bool CheckData()
        {
            if (txtMaPN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu nhập!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnChitietnhap_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text != "")
            {
                ModelDB model1 = new ModelDB();
                int t = int.Parse(txtMaPN.Text);
                List<ChiTietNhapSach> chiTietNhapSachs = model1.ChiTietNhapSaches.Where(p => p.MaPhieuNhap == t).ToList();
                FormChiTietNhap f = new FormChiTietNhap(chiTietNhapSachs);
                f.ShowDialog();
            }
            else
            {

            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPhieuNhap.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvPhieuNhap.CurrentRow.Selected = true;

                    txtMaPN.Text = dgvPhieuNhap.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    cmbMaKS.SelectedValue = dgvPhieuNhap.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    DtpNgayPN.Value = DateTime.Parse(dgvPhieuNhap.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    int maNV = 0;
                    if (int.TryParse(dgvPhieuNhap.Rows[e.RowIndex].Cells[2].FormattedValue.ToString(), out maNV))
                    {
                        cmbMaNV.SelectedValue = maNV;
                    }
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMaPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("ChitietNhapHang");

                // Header
                for (int i = 1; i <= dgvPhieuNhap.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dgvPhieuNhap.Columns[i - 1].HeaderText;
                }

                // Data
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPhieuNhap.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgvPhieuNhap.Rows[i].Cells[j].Value?.ToString();
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
    }
}
