using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private readonly CMSContext _db;

        public PageGroupRepository(CMSContext db)
        {
            _db = db;
        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
            return _db.PageGroups;
        }

        public PageGroup GetGroupById(int groupId)
        {
            return _db.PageGroups.Find(groupId);
        }

        public bool InsertGroup(PageGroup pageGroup)
        {
            try
            {
                _db.PageGroups.Add(pageGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                _db.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                _db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                var group = GetGroupById(groupId);
                DeleteGroup(group);
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

        public IEnumerable<ShowGroupViewModel> ShowGroupViews()
        {
            return _db.PageGroups.Select(P => new ShowGroupViewModel()
            {
                GroupId = P.Id,
                GroupTitle = P.Title,
                PageCount = P.Pages.Count
            });
        }
    }
}
