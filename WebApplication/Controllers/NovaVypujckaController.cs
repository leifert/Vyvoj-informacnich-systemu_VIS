using System;
using System.Collections.Generic;
using System.Linq;
using BussinessLayer.BO.Controllers;
using BussinessLayer.BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class NovaVypujckaController : Controller
    {
        // GET
        public IActionResult Index()
        {
            List<UzivatelModel> list =UzivatelController.SelectAll().ToList();
            ViewBag.data = new SelectList(list, "Id", "Login");
            
            List<ZamestnanecModel> list2 =ZamestnanecController.SelectAll().ToList();
            ViewBag.zamestnanci = new SelectList(list2, "Id", "Login");
            
            List<KoloModel> list3 =KoloController.SelectAll().ToList();
            ViewBag.kola = new SelectList(list3, "Id", "Nazev");
            return View();
        }
        [HttpPost]

        public ActionResult SaveRecord(VypujckaModel model)
        {
            try
            {
                List<UzivatelModel> list =UzivatelController.SelectAll().ToList();

                ViewBag.data = new SelectList(list, "Id", "Login");
                
                List<ZamestnanecModel> list2 =ZamestnanecController.SelectAll().ToList();
                ViewBag.zamestnanci = new SelectList(list2, "Id", "Login");
                
                List<KoloModel> list3 =KoloController.SelectAll().ToList();
                ViewBag.kola = new SelectList(list3, "Id", "Nazev");
                
                VypujckaModel vypujcka = new VypujckaModel();
                vypujcka.Zacatek = model.Zacatek;
                vypujcka.Konec = model.Konec;
                vypujcka.Cena = model.Cena;
                vypujcka.ZamestnanecId = model.ZamestnanecId;
                vypujcka.KoloId = model.KoloId;
                vypujcka.UzivatelId = model.UzivatelId;
                VypujckaController.Insert(vypujcka);
                    
                return RedirectToAction("Index", "Vypujcky");
            }

            catch (Exception ex)
            {
                throw ex;

            }
           
        }
    }
}