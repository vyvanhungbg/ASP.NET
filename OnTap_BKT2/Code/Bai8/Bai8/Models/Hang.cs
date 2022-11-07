﻿namespace Bai8.Models
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
        [Required(ErrorMessage ="Mã hàng không được để trống")]
        [DisplayName("Mã hàng")]
        public string MaHang { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Mã nhà cung cấp")]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Mã hàng không được để trống")]
        [StringLength(255)]
        [DisplayName("Tên hàng")]
        public string TenHang { get; set; }

        [Required(ErrorMessage = "Lượng có không được để trống")]
        [DisplayName("Giá")]
        public decimal? Gia { get; set; }

        [DisplayName("Lượng có")]
        public decimal LuongCo { get; set; }

        [StringLength(1000)]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }

        [DisplayName("Chiết khấu")]
        public decimal? ChietKhau { get; set; }

        [StringLength(100)]
        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }

        public virtual Nha_CC Nha_CC { get; set; }
    }
}
