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
    public partial class FormCapTaiKhoan : Form
    {

        private FormNhanvien F;
        private NhanVien N;
        public FormCapTaiKhoan()
        {
            InitializeComponent();
        }

        public FormCapTaiKhoan(FormNhanvien formNV, NhanVien NV)
        {
            InitializeComponent();
            F = formNV;
            N = NV;
            txtMaNV.Text = N.MaNhanVien.ToString();
        }

        private void FormCapTaiKhoan_Load(object sender, EventArgs e)
        {
           
            ReloadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            F.resetform();
        }

        private void btnCapTK_Click(object sender, EventArgs e)
        {
            if (cmbtk.Text != "")
            {
                ModelDB model1 = new ModelDB();
                var find = model1.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == cmbtk.Text.Trim());

                // Kiểm tra xem nhân viên đã có tài khoản chưa
                var existingEmployee = model1.NhanViens.FirstOrDefault(p => p.MaNhanVien == N.MaNhanVien && p.TaiKhoan != null);

                if (existingEmployee != null)
                {
                    MessageBox.Show("Nhân viên đã có tài khoản.");
                    return;
                }

                using (var transaction = model1.Database.BeginTransaction())
                {
                    try
                    {
                        N.TaiKhoan = find.TaiKhoan1.Trim();
                        model1.NhanViens.Add(N);
                        find.VoHieuHoa = false;
                        model1.SaveChanges();
                        transaction.Commit();
                        MessageBox.Show("Thêm Nhân Viên Thành Công \n Nhân viên" + N.TenNhanVien + " \n Có Tài Khoản " + find.TaiKhoan1 + " \n Và Mật Khẩu " + find.MatKhau);
                        ReloadData();
                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("Thêm Nhân Viên Thất Bại");
                    }
                }
            }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cmbtk.Text = dgvTK.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            }
            catch
            {

            }
        }
        public void ReloadData()
        {
            ModelDB model1 = new ModelDB();

            dgvTK.Rows.Clear();
            cmbtk.Items.Clear();
            cmbtk.Items.Add("");

            foreach (var x in model1.TaiKhoans.ToList())
            {
                if (x.VoHieuHoa == null)
                {
                    cmbtk.Items.Add(x.TaiKhoan1.Trim());
                    int r = dgvTK.Rows.Add();
                    dgvTK.Rows[r].Cells[0].Value = x.TaiKhoan1.Trim();
                    dgvTK.Rows[r].Cells[1].Value = x.MatKhau.Trim();
                    dgvTK.Rows[r].Cells[2].Value = x.Email.Trim();
                }
            }
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
