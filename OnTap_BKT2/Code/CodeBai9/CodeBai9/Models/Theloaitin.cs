namespace CodeBai9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theloaitin")]
    public partial class Theloaitin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Theloaitin()
        {
            Tintucs = new HashSet<Tintuc>();
        }

        [Key]
        public int IDLoai { get; set; }

        [StringLength(100)]
        public string Tentheloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}
