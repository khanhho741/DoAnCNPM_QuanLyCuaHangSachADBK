namespace QuanLyCuaHangSach.Model1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoSach")]
    public partial class KhoSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoSach()
        {
            PhieuNhaps = new HashSet<PhieuNhap>();
            SachTrongKhoes = new HashSet<SachTrongKho>();
        }

        [Key]
        [StringLength(10)]
        public string MaKhoSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKhoSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SachTrongKho> SachTrongKhoes { get; set; }
    }
}
