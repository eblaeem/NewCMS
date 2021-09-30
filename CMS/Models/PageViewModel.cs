using DataLayer;
using System.Collections.Generic;

namespace CMS.Models
{
    public class PageViewModel 
    {
        public IEnumerable<Page> Slider { get; set; }
        public IEnumerable<Page> LatestNews { get; set; }        
    }
}
