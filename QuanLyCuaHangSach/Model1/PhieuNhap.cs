namespace QuanLyCuaHangSach.Model1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            ChiTietNhapSaches = new HashSet<ChiTietNhapSach>();
        }

        [Key]
        public int MaPhieuNhap { get; set; }

        public DateTime NgayLapPhieu { get; set; }

        public int MaNhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKhoSach { get; set; }

        public decimal TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapSach> ChiTietNhapSaches { get; set; }

        public virtual KhoSach KhoSach { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
