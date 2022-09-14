namespace CURD_WINEDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogy")]
    public partial class Catalogy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalogy()
        {
            Products = new HashSet<Product>();
        }

        [StringLength(10)]
        [Required(ErrorMessage ="Không được để trống ID loại")]
        [DisplayName("Mã loại")]
        public string CatalogyID { get; set; }

        [Required(ErrorMessage = "Không được để trống Tên loại")]
        [DisplayName("Tên loại")]
        [StringLength(50)]
        public string CatalogyName { get; set; }

       
        [DisplayName("Mô tả")]
        [StringLength(100)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
