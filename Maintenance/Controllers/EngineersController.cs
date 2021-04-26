using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Repositories;
using Maintenance.Models.Employee;

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
        public ActionResult Index(SortState sortOrder = SortState.NameAsc)
        {
            ViewBag.NameSort = sortOrder == SortState.NameDesc ? SortState.NameAsc : SortState.NameDesc;
            List<EngineerModel> result = engineers.ReadAll();

            switch (sortOrder)
            {
                case SortState.NameAsc:
                    result = result.OrderBy(s => s.FullName).ToList();
                    break;
                case SortState.NameDesc:
                    result = result.OrderByDescending(s => s.FullName).ToList();
                    break;
                default:
                    break;
            }

            return View(result);
        }

        // GET: WorkwersController/Details/5
        public ActionResult Details(int id)
        {
            EngineerModel result = engineers.Read(id);
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
        public ActionResult Create(EngineerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    engineers.Create(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
                return View();

        }

        // GET: WorkwersController/Edit/5
        public ActionResult Edit(int id)
        {
            EngineerModel model = engineers.Read(id);
            return View(model);
        }

        // POST: WorkwersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EngineerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    engineers.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", "Home", new { message = e.Message },"");
                    //ModelState.AddModelError ("",e.Message);
                    //return View();
                }
            }
            return View();
        }

        // GET: WorkwersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkwersController/Delete/5
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
