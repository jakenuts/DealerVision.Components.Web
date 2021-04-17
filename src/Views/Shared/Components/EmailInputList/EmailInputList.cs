using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DealerVision.Components.Web.Views.Shared.Components.EmailInputList
{
    [ViewComponent]
    public class EmailInputList :  ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync( IList<string> emails, string fieldName )
        {
            var model = new EmailListModel
            {
                Value = emails?.Any() == true ? JsonSerializer.Serialize(emails) : "",
                Name = fieldName
            };

            return View("Default", model);
        }
    }

    public class EmailListModel
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }
}