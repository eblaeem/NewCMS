using CMS.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageRepository _pageRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPageRepository pageRepository,ILogger<HomeController> logger)
        {
            _pageRepository = pageRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var pages = new PageViewModel
            {
                Slider = _pageRepository.PagesInSlider(),
                LatestNews = _pageRepository.LatestNews()
            };        
            
            return View(pages);
        }

    }
}
