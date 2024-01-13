using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormThongke : Form
    {
        public FormThongke()
        {
            InitializeComponent();
        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormThongke_Load(object sender, EventArgs e)
        {
            using (ModelDB model = new ModelDB())
            {
                decimal doanhThu = model.HoaDons.Sum(hd => hd.SoTienThanhToan);
                labelDoanhthu.Text = doanhThu.ToString("N2", CultureInfo.InvariantCulture);

                DateTime thangTruoc = DateTime.Now.AddMonths(-1);

                decimal doanhThuHienTai = model.HoaDons.Sum(hd => hd.SoTienThanhToan);

                // Tính toán doanh thu của thời kỳ trước đó
                decimal? doanhThuTruocDo = model.HoaDons
                .Where(hd => hd.NgayLapHoaDon.Year == thangTruoc.Year && hd.NgayLapHoaDon.Month == thangTruoc.Month)
                 .Sum(hd => (decimal?)hd.SoTienThanhToan);

                if (doanhThuTruocDo.HasValue)
                {
                    decimal tiLeTangTruong = ((doanhThuHienTai - doanhThuTruocDo.Value) / doanhThuTruocDo.Value) * 100;
                    labelDoanhthuphantram.Text = $"+{tiLeTangTruong:N2}%";
                }
                else
                {
                    labelDoanhthuphantram.Text = "+0.00%";
                }

                // Lấy tổng số lượng sách đã bán từ tất cả hóa đơn
                int sachDaBan = model.HoaDons.Sum(hd => hd.SoLuongSachDaMua);
                labelSachban.Text = sachDaBan.ToString();

                // Lấy tổng số lượng sách đã nhập từ tất cả phiếu nhập
                int sachNhap = model.PhieuNhaps.Sum(pn => pn.ChiTietNhapSaches.Sum(ct => ct.SoLuongNhap));
                labelSachNhap.Text = sachNhap.ToString();

                // Lấy tồn kho sách còn trong kho từ tất cả bản ghi sách trong kho
                int tonKho = model.SachTrongKhoes.Sum(stk => stk.SoLuongTon);
                labelTonkho.Text = tonKho.ToString();


             

                int tongNhanVien = model.NhanViens.Count();
                labelNhanvien.Text = tongNhanVien.ToString();

                // Lấy tổng số khách hàng và hiển thị trên labelKhachHang
                int tongKhachHang = model.KhachHangs.Count();
                labelKhachhang.Text = tongKhachHang.ToString();


                labelDoanhthu.Text = $"{doanhThu:N2} $"; 

                labelSachban.Text = $"{sachDaBan} cuốn"; 
                labelSachNhap.Text = $"{sachNhap} cuốn";
                labelTonkho.Text = $"{tonKho} cuốn"; 

                
            }
            // Thêm các năm từ 2010 đến 2024
            for (int i = 2021; i <= 2024; i++)
            {
                cmbNam.Items.Add(i);
            }

            // Thêm các tháng từ 1 đến 12
            for (int i = 1; i <= 12; i++)
            {
                cmbThang.Items.Add(i);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            using (ModelDB model = new ModelDB())
            {
                if (cmbNam.SelectedItem != null)
                {
                    int nam = int.Parse(cmbNam.SelectedItem.ToString());

                    var doanhThuTheoNam = model.HoaDons
                        .Where(hd => hd.NgayLapHoaDon.Year == nam)
                        .GroupBy(hd => hd.NgayLapHoaDon.Month)
                        .Select(group => new
                        {
                            Thang = group.Key,
                            DoanhThuThang = group.Sum(hd => hd.SoTienThanhToan)
                        })
                        .ToList();

                    cartesianChartNam.Series.Clear();
                    cartesianChartNam.AxisX.Clear();
                    cartesianChartNam.AxisX.Add(new LiveCharts.Wpf.Axis
                    {
                        Title = "Tháng",
                        Labels = doanhThuTheoNam.Select(d => d.Thang.ToString()).ToList()
                    });
                    cartesianChartNam.AxisY.Clear();
                    cartesianChartNam.AxisY.Add(new LiveCharts.Wpf.Axis
                    {
                        Title = "Doanh thu"
                    });

                    var series = new LiveCharts.Wpf.LineSeries
                    {
                        Title = $"Doanh thu năm {nam}",
                        Values = new LiveCharts.ChartValues<decimal>(doanhThuTheoNam.Select(d => d.DoanhThuThang)),
                        PointGeometry = null
                    };
                    cartesianChartNam.Series.Add(series);

                }
                else if (cmbThang.SelectedItem != null)
                {
                    int thang = int.Parse(cmbThang.SelectedItem.ToString());

                    var doanhThuTheoThang = model.HoaDons
                        .Where(hd => hd.NgayLapHoaDon.Month == thang)
                        .GroupBy(hd => hd.NgayLapHoaDon.Day)
                        .Select(group => new
                        {
                            Ngay = group.Key,
                            DoanhThuNgay = group.Sum(hd => hd.SoTienThanhToan)
                        })
                        .ToList();

                    chartThang.Series.Clear();
                    chartThang.ChartAreas.Clear(); // Xóa các vùng biểu đồ hiện có

                    var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea(); // Tạo vùng biểu đồ mới
                    chartThang.ChartAreas.Add(chartArea);

                    var series = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        ChartArea = "ChartArea1", // Đặt vùng biểu đồ cho dòng này
                        LegendText = $"Doanh thu tháng {thang}"
                    };

                    foreach (var data in doanhThuTheoThang)
                    {
                        series.Points.AddXY(data.Ngay, data.DoanhThuNgay);
                    }

                    chartThang.Series.Add(series);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbNam.SelectedIndex = -1; 
            cmbThang.SelectedIndex = -1; 

            // Xóa dữ liệu của biểu đồ
            cartesianChartNam.Series.Clear();
            cartesianChartNam.AxisX.Clear();
            cartesianChartNam.AxisY.Clear();
            chartThang.Series.Clear();
            chartThang.ChartAreas.Clear();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            cmbNam.SelectedIndex = -1; 
            cmbThang.SelectedIndex = -1; 

            cartesianChartNam.Series.Clear();
            cartesianChartNam.AxisX.Clear();
            cartesianChartNam.AxisY.Clear();
            chartThang.Series.Clear();
            chartThang.ChartAreas.Clear();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }
    }
   }

