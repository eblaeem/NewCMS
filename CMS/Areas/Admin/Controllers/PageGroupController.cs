using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageGroupController : Controller
    {

        private IPageGroupRepository _pageGroupRepository;

        public PageGroupController(IPageGroupRepository pageGroupRepository)
        {
            _pageGroupRepository = pageGroupRepository;
        }

        //GET: Admin/PageGroups
        public IActionResult Index()
        {
            return View(_pageGroupRepository.GetAllGroups());
        }


        //GET: Admin/PageGroups/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            //Im sure id is not null because of if 
            PageGroup pageGroup = _pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return StatusCode(404);
            }
            return View(pageGroup);
        }

        //GET: Admin/PageGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Admin/PageGroups/Create
        [HttpPost]
        public IActionResult Create(PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                _pageGroupRepository.InsertGroup(pageGroup);
                _pageGroupRepository.Save();
                return RedirectToAction("Index");
            };
            return View(pageGroup);
        }

        //GET: Admin/PageGroups/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = _pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return StatusCode(404);
            }
            return View(pageGroup);
        }

        //POST: Admin/PageGroups/Edit
        [HttpPost]
        public IActionResult Edit(PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                _pageGroupRepository.UpdateGroup(pageGroup);
                _pageGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        //GET: Admin/PageGroups/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = _pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return StatusCode(404);
            }
            return View(pageGroup);
        }

        //POST: Admin/PageGroups/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _pageGroupRepository.DeleteGroup(id);
            _pageGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pageGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
