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
    public partial class FormLoaiSach : Form
    {
        public FormLoaiSach()
        {
            InitializeComponent();
        }

        private FormSach formsach;
        public FormLoaiSach(FormSach sachForm)
        {
            InitializeComponent();
            formsach = sachForm;
        }
        ModelDB context = new ModelDB();

        private void btnThoat_Click(object sender, EventArgs e)
        {

            this.Close();
            if (formsach != null)
            {
                formsach.ReloadData();
            }
        }
        private void resetForm()
        {
            txtMaLS.Text = "";
            txtTenLS.Text = "";


        }

        private void BindGrid(List<TheLoaiSach> listTLsach)
        {
            dgvLoaiSach.Rows.Clear();
            foreach (var item in listTLsach)
            {
                int index = dgvLoaiSach.Rows.Add();
                dgvLoaiSach.Rows[index].Cells[0].Value = item.MaTheLoaiSach;
                dgvLoaiSach.Rows[index].Cells[1].Value = item.TenTheLoai;

            }
        }
        private bool CheckData()
        {
            if (txtMaLS.Text == "" || txtTenLS.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thể loại sách!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TheLoaiSach theloaiAdd = context.TheLoaiSaches.FirstOrDefault(s => s.MaTheLoaiSach.Trim() == txtMaLS.Text);
                if (theloaiAdd == null)
                {
                    TheLoaiSach theloaisach = new TheLoaiSach();
                    theloaisach.MaTheLoaiSach = txtMaLS.Text;
                    theloaisach.TenTheLoai = txtTenLS.Text;

                    context.TheLoaiSaches.Add(theloaisach);
                    context.SaveChanges();
                    List<TheLoaiSach> listTLsach = context.TheLoaiSaches.ToList();
                    BindGrid(listTLsach);
                    resetForm();
                    MessageBox.Show("Thêm loại sách thành công !", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Loại sách đã tồn tại !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TheLoaiSach theloaiUpt = context.TheLoaiSaches.FirstOrDefault(s => s.MaTheLoaiSach.Trim() == txtMaLS.Text);
                if (theloaiUpt != null)
                {

                    theloaiUpt.TenTheLoai = txtTenLS.Text;

                    context.SaveChanges();
                    List<TheLoaiSach> listTLsach = context.TheLoaiSaches.ToList();
                    BindGrid(listTLsach);
                    resetForm();
                    MessageBox.Show("Cập nhật loại sách thành công !", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Loại sách không tìm thấy!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TheLoaiSach theloaiRmv = context.TheLoaiSaches.FirstOrDefault(s => s.MaTheLoaiSach.Trim() == txtMaLS.Text);


                if (theloaiRmv != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa loại sách này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        context.TheLoaiSaches.Remove(theloaiRmv);
                        context.SaveChanges();
                        List<TheLoaiSach> listTLsach = context.TheLoaiSaches.ToList();
                        BindGrid(listTLsach);
                        resetForm();
                        MessageBox.Show("Xóa loại sách thành công !", "Thông báo", MessageBoxButtons.OK);

                    }
                }
                else
                {
                    MessageBox.Show("Loại sách không tìm thấy!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void FormLoaiSach_Load(object sender, EventArgs e)
        {
            List<TheLoaiSach> listTLsach = context.TheLoaiSaches.ToList();

            BindGrid(listTLsach);
        }

        private void dgvLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLoaiSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvLoaiSach.CurrentRow.Selected = true;
                    txtMaLS.Text = dgvLoaiSach.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenLS.Text = dgvLoaiSach.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PerformSearch()
        {
            string searchText = txtTimKiem.Text.Trim().ToLower();

            List<TheLoaiSach> listTLsach = context.TheLoaiSaches.ToList();

            List<TheLoaiSach> filteredList = new List<TheLoaiSach>();

            filteredList = listTLsach.Where(t =>
                t.MaTheLoaiSach.ToLower().Contains(searchText) ||
                t.TenTheLoai.ToLower().Contains(searchText)
            ).ToList();

            BindGrid(filteredList);
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                PerformSearch();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}
