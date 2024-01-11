using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormNhanvien : Form
    {
        public FormNhanvien()
        {
            InitializeComponent();
        }
        ModelDB context = new ModelDB();
        
        public void resetform()
        {
            object sender = null;
            EventArgs e = null;
            txtDiachi.Text = "";
            txtMaNV.Text = "";
            txtSDT.Text = "";
            txtTimKiem.Text = "";
            txtTenNV.Text = "";
            txtTaikhoan.Text = "";
            pathImage = "";
            picAnhNV.Image = null;
            FormNhanvien_Load(sender, e);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            resetform();
        }

        private void FillComboboxLoaiNV()
        {
            cmbLoaiNV.Items.Clear();
            cmbLoaiNV.Items.Add("");
            ModelDB model1 = new ModelDB();
            foreach (var item in model1.LoaiNhanViens.ToList())
            {
                cmbLoaiNV.Items.Add(item.MaLoaiNhanVien.Trim());
            }
        }
        private string pathImage = "";
        private void ShowAvatar(string ImageName)
        {
            try
            {
                if (string.IsNullOrEmpty(ImageName))
                {
                    picAnhNV.Image = null;
                }
                else
                {
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "AnhNV", ImageName);
                    picAnhNV.Image = Image.FromFile(imagePath);
                    picAnhNV.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void SaveImage(string path)
        {
            var folder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(folder, "AnhNV");
            var img = imagePath + @"\" + path;
            picAnhNV.Image.Save(img, ImageFormat.Jpeg);
        }

        private bool CheckData()
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtSDT.Text == "" || txtDiachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Nhân viên!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchCriteria = txtTimKiem.Text.Trim();

            List<NhanVien> listNV = context.NhanViens.ToList();

            List<NhanVien> filteredList = listNV
                .Where(nhanvien =>
                    nhanvien.MaNhanVien.ToString().Contains(searchCriteria) ||
                    nhanvien.TenNhanVien.ToLower().Contains(searchCriteria.ToLower())
                )
                .ToList();

            BindGrid(filteredList);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem_TextChanged(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (ktrhl())
                {
                    int MaNV = int.Parse(txtMaNV.Text);
                    NhanVien nhanVienAdd = context.NhanViens.FirstOrDefault(s => s.MaNhanVien == MaNV);

                    if (nhanVienAdd != null)
                    {
                        MessageBox.Show("Nhân viên đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }

                    NhanVien nhanvien = new NhanVien();
                    nhanvien.MaNhanVien = int.Parse(txtMaNV.Text);
                    nhanvien.TaiKhoan = txtTaikhoan.Text;
                    var find = context.LoaiNhanViens.FirstOrDefault(t => t.TenLoaiNhanVien.Trim() == cmbLoaiNV.Text.Trim());
                    nhanvien.LoaiNhanVien = cmbLoaiNV.Text;
                    nhanvien.TenNhanVien = txtTenNV.Text.Trim();
                    nhanvien.SDTNhanVien = txtSDT.Text.Trim();
                    nhanvien.DiaChiNhanVien = txtDiachi.Text.Trim();

                    if (pathImage != "")
                    {
                        nhanvien.HinhAnhNhanVien = pathImage;
                        SaveImage(pathImage);
                    }
                    nhanvien.TaiKhoan = "0";
                    FormCapTaiKhoan formCTP = new FormCapTaiKhoan(this, nhanvien);
                    formCTP.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Số điện thoại phải có 10 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (ktrhl())
                {
                    int MaNV = int.Parse(txtMaNV.Text);
                    NhanVien nhanvienUpt = context.NhanViens.FirstOrDefault(s => s.MaNhanVien == MaNV);
                    if (nhanvienUpt != null)
                    {
                        nhanvienUpt.TaiKhoan = txtTaikhoan.Text;
                        var find = context.LoaiNhanViens.FirstOrDefault(t => t.TenLoaiNhanVien.Trim() == cmbLoaiNV.Text.Trim());
                        nhanvienUpt.LoaiNhanVien = cmbLoaiNV.Text.Trim();
                        nhanvienUpt.TenNhanVien = txtTenNV.Text.Trim();
                        nhanvienUpt.SDTNhanVien = txtSDT.Text.Trim();
                        nhanvienUpt.DiaChiNhanVien = txtDiachi.Text.Trim();

                        if (pathImage != "")
                        {
                            nhanvienUpt.HinhAnhNhanVien = pathImage;
                            SaveImage(pathImage);
                        }

                        context.SaveChanges();
                        List<NhanVien> listNV = context.NhanViens.ToList();
                        BindGrid(listNV);
                        MessageBox.Show("Cập nhật nhân viên thành công !", "Thông báo", MessageBoxButtons.OK);
                        resetform();

                    }
                    else
                    {
                        MessageBox.Show("nhân viên không tìm thấy!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {

                }
            }
        }



        private void XoaNhanVien(int maNV)
        {
            NhanVien nhanvienToRemove = context.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNV);

            if (nhanvienToRemove != null)
            {
                try
                {
                    // Xóa nhân viên từ context và lưu thay đổi vào cơ sở dữ liệu
                    context.NhanViens.Remove(nhanvienToRemove);
                    context.SaveChanges();

                    // Hiển thị lại danh sách nhân viên sau khi xóa
                    List<NhanVien> listNV = context.NhanViens.ToList();
                    BindGrid(listNV);

                    MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xóa nhân viên không thành công. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn nhân viên cần xóa chưa
            if (!string.IsNullOrEmpty(txtMaNV.Text))
            {
                int maNV = int.Parse(txtMaNV.Text);

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    XoaNhanVien(maNV);
                    resetform(); // Sau khi xóa, reset form để chuẩn bị cho thêm/sửa mới
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnquanlycapquyentk_Click(object sender, EventArgs e)
        {
            FormQLTK formTK = new FormQLTK(this);
            formTK.ShowDialog();
        }
        private void BindGrid(List<NhanVien> listNV)
        {
            dgvNhanvien.Rows.Clear();
            foreach (var item in listNV)
            {
                int index = dgvNhanvien.Rows.Add();
                dgvNhanvien.Rows[index].Cells[0].Value = item.MaNhanVien;
                dgvNhanvien.Rows[index].Cells[1].Value = item.TaiKhoan;
                dgvNhanvien.Rows[index].Cells[2].Value = item.LoaiNhanVien;
                dgvNhanvien.Rows[index].Cells[3].Value = item.TenNhanVien;
                dgvNhanvien.Rows[index].Cells[4].Value = item.SDTNhanVien;
                dgvNhanvien.Rows[index].Cells[5].Value = item.DiaChiNhanVien;
                if (item.HinhAnhNhanVien != null)
                {
                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "AnhNV", item.HinhAnhNhanVien);
                    Image avatarImage = Image.FromFile(imagePath);
                    dgvNhanvien.Rows[index].Cells[6].Value = avatarImage;
                }




            }
        }
        private void FormNhanvien_Load(object sender, EventArgs e)
        {
            List<NhanVien> listNV = context.NhanViens.ToList();
            BindGrid(listNV);
            FillComboboxLoaiNV();
        }

        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtMaNV.Text = dgvNhanvien.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtTaikhoan.Text = dgvNhanvien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                cmbLoaiNV.Text = dgvNhanvien.Rows[e.RowIndex].Cells[2].FormattedValue.ToString().Trim();
                txtTenNV.Text = dgvNhanvien.Rows[e.RowIndex].Cells[3].FormattedValue.ToString().Trim();
                txtSDT.Text = dgvNhanvien.Rows[e.RowIndex].Cells[4].FormattedValue.ToString().Trim();
                txtDiachi.Text = dgvNhanvien.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                string s = dgvNhanvien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString().Trim();
               
                if (dgvNhanvien.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    picAnhNV.Image = (Image)dgvNhanvien.Rows[e.RowIndex].Cells[6].Value;
                }
                else
                {
                    // Nếu không có hình ảnh, đặt hình ảnh của PictureBox thành null
                    picAnhNV.Image = null;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool ktrhl()
        {
            if (txtSDT.Text.Length == 10)
            {
                return true;
            }
            return false;
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog fileOpen = new OpenFileDialog();
                fileOpen.Title = "chon hinh Sach";
                fileOpen.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = fileOpen.FileName;
                    picAnhNV.Image = Image.FromFile(imageLocation);
                    pathImage = imageLocation.Substring(imageLocation.LastIndexOf("\\"));
                    pathImage = pathImage.Remove(0, 1);
                    var time = DateTime.Now.Ticks.ToString();
                    pathImage = time + "-" + pathImage;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtSDT.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Từ chối ký tự không phải số
            }
        }
    }
}
