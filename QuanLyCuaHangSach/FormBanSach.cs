using NUnit.Framework;
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
    public partial class FormBanSach : Form
    {
        public FormBanSach()
        {
            InitializeComponent();
            cbbluachontim.Items.Clear();
            cbbluachontim.Items.Add("");
            cbbluachontim.Items.Add("Tên Sách");
            cbbluachontim.Items.Add("Tên Tác Giả");
            cbbluachontim.Items.Add("Tên Nhà Xuất Bản");
            cbbluachontim.Items.Add("Tên Thể Loại");
            ModelDB model1 = new ModelDB();
            cbbkho.Items.Clear();
            foreach (var kho in model1.KhoSaches.ToList())
            {
                cbbkho.Items.Add(kho.MaKhoSach.Trim());
                cbbkho.SelectedIndex = 0;
            }
            cmbnv.Items.Clear();
            foreach (var nv in model1.NhanViens.ToList())
            {
                cmbnv.Items.Add(nv.TenNhanVien.Trim());
                cmbnv.SelectedIndex = 0;
            }
            cmbdg.Items.Clear();
            foreach (var dg in model1.TheDocGias.ToList())
            {
                cmbdg.Items.Add(dg.MaTheDocGia.Trim());
                cmbdg.SelectedIndex = 0;
            }
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            ktrsave();
        }

        public void resetdata()
        {
            cbbluachontim.Items.Clear();
            cbbluachontim.Items.Add("");
            cbbluachontim.Items.Add("Tên Sách");
            cbbluachontim.Items.Add("Tên Tác Giả");
            cbbluachontim.Items.Add("Tên Nhà Xuất Bản");
            cbbluachontim.Items.Add("Tên Thể Loại");
            ModelDB model1 = new ModelDB();
            cbbkho.Items.Clear();
            foreach (var kho in model1.KhoSaches.ToList())
            {
                cbbkho.Items.Add(kho.MaKhoSach.Trim());
                cbbkho.SelectedIndex = 0;
            }
            cmbnv.Items.Clear();
            foreach (var nv in model1.NhanViens.ToList())
            {
                cmbnv.Items.Add(nv.TenNhanVien.Trim());
                cmbnv.SelectedIndex = 0;
            }
            cmbdg.Items.Clear();
            foreach (var dg in model1.TheDocGias.ToList())
            {
                cmbdg.Items.Add(dg.MaTheDocGia.Trim());
                cmbdg.SelectedIndex = 0;
            }
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            ktrsave();
        }

        private void resetall()
        {
            cbbluachontim.Items.Clear();
            cbbluachontim.Items.Add("");
            cbbluachontim.Items.Add("Tên Sách");
            cbbluachontim.Items.Add("Tên Tác Giả");
            cbbluachontim.Items.Add("Tên Nhà Xuất Bản");
            cbbluachontim.Items.Add("Tên Thể Loại");
            ModelDB model1 = new ModelDB();
            cbbkho.Items.Clear();
            foreach (var kho in model1.KhoSaches.ToList())
            {
                cbbkho.Items.Add(kho.MaKhoSach.Trim());
                cbbkho.SelectedIndex = 0;
            }
            cmbnv.Items.Clear();
            foreach (var nv in model1.NhanViens.ToList())
            {
                cmbnv.Items.Add(nv.TenNhanVien.Trim());
                cmbnv.SelectedIndex = 0;
            }
            cmbdg.Items.Clear();
            foreach (var dg in model1.TheDocGias.ToList())
            {
                cmbdg.Items.Add(dg.MaTheDocGia.Trim());
                cmbdg.SelectedIndex = 0;
            }
            dgvBanSach.Rows.Clear();
            object sender = null;
            EventArgs e = null;
            FormBanSach_Load(sender, e);
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            ktrsave();
        }

        private void FormBanSach_Load(object sender, EventArgs e)
        {
            dgvSach.Rows.Clear();
        }

        private void cbbluachontim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbluachontim.SelectedIndex != -1)
            {
                if (cbbluachontim.Text == "")
                {
                    cbbchon.Items.Clear();
                    return;

                }
                if (cbbluachontim.Text == "Tên Sách")
                {
                    ModelDB model1 = new ModelDB();
                    cbbchon.Items.Clear();
                    cbbchon.Items.Add("");
                    foreach (var sach in model1.Saches.ToList())
                    {
                        cbbchon.Items.Add(sach.TenSach);
                    }
                    return;
                }
                if (cbbluachontim.Text == "Tên Tác Giả")
                {
                    ModelDB model1 = new ModelDB();
                    cbbchon.Items.Clear();
                    cbbchon.Items.Add("");
                    foreach (var tacgia in model1.TacGias.ToList())
                    {
                        cbbchon.Items.Add(tacgia.TenTacGia);
                    }
                    return;
                }
                if (cbbluachontim.Text == "Tên Nhà Xuất Bản")
                {
                    ModelDB model1 = new ModelDB();
                    cbbchon.Items.Clear();
                    cbbchon.Items.Add("");
                    foreach (var nahxuatban in model1.NhaXuatBans.ToList())
                    {
                        cbbchon.Items.Add(nahxuatban.TenNhaXuatBan);
                    }
                    return;
                }
                if (cbbluachontim.Text == "Tên Thể Loại")
                {
                    ModelDB model1 = new ModelDB();
                    cbbchon.Items.Clear();
                    cbbchon.Items.Add("");
                    foreach (var theloaisach in model1.TheLoaiSaches.ToList())
                    {
                        cbbchon.Items.Add(theloaisach.TenTheLoai);
                    }
                    return;
                }

            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cbbluachontim.Text == "")
            {
                FormBanSach_Load(sender, e);
                return;
            }
            if (cbbluachontim.Text == "Tên Sách")
            {
                if (cbbchon.Text == "")
                {
                    FormBanSach_Load(sender, e);
                    return;
                }
                else
                {
                    dgvSach.Rows.Clear();
                    ModelDB model1 = new ModelDB();
                    var find1 = model1.Saches.FirstOrDefault(p => p.TenSach.Trim() == cbbchon.Text.Trim());
                    foreach (var kho in model1.KhoSaches.ToList())
                    {
                        foreach (var f in model1.SachTrongKhoes.ToList())
                        {
                            if (f.MaKhoSach.Trim() == kho.MaKhoSach.Trim() && f.SoLuongTon > 0 && f.MaSach.Trim() == find1.MaSach.Trim())
                            {
                                var find = model1.Saches.FirstOrDefault(p => p.MaSach.Trim() == f.MaSach.Trim());
                                int r = dgvSach.Rows.Add();
                                dgvSach.Rows[r].Cells[0].Value = f.MaKhoSach;
                                dgvSach.Rows[r].Cells[1].Value = find.MaSach.Trim();
                                dgvSach.Rows[r].Cells[2].Value = find.TenSach.Trim();
                                dgvSach.Rows[r].Cells[3].Value = find.GiaBan.ToString();
                                var tim = model1.TacGias.FirstOrDefault(p => p.MaTacGia.Trim() == find.MaTacGia.Trim());
                                dgvSach.Rows[r].Cells[4].Value = tim.TenTacGia;
                                var timnxb = model1.NhaXuatBans.FirstOrDefault(p => p.MaNhaXuatBan.Trim() == find.MaNhaXuatBan.Trim());
                                dgvSach.Rows[r].Cells[5].Value = timnxb.TenNhaXuatBan;
                                var timntls = model1.TheLoaiSaches.FirstOrDefault(p => p.MaTheLoaiSach.Trim() == find.MaTheLoaiSach.Trim());
                                dgvSach.Rows[r].Cells[6].Value = timntls.TenTheLoai;
                                if (find.NDTomTat != null)
                                {
                                    dgvSach.Rows[r].Cells[7].Value = find.NDTomTat.Trim();
                                }
                                else
                                {
                                    dgvSach.Rows[r].Cells[7].Value = null;
                                }
                                if (find.HinhAnh != null)
                                {
                                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                                    string imagePath = Path.Combine(parentDirectory, "Images", find.HinhAnh);
                                    Image avatarImage = Image.FromFile(imagePath);
                                    dgvSach.Rows[r].Cells[8].Value = avatarImage;
                                }
                                int kt = 0;
                                for (int i = 0; i < dgvBanSach.Rows.Count; i++)
                                {
                                    if (dgvBanSach.Rows[i].Cells[1].Value.ToString().Trim() == f.MaKhoSach.Trim() && dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim() == f.MaSach.Trim())
                                    {
                                        kt = 1;
                                        dgvSach.Rows[r].Cells[9].Value = (f.SoLuongTon - int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim())).ToString();

                                    }
                                }
                                if (kt == 0)
                                {
                                    dgvSach.Rows[r].Cells[9].Value = f.SoLuongTon;
                                }

                            }
                        }
                    }

                    return;
                }
            }
            if (cbbluachontim.Text == "Tên Tác Giả")
            {
                if (cbbchon.Text == "")
                {
                    FormBanSach_Load(sender, e);
                    return;
                }
                else
                {
                    dgvSach.Rows.Clear();
                    ModelDB model1 = new ModelDB();
                    var fo = model1.TacGias.FirstOrDefault(p => p.TenTacGia.Trim() == cbbchon.Text.Trim());
                    var find1 = model1.Saches.FirstOrDefault(p => p.MaTacGia.Trim() == fo.MaTacGia.Trim());
                    foreach (var kho in model1.KhoSaches.ToList())
                    {
                        foreach (var f in model1.SachTrongKhoes.ToList())
                        {
                            if (f.MaKhoSach.Trim() == kho.MaKhoSach.Trim() && f.SoLuongTon > 0 && f.MaSach.Trim() == find1.MaSach.Trim())
                            {
                                var find = model1.Saches.FirstOrDefault(p => p.MaSach.Trim() == f.MaSach.Trim());
                                int r = dgvSach.Rows.Add();
                                dgvSach.Rows[r].Cells[0].Value = f.MaKhoSach;
                                dgvSach.Rows[r].Cells[1].Value = find.MaSach.Trim();
                                dgvSach.Rows[r].Cells[2].Value = find.TenSach.Trim();
                                dgvSach.Rows[r].Cells[3].Value = find.GiaBan.ToString();
                                var tim = model1.TacGias.FirstOrDefault(p => p.MaTacGia.Trim() == find.MaTacGia.Trim());
                                dgvSach.Rows[r].Cells[4].Value = tim.TenTacGia;
                                var timnxb = model1.NhaXuatBans.FirstOrDefault(p => p.MaNhaXuatBan.Trim() == find.MaNhaXuatBan.Trim());
                                dgvSach.Rows[r].Cells[5].Value = timnxb.TenNhaXuatBan;
                                var timntls = model1.TheLoaiSaches.FirstOrDefault(p => p.MaTheLoaiSach.Trim() == find.MaTheLoaiSach.Trim());
                                dgvSach.Rows[r].Cells[6].Value = timntls.TenTheLoai;
                                if (find.NDTomTat != null)
                                {
                                    dgvSach.Rows[r].Cells[7].Value = find.NDTomTat.Trim();
                                }
                                else
                                {
                                    dgvSach.Rows[r].Cells[7].Value = null;
                                }
                                if (find.HinhAnh != null)
                                {
                                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                                    string imagePath = Path.Combine(parentDirectory, "Images", find.HinhAnh);
                                    Image avatarImage = Image.FromFile(imagePath);
                                    dgvSach.Rows[r].Cells[8].Value = avatarImage;
                                }
                                int kt = 0;
                                for (int i = 0; i < dgvBanSach.Rows.Count; i++)
                                {
                                    if (dgvBanSach.Rows[i].Cells[1].Value.ToString().Trim() == f.MaKhoSach.Trim() && dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim() == f.MaSach.Trim())
                                    {
                                        kt = 1;
                                        dgvSach.Rows[r].Cells[9].Value = (f.SoLuongTon - int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim())).ToString();

                                    }
                                }
                                if (kt == 0)
                                {
                                    dgvSach.Rows[r].Cells[9].Value = f.SoLuongTon;
                                }

                            }
                        }
                    }
                    return;
                }
            }
            if (cbbluachontim.Text == "Tên Nhà Xuất Bản")
            {
                if (cbbchon.Text == "")
                {
                    FormBanSach_Load(sender, e);
                    return;
                }
                else
                {
                    dgvSach.Rows.Clear();
                    ModelDB model1 = new ModelDB();
                    var fo = model1.NhaXuatBans.FirstOrDefault(p => p.TenNhaXuatBan.Trim() == cbbchon.Text.Trim());
                    var find1 = model1.Saches.FirstOrDefault(p => p.MaNhaXuatBan.Trim() == fo.MaNhaXuatBan.Trim());
                    foreach (var kho in model1.KhoSaches.ToList())
                    {
                        foreach (var f in model1.SachTrongKhoes.ToList())
                        {
                            if (f.MaKhoSach.Trim() == kho.MaKhoSach.Trim() && f.SoLuongTon > 0 && f.MaSach.Trim() == find1.MaSach.Trim())
                            {
                                var find = model1.Saches.FirstOrDefault(p => p.MaSach.Trim() == f.MaSach.Trim());
                                int r = dgvSach.Rows.Add();
                                dgvSach.Rows[r].Cells[0].Value = f.MaKhoSach;
                                dgvSach.Rows[r].Cells[1].Value = find.MaSach.Trim();
                                dgvSach.Rows[r].Cells[2].Value = find.TenSach.Trim();
                                dgvSach.Rows[r].Cells[3].Value = find.GiaBan.ToString();
                                var tim = model1.TacGias.FirstOrDefault(p => p.MaTacGia.Trim() == find.MaTacGia.Trim());
                                dgvSach.Rows[r].Cells[4].Value = tim.TenTacGia;
                                var timnxb = model1.NhaXuatBans.FirstOrDefault(p => p.MaNhaXuatBan.Trim() == find.MaNhaXuatBan.Trim());
                                dgvSach.Rows[r].Cells[5].Value = timnxb.TenNhaXuatBan;
                                var timntls = model1.TheLoaiSaches.FirstOrDefault(p => p.MaTheLoaiSach.Trim() == find.MaTheLoaiSach.Trim());
                                dgvSach.Rows[r].Cells[6].Value = timntls.TenTheLoai;
                                if (find.NDTomTat != null)
                                {
                                    dgvSach.Rows[r].Cells[7].Value = find.NDTomTat.Trim();
                                }
                                else
                                {
                                    dgvSach.Rows[r].Cells[7].Value = null;
                                }
                                if (find.HinhAnh != null)
                                {
                                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                                    string imagePath = Path.Combine(parentDirectory, "Images", find.HinhAnh);
                                    Image avatarImage = Image.FromFile(imagePath);
                                    dgvSach.Rows[r].Cells[8].Value = avatarImage;
                                }
                                int kt = 0;
                                for (int i = 0; i < dgvBanSach.Rows.Count; i++)
                                {
                                    if (dgvBanSach.Rows[i].Cells[1].Value.ToString().Trim() == f.MaKhoSach.Trim() && dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim() == f.MaSach.Trim())
                                    {
                                        kt = 1;
                                        dgvSach.Rows[r].Cells[9].Value = (f.SoLuongTon - int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim())).ToString();

                                    }
                                }
                                if (kt == 0)
                                {
                                    dgvSach.Rows[r].Cells[9].Value = f.SoLuongTon;
                                }

                            }
                        }
                    }
                    return;
                }
            }
            if (cbbluachontim.Text == "Tên Thể Loại")
            {
                if (cbbchon.Text == "")
                {
                    FormBanSach_Load(sender, e);
                    return;
                }
                else
                {
                    dgvSach.Rows.Clear();
                    ModelDB model1 = new ModelDB();
                    var fo = model1.TheLoaiSaches.FirstOrDefault(p => p.TenTheLoai.Trim() == cbbchon.Text.Trim());
                    var find1 = model1.Saches.FirstOrDefault(p => p.MaTheLoaiSach.Trim() == fo.MaTheLoaiSach.Trim());
                    foreach (var kho in model1.KhoSaches.ToList())
                    {
                        foreach (var f in model1.SachTrongKhoes.ToList())
                        {
                            if (f.MaKhoSach.Trim() == kho.MaKhoSach.Trim() && f.SoLuongTon > 0 && f.MaSach.Trim() == find1.MaSach.Trim())
                            {
                                var find = model1.Saches.FirstOrDefault(p => p.MaSach.Trim() == f.MaSach.Trim());
                                int r = dgvSach.Rows.Add();
                                dgvSach.Rows[r].Cells[0].Value = f.MaKhoSach;
                                dgvSach.Rows[r].Cells[1].Value = find.MaSach.Trim();
                                dgvSach.Rows[r].Cells[2].Value = find.TenSach.Trim();
                                dgvSach.Rows[r].Cells[3].Value = find.GiaBan.ToString();
                                var tim = model1.TacGias.FirstOrDefault(p => p.MaTacGia.Trim() == find.MaTacGia.Trim());
                                dgvSach.Rows[r].Cells[4].Value = tim.TenTacGia;
                                var timnxb = model1.NhaXuatBans.FirstOrDefault(p => p.MaNhaXuatBan.Trim() == find.MaNhaXuatBan.Trim());
                                dgvSach.Rows[r].Cells[5].Value = timnxb.TenNhaXuatBan;
                                var timntls = model1.TheLoaiSaches.FirstOrDefault(p => p.MaTheLoaiSach.Trim() == find.MaTheLoaiSach.Trim());
                                dgvSach.Rows[r].Cells[6].Value = timntls.TenTheLoai;
                                if (find.NDTomTat != null)
                                {
                                    dgvSach.Rows[r].Cells[7].Value = find.NDTomTat.Trim();
                                }
                                else
                                {
                                    dgvSach.Rows[r].Cells[7].Value = null;
                                }
                                if (find.HinhAnh != null)
                                {
                                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                                    string imagePath = Path.Combine(parentDirectory, "Images", find.HinhAnh);
                                    Image avatarImage = Image.FromFile(imagePath);
                                    dgvSach.Rows[r].Cells[8].Value = avatarImage;
                                }
                                int kt = 0;
                                for (int i = 0; i < dgvBanSach.Rows.Count; i++)
                                {
                                    if (dgvBanSach.Rows[i].Cells[1].Value.ToString().Trim() == f.MaKhoSach.Trim() && dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim() == f.MaSach.Trim())
                                    {
                                        kt = 1;
                                        dgvSach.Rows[r].Cells[9].Value = (f.SoLuongTon - int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim())).ToString();

                                    }
                                }
                                if (kt == 0)
                                {
                                    dgvSach.Rows[r].Cells[9].Value = f.SoLuongTon;
                                }

                            }
                        }
                    }
                    return;
                }
            }
        }
        private void resetform()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtsl.Text = "";
            txtsachthem.Text = "";
        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbkho.Text = dgvSach.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtsachthem.Text = dgvSach.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }

        private void dgvBanSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbkho.Text = dgvBanSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtsachthem.Text = dgvBanSach.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtsl.Text = dgvBanSach.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtsl.Text == "" || txtsachthem.Text == "" || cbbkho.Text == "")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                if (txtsl.Text != "0")
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }

            }
        }

        private void ktrsave()
        {
            if (dgvBanSach.Rows.Count <= 0)
            {
                btnHuyLuu.Enabled = false;
                btnLuu.Enabled = false;
            }
            else
            {
                btnHuyLuu.Enabled = true;
                btnLuu.Enabled = true;
            }
        }
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            int ktr = 0;
            for (int i = 0; i < dgvSach.Rows.Count; i++)
            {
                string s = dgvSach.Rows[i].Cells[0].Value.ToString().Trim();
                string st = dgvSach.Rows[i].Cells[1].Value.ToString().Trim();
                if (s == cbbkho.Text.Trim() && st == txtsachthem.Text.Trim())
                {
                    if (int.Parse(txtsl.Text.Trim()) > int.Parse(dgvSach.Rows[i].Cells[9].Value.ToString().Trim()))
                    {
                        MessageBox.Show("Them That bai do " + cbbkho.Text + " khong du so luong sach can ban");
                        return;
                    }
                    else
                    {
                        dgvSach.Rows[i].Cells[9].Value = (int.Parse(dgvSach.Rows[i].Cells[9].Value.ToString().Trim()) - int.Parse(txtsl.Text.Trim())).ToString();
                    }
                }
            }
            for (int i = 0; i < dgvBanSach.Rows.Count; i++)
            {
                string s = dgvBanSach.Rows[i].Cells[1].Value.ToString().Trim();
                string st = dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim();
                if (s == cbbkho.Text.Trim() && st == txtsachthem.Text.Trim())
                {
                    dgvBanSach.Rows[i].Cells[2].Value = (long.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString()) + long.Parse(txtsl.Text.Trim())).ToString();
                    ktr = 1;
                }
            }
            if (ktr == 0)
            {
                int r = dgvBanSach.Rows.Add();
                dgvBanSach.Rows[r].Cells[1].Value = cbbkho.Text.Trim();
                dgvBanSach.Rows[r].Cells[0].Value = txtsachthem.Text.Trim();
                dgvBanSach.Rows[r].Cells[2].Value = txtsl.Text.Trim();
            }
            ktrsave();
            resetform();
            MessageBox.Show("Them thanh cong");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvBanSach.Rows.Count; i++)
            {
                if (dgvBanSach.Rows[i].Cells[1].Value.ToString().Trim() == cbbkho.Text.Trim() && dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim() == txtsachthem.Text.Trim())
                {
                    int temp = int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim());
                    dgvBanSach.Rows.RemoveAt(i);
                    for (int j = 0; j < dgvSach.Rows.Count; j++)
                    {
                        if (dgvSach.Rows[j].Cells[0].Value.ToString().Trim() == cbbkho.Text.Trim() && dgvSach.Rows[j].Cells[1].Value.ToString().Trim() == txtsachthem.Text.Trim())
                        {
                            dgvSach.Rows[j].Cells[9].Value = (int.Parse(dgvSach.Rows[j].Cells[9].Value.ToString().Trim()) + temp).ToString();
                            ktrsave();
                            MessageBox.Show("Xoa thanh cong");
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Xoa that bai");
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            if (txtsl.Text == "" || txtsachthem.Text == "" || cbbkho.Text == "")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                if (txtsl.Text != "0")
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
        }

        public void ReloadData()
        {
            object sender = null;
            EventArgs e = null;
            FormBanSach_Load(sender, e);
        }


        private void txtsachthem_TextChanged(object sender, EventArgs e)
        {
            if (txtsl.Text == "" || txtsachthem.Text == "" || cbbkho.Text == "")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                if (txtsl.Text != "0")
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ModelDB context = new ModelDB();


            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.NgayLapHoaDon = DateTime.Now;
                    var find = context.NhanViens.FirstOrDefault(x => x.TenNhanVien.Trim() == cmbnv.Text.Trim());
                    hoaDon.MaNhanVien = find.MaNhanVien;
                    hoaDon.MaTheDocGia = cmbdg.Text.Trim();
                    hoaDon.SoTienThanhToan = 0;
                    hoaDon.SoLuongSachDaMua = 0;
                    context.HoaDons.Add(hoaDon);
                    context.SaveChanges();
                    for (int i = 0; i < dgvBanSach.Rows.Count; i++)
                    {

                        string s = dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim();
                        var f = context.ChiTietHoaDons.FirstOrDefault(p => p.MaHoaDon == hoaDon.MaHoaDon && p.MaSach.Trim() == s);
                        var sach = context.Saches.FirstOrDefault(p => p.MaSach.Trim() == s);

                        if (f != null)
                        {
                            f.SoLuong += int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim());
                        }
                        else
                        {
                            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
                            chiTietHoaDon.MaSach = dgvBanSach.Rows[i].Cells[0].Value.ToString().Trim();
                            chiTietHoaDon.MaHoaDon = hoaDon.MaHoaDon;
                            chiTietHoaDon.SoLuong = int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim());
                            context.ChiTietHoaDons.Add(chiTietHoaDon);
                            context.SaveChanges();
                        }
                        hoaDon.SoLuongSachDaMua += int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim());
                        hoaDon.SoTienThanhToan += decimal.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim()) * sach.GiaBan;
                        string tr = dgvBanSach.Rows[i].Cells[1].Value.ToString().Trim();
                        var sachkho = context.SachTrongKhoes.FirstOrDefault(p => p.MaKhoSach.Trim() == tr && p.MaSach.Trim() == s);
                        sachkho.SoLuongTon -= int.Parse(dgvBanSach.Rows[i].Cells[2].Value.ToString().Trim());
                        context.SaveChanges();
                    }
                    var timnguoi = context.TheDocGias.FirstOrDefault(p => p.MaTheDocGia.Trim() == cmbdg.Text.Trim());
                    timnguoi.SoDiemTichLuy += hoaDon.SoLuongSachDaMua;
                    var t = context.KhachHangs.FirstOrDefault(p => p.MaKhachHang == timnguoi.MaKhachHang);
                    if (timnguoi.SoDiemTichLuy > 50)
                    {
                        t.LoaiKhachHang = 2;
                    }
                    else
                    {
                        if (timnguoi.SoDiemTichLuy > 10)
                        {
                            t.LoaiKhachHang = 1;
                        }
                    }
                    context.SaveChanges();
                    transaction.Commit();
                    resetall();
                    MessageBox.Show("Xuat Hoa Don Thanh Cong");
                }
                catch
                {
                    transaction.Rollback();
                    MessageBox.Show("Xuat Hoa Don That Bai");
                }
            }
        }

        private void btnHuyLuu_Click(object sender, EventArgs e)
        {
            ModelDB context = new ModelDB();

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var latestInvoice = context.HoaDons.OrderByDescending(hd => hd.NgayLapHoaDon).FirstOrDefault();

                    if (latestInvoice != null)
                    {
                        var invoiceDetails = context.ChiTietHoaDons.Where(ct => ct.MaHoaDon == latestInvoice.MaHoaDon);
                        context.ChiTietHoaDons.RemoveRange(invoiceDetails);

                        context.HoaDons.Remove(latestInvoice);

                        foreach (DataGridViewRow row in dgvBanSach.Rows)
                        {
                            string bookId = row.Cells[0].Value.ToString().Trim();
                            string warehouseId = row.Cells[1].Value.ToString().Trim();
                            int quantity = int.Parse(row.Cells[2].Value.ToString().Trim());

                            var bookInWarehouse = context.SachTrongKhoes.FirstOrDefault(stk => stk.MaSach == bookId && stk.MaKhoSach == warehouseId);
                            if (bookInWarehouse != null)
                            {
                                bookInWarehouse.SoLuongTon += quantity;
                            }
                        }

                        var buyerId = cmbdg.Text.Trim();
                        var buyer = context.TheDocGias.FirstOrDefault(td => td.MaTheDocGia == buyerId);
                        if (buyer != null)
                        {
                            buyer.SoDiemTichLuy -= latestInvoice.SoLuongSachDaMua;
                        }

                        context.SaveChanges();
                        transaction.Commit();
                        MessageBox.Show("Đã hủy lưu thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không có hoá đơn để hủy lưu.");
                    }
                }
                catch
                {
                    transaction.Rollback();
                    MessageBox.Show("Hủy lưu không thành công. Đã xảy ra lỗi.");
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}
