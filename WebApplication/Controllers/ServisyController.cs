using System.Linq;
using BussinessLayer.BO.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class ServisyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(ServisController.SelectAll().ToList());
        }
        // GET: Trasa/Details/5
        public ActionResult Details(int id)
        {
           return RedirectToAction("Details", "Kola" ,new { id });
            //return View(KoloController.GetKoloById(id));
            
        }
    }
}