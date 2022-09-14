namespace CURD_WINEDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage ="Không được để trống mã sản phẩm")]
        [DisplayName("Mã sản phẩm")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Không được để trống tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        [StringLength(50)]
        public string ProductName { get; set; }


        
        [DisplayName("Mô tả sản phẩm")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "numeric")]
        [Required(ErrorMessage = "Không được để trống giá nhập")]
        [DisplayName("Giá nhập ")]
        public decimal PurchasePrice { get; set; }


        [Required(ErrorMessage = "Không được để trống giá bán")]
        [DisplayName("Giá bán ")]
        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Không được để trống số lượng")]
        [DisplayName("Số lượng ")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Không được để trống xuất xứ")]
        [DisplayName("Xuất xứ ")]
        [StringLength(20)]
        public string Vintage { get; set; }

        [Required(ErrorMessage = "Không được để trống mã loại")]
        [DisplayName("Mã loại ")]
        [StringLength(10)]
        public string CatalogyID { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Ảnh ")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Không được để trống quốc gia")]
        [DisplayName("Quốc gia ")]
        [StringLength(100)]
        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
