using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormTrangchu : Form
    {
        public FormTrangchu()
        {
            InitializeComponent();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {

        }
        private void UpdateLabelTime()
        {
            DateTime thoiGianHienTai = DateTime.Now;

            labelThoigian.Text = thoiGianHienTai.ToString("hh:mm:ss tt");
        }
        private void FormTrangchu_Load(object sender, EventArgs e)
        {

            UpdateLabelTime();

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Start();
            DateTime ngayHienTai = DateTime.Today;



            monthCalendarLich.TodayDate = ngayHienTai;
            using (ModelDB model = new ModelDB())
            {
                int tongNhanVien = model.NhanViens.Count();
                labelNhanvien.Text = tongNhanVien.ToString();

                int tongKhachHang = model.KhachHangs.Count();
                labelKhachhang.Text = tongKhachHang.ToString();



                decimal tongChiTieu = model.ChiTietNhapSaches.Sum(s => s.GiaNhap * s.SoLuongNhap);
                labelChitieu.Text = tongChiTieu.ToString("N2", CultureInfo.InvariantCulture) + " $";

                int giaTriToiDa = 1000000000;

                decimal tongTienBanSach = model.HoaDons.Sum(hd => hd.SoTienThanhToan);
                decimal tongChiPhiNhapSach = model.PhieuNhaps.Sum(pn => pn.TongTien);

                decimal phanTramDoanhSo = (tongTienBanSach / giaTriToiDa) * 100;
                decimal phanTramChiPhiNhapSach = (tongChiPhiNhapSach / giaTriToiDa) * 100;

                circularProgressBarVao.Maximum = giaTriToiDa;
                circularProgressBarRa.Maximum = giaTriToiDa;

                circularProgressBarVao.Value = (int)tongTienBanSach;
                circularProgressBarRa.Value = (int)tongChiPhiNhapSach;

                circularProgressBarVao.Text = $"{Math.Round(phanTramDoanhSo, 2)} %";
                circularProgressBarRa.Text = $"{Math.Round(phanTramChiPhiNhapSach, 2)} %";
            }
            // Truy vấn cơ sở dữ liệu để lấy thông tin sách bán nhiều nhất
            using (ModelDB model = new ModelDB())
            {
                var sachBanNhieuNhatList = model.ChiTietHoaDons
                                                .GroupBy(cthd => cthd.MaSach)
                                                .Select(g => new
                                                {
                                                    MaSach = g.Key,
                                                    SoLuongBan = g.Sum(cthd => cthd.SoLuong)
                                                })
                                                .OrderByDescending(x => x.SoLuongBan)
                                                .Take(5) // Lấy 6 cuốn sách bán nhiều nhất
                                                .ToList();

                // Kiểm tra và gán thông tin cho từng sách trong danh sách sách bán nhiều nhất
                for (int i = 0; i < sachBanNhieuNhatList.Count; i++)
                {
                    var sach = sachBanNhieuNhatList[i];

                    var thongTinSach = model.Saches.FirstOrDefault(s => s.MaSach == sach.MaSach);
                    if (thongTinSach != null && thongTinSach.HinhAnh != null)
                    {
                        string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                        string imagePath = Path.Combine(parentDirectory, "Images", thongTinSach.HinhAnh);

                        // Gán thông tin sách vào label và pictureBox tương ứng
                        if (i == 0)
                        {
                            labelNameSach1.Text = thongTinSach.TenSach; // Đặt tên sách
                            labelsoluong1.Text = sach.SoLuongBan.ToString(); // Đặt số lượng sách đã bán
                            picAnhSach1.Image = Image.FromFile(imagePath); // Hiển thị hình ảnh sách
                        }
                        else if (i == 1)
                        {
                            labelNameSach2.Text = thongTinSach.TenSach;
                            labelsoluong2.Text = sach.SoLuongBan.ToString();
                            picAnhSach2.Image = Image.FromFile(imagePath);
                        } else if(i == 2)
                        {
                            labelNameSach3.Text = thongTinSach.TenSach;
                            labelsoluong3.Text = sach.SoLuongBan.ToString();
                            picAnhSach3.Image = Image.FromFile(imagePath);
                        }
                        else if (i == 3)
                        {
                            labelNameSach4.Text = thongTinSach.TenSach;
                            labelsoluong4.Text = sach.SoLuongBan.ToString();
                            picAnhSach4.Image = Image.FromFile(imagePath);
                        }
                        else if (i == 4)
                        {
                            labelNameSach5.Text = thongTinSach.TenSach;
                            labelsoluong5.Text = sach.SoLuongBan.ToString();
                            picAnhSach5.Image = Image.FromFile(imagePath);
                        }
                        // Tiếp tục cho các label và pictureBox còn lại tương tự như trên
                        // ...
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLabelTime();
        }
    }
}
