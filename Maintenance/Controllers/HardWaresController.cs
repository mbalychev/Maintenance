using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Maintenance.Models;
using Maintenance.Repositories;

namespace Maintenance.Controllers
{
    public class HardWaresController : Controller
    {
        private readonly IHardWaresService hardWares;

        public HardWaresController(IHardWaresService service)
        {
            hardWares = service;
        }

        // GET: HardWares
        public async Task<IActionResult> Index(string type)
        {
            List<HardWareModel> models = await hardWares.ReadAllAsync();

            ViewBag.Types = new SelectList(HardWareModel.TypesRead,"Type", "Description");
            switch (type)
            {
                case "Monitor":
                    models = await hardWares.ReadMonitorsAsync();

                    break;
                default:
                    break;
            }

            return View(models);
        }

        // GET: HardWares/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hardWareModel = await _context.HardWareModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (hardWareModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hardWareModel);
        //}

        //// GET: HardWares/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: HardWares/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,SerialNumber,ManufacturerId,InstallationDate")] HardWareModel hardWareModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(hardWareModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hardWareModel);
        //}

        //// GET: HardWares/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hardWareModel = await _context.HardWareModel.FindAsync(id);
        //    if (hardWareModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(hardWareModel);
        //}

        //// POST: HardWares/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SerialNumber,ManufacturerId,InstallationDate")] HardWareModel hardWareModel)
        //{
        //    if (id != hardWareModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(hardWareModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HardWareModelExists(hardWareModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hardWareModel);
        //}

        //// GET: HardWares/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hardWareModel = await _context.HardWareModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (hardWareModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hardWareModel);
        //}

        //// POST: HardWares/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var hardWareModel = await _context.HardWareModel.FindAsync(id);
        //    _context.HardWareModel.Remove(hardWareModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool HardWareModelExists(int id)
        //{
        //    return _context.HardWareModel.Any(e => e.Id == id);
        //}
    }
}
