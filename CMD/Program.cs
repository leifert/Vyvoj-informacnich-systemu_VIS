using System;
using System.Collections.ObjectModel;
using BussinessLayer.BO;
using BussinessLayer.BO.Controllers;
using BussinessLayer.BO.Models;

namespace CMD
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {

            // KoloModel koloModel = new KoloModel()
            // {
            //     Nazev = "GHOST Kato Pro 29",
            //     Typ = "Horské",
            //     Popis = "Ghost Kato to je rychlý a obratný hardtail, který ti přinese spoustu zábavy jak na běžných cyklostezkách, tak i mimo ně.",
            //     Zaloha = 500,
            //     CenaDen = 500,
            //     CenaVikend = 800,
            //     CenaTyden = 3000,
            //     Dostupnost = 1
            // };
            // KoloController.Insert(koloModel);
            //
            // KoloModel koloModel2 = new KoloModel()
            // {
            //     Nazev = "PELLS Razzer Pro",
            //     Typ = "Horské",
            //     Popis = "Pells Razzer Pro je horské kolo pro sportovně založené jezdce.",
            //     Zaloha = 500,
            //     CenaDen = 500,
            //     CenaVikend = 800,
            //     CenaTyden = 3000,
            //     Dostupnost = 1
            // };
            // KoloController.Insert(koloModel2);
            //
            // KoloModel koloModel3 = new KoloModel()
            // {
            //     Nazev = "LAPIERRE Sensium",
            //     Typ = "Silniční",
            //     Popis = "Lapierre již od roku 2002 spolupracuje s profesionálním silničním týmem FDJ. Tato spolupráce se promítá do kompletní modelové řady silničních kol Lapierre.",
            //     Zaloha = 500,
            //     CenaDen = 500,
            //     CenaVikend = 800,
            //     CenaTyden = 3000,
            //     Dostupnost = 1
            // };
            // KoloController.Insert(koloModel3);
            
            // Seznam kol
            Console.WriteLine("\nSeznam kol");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}", "idKola", "nazev", "cenaDen");
            Collection<KoloModel> kola = KoloController.SelectAll();
            foreach (KoloModel i in kola)
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", i.Id, i.Nazev, i.CenaDen);

            
            // UzivatelModel uzivatelModel = new UzivatelModel()
            // {
            //    Login = "test123",
            //    Jmeno = "karel",
            //    Prijmeni = "Novak",
            //    Email = "karliknovaku@seznam.cz",
            //    Adresa = "Novodvorská 96, Opava",
            //    Telefon = "756956250"
            //    
            // };
            // UzivatelController.Insert(uzivatelModel);
            //
            //  UzivatelModel uzivatelModel2 = new UzivatelModel()
            // {
            //    Login = "pil123",
            //    Jmeno = "Vojta",
            //    Prijmeni = "Pilný",
            //    Email = "pilny@seznam.cz",
            //    Adresa = "Smetanova 14, Opava",
            //    Telefon = "789541332"
            //    
            // };
            // UzivatelController.Insert(uzivatelModel2);
            //
            // UzivatelModel uzivatelModel3 = new UzivatelModel()
            // {
            //     Login = "Mar565",
            //     Jmeno = "Adam",
            //     Prijmeni = "Mareček",
            //     Email = "marekad@seznam.cz",
            //     Adresa = "Krasnohorská, Ostrava",
            //     Telefon = "756956250"
            //    
            // };
            // UzivatelController.Insert(uzivatelModel3);
            
          
            // Seznam uzivatelu
            Console.WriteLine("\nSeznam uzivatelu");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}", "iduzivatele", "jmeno", "prijmeni");
            Collection<UzivatelModel> uzivatele = UzivatelController.SelectAll();
            foreach (UzivatelModel i in uzivatele)
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", i.Id, i.Jmeno, i.Prijmeni);
            
            
            // ZamestnanecModel zamestnanecModel = new ZamestnanecModel()
            // {
            //    Login = "tvr456",
            //    Jmeno = "František",
            //    Prijmeni = "Tvrdý",
            //    Email = "tvrdyfranta@seznam.cz",
            //    Adresa = "Malinová 14, Opava",
            //    Telefon = "605987425",
            //    BankUcet = "65045060",
            //    PracovniPomerOd =  new DateTime(2020, 1, 1)
            //    
            // };
            // ZamestnanecController.Insert(zamestnanecModel);
            //
            // ZamestnanecModel zamestnanecModel2 = new ZamestnanecModel()
            // {
            //     Login = "Mek589",
            //     Jmeno = "Martin",
            //     Prijmeni = "Měkký",
            //     Email = "mekkymartin@seznam.cz",
            //     Adresa = "Nerudová 14, Opava",
            //     Telefon = "754132687",
            //     BankUcet = "541065970",
            //     PracovniPomerOd =  new DateTime(2020, 1, 1)
            //    
            // };
            // ZamestnanecController.Insert(zamestnanecModel2);
            //
            // ZamestnanecModel zamestnanecModel3 = new ZamestnanecModel()
            // {
            //     Login = "Voj156",
            //     Jmeno = "David",
            //     Prijmeni = "Vojaček",
            //     Email = "vojnadavid@seznam.cz",
            //     Adresa = "Svobodová 15, Opava",
            //     Telefon = "754864112",
            //     BankUcet = "640510879",
            //     PracovniPomerOd =  new DateTime(2020, 1, 1)
            //    
            // };
            // ZamestnanecController.Insert(zamestnanecModel3);
            
           
            
            // Seznam zamestnancu
            Console.WriteLine("\nSeznam zamestnancu");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}", "idzam", "jmeno", "prijmeni");
            Collection<ZamestnanecModel> zamestnanci = ZamestnanecController.SelectAll();
            foreach (ZamestnanecModel i in zamestnanci)
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", i.Id, i.Jmeno, i.Prijmeni);

            
            
            // ServisModel servisModel = new ServisModel()
            // {
            //     Zacatek =  new DateTime(2021, 5, 12),
            //     Konec =  new DateTime(2021, 5, 15),
            //     Popis =  "Běžný servis",
            //     KoloId =  1,
            //     ZamestnanecId = 1,
            //    
            // };
            // ServisController.Insert(servisModel);
            //
            // ServisModel servisModel2 = new ServisModel()
            // {
            //     Zacatek =  new DateTime(2021, 5, 22),
            //     Konec =  new DateTime(2021, 5, 26),
            //     Popis =  "Běžný servis",
            //     KoloId =  2,
            //     ZamestnanecId = 2,
            //    
            // };
            // ServisController.Insert(servisModel2);
            
            // Seznam servisu
            Console.WriteLine("\nSeznam servisu");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "idservis", "zacatek", "konec","idkolo","idzamestnanec","zamestnanec");
            Collection<ServisModel> servisy = ServisController.SelectAll();
            foreach (ServisModel i in servisy)
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", i.Id, i.Zacatek, i.Konec,i.KoloId,i.ZamestnanecId,i.Zamestnanec);
            
            
            // RecenzeModel recenzeModel = new RecenzeModel()
            // {
            //     Hvezdy = 9,
            //     Popis = "Super kolo!",
            //     KoloId = 1,
            //     UzivatelId = 1
            //    
            // };
            // RecenzeController.Insert(recenzeModel);
            
            // Seznam recenzí
            Console.WriteLine("\nSeznam recenzi");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "idrecenze", "hodnoceni", "popis","idkolo","iduzivatel","uzivatel");
            Collection<RecenzeModel> recenzes = RecenzeController.SelectAll();
            foreach (RecenzeModel i in recenzes)
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", i.Id, i.Hvezdy, i.Popis,i.KoloId,i.UzivatelId,i.Uzivatel);
            
            
            // VypujckaModel vypujckaModel = new VypujckaModel()
            // {
            //     Zacatek = new DateTime(2021, 4, 20),
            //     Konec= new DateTime(2021, 4, 21),
            //     Cena = 500,
            //     ZamestnanecId = 1,
            //     KoloId = 1,
            //     UzivatelId = 1
            //
            // };
            // VypujckaController.Insert(vypujckaModel);
            
            // Seznam vypujcek
            Console.WriteLine("\nSeznam vypujcek");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", "idvypujcky", "zacatek", "konec","cena","idzamestnanec","zamestnanec","koloid","uzivatelid","uzivatel");
            Collection<VypujckaModel> vypujcky = VypujckaController.SelectAll();
            foreach (VypujckaModel i in vypujcky)
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", i.Id,i.Zacatek,i.Konec,i.Cena,i.ZamestnanecId,i.Zamestnanec,i.KoloId,i.UzivatelId,i.Uzivatel);
            ZamestnanecController.ExportToXml();
            Console.ReadLine();

          

        }
    }
}