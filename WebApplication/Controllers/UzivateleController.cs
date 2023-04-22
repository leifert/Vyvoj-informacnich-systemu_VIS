using System.Linq;
using BussinessLayer.BO.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class UzivateleController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(UzivatelController.SelectAll().ToList());
        }
    }
}