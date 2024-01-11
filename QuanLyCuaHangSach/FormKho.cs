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
    public partial class FormKho : Form
    {
        public FormKho()
        {
            InitializeComponent();
            ModelDB model1 = new ModelDB();
            cbbKhosach.Items.Add("");
            foreach (var t in model1.KhoSaches)
            {
                cbbKhosach.Items.Add(t.MaKhoSach.Trim());
            }
        }

        private void FormKho_Load(object sender, EventArgs e)
        {
            ModelDB model1 = new ModelDB();
            dgvKhoBook.Rows.Clear();
            foreach (var f in model1.SachTrongKhoes)
            {
                int r = dgvKhoBook.Rows.Add();
                dgvKhoBook.Rows[r].Cells[0].Value = f.MaKhoSach;
                var find1 = model1.KhoSaches.FirstOrDefault(p => p.MaKhoSach.Trim() == f.MaKhoSach.Trim());

                dgvKhoBook.Rows[r].Cells[1].Value = find1.TenKhoSach;

                var find = model1.Saches.FirstOrDefault(p => p.MaSach.Trim() == f.MaSach.Trim());
                dgvKhoBook.Rows[r].Cells[2].Value = find.MaSach.Trim();
                dgvKhoBook.Rows[r].Cells[3].Value = find.TenSach.Trim();
                var tim = model1.TacGias.FirstOrDefault(p => p.MaTacGia.Trim() == find.MaTacGia.Trim());
                dgvKhoBook.Rows[r].Cells[4].Value = tim.TenTacGia;
                var timnxb = model1.NhaXuatBans.FirstOrDefault(p => p.MaNhaXuatBan.Trim() == find.MaNhaXuatBan.Trim());
                dgvKhoBook.Rows[r].Cells[5].Value = timnxb.TenNhaXuatBan;
                var timntls = model1.TheLoaiSaches.FirstOrDefault(p => p.MaTheLoaiSach.Trim() == find.MaTheLoaiSach.Trim());
                dgvKhoBook.Rows[r].Cells[6].Value = timntls.TenTheLoai;
                if (find.NDTomTat != null)
                {
                    dgvKhoBook.Rows[r].Cells[7].Value = find.NDTomTat.Trim();

                }
                else
                {
                    dgvKhoBook.Rows[r].Cells[7].Value = null;

                }
                if (find.HinhAnh != null)
                {
                    // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "Images", find.HinhAnh);
                    Image avatarImage = Image.FromFile(imagePath);
                    dgvKhoBook.Rows[r].Cells[8].Value = avatarImage;
                }
                dgvKhoBook.Rows[r].Cells[9].Value = f.SoLuongTon;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbbKhosach.Text == "")
            {
                FormKho_Load(sender, e);
            }
            else
            {
                ModelDB model1 = new ModelDB();
                dgvKhoBook.Rows.Clear();
                foreach (var f in model1.SachTrongKhoes)
                {
                    if (f.MaKhoSach.Trim() == cbbKhosach.Text.Trim())
                    {
                        int r = dgvKhoBook.Rows.Add();
                        dgvKhoBook.Rows[r].Cells[0].Value = f.MaKhoSach;
                        var find1 = model1.KhoSaches.FirstOrDefault(p => p.MaKhoSach.Trim() == f.MaKhoSach.Trim());

                        dgvKhoBook.Rows[r].Cells[1].Value = find1.TenKhoSach;
                        var find = model1.Saches.FirstOrDefault(p => p.MaSach.Trim() == f.MaSach.Trim());
                        dgvKhoBook.Rows[r].Cells[2].Value = find.MaSach.Trim();
                        dgvKhoBook.Rows[r].Cells[3].Value = find.TenSach.Trim();
                        var tim = model1.TacGias.FirstOrDefault(p => p.MaTacGia.Trim() == find.MaTacGia.Trim());
                        dgvKhoBook.Rows[r].Cells[4].Value = tim.TenTacGia;
                        var timnxb = model1.NhaXuatBans.FirstOrDefault(p => p.MaNhaXuatBan.Trim() == find.MaNhaXuatBan.Trim());
                        dgvKhoBook.Rows[r].Cells[5].Value = timnxb.TenNhaXuatBan;
                        var timntls = model1.TheLoaiSaches.FirstOrDefault(p => p.MaTheLoaiSach.Trim() == find.MaTheLoaiSach.Trim());
                        dgvKhoBook.Rows[r].Cells[6].Value = timntls.TenTheLoai;
                        if (find.NDTomTat != null)
                        {
                            dgvKhoBook.Rows[r].Cells[7].Value = find.NDTomTat.Trim();

                        }
                        else
                        {
                            dgvKhoBook.Rows[r].Cells[7].Value = null;

                        }
                        if (find.HinhAnh != null)
                        {
                            // Tạo một đối tượng hình ảnh từ đường dẫn và đặt nó cho cột AvatarColumn
                            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                            string imagePath = Path.Combine(parentDirectory, "Images", find.HinhAnh);
                            Image avatarImage = Image.FromFile(imagePath);
                            dgvKhoBook.Rows[r].Cells[8].Value = avatarImage;
                        }
                        dgvKhoBook.Rows[r].Cells[9].Value = f.SoLuongTon;
                    }

                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            dgvKhoBook.Rows.Clear();
        }
    }
}
