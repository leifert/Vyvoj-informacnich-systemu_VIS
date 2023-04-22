using DTO;

namespace BussinessLayer.BO.Models
{
    public class UzivatelModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        
        
        public UzivatelModel()
        {
                
        }
        public UzivatelModel(Uzivatel uzivatel)
        {
            this.Id = uzivatel.Id;
            this.Login = uzivatel.Login;
            this.Jmeno = uzivatel.Jmeno;
            this.Prijmeni = uzivatel.Prijmeni;
            this.Email = uzivatel.Email;
            this.Adresa = uzivatel.Adresa;
            this.Telefon = uzivatel.Telefon;
            
        }
        
        public Uzivatel ToDTO()
        {
            Uzivatel uzivatel = new Uzivatel()
            {
                Id = Id,
                Login = Login,
                Jmeno = Jmeno,
                Prijmeni = Prijmeni,
                Email = Email,
                Adresa = Adresa,
                Telefon = Telefon
            };

            return uzivatel;
        }
    }
}