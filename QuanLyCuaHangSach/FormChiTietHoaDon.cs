using OfficeOpenXml;
using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormChiTietHoaDon : Form
    {
        public FormChiTietHoaDon()
        {
            InitializeComponent();
        }
        List<ChiTietHoaDon> list;
        public FormChiTietHoaDon(List<ChiTietHoaDon> l)
        {
            list = l;
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            dgvChitietHD.Rows.Clear();
            foreach (var t in list)
            {
                int r = dgvChitietHD.Rows.Add();
                dgvChitietHD.Rows[r].Cells[0].Value = t.MaHoaDon;
                dgvChitietHD.Rows[r].Cells[1].Value = t.MaSach;
                dgvChitietHD.Rows[r].Cells[3].Value = t.SoLuong;
                ModelDB model1 = new ModelDB();
                var find = model1.Saches.FirstOrDefault(p => p.MaSach == t.MaSach);
                dgvChitietHD.Rows[r].Cells[2].Value = find.TenSach;
                dgvChitietHD.Rows[r].Cells[4].Value = find.GiaBan;
                dgvChitietHD.Rows[r].Cells[5].Value = t.SoLuong * find.GiaBan;


            }
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

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvChitietHD.Width, this.dgvChitietHD.Height);
            dgvChitietHD.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvChitietHD.Width, this.dgvChitietHD.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            dgvChitietHD.Rows.Clear();
        }
    }
}
