using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class CreatePageRequest
    {
        public int PageGroupId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Text { get; set; }

        public string Tags { get; set; }

        public string ImageName { get; set; }

        public bool ShowInSlideshow { get; set; }

        public SelectList PageGroups { get; set; }

        public DateTime CreateDate { get; set; }

        public IFormFile UploadImage { get; set; }
    }
}

