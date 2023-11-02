using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_MVC.Models
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Vui Lòng nhập tên danh mục")]
        [MinLength(6, ErrorMessage = "Vui lòng nhập tối thiếu 6 kí tự")]
        [Display(Name = "Tên danh mục")]
        public string name { get; set; }
    }
}
