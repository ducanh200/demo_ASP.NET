using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_MVC.Models
{
    public class BrandEditModel
    {
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Vui Lòng nhập tên danh mục")]
        [MinLength(1, ErrorMessage = "Vui lòng nhập tối thiếu 1 kí tự")]
        [Display(Name = "Tên danh mục")]
        public string name { get; set; }
    }
}
