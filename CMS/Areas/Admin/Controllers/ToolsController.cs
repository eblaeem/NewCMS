using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Controllers
{
    public class ToolsController : Controller
    {
        private IWebHostEnvironment _environment;

        public ToolsController(IWebHostEnvironment environment)
        {

            _environment = environment;
        }

        public IActionResult ShwoImage(Guid guid)
        {   string fileName = ;
            string contentRootPath = _environment.ContentRootPath;
            string path = Path.Combine(contentRootPath, "PageImages",);
            return View();
        }
    }
}
