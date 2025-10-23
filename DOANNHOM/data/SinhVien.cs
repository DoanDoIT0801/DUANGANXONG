namespace DOANNHOM.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            MuonTraSach = new HashSet<MuonTraSach>();
        }

        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSV { get; set; }

        [Required]
        [StringLength(50)]
        public string NganhHoc { get; set; }

        [Required]
        [StringLength(50)]
        public string KhoaHoc { get; set; }

        public int SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonTraSach> MuonTraSach { get; set; }
    }
}
