using CMS.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class NewsController : Controller
    {
        private readonly IPageRepository _pageRepository;
        private readonly IPageCommentRepository _pageCommentRepository;
        private readonly ILogger<HomeController> _logger;

        public NewsController(IPageRepository pageRepository,
            IPageCommentRepository pageCommentRepository,
            ILogger<HomeController> logger)
        {
            _pageRepository = pageRepository;
            _pageCommentRepository = pageCommentRepository;
            _logger = logger;
        }

        public async Task<IActionResult> ArchiveNews()
        {
            return View(_pageRepository.GetAllPage());
        }

        public async Task<IActionResult> ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(_pageRepository.ShowPageById(id));
        }

        public async Task<IActionResult> ShowNews(int id)
        {
            var news = _pageRepository.GetPageById(id);
            if (news != null)
            {
                news.VisitNumber += 1;
                _pageRepository.UpdatePage(news);
                _pageRepository.Save();
                return View(news);
            }
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }

        public async Task<IActionResult> AddComment(AddCommnetViewModel model)
        {
            PageComment comment = new PageComment
            {
                PageId = model.Id,
                Name = model.Name,
                Email = model.Email,
                Comment = model.Comment,
                CreateDate = DateTime.Now
            };
            _pageCommentRepository.AddComment(comment);
            return null;
        }

        public async Task<IActionResult> ShowComments(int id)
        {
            return PartialView(_pageCommentRepository.GetCommentByNewsId(id));
        }
    }
}
