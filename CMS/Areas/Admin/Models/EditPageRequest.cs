using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class EditPageRequest : CreatePageRequest
    {
        [Key]
        public int Id { get; set; }
    }
}

