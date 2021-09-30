using CMS.Models;
using DataLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private IWebHostEnvironment _environment;
        private readonly IPageRepository _pageRepository;
        private readonly IPageGroupRepository _pageGroupRepository;

        public PageController(IPageRepository pageRepository, 
                                IPageGroupRepository pageGroupRepository, 
                                IWebHostEnvironment environment)
        {
            _pageRepository = pageRepository;
            _pageGroupRepository = pageGroupRepository;
            _environment = environment;
        }


        // GET: Admin/Page
        public IActionResult Index()
        {
            return View(_pageRepository.GetAllPage());
        }

        // GET: Admin/Page/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Page page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return StatusCode(404);
            }
            return View(page);
        }

        // GET: Admin/Page/Create
        public IActionResult Create()
        {
            var pageGroups = _pageGroupRepository.GetAllGroups();
            var model = new CreatePageRequest()
            {
                PageGroups = new SelectList(pageGroups, nameof(PageGroup.Id), nameof(PageGroup.Title))
            };
            return View(model);
        }

        // POST: Admin/Page/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreatePageRequest request)
        {
            if (ModelState.IsValid)
            {
                var page = new Page
                {
                    PageGroupId = request.PageGroupId,
                    Title = request.Title,
                    ShortDescription = request.ShortDescription,
                    Text = request.Text,
                    ShowInSlideshow = request.ShowInSlideshow,
                    CreateDate = DateTime.Now
            };
                var uploadImage = request.UploadImage;
                if (uploadImage != null)
                {
                    page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);
                    string webRootPath = _environment.WebRootPath;
                    var path = Path.Combine(webRootPath, "PageImages", page.ImageName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await uploadImage.CopyToAsync(stream);
                    }
                }

                _pageRepository.InsertPage(page);
                _pageRepository.Save();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: Admin/Page/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Page page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return StatusCode(404);
            }

            var pageGroups = _pageGroupRepository.GetAllGroups();

            var model = new EditPageRequest()
            {
                Id = page.Id,
                PageGroupId = page.PageGroupId,
                Title = page.Title,
                ShortDescription = page.ShortDescription,
                Text = page.Text,
                ShowInSlideshow = page.ShowInSlideshow,
                ImageName = page.ImageName,
                PageGroups = new SelectList(pageGroups, nameof(PageGroup.Id), nameof(PageGroup.Title))
            };

            return View(model);
        }

        // POST: Admin/Page/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(EditPageRequest request)
        {
            if (ModelState.IsValid)
            {
                var page = new Page
                {
                    Id = request.Id,
                    PageGroupId = request.PageGroupId,
                    Title = request.Title,
                    ShortDescription = request.ShortDescription,
                    Text = request.Text,
                    ShowInSlideshow = request.ShowInSlideshow,
                    ImageName = request.ImageName,
                    CreateDate = DateTime.Now,
                };
                var uploadImage = request.UploadImage;
                if (uploadImage != null )
                {
                    if (request.UploadImage != null)
                    {
                        page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);
                        string webRootPath = _environment.WebRootPath;
                        string path = Path.Combine(webRootPath, "PageImages", uploadImage.FileName);
                        System.IO.File.Delete(path);
                        page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);
                        using (Stream stream = new FileStream(path, FileMode.Create))
                        {
                            await uploadImage.CopyToAsync(stream);
                        }
                    }
                }
                _pageRepository.UpdatePage(page);
                _pageRepository.Save();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: Admin/Page/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Page page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return StatusCode(404);
            }
            return View(page);
        }

        // POST: Admin/Page/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var page = _pageRepository.GetPageById(id);
            if (page.ImageName != null)
            {
                string webRootPath = _environment.WebRootPath;
                System.IO.File.Delete(Path.Combine(webRootPath, "PageImages", page.ImageName));
            }
            _pageRepository.DeletePage(page);
            _pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
