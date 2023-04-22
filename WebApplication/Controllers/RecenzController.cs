using System.Linq;
using BussinessLayer.BO.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class RecenzController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(RecenzeController.SelectAll().ToList());
        }

        public IActionResult Details(int id)
        {
            return RedirectToAction("Details", "Kola" ,new { id });
        }
    }
}