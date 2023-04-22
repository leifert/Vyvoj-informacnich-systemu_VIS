using System.Linq;
using BussinessLayer.BO.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class VypujckyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(VypujckaController.SelectAll().ToList());
        }
    }
}