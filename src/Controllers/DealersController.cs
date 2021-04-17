// Copyright (c) DealerVision.com All rights reserved.
// DealersController.cs in DealerVision.Components.Web

using System.Linq;
using System.Threading.Tasks;
using DealerVision.Components.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DealerVision.Components.Web.Controllers
{
    /// <summary>
    /// Just a basic crud controller, nothing custom here.
    /// </summary>
    public class DealersController : Controller
    {
        // GET: DealersController
        public ActionResult Index()
        {
            var viewModel = FakeDatabase.Dealers;

            return View(viewModel);
        }

        // GET: DealersController/Create
        public ActionResult Create()
        {
            var model = new DealerViewModel();

            return View("Edit", model);
        }

        // POST: DealersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealerViewModel dealer)
        {
            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            try
            {
                FakeDatabase.Add(dealer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Edit", dealer);
            }
        }

        // GET: DealersController/Edit/5
        public ActionResult Edit(int id)
        {
            var dealer = FakeDatabase.Dealers.FirstOrDefault(d => d.Id == id);
            return View(dealer);
        }

        // POST: DealersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DealerViewModel dealer)
        {
            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            try
            {
                var index = FakeDatabase.Dealers.FindIndex(d => d.Id == dealer.Id);

                if (index > 0)
                {
                    FakeDatabase.Dealers[index] = dealer;
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}