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
    public class MaintenancesPlan : Controller
    {
        private readonly IServices<MaintenancePlanModel> plans;
        public MaintenancesPlan(IServices<MaintenancePlanModel> service)
        {
            plans = service;
        }
        // GET: MaintenancesPlan
        public async Task<ActionResult> Index(int idHardWare)
        {
            List<MaintenancePlanModel> models = await plans.ReadAllAsync(idHardWare);
            return View(models);
        }

        // GET: MaintenancesPlan/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id != 0)
            {
                MaintenancePlanModel model = await plans.ReadAsync(id);
                return View(model);
            }
            return null;
        }

        // GET: MaintenancesPlan/Create
        public ActionResult Create()
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживаеться в демо версии"});
        }

        // POST: MaintenancesPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MaintenancePlanModel model)
        {
            try
            {
                await plans.CreateAsync(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
            return View();
        }

        // GET: MaintenancesPlan/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживаеться в демо версии" });
        }

        // POST: MaintenancesPlan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaintenancesPlan/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживаеться в демо версии" });
        }

        // POST: MaintenancesPlan/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
