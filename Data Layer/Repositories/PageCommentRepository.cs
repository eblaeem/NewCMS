using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private readonly CMSContext _db;

        public PageCommentRepository(CMSContext db)
        {
            _db = db;
        }

        public bool AddComment(PageComment comment)
        {
            try
            {
                _db.PageComments.Add(comment);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<PageComment> GetCommentByNewsId(int pageId)
        {
            return _db.PageComments.Where(P => P.Id == pageId);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
