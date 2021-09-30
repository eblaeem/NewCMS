using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageCommentRepository: IDisposable
    {
        IEnumerable<PageComment> GetCommentByNewsId(int pageId);

        bool AddComment(PageComment comment);

    }
}
