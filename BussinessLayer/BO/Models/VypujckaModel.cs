using System;
using DTO;

namespace BussinessLayer.BO.Models
{
    public class VypujckaModel
    {
        public int Id { get; set; }
        public DateTime Zacatek { get; set; }
        public DateTime Konec { get; set; }
        public int Doba { get; set; }
        public int Cena { get; set; }
        public int ZamestnanecId { get; set; }
        public int UzivatelId { get; set; }
        public int KoloId { get; set; }
        public string Zamestnanec { get; set; }
        public string Uzivatel { get; set; }
        
        
        public VypujckaModel()
        {
                
        }
        public VypujckaModel(Vypujcka vypujcka)
        {
            this.Id = vypujcka.Id;
            this.Zacatek = vypujcka.Zacatek;
            this.Konec = vypujcka.Konec;
            this.Cena = vypujcka.Cena;
            this.ZamestnanecId = vypujcka.ZamestnanecId;
            this.UzivatelId = vypujcka.UzivatelId;
            this.KoloId = vypujcka.KoloId;
            this.Zamestnanec = vypujcka.Zamestnanec;
            this.Uzivatel = vypujcka.Uzivatel;
            
        }
        
        public Vypujcka ToDTO()
        {
            Vypujcka vypujcka = new Vypujcka()
            {
                Id = Id,
                Zacatek = Zacatek,
                Konec = Konec,
                Cena = Cena,
                ZamestnanecId = ZamestnanecId,
                UzivatelId = UzivatelId,
                KoloId = KoloId,
                Zamestnanec = Zamestnanec,
                Uzivatel = Uzivatel
            };

            return vypujcka;
        }
        
    }
}