using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Views.Shared.Components.TopNews
{
    public class TopNews: ViewComponent
    {
        private readonly IPageRepository _pageRepository;

        public TopNews(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_pageRepository.TopNews());
        }
    }
}
