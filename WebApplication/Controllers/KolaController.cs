using System.Linq;
using BussinessLayer.BO.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class KolaController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(KoloController.SelectAll().ToList());
        }
        
        // GET: Trasa/Details/5
        public ActionResult Details(int id)
        {
            return View(KoloController.GetKoloById(id));
        }
    }
}