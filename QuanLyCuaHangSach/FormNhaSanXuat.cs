using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormNhaSanXuat : Form
    {
        public FormNhaSanXuat()
        {
            InitializeComponent();
        }
        private FormSach formsach;
        public FormNhaSanXuat(FormSach sachForm)
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

        private void resetform()
        {
            txtDiachiNXB.Text = "";
            txtMaNXB.Text = "";
            txtSDTNXB.Text = "";
            txtTenNXB.Text = "";
            txtTimKiem.Text = "";
        }
        private void BindGrid(List<NhaXuatBan> listNXB)
        {
            dgvNXB.Rows.Clear();
            foreach (var nxb in listNXB)
            {
                int index = dgvNXB.Rows.Add();
                dgvNXB.Rows[index].Cells[0].Value = nxb.MaNhaXuatBan;
                dgvNXB.Rows[index].Cells[1].Value = nxb.TenNhaXuatBan;
                dgvNXB.Rows[index].Cells[2].Value = nxb.SDTNhaXuatBan;
                dgvNXB.Rows[index].Cells[3].Value = nxb.DiaChiNhaXuatBan;
            }
        }

        private bool CheckData()
        {
            if (txtMaNXB.Text == "" || txtTenNXB.Text == "" || txtSDTNXB.Text == "" || txtDiachiNXB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà xuất bản!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                NhaXuatBan nxbAdd = context.NhaXuatBans.FirstOrDefault(n => n.MaNhaXuatBan.Trim() == txtMaNXB.Text);
                if (nxbAdd == null)
                {
                    NhaXuatBan nxb = new NhaXuatBan();
                    nxb.MaNhaXuatBan = txtMaNXB.Text;
                    nxb.TenNhaXuatBan = txtTenNXB.Text;
                    nxb.SDTNhaXuatBan = txtSDTNXB.Text;
                    nxb.DiaChiNhaXuatBan = txtDiachiNXB.Text;

                    context.NhaXuatBans.Add(nxb);
                    context.SaveChanges();

                    List<NhaXuatBan> listNXB = context.NhaXuatBans.ToList();
                    BindGrid(listNXB);
                    resetform();
                    MessageBox.Show("Thêm nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Nhà xuất bản đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                NhaXuatBan nxbUpt = context.NhaXuatBans.FirstOrDefault(n => n.MaNhaXuatBan.Trim() == txtMaNXB.Text);
                if (nxbUpt != null)
                {
                    nxbUpt.TenNhaXuatBan = txtTenNXB.Text;
                    nxbUpt.SDTNhaXuatBan = txtSDTNXB.Text;
                    nxbUpt.DiaChiNhaXuatBan = txtDiachiNXB.Text;

                    context.SaveChanges();

                    List<NhaXuatBan> listNXB = context.NhaXuatBans.ToList();
                    BindGrid(listNXB);
                    resetform();
                    MessageBox.Show("Cập nhật nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Nhà xuất bản không tồn tại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                NhaXuatBan nxbRmv = context.NhaXuatBans.FirstOrDefault(n => n.MaNhaXuatBan.Trim() == txtMaNXB.Text);

                if (nxbRmv != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa nhà xuất bản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        context.NhaXuatBans.Remove(nxbRmv);
                        context.SaveChanges();

                        List<NhaXuatBan> listNXB = context.NhaXuatBans.ToList();
                        BindGrid(listNXB);
                        resetform();
                        MessageBox.Show("Xóa nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Nhà xuất bản không tồn tại!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void FormNhaSanXuat_Load(object sender, EventArgs e)
        {
            List<NhaXuatBan> listNXB = context.NhaXuatBans.ToList();
            BindGrid(listNXB);
        }

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNXB.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvNXB.CurrentRow.Selected = true;
                    txtMaNXB.Text = dgvNXB.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenNXB.Text = dgvNXB.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtSDTNXB.Text = dgvNXB.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtDiachiNXB.Text = dgvNXB.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem_TextChanged(sender, e);
        }

        private void txtSDTNXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtSDTNXB.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ModelDB model = new ModelDB();
            dgvNXB.Rows.Clear();
            foreach (var nxb in model.NhaXuatBans.ToList())
            {
                if (nxb.MaNhaXuatBan.Trim().ToLower().Contains(txtTimKiem.Text.Trim().ToLower()))
                {
                    int r = dgvNXB.Rows.Add();
                    dgvNXB.Rows[r].Cells[0].Value = nxb.MaNhaXuatBan;
                    dgvNXB.Rows[r].Cells[1].Value = nxb.TenNhaXuatBan;
                    dgvNXB.Rows[r].Cells[2].Value = nxb.SDTNhaXuatBan;
                    dgvNXB.Rows[r].Cells[3].Value = nxb.DiaChiNhaXuatBan;
                }

            }
        }
    }
}
