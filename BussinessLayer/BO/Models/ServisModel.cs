using System;
using DTO;

namespace BussinessLayer.BO.Models
{
    public class ServisModel
    {
        public int Id { get; set; }
        public DateTime Zacatek { get; set; }
        public DateTime Konec { get; set; }
        public string Popis { get; set; }
        public int KoloId { get; set; }
        public int ZamestnanecId { get; set; }
        public string Zamestnanec { get; set; }
        
        public ServisModel()
        {
                
        }
        public ServisModel(Servis servis)
        {
            this.Id = servis.Id;
            this.Zacatek = servis.Zacatek;
            this.Konec = servis.Konec;
            this.Popis = servis.Popis;
            this.KoloId = servis.KoloId;
            this.ZamestnanecId = servis.ZamestnanecId;
            this.Zamestnanec = servis.Zamestnanec;
            
            
        }
        
        public Servis ToDTO()
        {
            Servis servis = new Servis()
            {
                Id = Id,
                Zacatek = Zacatek,
                Konec = Konec,
                Popis = Popis,
                KoloId = KoloId,
                ZamestnanecId = ZamestnanecId,
                Zamestnanec = Zamestnanec
            };

            return servis;
        }
        
    }
}