using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Views.Shared.Components
{
    public class ShowGroups : ViewComponent
    {
        private readonly IPageGroupRepository _pageGroupRepository;
        public ShowGroups(IPageGroupRepository pageGroupRepository)
        {
            _pageGroupRepository = pageGroupRepository ;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_pageGroupRepository.ShowGroupViews());
        }
      
    }
}
