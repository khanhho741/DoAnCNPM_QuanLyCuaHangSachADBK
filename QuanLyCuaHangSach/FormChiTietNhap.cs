using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormChiTietNhap : Form
    {
        public FormChiTietNhap()
        {
            InitializeComponent();
        }
        List<ChiTietNhapSach> list;
        public FormChiTietNhap(List<ChiTietNhapSach> l)
        {
            list = l;
            InitializeComponent();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            // Mở hộp thoại in và in DataGridView
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang bảo trì");

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvChitietnhap.Width, this.dgvChitietnhap.Height);
            dgvChitietnhap.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvChitietnhap.Width, this.dgvChitietnhap.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
        private void FormChiTietNhap_Load(object sender, EventArgs e)
        { 
            dgvChitietnhap.Rows.Clear();
            foreach (var t in list)
            {
                int r = dgvChitietnhap.Rows.Add();
                dgvChitietnhap.Rows[r].Cells[0].Value = t.MaSach;
                dgvChitietnhap.Rows[r].Cells[1].Value = t.MaPhieuNhap;
                dgvChitietnhap.Rows[r].Cells[2].Value = t.NgayNhap;

                dgvChitietnhap.Rows[r].Cells[3].Value = t.SoLuongNhap;
                dgvChitietnhap.Rows[r].Cells[4].Value = t.GiaNhap;
                dgvChitietnhap.Rows[r].Cells[5].Value = t.SoLuongNhap * t.GiaNhap;


            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            dgvChitietnhap.Rows.Clear();
        }
    }
}
