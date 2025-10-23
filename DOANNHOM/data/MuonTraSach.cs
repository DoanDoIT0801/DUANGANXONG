namespace DOANNHOM.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuonTraSach")]
    public partial class MuonTraSach
    {
        [Key]
        public int MaPhieuMuon { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTra { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
