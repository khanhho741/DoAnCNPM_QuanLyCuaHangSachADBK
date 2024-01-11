namespace QuanLyCuaHangSach.Model1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SachTrongKho")]
    public partial class SachTrongKho
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaKhoSach { get; set; }

        public int SoLuongTon { get; set; }

        public virtual KhoSach KhoSach { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
