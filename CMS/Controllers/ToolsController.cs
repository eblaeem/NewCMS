using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CMS.Controllers
{
    public class ToolsController : Controller
    {
        private IWebHostEnvironment _environment;

        public ToolsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult ShowImage(string guid)
        {
            string path = Path.Combine("PageImages", guid.ToString());
            var fileInfo = _environment.WebRootFileProvider.GetFileInfo(path);
            if (fileInfo.Exists)
            {
               return File(fileInfo.CreateReadStream(), "image/jpeg");
            }
            return NotFound();
        }
    }
}
