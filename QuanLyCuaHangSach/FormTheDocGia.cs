using Guna.UI2.WinForms;
using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormTheDocGia : Form
    {
        public FormTheDocGia()
        {
            InitializeComponent();
        }

        private FormKhachhang formKH;

        public FormTheDocGia(FormKhachhang formkhachhang)
        {
            InitializeComponent();
            checknam.Checked = true;
            formKH = formkhachhang;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            if (formKH != null)
            {
                formKH.resetdata();
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (datetimeNS.Value > DateTime.Now)
            {
                MessageBox.Show("Doc gia chua ton tai!!!!!!!!!");
            }
            else
            {

                ModelDB context = new ModelDB();
                var find = context.KhachHangs.FirstOrDefault(p => p.Email.Trim() == txtEmail.Text.Trim());
                var find1 = context.TheDocGias.FirstOrDefault(p => p.MaTheDocGia.Trim() == txtmathedoc.Text.Trim());
                if (find == null && find1 == null)
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            KhachHang khachHang = new KhachHang();
                            khachHang.LoaiKhachHang = 0;
                            khachHang.Email = txtEmail.Text;
                            khachHang.DiaChiKhachHang = txtdiachi.Text;
                            khachHang.HoTenKhachHang = txttenkh.Text;
                            khachHang.SDT_KhachHang = txtsdt.Text;
                            khachHang.NgaySinh = datetimeNS.Value;
                            if (checknam.Checked == true)
                            {
                                khachHang.GioiTinh = 1;

                            }
                            if (checknu.Checked == true)
                            {
                                khachHang.GioiTinh = 0;

                            }
                            context.KhachHangs.Add(khachHang);
                            context.SaveChanges();
                            TheDocGia theDocGia = new TheDocGia();
                            theDocGia.MaTheDocGia = txtmathedoc.Text;
                            theDocGia.MaKhachHang = khachHang.MaKhachHang;
                            theDocGia.NgayLapThe = DateTime.Now;
                            theDocGia.SoDiemTichLuy = 0;
                            context.TheDocGias.Add(theDocGia);
                            context.SaveChanges();
                            transaction.Commit();
                            MessageBox.Show("Luu thanh cong Doc Gia co ma: " + theDocGia.MaTheDocGia);
                        }
                        catch
                        {

                            transaction.Rollback();
                            MessageBox.Show("Luu that bai");

                        }
                        this.Close();
                        formKH.resetdata();
                    }
                }
                else
                {
                    if (find != null && find1 == null)
                    {
                        MessageBox.Show("Da ton tai Email: " + txtEmail);
                        return;
                    }
                    if (find == null && find1 != null)
                    {
                        MessageBox.Show("Da ton tai TheDocGia Co Ma: " + txtmathedoc);
                        return;
                    }
                    if (find != null && find1 != null)
                    {
                        MessageBox.Show("Da ton tai Email: " + txtEmail + "\nDa ton tai TheDocGia Co Ma: " + txtmathedoc);
                        return;
                    }
                }


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtdiachi.Text = "";
            txtEmail.Text = "";
            txtsdt.Text = "";
            txttenkh.Text = "";
            datetimeNS.Value = DateTime.Now;
            checknam.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (formKH != null)
            {
                formKH.resetdata();
                return;
            }
        }

        private void FormTheDocGia_Load(object sender, EventArgs e)
        {

        }
    }
}
