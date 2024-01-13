using QuanLyCuaHangSach.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class FormHome : Form
    {

        private Boolean showPanelHethong = false;
        private Boolean showPanelSanpham = false;
        private Boolean showPanelKhachhang = false;
        private Boolean showPanelNghiepVu = false;
        private Boolean showPanelThongKe = false;
        private Boolean showPanelKhac = false;

        public FormHome()
        {
            InitializeComponent();
            string directoryPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Images");

            // Tạo một đối tượng DirectoryInfo
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Lấy danh sách tất cả các tệp 
            FileInfo[] fileInfos = directoryInfo.GetFiles();

            // Duyệt qua danh sách các tệp
            foreach (FileInfo fileInfo in fileInfos)
            {
                // In tên của tệp
                ModelDB model = new ModelDB();
                var find = model.Saches.FirstOrDefault(p => p.HinhAnh.Trim() == fileInfo.Name);
                if (find == null)
                {
                    string f = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Images", fileInfo.Name);
                    File.Delete(f);
                }
            }

            string directoryPath1 = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "AnhNV");

            // Tạo một đối tượng DirectoryInfo
            DirectoryInfo directoryInfo1 = new DirectoryInfo(directoryPath1);

            // Lấy danh sách tất cả các tệp 
            FileInfo[] fileInfos1 = directoryInfo1.GetFiles();

            // Duyệt qua danh sách các tệp
            foreach (FileInfo fileInfo in fileInfos1)
            {
                // In tên của tệp
                ModelDB model = new ModelDB();
                var find = model.NhanViens.FirstOrDefault(p => p.HinhAnhNhanVien.Trim() == fileInfo.Name);
                if (find == null)
                {
                    string f = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "AnhNV", fileInfo.Name);
                    File.Delete(f);
                }
            }
            phanquyen();
        }

        public FormHome(string tk)
        {
            InitializeComponent();
            this.taiKhoan = tk;
            string directoryPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Images");

            // Tạo một đối tượng DirectoryInfo
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Lấy danh sách tất cả các tệp 
            FileInfo[] fileInfos = directoryInfo.GetFiles();

            // Duyệt qua danh sách các tệp
            foreach (FileInfo fileInfo in fileInfos)
            {
                // In tên của tệp
                ModelDB model = new ModelDB();
                var find = model.Saches.FirstOrDefault(p => p.HinhAnh.Trim() == fileInfo.Name);
                if (find == null)
                {
                    string f = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Images", fileInfo.Name);
                    File.Delete(f);
                }
            }
            string directoryPath1 = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "AnhNV");

            // Tạo một đối tượng DirectoryInfo
            DirectoryInfo directoryInfo1 = new DirectoryInfo(directoryPath1);

            // Lấy danh sách tất cả các tệp 
            FileInfo[] fileInfos1 = directoryInfo1.GetFiles();

            // Duyệt qua danh sách các tệp
            foreach (FileInfo fileInfo in fileInfos1)
            {
                // In tên của tệp
                ModelDB model = new ModelDB();
                var find = model.NhanViens.FirstOrDefault(p => p.HinhAnhNhanVien.Trim() == fileInfo.Name);
                if (find == null)
                {
                    string f = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "AnhNV", fileInfo.Name);
                    File.Delete(f);
                }
            }
            //ModelDB model1 = new ModelDB();
            //var k = model1.NhanViens.FirstOrDefault(p => p.TaiKhoan.Trim() == tk.Trim());
            //if (k != null)
            //{
            //    if (k.HinhAnhNhanVien != null)
            //    {
            //        string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            //        string imagePath = Path.Combine(parentDirectory, "AnhNV", k.HinhAnhNhanVien);
            //        Image avatarImage = Image.FromFile(imagePath);
            //        picAvatar.Image = avatarImage;
            //    }
            //}
            phanquyen();
        }

        private string userName;
        private string userEmail;

        public FormHome(string userName, string userEmail)
        {
            InitializeComponent();
            this.userName = userName;
            this.userEmail = userEmail;

            labelTen.Text = userName;
            labelName.Text = userName;
            labelEmail.Text = userEmail;
        }

   
        private void phanquyen()
        {

            ModelDB model1 = new ModelDB();
            var find = model1.NhanViens.FirstOrDefault(p => p.TaiKhoan.Trim() == taiKhoan.Trim());
            if (find != null  && (find.LoaiNhanVien.Trim() != "GD" && find.LoaiNhanVien.Trim() != "QLNV"))
            {
                btnQLnhanvien.Enabled = false;
                MessageBox.Show("Đã phân quyền");
            }
            

        }

        public void UpdateLabelName(string userName, string tk, string email)
        {
            ModelDB model1 = new ModelDB();
            var find = model1.NhanViens.FirstOrDefault(p => p.TaiKhoan.Trim() == userName.Trim());
            var find1 = model1.TaiKhoans.FirstOrDefault(p => p.Email.Trim() == email.Trim());
            var find2 = model1.TaiKhoans.FirstOrDefault(p => p.TaiKhoan1.Trim() == tk.Trim());


            labelName.Text = find.TenNhanVien.Trim();
            labelTen.Text = find2.TaiKhoan1.Trim();
            labelEmail.Text = find1.Email.Trim();
        }

        private string hoten;
        private string taiKhoan;
        private string matKhau;
        private string email;
        public void SetUserInfo(string hoten, string taiKhoan, string matKhau, string email)
        {
            this.hoten = hoten;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.email = email;
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        private void tooglePanels()
        {
            if(showPanelHethong)
            {
                panelHethong.Height = 127;
            }
            else
            {
                panelHethong.Height = 0;
            }
            if (showPanelSanpham)
            {
                panelSanPham.Height = 84;
            }
            else
            {
                panelSanPham.Height = 0;
            }
            if (showPanelNghiepVu)
            {
                panelNghiepvu.Height = 166;
            }
            else
            {
                panelNghiepvu.Height = 0;
            }
            if (showPanelKhachhang)
            {
                panelKhachhang.Height = 44;
            }
            else
            {
                panelKhachhang.Height = 0;
            }
            if (showPanelThongKe)
            {
                panelTK.Height = 44;
            }
            else
            {
                panelTK.Height = 0;
            }
            if (showPanelKhac)
            {
                panelKhac.Height = 49;
            }
            else
            {
                panelKhac.Height = 0;
            }
        }

        private void btnHethong_Click(object sender, EventArgs e)
        {
            showPanelSanpham = false;
            showPanelKhachhang = false;
            showPanelNghiepVu = false;
            showPanelThongKe = false;
            showPanelKhac = false;
            showPanelHethong = !showPanelHethong;  

            tooglePanels();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            


        }

      
        private Form currentForm;
        private void OpenFormChild(Form formChild)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            panelBody.Controls.Add(formChild);
            panelBody.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }

       

      

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void MoveForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MoveForm();
        }

        private void buttonTK_Click(object sender, EventArgs e)
        {
            showPanelSanpham = false;
            showPanelKhachhang = false;
            showPanelNghiepVu = false;
            showPanelHethong = false;
            showPanelKhac = false;
            showPanelThongKe = !showPanelThongKe;

            tooglePanels();
        }

        private void buttonKhac_Click(object sender, EventArgs e)
        {
            showPanelSanpham = false;
            showPanelKhachhang = false;
            showPanelNghiepVu = false;
            showPanelThongKe = false;
            showPanelHethong = false;
            showPanelKhac = !showPanelKhac;

            tooglePanels();
        }

        private void buttonSanpham_Click(object sender, EventArgs e)
        {
            showPanelHethong = false;
            showPanelKhachhang = false;
            showPanelNghiepVu = false;
            showPanelThongKe = false;
            showPanelKhac = false;
            showPanelSanpham = !showPanelSanpham;

            tooglePanels();
        }

        private void buttonKhachhang_Click(object sender, EventArgs e)
        {
            showPanelSanpham = false;
            showPanelHethong = false;
            showPanelNghiepVu = false;
            showPanelThongKe = false;
            showPanelKhac = false;
            showPanelKhachhang = !showPanelKhachhang;

            tooglePanels();
        }

        private void btnNghiepvu_Click(object sender, EventArgs e)
        {
            showPanelSanpham = false;
            showPanelKhachhang = false;
            showPanelHethong = false;
            showPanelThongKe = false;
            showPanelKhac = false;
            showPanelNghiepVu = !showPanelNghiepVu;

            tooglePanels();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
               
                FormLogin formLogin = new FormLogin();
                formLogin.Show();

                this.Close(); 
            }
        }

        private void btnTongquan_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormTrangchu());
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormThongke());

        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            FormTaikhoan formTaiKhoan = new FormTaikhoan();

            formTaiKhoan.SetAccountInfo(hoten, taiKhoan, matKhau, email);

            OpenFormChild(formTaiKhoan);
        }

        private void btnQLsach_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormSach());

        }

        private void btnQLnhapsach_Click(object sender, EventArgs e)
        {

        }

        private void btnQLnhanvien_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormNhanvien());

        }

        private void btnQLKho_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormKho());

        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormKhachhang());

        }

        private void btnPhieugiao_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormNhapHang());


        }

        private void btnHoadon_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormHoadon());

        }

        private void btnCaidat_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormCaiDat());

        }

        private void btnBansach_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormBanSach());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormCaiDat());
        }

        private void buttonHotro_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormHotro());
        }

        private void labelTen_Click(object sender, EventArgs e)
        {

        }

        private void btnTiemkiem_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormKhuyenMai());

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Lấy chuỗi tìm kiếm từ TextBox
            string tuKhoa = guna2TextBox1.Text.Trim().ToLower();

          
            bool timThay = "khách hàng".Contains(tuKhoa); 
            bool timThay1 = "sách".Contains(tuKhoa);
            bool timThay2 = "hóa đơn".Contains(tuKhoa); 
            bool timThay3 = "kho".Contains(tuKhoa); 
            bool timThay4 = "nhập hàng".Contains(tuKhoa); 
            bool timThay5 = "hỗ trợ".Contains(tuKhoa);
            bool timThay6 = "bán".Contains(tuKhoa);
            bool timThay7 = "tổng quan".Contains(tuKhoa); 

            if (timThay)
            {
                OpenFormChild(new FormKhachhang());
            }
            if (timThay1)
            {
                OpenFormChild(new FormSach());
            }
            if (timThay2)
            {
                OpenFormChild(new FormHoadon());
            }
            if (timThay3)
            {
                OpenFormChild(new FormKho());
            }
            if (timThay4)
            {
                OpenFormChild(new FormNhapHang());
            }
            if (timThay5)
            {
                OpenFormChild(new FormHotro());
            }
            if (timThay6)
            {
                OpenFormChild(new FormBanSach());
            }
            if (timThay7)
            {
                OpenFormChild(new FormTrangchu());
            }
        }
    }
}
