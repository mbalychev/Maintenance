using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Repositories;
using Maintenance.Models;
using Maintenance.Services;

namespace Maintenance.Controllers
{
    public class MonitorController : Controller
    {
        private readonly IServices<MonitorModel> monitors;

        public MonitorController(IServices<MonitorModel> service)
        {
            monitors = service;
        }
        // GET: MonitorController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: MonitorController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            MonitorModel model;
            try
            {
                model = await monitors.ReadAsync(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
            if (model != null)
                return View(model);
            else
                return RedirectToAction("Error", "Home", new { message = "модель монитора не найдена" });
        }

        // GET: MonitorController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonitorController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MonitorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await monitors.CreateAsync(model);
                    return RedirectToAction("HardWare", "Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View();
                    //return RedirectToAction("Error", "Home", new { message = ex.Message });
                }
            }
            else
                return View();
        }

        // GET: MonitorController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonitorController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MonitorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await monitors.UpdateAsync(model);
                    return RedirectToAction("Details", new { id = model.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View();
                }
            }
            else
                return View();
        }

        // GET: MonitorController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonitorController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(MonitorModel model)
        {
            try
            {
                await monitors.DeleteAsync(model.Id);
                return RedirectToAction("HardWare", "Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
