using DTO;

namespace BussinessLayer.BO.Models
{
    public class KoloModel
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public string Typ { get; set; }
        public string Popis { get; set; }
        public int Zaloha { get; set; }
        public int CenaDen { get; set; }
        public int CenaVikend { get; set; }
        public int CenaTyden { get; set; }
        public int Dostupnost { get; set; }
        
        public KoloModel()
        {
                
        }
        public KoloModel(Kolo kolo)
        {
            this.Id = kolo.Id;
            this.Nazev = kolo.Nazev;
            this.Typ = kolo.Typ;
            this.Popis = kolo.Popis;
            this.Zaloha = kolo.Zaloha;
            this.CenaDen = kolo.CenaDen;
            this.CenaVikend = kolo.CenaVikend;
            this.CenaTyden = kolo.CenaTyden;
            this.Dostupnost = kolo.Dostupnost;
        }
        public Kolo ToDTO()
        {
            Kolo kolo = new Kolo()
            {
                Id = Id,
                Nazev = Nazev,
                Typ = Typ,
                Popis = Popis,
                Zaloha = Zaloha,
                CenaDen = CenaDen,
                CenaVikend = CenaVikend,
                CenaTyden = CenaTyden,
                Dostupnost = Dostupnost
            };

            return kolo;
        }
        
    }
    
}