using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "عنوان گروه خبر")]
        [MaxLength(50)]
        public string Title { get; set; }


        public virtual ICollection<Page> Pages { get; set; }

        public PageGroup()
        {

        }
    }
}
