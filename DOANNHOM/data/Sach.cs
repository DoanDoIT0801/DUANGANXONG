namespace DOANNHOM.data
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
            MuonTraSach = new HashSet<MuonTraSach>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSach { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTacGia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaXB { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoai { get; set; }

        public int SoTrang { get; set; }

        public int GiaBan { get; set; }

        public int SoLuong { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonTraSach> MuonTraSach { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
