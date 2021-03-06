using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

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

        [Display(Name = "آمار بازدید")]
        public int? VisitNumber { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }

        [Display(Name = "نام تصویر")]
        [MaxLength(50)]
        public string ImageName { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlideshow { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }


        public virtual PageGroup PageGroup { get; set; }

        private ICollection<PageComment> _pageComments;
        public virtual ICollection<PageComment> PageComments
        {
            get => _pageComments ??= new HashSet<PageComment>();
            set => _pageComments = value;
        }

    }
}
