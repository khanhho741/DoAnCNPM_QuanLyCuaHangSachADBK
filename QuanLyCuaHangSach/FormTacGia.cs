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
    public partial class FormTacGia : Form
    {
        public FormTacGia()
        {
            InitializeComponent();
        }

        private FormSach formsach;
        public FormTacGia(FormSach sachForm)
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
            txtMatg.Text = "";
            txtTentg.Text = "";
            txtSDTtg.Text = "";
            txtDiachitg.Text = "";


        }
        private bool CheckData()
        {
            if (txtMatg.Text == "" || txtTentg.Text == "" || txtSDTtg.Text == "" || txtDiachitg.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tác giả!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void BindGrid(List<TacGia> listTacGia)
        {
            dgvTacGia.Rows.Clear();
            foreach (var item in listTacGia)
            {
                int index = dgvTacGia.Rows.Add();
                dgvTacGia.Rows[index].Cells[0].Value = item.MaTacGia;
                dgvTacGia.Rows[index].Cells[1].Value = item.TenTacGia;
                dgvTacGia.Rows[index].Cells[2].Value = item.SDTTacGia;
                dgvTacGia.Rows[index].Cells[3].Value = item.DiaChiTacGia;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TacGia tacgiaAdd = context.TacGias.FirstOrDefault(s => s.MaTacGia.Trim() == txtMatg.Text);
                if (tacgiaAdd == null)
                {
                    TacGia tacgia = new TacGia();
                    tacgia.MaTacGia = txtMatg.Text;
                    tacgia.TenTacGia = txtTentg.Text;
                    tacgia.SDTTacGia = txtSDTtg.Text;
                    tacgia.DiaChiTacGia = txtDiachitg.Text;

                    context.TacGias.Add(tacgia);
                    context.SaveChanges();
                    List<TacGia> listTacgia = context.TacGias.ToList();
                    BindGrid(listTacgia);
                    resetForm();
                    MessageBox.Show("Thêm tác giả thành công !", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Tác giả đã tồn tại !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TacGia tacgiaUpt = context.TacGias.FirstOrDefault(s => s.MaTacGia.Trim() == txtMatg.Text);
                if (tacgiaUpt != null)
                {
                    tacgiaUpt.TenTacGia = txtTentg.Text;
                    tacgiaUpt.SDTTacGia = txtSDTtg.Text;
                    tacgiaUpt.DiaChiTacGia = txtDiachitg.Text;

                    context.SaveChanges();
                    List<TacGia> listTacgia = context.TacGias.ToList();
                    BindGrid(listTacgia);
                    resetForm();
                    MessageBox.Show("Cập nhật tác giả thành công !", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Tác giả không tìm thấy!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TacGia tacgiaRmv = context.TacGias.FirstOrDefault(s => s.MaTacGia.Trim() == txtMatg.Text);

                if (tacgiaRmv != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa tác giả này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        context.TacGias.Remove(tacgiaRmv);
                        context.SaveChanges();
                        List<TacGia> listTacgia = context.TacGias.ToList();
                        BindGrid(listTacgia);
                        resetForm();
                        MessageBox.Show("Xóa tác giả thành công !", "Thông báo", MessageBoxButtons.OK);

                    }
                }
                else
                {
                    MessageBox.Show("Tác giả không tìm thấy !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void FormTacGia_Load(object sender, EventArgs e)
        {
            List<TacGia> listTacgia = context.TacGias.ToList();
            BindGrid(listTacgia);

        }

        private void PerformSearch()
        {
            string searchText = txtTimKiem.Text.Trim().ToLower();

            List<TacGia> listTacgia = context.TacGias.ToList();
            List<TacGia> filteredList = new List<TacGia>();

            filteredList = listTacgia.Where(t =>
                t.MaTacGia.ToLower().Contains(searchText) ||
                t.TenTacGia.ToLower().Contains(searchText) ||
                t.SDTTacGia.ToLower().Contains(searchText) ||
                t.DiaChiTacGia.ToLower().Contains(searchText)
            ).ToList();

            BindGrid(filteredList);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                PerformSearch();
            }
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTacGia.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvTacGia.CurrentRow.Selected = true;
                    txtMatg.Text = dgvTacGia.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTentg.Text = dgvTacGia.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtSDTtg.Text = dgvTacGia.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtDiachitg.Text = dgvTacGia.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSDTtg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Kiểm tra xem TextBox đã có 10 ký tự chưa, nếu có thì không cho phép nhập thêm.
            if (txtSDTtg.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
