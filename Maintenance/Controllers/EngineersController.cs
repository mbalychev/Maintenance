using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Repositories;
using Maintenance.Models.Employee;
using Maintenance.Models;

namespace Maintenance.Controllers
{
    public class EngineersController : Controller
    {
        private readonly IServices<EngineerModel> engineers;
        public EngineersController (IServices<EngineerModel> service)
        {
            engineers = service;
        }
        // GET: WorkwersController
        public async Task<ActionResult> Index(SortState sortOrder)
        {
            ViewBag.NameSort = sortOrder == SortState.NameDesc ? SortState.NameAsc : SortState.NameDesc;
            ViewBag.MainSort = sortOrder == SortState.MaintenanceDesc ? SortState.MaintenanceAsc : SortState.MaintenanceDesc;

            List<EngineerModel> result = await engineers.ReadAllAsync();

            switch (sortOrder)
            {
                case SortState.NameAsc:
                    result = result.OrderBy(s => s.FullName).ToList();
                    break;
                case SortState.NameDesc:
                    result = result.OrderByDescending(s => s.FullName).ToList();
                    break;
                case SortState.MaintenanceAsc:
                    result = result.OrderBy(s => s.CountMaintenance).ToList();
                    break;
                case SortState.MaintenanceDesc:
                    result = result.OrderByDescending(s => s.CountMaintenance).ToList();
                    break;
                default:
                    break;
            }

            return View(result);
        }

        // GET: WorkwersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            EngineerModel result = null;
            try
            {
                result = await engineers.ReadAsync(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
            return View(result);
        }

        // GET: WorkwersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkwersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EngineerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await engineers.CreateAsync(model);
                    return RedirectToAction(nameof(Index));
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

        // GET: WorkwersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EngineerModel model = null;
            try
            {
                model = await engineers.ReadAsync(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message }, "");
            }
            return View(model);
        }

        // POST: WorkwersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EngineerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await engineers.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        // GET: WorkwersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EngineerModel model;
            try
            {
                model = await engineers.ReadAsync(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", ex.Message);
            }
            return View(model);
        }

        // POST: WorkwersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(EngineerModel model)
        {
            try
            {
                await engineers.DeleteAsync(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
    }
}
