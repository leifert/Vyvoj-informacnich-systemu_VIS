using System;
using System.Collections.Generic;
using System.Linq;
using BussinessLayer.BO.Controllers;
using BussinessLayer.BO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class PridatRecenziController : Controller
    {
        // GET
        public IActionResult Index()
        {
            List<UzivatelModel> list2 =UzivatelController.SelectAll().ToList();
            ViewBag.uzivatele = new SelectList(list2, "Id", "Login");
            
            List<KoloModel> list3 =KoloController.SelectAll().ToList();
            ViewBag.kola = new SelectList(list3, "Id", "Nazev");
            return View();
        }
        
        public ActionResult SaveRecord(RecenzeModel model)
        {
            try
            {
                List<UzivatelModel> list2 =UzivatelController.SelectAll().ToList();
                ViewBag.uzivatele = new SelectList(list2, "Id", "Login");
                
                List<KoloModel> list3 =KoloController.SelectAll().ToList();
                ViewBag.kola = new SelectList(list3, "Id", "Nazev");
                
                RecenzeModel recenze = new RecenzeModel();
                recenze.Hvezdy = model.Hvezdy;
                recenze.Popis = model.Popis;
                recenze.KoloId = model.KoloId;
                recenze.UzivatelId = model.UzivatelId;
                RecenzeController.Insert(recenze);
                    
                return RedirectToAction("Index", "recenz");
            }

            catch (Exception ex)
            {
                throw ex;

            }
           
        }
    }
    
}