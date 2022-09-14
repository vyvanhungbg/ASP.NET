namespace CodeBai9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tintuc")]
    public partial class Tintuc
    {
        [Key]
        public int IdTin { get; set; }

        public int? IDLoai { get; set; }

        [StringLength(100)]
        public string Tieudetin { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidungtin { get; set; }

        public virtual Theloaitin Theloaitin { get; set; }
    }
}
