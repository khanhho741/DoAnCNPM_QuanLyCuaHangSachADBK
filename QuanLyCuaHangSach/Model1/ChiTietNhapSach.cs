namespace QuanLyCuaHangSach.Model1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhapSach")]
    public partial class ChiTietNhapSach
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuNhap { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime NgayNhap { get; set; }

        public int SoLuongNhap { get; set; }

        public decimal GiaNhap { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
