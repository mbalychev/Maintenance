using Maintenance.Models;
using Maintenance.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IServices<ComputerModel> computers;
        public ComputerController (IServices<ComputerModel> services)
        {
            computers = services;
        }
        // GET: ComputerController
        public ActionResult Index()
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // GET: ComputerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ComputerModel model = await computers.ReadAsync(id);
            return View(model);
        }

        // GET: ComputerController/Create
        public ActionResult Create()
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // POST: ComputerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // GET: ComputerController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // POST: ComputerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // GET: ComputerController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }

        // POST: ComputerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }
    }
}
