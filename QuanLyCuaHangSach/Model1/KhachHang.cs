namespace QuanLyCuaHangSach.Model1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            TheDocGias = new HashSet<TheDocGia>();
        }

        [Key]
        public int MaKhachHang { get; set; }

        [Required]
        [StringLength(250)]
        public string HoTenKhachHang { get; set; }

        [Required]
        [StringLength(10)]
        public string SDT_KhachHang { get; set; }

        [StringLength(250)]
        public string DiaChiKhachHang { get; set; }

        public int GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        public int LoaiKhachHang { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public virtual LoaiKhachHang LoaiKhachHang1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheDocGia> TheDocGias { get; set; }
    }
}
