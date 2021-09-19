using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class CreatePageRequest
    {

        [Required]
        [Display(Name = "گروه خبر")]
        public int PageGroupId { get; set; }

        [Required]
        [Display(Name = "عنوان خبر")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "توضیحات")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "شرح خبر")]
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Display(Name = "نام تصویر")]
        [MaxLength(50)]
        public string ImageName { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlideshow { get; set; }

        public SelectList PageGroups { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        public IFormFile UploadImage { get; set; }
    }
}

