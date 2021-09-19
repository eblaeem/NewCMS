using System;
using System.Collections.Generic;
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


    }
}
