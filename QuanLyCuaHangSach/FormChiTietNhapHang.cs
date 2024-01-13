using Guna.UI2.WinForms;
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
    public partial class FormChiTietNhapHang : Form
    {
        public FormChiTietNhapHang()
        {
            InitializeComponent();
            ModelDB model = new ModelDB();
            BindGrid(model.Saches.ToList());
            FillCmbMaS(model.Saches.ToList());
        }


        private FormNhapHang formnhaphang;
        private DateTime t;
        public FormChiTietNhapHang(FormNhapHang nhaphangform, string makho, string manv, DateTime time)
        {
            InitializeComponent();
            formnhaphang = nhaphangform;
            txtMaKS.Text = makho;
            txtMaNV.Text = manv;
            DtpNgayPN.Value = time;
            ModelDB model = new ModelDB();
            BindGrid(model.Saches.ToList());
            FillCmbMaS(model.Saches.ToList());


        }
    
        private void FillCmbMaS(List<Sach> listsach)
        {
            this.cmbS.DataSource = listsach;
            this.cmbS.DisplayMember = "MaSach";
            this.cmbS.ValueMember = "MaSach";
        }
        private void BindGrid(List<Sach> listSach)
        {
            dgvBook.Rows.Clear();
            foreach (var item in listSach)
            {
                int index = dgvBook.Rows.Add();
                dgvBook.Rows[index].Cells[0].Value = item.MaSach;
                dgvBook.Rows[index].Cells[1].Value = item.TenSach.Trim();
                dgvBook.Rows[index].Cells[2].Value = item.GiaBan;
                dgvBook.Rows[index].Cells[3].Value = item.TacGia.TenTacGia.Trim();
                dgvBook.Rows[index].Cells[4].Value = item.NhaXuatBan.TenNhaXuatBan.Trim();
                dgvBook.Rows[index].Cells[5].Value = item.TheLoaiSach.TenTheLoai.Trim();
                if (item.NDTomTat != null)
                {
                    dgvBook.Rows[index].Cells[6].Value = item.NDTomTat.Trim();

                }
                else
                {
                    dgvBook.Rows[index].Cells[6].Value = null;

                }
                if (item.HinhAnh != null)
                {
                    // Đường dẫn đến thư mục ảnh
                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "Images", item.HinhAnh);
                    Image avatarImage = Image.FromFile(imagePath);
                    dgvBook.Rows[index].Cells[7].Value = avatarImage;
                }


            }
        }
        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void FormChiTietNhapHang_Load(object sender, EventArgs e)
        {
            if (dgvChiTiet.Rows.Count <= 0)
            {
                btnNoSave.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                btnNoSave.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FormChiTietNhapHang_Load(sender,e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int ktr = 0;
            for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
            {
                if (dgvChiTiet.Rows[i].Cells[0].Value.ToString().Trim() == cmbS.Text.Trim() && dgvChiTiet.Rows[i].Cells[1].Value.ToString() == DtpNgayPN.Value.ToString())
                {
                    dgvChiTiet.Rows[i].Cells[2].Value = (long.Parse(dgvChiTiet.Rows[i].Cells[2].Value.ToString()) + long.Parse(txtsl.Text.Trim())).ToString();
                    dgvChiTiet.Rows[i].Cells[3].Value = (long.Parse(dgvChiTiet.Rows[i].Cells[3].Value.ToString()) + long.Parse(txtgia.Text.Trim())).ToString();
                    ktr = 1;
                }
            }
            if (ktr == 0)
            {
                int r = dgvChiTiet.Rows.Add();
                dgvChiTiet.Rows[r].Cells[0].Value = cmbS.Text.Trim();
                dgvChiTiet.Rows[r].Cells[1].Value = DtpNgayPN.Value.ToString();
                dgvChiTiet.Rows[r].Cells[2].Value = txtsl.Text.Trim();
                dgvChiTiet.Rows[r].Cells[3].Value = txtgia.Text.Trim();
            }
            FormChiTietNhapHang_Load(sender, e);

            MessageBox.Show("Them thanh cong");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
            {
                if (dgvChiTiet.Rows[i].Cells[0].Value.ToString().Trim() == cmbS.Text.Trim() && dgvChiTiet.Rows[i].Cells[1].Value.ToString() == DtpNgayPN.Value.ToString())
                {

                    dgvChiTiet.Rows[i].Cells[0].Value = cmbS.Text.Trim();
                    dgvChiTiet.Rows[i].Cells[1].Value = DtpNgayPN.Value.ToString();
                    dgvChiTiet.Rows[i].Cells[2].Value = txtsl.Text.Trim();
                    dgvChiTiet.Rows[i].Cells[3].Value = txtgia.Text.Trim();
                    MessageBox.Show("Sua Thanh Cong");
                    FormChiTietNhapHang_Load(sender, e);
                    return;

                }
            }
            MessageBox.Show("Khong ton tai chi tiet nhap hang de sua");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
            {
                if (dgvChiTiet.Rows[i].Cells[0].Value.ToString().Trim() == cmbS.Text.Trim() && dgvChiTiet.Rows[i].Cells[1].Value.ToString() == DtpNgayPN.Value.ToString())

                {
                    dgvChiTiet.Rows.RemoveAt(i);
                    MessageBox.Show("Xoa thanh cong");
                    FormChiTietNhapHang_Load(sender, e);

                    return;

                }
            }
            MessageBox.Show("Xoa that bai");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var context = new ModelDB();
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    decimal tong = 0;
                    PhieuNhap phieuNhap = new PhieuNhap();
                    phieuNhap.MaKhoSach = txtMaKS.Text;
                    phieuNhap.MaNhanVien = int.Parse(txtMaNV.Text);
                    phieuNhap.NgayLapPhieu = t;
                    context.PhieuNhaps.Add(phieuNhap);
                    context.SaveChanges();
                    for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                    {
                        ChiTietNhapSach chiTietNhapSach = new ChiTietNhapSach();
                        chiTietNhapSach.MaSach = dgvChiTiet.Rows[i].Cells[0].Value.ToString();
                        chiTietNhapSach.MaPhieuNhap = phieuNhap.MaPhieuNhap;
                        chiTietNhapSach.NgayNhap = DateTime.Parse(dgvChiTiet.Rows[i].Cells[1].FormattedValue.ToString());
                        chiTietNhapSach.SoLuongNhap = int.Parse(dgvChiTiet.Rows[i].Cells[2].Value.ToString());
                        chiTietNhapSach.GiaNhap = decimal.Parse(dgvChiTiet.Rows[i].Cells[3].Value.ToString());
                        tong += chiTietNhapSach.SoLuongNhap * chiTietNhapSach.GiaNhap;
                        context.ChiTietNhapSaches.Add(chiTietNhapSach);
                        var find = context.SachTrongKhoes.FirstOrDefault(p => p.MaKhoSach.Trim() == txtMaKS.Text.Trim() && p.MaSach.Trim() == chiTietNhapSach.MaSach.Trim());
                        if (find != null)
                        {
                            find.SoLuongTon += int.Parse(dgvChiTiet.Rows[i].Cells[2].Value.ToString());
                            context.SaveChanges();
                        }
                        else
                        {
                            SachTrongKho sachTrongKho = new SachTrongKho();
                            sachTrongKho.MaKhoSach = txtMaKS.Text.Trim();
                            sachTrongKho.MaSach = dgvChiTiet.Rows[i].Cells[0].Value.ToString();
                            sachTrongKho.SoLuongTon = int.Parse(dgvChiTiet.Rows[i].Cells[2].Value.ToString());
                            context.SachTrongKhoes.Add(sachTrongKho);
                            context.SaveChanges();
                        }
                    }
                    phieuNhap.TongTien = tong;
                    context.SaveChanges();
                    transaction.Commit();
                    MessageBox.Show("Luu thanh cong");
                    btnThoat_Click(sender, e);
                }
                catch
                {

                    transaction.Rollback();
                    MessageBox.Show("Luu that bai");

                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dgvChiTiet.Rows.Clear();
            txtgia.Text = "";
            txtsl.Text = "";
            txtthanhtien.Text = "";
            DtpNgayPN.Value = DateTime.Now;
            FormChiTietNhapHang_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            formnhaphang.ReloadData();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cmbS.Text = dgvBook.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cmbS.Text = dgvChiTiet.Rows[e.RowIndex].Cells[0].Value.ToString();
                DtpNgayPN.Value = DateTime.Parse(dgvChiTiet.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                txtsl.Text = dgvChiTiet.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtgia.Text = dgvChiTiet.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtthanhtien.Text = (long.Parse(txtsl.Text) * long.Parse(txtgia.Text)).ToString();
            }
            catch { }
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            if (txtsl.Text != "" && txtgia.Text != "")
            {
                txtthanhtien.Text = (long.Parse(txtsl.Text) * long.Parse(txtgia.Text)).ToString();
            }
            else
            {
                txtthanhtien.Text = "";
            }
        }

        private void txtgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgia_TextChanged(object sender, EventArgs e)
        {
            if (txtsl.Text != "" && txtgia.Text != "")
            {
                txtthanhtien.Text = (long.Parse(txtsl.Text) * long.Parse(txtgia.Text)).ToString();
            }
            else
            {
                txtthanhtien.Text = "";
            }
        }
    }
}
