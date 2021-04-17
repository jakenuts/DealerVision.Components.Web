// Copyright (c) DealerVision.com All rights reserved.
// FakeDatabase.cs in DealerVision.Components.Web

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealerVision.Components.Web.Models
{
    public static class FakeDatabase
    {
        public static List<DealerViewModel> Dealers = new List<DealerViewModel>();

        static FakeDatabase()
        {
            Dealers.Add(new DealerViewModel
            {
                Id = 1,
                Name = "Foo", PhoneNumber = "800-FOO-GOGO",
                EmailList1 = new[] {"jim@oneplace.com", "bob@another.com"},
                EmailList2 = new[] {"jim@oneplace.com", "bob@another.com"}
            });

            Dealers.Add(new DealerViewModel
            {
                Id = 2,
                Name = "Bar", PhoneNumber = "900-BAR-OGOG",
                EmailList1 = new[] {"tom@oneplace.com", "sam@another.com"},
                EmailList2 = new[] {"tom@oneplace.com", "sam@another.com"}
            });
        }

        public static DealerViewModel Add(DealerViewModel model)
        {
            if (model.Id == 0)
            {
                model.Id = Dealers.Count + 1;
            }

            Dealers.Add(model);

            return model;
        }
    }
}