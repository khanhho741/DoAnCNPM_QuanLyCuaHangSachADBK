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
    public partial class FormQLTK : Form
    {
        public FormQLTK()
        {
            InitializeComponent();
        }

        private FormNhanvien formnv;
        public FormQLTK(FormNhanvien formNV)
        {
            InitializeComponent();
            formnv = formNV;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void FormQLTK_Load(object sender, EventArgs e)
        {
            ModelDB model = new ModelDB();
            dgvTK.Rows.Clear();
            foreach (var tk in model.TaiKhoans.ToList())
            {
                int r = dgvTK.Rows.Add();
                dgvTK.Rows[r].Cells[0].Value = tk.HovaTen.ToString().Trim();
                dgvTK.Rows[r].Cells[1].Value = tk.TaiKhoan1.ToString().Trim();
                dgvTK.Rows[r].Cells[2].Value = tk.MatKhau.ToString().Trim();
                dgvTK.Rows[r].Cells[3].Value = tk.Email.ToString().Trim();
                if (tk.VoHieuHoa == null)
                {
                    dgvTK.Rows[r].Cells[4].Value = "";
                }
                else
                {
                    dgvTK.Rows[r].Cells[4].Value = tk.VoHieuHoa.ToString().Trim();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmk.Text.Length >= 8 && txtmk.Text.Length <= 16)
                {
                    ModelDB model = new ModelDB();
                    for (int i = 0; i < dgvTK.Rows.Count; i++)
                    {
                        if (dgvTK.Rows[i].Cells[0].Value.ToString().Trim() == txthoten.Text.Trim())
                        {
                            MessageBox.Show("Ho ten ton tai");
                            return;
                        }
                        if (dgvTK.Rows[i].Cells[1].Value.ToString().Trim() == txttk.Text.Trim())
                        {
                            MessageBox.Show("Tai khoan ton tai");
                            return;
                        }
                        if (dgvTK.Rows[i].Cells[2].Value.ToString().Trim() == txtEmail.Text.Trim())
                        {
                            MessageBox.Show("Email ton tai");
                            return;
                        }
                    }
                    TaiKhoan taiKhoan = new TaiKhoan();
                    taiKhoan.HovaTen = txthoten.Text.Trim();
                    taiKhoan.TaiKhoan1 = txttk.Text.Trim();
                    taiKhoan.MatKhau = txtmk.Text.Trim();
                    taiKhoan.Email = txtEmail.Text.Trim();
                    model.TaiKhoans.Add(taiKhoan);
                    model.SaveChanges();
                    FormQLTK_Load(sender, e);
                    MessageBox.Show("Them Tai Khoan Thanh cong");
                }
                else
                {
                    MessageBox.Show("Mat khau Phai co do dai 8-16");
                }
            }
            catch { }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmk.Text.Length >= 8 && txtmk.Text.Length <= 16)
                {
                    ModelDB model = new ModelDB();
                    var find = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == txttk.Text.Trim());
                    var find1 = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() != txttk.Text.Trim() && p.Email.Trim() == txtEmail.Text.Trim());
                    if (find != null)
                    {
                        if (find1 == null)
                        {
                            if (find.VoHieuHoa == null && (checkkhongvohieu.Checked == true || checkvohieuhoa.Checked == true))
                            {
                                MessageBox.Show("Tài khoản chưa liên kết với nhân viên, không thể điều chỉnh chức năng vô hiệu hóa");
                                return;
                            }
                            else
                            {
                                find.Email = txtEmail.Text;
                                if (checkvohieuhoa.Checked == true)
                                {
                                    find.VoHieuHoa = true;
                                }
                                if (checkkhongvohieu.Checked == true)
                                {
                                    find.VoHieuHoa = false;
                                }
                                find.MatKhau = txtmk.Text;

                                // Cập nhật thông tin họ tên
                                find.HovaTen = txthoten.Text;

                                model.SaveChanges();
                                FormQLTK_Load(sender, e);
                                MessageBox.Show("Sửa tài khoản thành công");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tồn tại tài khoản với email khác: " + find1.TaiKhoan1 + " có email " + find1.Email);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sửa tài khoản thất bại do không tìm thấy tài khoản: " + find.TaiKhoan1);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu phải có độ dài từ 8 đến 16 ký tự");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (ModelDB model = new ModelDB())
                    {
                        var find = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == txttk.Text.Trim());

                        if (find != null)
                        {
                            // Check if the account is linked to any employee
                            var linkedEmployee = model.NhanViens.FirstOrDefault(nv => nv.TaiKhoan.Trim() == find.TaiKhoan1.Trim());

                            if (linkedEmployee != null)
                            {
                                // If the account is linked to an employee, show a message and don't allow deletion
                                MessageBox.Show("Tài khoản này đã được liên kết với nhân viên. Không thể xóa!");
                            }
                            else
                            {
                                // If the account is not linked to any employee, proceed with deletion
                                model.TaiKhoans.Remove(find);
                                model.SaveChanges();

                                MessageBox.Show("Xóa tài khoản thành công!");
                                FormQLTK_Load(sender, e); // Refresh the user interface after deletion
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tồn tại tài khoản cần xóa!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
                }
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            txthoten.Text = "";
            txttk.Text = "";
            txtmk.Text = "";
            txtEmail.Text = "";
            checkkhongvohieu.Checked = false;
            checkvohieuhoa.Checked = false;
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txthoten.Text = dgvTK.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txttk.Text = dgvTK.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtmk.Text = dgvTK.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtEmail.Text = dgvTK.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                ModelDB model = new ModelDB();
                var find = model.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == txttk.Text.Trim());
                if (find.VoHieuHoa == null)
                {
                    checkkhongvohieu.Checked = false;
                    checkvohieuhoa.Checked = false;
                }
                else
                {
                    if (find.VoHieuHoa == true)
                    {
                        checkvohieuhoa.Checked = true;
                    }
                    else
                    {
                        checkkhongvohieu.Checked = true;
                    }
                }
            }
            catch
            {
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            formnv.resetform();
        }

        private void txtmk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtmk.Text.Length > 16 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtmk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
