using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormSach : Form
    {
        public FormSach()
        {
            InitializeComponent();
        }
        ModelDB context = new ModelDB();
        private void FormSach_Load(object sender, EventArgs e)
        {
            List<Sach> listSach = context.Saches.ToList();
            FillCmbTacgia();
            FillCmbNxb();
            FillCmbTheloai();
            BindGrid(listSach);
            ShowAvatar("");
        }

        public void ReloadData()
        {
            object sender = null;
            EventArgs e = null;
            FormSach_Load(sender, e);
        }

        private string pathImage = "";

        private void ShowAvatar(string ImageName)
        {
            try
            {
                if (string.IsNullOrEmpty(ImageName))
                {
                    picSach.Image = null;
                }
                else
                {
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "Images", ImageName);
                    picSach.Image = Image.FromFile(imagePath);
                    picSach.SizeMode = PictureBoxSizeMode.CenterImage;
                    picSach.Refresh();
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
            string imagePath = Path.Combine(folder, "Images");
            var img = imagePath + @"\" + path;
            picSach.Image.Save(img, ImageFormat.Jpeg);
        }

        private void resetform()
        {
            txtGia.Text = "";
            txtMaSach.Text = "";
            txtNDTT.Text = "";
            txtTimkiem.Text = "";
            txtTenSach.Text = "";
            pathImage = "";
            cmbTacGia.SelectedIndex = 0;
            cmbNXB.SelectedIndex = 0;
            cmbTheLoai.SelectedIndex = 0;
            picSach.Image = null;
        }

        private void resetForm()
        {

            resetform();

        }

        // FILL CMB
        private void FillCmbTacgia()
        {
            cmbTacGia.Items.Clear();
            cmbTacGia.Items.Add("");
            ModelDB model1 = new ModelDB();
            foreach (var item in model1.TacGias.ToList())
            {
                cmbTacGia.Items.Add(item.TenTacGia.Trim());
            }
        }

        private void FillCmbNxb()
        {
            cmbNXB.Items.Clear();
            cmbNXB.Items.Add("");
            ModelDB model1 = new ModelDB();
            foreach (var item in model1.NhaXuatBans.ToList())
            {
                cmbNXB.Items.Add(item.TenNhaXuatBan.Trim());
            }
        }

        private void FillCmbTheloai()
        {
            cmbTheLoai.Items.Clear();
            cmbTheLoai.Items.Add("");
            ModelDB model1 = new ModelDB();
            foreach (var item in model1.TheLoaiSaches.ToList())
            {
                cmbTheLoai.Items.Add(item.TenTheLoai.Trim());
            }
        }

        private void BindGrid(List<Sach> listSach)
        {
            dgvSach.Rows.Clear();
            foreach (var item in listSach)
            {
                int index = dgvSach.Rows.Add();
                dgvSach.Rows[index].Cells[0].Value = item.MaSach;
                dgvSach.Rows[index].Cells[1].Value = item.TenSach.Trim();
                dgvSach.Rows[index].Cells[2].Value = item.GiaBan;
                dgvSach.Rows[index].Cells[3].Value = item.TacGia.TenTacGia.Trim();
                dgvSach.Rows[index].Cells[4].Value = item.NhaXuatBan.TenNhaXuatBan.Trim();
                dgvSach.Rows[index].Cells[5].Value = item.TheLoaiSach.TenTheLoai.Trim();
                if (item.NDTomTat != null)
                {
                    dgvSach.Rows[index].Cells[6].Value = item.NDTomTat.Trim();

                }
                else
                {
                    dgvSach.Rows[index].Cells[6].Value = null;

                }
                if (item.HinhAnh != null)
                {

                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "Images", item.HinhAnh);
                    Image avatarImage = Image.FromFile(imagePath);
                    dgvSach.Rows[index].Cells[7].Value = avatarImage;
                }


            }
        }

        private bool CheckData()
        {
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || txtGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (txtMaSach.Text.Length != 10)
            {
                MessageBox.Show("Vui long nhập lại Mã sách với 10 ký tự ", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (cmbTacGia.SelectedIndex <= 0 || cmbNXB.SelectedIndex <= 0 || cmbTheLoai.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin tác giả, nhà xuất bản và thể loại sách!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void OpenformTacGia()
        {
            FormTacGia tacgia = new FormTacGia(this);
            tacgia.Show();
        }

        private void OpenformNXB()
        {
            FormNhaSanXuat NXB = new FormNhaSanXuat(this);
            NXB.Show();
        }

        private void OpenformLoaiSach()
        {
            FormLoaiSach loaisach = new FormLoaiSach(this);
            loaisach.Show();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            OpenformTacGia();
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            OpenformNXB();
        }

        private void btnLoaiSach_Click(object sender, EventArgs e)
        {
            OpenformLoaiSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Sach sachAdd = context.Saches.FirstOrDefault(s => s.MaSach.Trim() == txtMaSach.Text);
                if (sachAdd == null)
                {
                    Sach sach = new Sach();
                    sach.MaSach = txtMaSach.Text;
                    sach.TenSach = txtTenSach.Text;
                    sach.GiaBan = decimal.Parse(txtGia.Text);
                    var find = context.TacGias.FirstOrDefault(t => t.TenTacGia.Trim() == cmbTacGia.Text.Trim());
                    sach.MaTacGia = find.MaTacGia;
                    var find1 = context.NhaXuatBans.FirstOrDefault(t => t.TenNhaXuatBan.Trim() == cmbNXB.Text.Trim());
                    sach.MaNhaXuatBan = find1.MaNhaXuatBan;
                    var find2 = context.TheLoaiSaches.FirstOrDefault(t => t.TenTheLoai.Trim() == cmbTheLoai.Text.Trim());
                    sach.MaTheLoaiSach = find2.MaTheLoaiSach;
                    if (txtNDTT.Text != "")
                    {
                        sach.NDTomTat = txtNDTT.Text;

                    }
                    if (pathImage != "")
                    {
                        sach.HinhAnh = pathImage;
                        SaveImage(pathImage);
                    }

                    context.Saches.Add(sach);
                    context.SaveChanges();
                    List<Sach> listSach = context.Saches.ToList();
                    BindGrid(listSach);
                    resetForm();
                    MessageBox.Show("Thêm sách thành công !", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Sách đã tồn tại !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Sach sachUpt = context.Saches.FirstOrDefault(s => s.MaSach.Trim() == txtMaSach.Text);
                if (sachUpt != null)
                {
                    sachUpt.TenSach = txtTenSach.Text;
                    sachUpt.GiaBan = decimal.Parse(txtGia.Text);
                    var find = context.TacGias.FirstOrDefault(t => t.TenTacGia.Trim() == cmbTacGia.Text.Trim());
                    sachUpt.MaTacGia = find.MaTacGia;
                    var find1 = context.NhaXuatBans.FirstOrDefault(t => t.TenNhaXuatBan.Trim() == cmbNXB.Text.Trim());
                    sachUpt.MaNhaXuatBan = find1.MaNhaXuatBan;
                    var find2 = context.TheLoaiSaches.FirstOrDefault(t => t.TenTheLoai.Trim() == cmbTheLoai.Text.Trim());
                    sachUpt.MaTheLoaiSach = find2.MaTheLoaiSach;
                    if (txtNDTT.Text != "")
                    {
                        sachUpt.NDTomTat = txtNDTT.Text;

                    }
                    if (sachUpt.HinhAnh != null)
                    {

                    }
                    if (pathImage != "")
                    {
                        sachUpt.HinhAnh = pathImage;
                        SaveImage(pathImage);

                    }
                    context.SaveChanges();
                    List<Sach> listSach = context.Saches.ToList();
                    resetform();
                    BindGrid(listSach);

                    MessageBox.Show("Cập nhật sách thành công !", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Sách không tìm thấy !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Sach sachRmv = context.Saches.FirstOrDefault(s => s.MaSach.Trim() == txtMaSach.Text);
                if (sachRmv != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa sách này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                foreach (var x in context.SachTrongKhoes)
                                {
                                    if (x.MaSach.Trim() == sachRmv.MaSach.Trim())
                                    {
                                        if (x.SoLuongTon > 0)
                                        {
                                            transaction.Rollback();
                                            MessageBox.Show("Xoa that bai vi trong kho " + x.MaKhoSach + " van con sach co ma " + x.MaSach);
                                            return;
                                        }
                                        else
                                        {
                                            context.SachTrongKhoes.Remove(x);
                                            context.SaveChanges();

                                        }
                                    }
                                }
                                foreach (var x in context.ChiTietNhapSaches.ToList())
                                {
                                    if (x.MaSach.Trim() == sachRmv.MaSach.Trim())
                                    {
                                        context.ChiTietNhapSaches.Remove(x);
                                        context.SaveChanges();
                                    }
                                }
                                foreach (var x in context.ChiTietHoaDons.ToList())
                                {
                                    if (x.MaSach.Trim() == sachRmv.MaSach.Trim())
                                    {
                                        context.ChiTietHoaDons.Remove(x);
                                        context.SaveChanges();
                                    }
                                }

                                context.SaveChanges();
                                transaction.Commit();
                                MessageBox.Show("Xoa thanh cong Sach co ma: " + sachRmv.MaSach);
                            }
                            catch
                            {

                                transaction.Rollback();
                                MessageBox.Show("Xoa that bai");

                            }
                            context.Saches.Remove(sachRmv);
                            context.SaveChanges();
                            List<Sach> listSach = context.Saches.ToList();
                            BindGrid(listSach);
                            resetForm();
                            MessageBox.Show("Xóa sách thành công !", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sách không tìm thấy !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTimkiem.Text.Trim();

            // Lọc danh sách sách dựa trên mã sách hoặc tên sách
            List<Sach> searchResults = context.Saches.Where(s =>
                s.MaSach.Contains(searchTerm) || s.TenSach.Contains(searchTerm)
            ).ToList();

            // Cập nhật DataGridView với kết quả tìm kiếm
            BindGrid(searchResults);
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtTimkiem_TextChanged(sender, e);
        }
        private void ResetTextboxes()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtGia.Text = "";
            cmbTacGia.SelectedIndex = 0;
            cmbNXB.SelectedIndex = 0;
            cmbTheLoai.SelectedIndex = 0;
            txtNDTT.Text = "";
            picSach.Image = null;
        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            ResetTextboxes();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ReloadData();
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
                    picSach.Image = Image.FromFile(imageLocation);
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

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtMaSach.Text = dgvSach.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtTenSach.Text = dgvSach.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtGia.Text = dgvSach.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                cmbTacGia.Text = dgvSach.Rows[e.RowIndex].Cells[3].FormattedValue.ToString().Trim();
                cmbNXB.Text = dgvSach.Rows[e.RowIndex].Cells[4].FormattedValue.ToString().Trim();
                cmbTheLoai.Text = dgvSach.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();

                if (dgvSach.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    txtNDTT.Text = dgvSach.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();

                }
                else
                {
                    txtNDTT.Text = null;
                }
                if (dgvSach.Rows[e.RowIndex].Cells[7].Value != null)
                {
                    picSach.Image = (Image)dgvSach.Rows[e.RowIndex].Cells[7].Value;
                }
                else
                {
                    // Nếu không có hình ảnh, đặt hình ảnh của PictureBox thành null
                    picSach.Image = null;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.')
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
