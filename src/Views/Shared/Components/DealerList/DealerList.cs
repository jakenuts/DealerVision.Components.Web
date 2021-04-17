using System.Collections.Generic;
using System.Threading.Tasks;
using DealerVision.Components.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DealerVision.Components.Web.Views.Shared.Components.DealerList
{
    [ViewComponent]
    public class DealerList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<DealerViewModel> list)
        {
            return View(list);
        }
    }
}
