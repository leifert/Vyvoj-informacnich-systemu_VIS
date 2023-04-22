using System;
using System.Collections.Generic;
using System.Linq;
using BussinessLayer.BO.Controllers;
using BussinessLayer.BO.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class NovyServisController : Controller
    {
        // GET
        public IActionResult Index()
        {
            List<ZamestnanecModel> list2 =ZamestnanecController.SelectAll().ToList();
            ViewBag.zamestnanci = new SelectList(list2, "Id", "Login");
            
            List<KoloModel> list3 =KoloController.SelectAll().ToList();
            ViewBag.kola = new SelectList(list3, "Id", "Nazev");
            return View();
        }
        
        public ActionResult SaveRecord(ServisModel model)
        {
            try
            {
                List<ZamestnanecModel> list2 =ZamestnanecController.SelectAll().ToList();
                ViewBag.zamestnanci = new SelectList(list2, "Id", "Login");
                
                List<KoloModel> list3 =KoloController.SelectAll().ToList();
                ViewBag.kola = new SelectList(list3, "Id", "Nazev");
                
                ServisModel servis = new ServisModel();
                servis.Zacatek = model.Zacatek;
                servis.Konec = model.Konec;
                servis.Popis = model.Popis;
                servis.KoloId = model.KoloId;
                servis.ZamestnanecId = model.ZamestnanecId;
                ServisController.Insert(servis);
                    
                return RedirectToAction("Index", "servisy");
            }

            catch (Exception ex)
            {
                throw ex;

            }
           
        }
    }
}