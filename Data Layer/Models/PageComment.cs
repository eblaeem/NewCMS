using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "خبر")]
        [MaxLength(50)]
        public int PageId { get; set; }

        [Required]
        [Display(Name = "نام کاربر")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "ایمیل کاربر")]
        [MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "وبسایت کاربر")]
        [MaxLength(200)]
        public string Website { get; set; }

        [Display(Name = "نظر کاربر")]
        [MaxLength(1000)]
        public string Comment { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }


        public virtual Page Page { get; set; }

        public PageComment()
        {

        }
    }
}
