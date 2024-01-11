using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyCuaHangSach.Model1
{
    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=Model14")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietNhapSach> ChiTietNhapSaches { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhoSach> KhoSaches { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoaiNhanVien> LoaiNhanViens { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<SachTrongKho> SachTrongKhoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TheDocGia> TheDocGias { get; set; }
        public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.MaSach)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietNhapSach>()
                .Property(e => e.MaSach)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietNhapSach>()
                .Property(e => e.GiaNhap)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SoTienThanhToan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaTheDocGia)
                .IsFixedLength();

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT_KhachHang)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.TheDocGias)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoSach>()
                .Property(e => e.MaKhoSach)
                .IsFixedLength();

            modelBuilder.Entity<KhoSach>()
                .HasMany(e => e.PhieuNhaps)
                .WithRequired(e => e.KhoSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoSach>()
                .HasMany(e => e.SachTrongKhoes)
                .WithRequired(e => e.KhoSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.LoaiKhachHang1)
                .HasForeignKey(e => e.LoaiKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiNhanVien>()
                .Property(e => e.MaLoaiNhanVien)
                .IsFixedLength();

            modelBuilder.Entity<LoaiNhanVien>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.LoaiNhanVien1)
                .HasForeignKey(e => e.LoaiNhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.LoaiNhanVien)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDTNhanVien)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuNhaps)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength();

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.SDTNhaXuatBan)
                .IsFixedLength();

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.NhaXuatBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.MaKhoSach)
                .IsFixedLength();

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.ChiTietNhapSaches)
                .WithRequired(e => e.PhieuNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsFixedLength();

            modelBuilder.Entity<Sach>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTacGia)
                .IsFixedLength();

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength();

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTheLoaiSach)
                .IsFixedLength();

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.ChiTietNhapSaches)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.SachTrongKhoes)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SachTrongKho>()
                .Property(e => e.MaSach)
                .IsFixedLength();

            modelBuilder.Entity<SachTrongKho>()
                .Property(e => e.MaKhoSach)
                .IsFixedLength();

            modelBuilder.Entity<TacGia>()
                .Property(e => e.MaTacGia)
                .IsFixedLength();

            modelBuilder.Entity<TacGia>()
                .Property(e => e.SDTTacGia)
                .IsFixedLength();

            modelBuilder.Entity<TacGia>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.TacGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TaiKhoan1)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.TaiKhoan1)
                .HasForeignKey(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheDocGia>()
                .Property(e => e.MaTheDocGia)
                .IsFixedLength();

            modelBuilder.Entity<TheDocGia>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.TheDocGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoaiSach>()
                .Property(e => e.MaTheLoaiSach)
                .IsFixedLength();

            modelBuilder.Entity<TheLoaiSach>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.TheLoaiSach)
                .WillCascadeOnDelete(false);
        }
    }
}
