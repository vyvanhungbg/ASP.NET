namespace OnTapDe3_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        [Key]
        [StringLength(10)]
        [DisplayName("Mã hàng")]
        [Required(ErrorMessage ="Mã hàng không được để trống")]
        public string Mahang { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên hàng không được để trống")]
        [DisplayName("Tên hàng")]
        public string Tenhang { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Loại hàng không được để trống")]
        [DisplayName("Loại hàng")]
        public string Loai { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [DisplayName("Giá")]
        public int? Gia { get; set; }
    }
}
