    namespace QuanLyCuaHangSach.Model1
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity.Spatial;

        [Table("ChiTietHoaDon")]
        public partial class ChiTietHoaDon
        {
            [Key]
            [Column(Order = 0)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int MaHoaDon { get; set; }

            [Key]
            [Column(Order = 1)]
            [StringLength(10)]
            public string MaSach { get; set; }

            public int SoLuong { get; set; }

            public virtual HoaDon HoaDon { get; set; }

            public virtual Sach Sach { get; set; }
        }
    }
