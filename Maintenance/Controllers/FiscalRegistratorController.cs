using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Services;
using Maintenance.Models;

namespace Maintenance.Controllers
{
    public class FiscalRegistratorController : Controller
    {
        private readonly IServices<FiscalRegistratorModel> fiscals; 
        public FiscalRegistratorController(IServices<FiscalRegistratorModel> services)
        {
            fiscals = services;
        }
        // GET: FiscalRegistratorController
        public ActionResult Index()
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // GET: FiscalRegistratorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            FiscalRegistratorModel model = await fiscals.ReadAsync(id);
            return View(model);
        }

        // GET: FiscalRegistratorController/Create
        public ActionResult Create()
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // POST: FiscalRegistratorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // GET: FiscalRegistratorController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // POST: FiscalRegistratorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // GET: FiscalRegistratorController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // POST: FiscalRegistratorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }
    }
}
