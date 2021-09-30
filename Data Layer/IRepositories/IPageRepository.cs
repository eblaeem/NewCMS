using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAllPage();

        Page GetPageById(int pageId);

        bool InsertPage(Page page);

        bool UpdatePage(Page page);

        bool DeletePage(Page page);

        bool DeletePage(int pageId);

        void Save();

        IEnumerable<Page> TopNews(int take=4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LatestNews(int take =4);
        IEnumerable<Page> ShowPageById(int id);
    }
}
