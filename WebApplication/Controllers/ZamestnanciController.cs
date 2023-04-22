using System.Linq;
using BussinessLayer.BO.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class ZamestnanciController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(ZamestnanecController.SelectAll().ToList());
        }
        public IActionResult Export()
        {
            ZamestnanecController.ExportToXml(); 
            return RedirectToAction("Index", "zamestnanci");
        }
    }
}