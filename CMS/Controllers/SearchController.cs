using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPageRepository _pageRepository;

        public SearchController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }
        public IActionResult Index(string search)
        {
            ViewBag.Name = search;
            return View(_pageRepository.SearchPages(search));
        }
    }
}
