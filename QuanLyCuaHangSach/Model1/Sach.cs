namespace QuanLyCuaHangSach.Model1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietNhapSaches = new HashSet<ChiTietNhapSach>();
            SachTrongKhoes = new HashSet<SachTrongKho>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSach { get; set; }

        public decimal GiaBan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTacGia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXuatBan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTheLoaiSach { get; set; }

        [StringLength(2500)]
        public string NDTomTat { get; set; }

        [StringLength(150)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapSach> ChiTietNhapSaches { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoaiSach TheLoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SachTrongKho> SachTrongKhoes { get; set; }
    }
}
