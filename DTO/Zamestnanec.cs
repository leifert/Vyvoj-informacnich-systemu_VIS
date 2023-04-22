using System;

namespace DTO
{
    public class Zamestnanec
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
    }
}