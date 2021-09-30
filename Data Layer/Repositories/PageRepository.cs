using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private readonly CMSContext _db;

        public PageRepository(CMSContext db)
        {
            _db = db;
        }
        public IEnumerable<Page> GetAllPage()
        {
            return _db.Pages;
        }

        public Page GetPageById(int pageId)
        {
            return _db.Pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                _db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                _db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(Page page)
        {
            try
            {
                _db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(int pageId)
        {
            try
            {
                var page = GetPageById(pageId);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return _db.Pages.OrderByDescending(p => p.VisitNumber).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return _db.Pages.Where(P => P.ShowInSlideshow);
        }

        public IEnumerable<Page> LatestNews(int take=4)
        {
            return _db.Pages.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageById(int id)
        {
            return _db.Pages.Where(p => p.PageGroupId == id);
        }
    }
}
