using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Views.Shared.Components.ShowGroupsInMenu
{
    public class ShowGroupsInMenu : ViewComponent
    {
        private readonly IPageGroupRepository _pageGroupRepository;

        public ShowGroupsInMenu(IPageGroupRepository pageGroupRepository)
        {
            _pageGroupRepository = pageGroupRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_pageGroupRepository.GetAllGroups());
        }
    }
}
