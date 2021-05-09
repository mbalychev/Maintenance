using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Maintenance.Models;
using Maintenance.Services;
using Maintenance.Entities;
using Maintenance.Repositories;

namespace Maintenance.Controllers
{
    public class HardWaresController : Controller
    {
        private readonly IHardWaresService<HardWareModel> hardWares;

        public HardWaresController(IHardWaresService<HardWareModel> hardWareService)
        {
            hardWares = hardWareService;
        }

        // HACK: изменить получение типа оборудования
        public async Task<IActionResult> Index(string serialNumber, string type = "All")
        {
            List<HardWareModel> models = await hardWares.ReadAllAsync();
            ViewBag.SNFilter = serialNumber;
            ViewBag.Types = new SelectList(HardWareModel.TypesRead,"Type", "Description", type);
            switch (type)
            {
                case "Monitor":
                    models = await hardWares.ReadMonitorsAsync();
                    break;
                case "Computer":
                    models = await hardWares.ReadComputersAsync();
                    break;
                case "FiscalRegistrator":
                    models = await hardWares.ReadFiscalsAsync();
                    break;

                default:
                    break;
            }

            if (!String.IsNullOrEmpty(serialNumber))
                models = models.Where(x => x.SerialNumber.Contains(serialNumber)).ToList();
            return View(models);
        }

        // HACK: изменить получение типа оборудования
        public async Task<IActionResult> Details(int id)
        {
            HardWareModel model = await hardWares.ReadAsync(id);
            switch (model.TypeModel)
            {
                case ("Monitor"):
                    return RedirectToAction("Details", "Monitor", new { id = id });
                case ("Computer"):
                    return RedirectToAction("Details", "Computer", new { id = id });
                case ("FiscalRegistrator"):
                    return RedirectToAction("Details", "FiscalRegistrator", new { id = id });
                default:
                    return RedirectToAction("Home", "Error", new { message = "не определен тип модели" });
            }
        }

        public IActionResult Create()
        {
            return RedirectToAction("Error", "Home", new { message = "не поддерживается в демо версии" });
        }
    }
}
