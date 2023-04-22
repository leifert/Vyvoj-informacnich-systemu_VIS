using System;
using DTO;

namespace BussinessLayer.BO.Models
{
    public class ZamestnanecModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string BankUcet { get; set; }
        public DateTime PracovniPomerOd { get; set; }
        
        
        public ZamestnanecModel()
        {
                
        }
        public ZamestnanecModel(Zamestnanec zamestnanec)
        {
            this.Id = zamestnanec.Id;
            this.Login = zamestnanec.Login;
            this.Jmeno = zamestnanec.Jmeno;
            this.Prijmeni = zamestnanec.Prijmeni;
            this.Email = zamestnanec.Email;
            this.Adresa = zamestnanec.Adresa;
            this.Telefon = zamestnanec.Telefon;
            this.BankUcet = zamestnanec.BankUcet;
            this.PracovniPomerOd = zamestnanec.PracovniPomerOd;
            
        }
        
        public Zamestnanec ToDTO()
        {
            Zamestnanec zamestnanec = new Zamestnanec()
            {
                Id = Id,
                Login = Login,
                Jmeno = Jmeno,
                Prijmeni = Prijmeni,
                Email = Email,
                Adresa = Adresa,
                Telefon = Telefon,
                BankUcet = BankUcet,
                PracovniPomerOd = PracovniPomerOd
            };

            return zamestnanec;
        }
    }
}