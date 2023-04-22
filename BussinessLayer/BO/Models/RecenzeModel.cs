using DTO;

namespace BussinessLayer.BO.Models
{
    public class RecenzeModel
    {
        public int Id { get; set; }
        public int Hvezdy { get; set; }
        public string Popis { get; set; }
        public int KoloId { get; set; }
        public int UzivatelId { get; set; }
        public string Uzivatel { get; set; }
        
        public RecenzeModel()
        {
                
        }
        public RecenzeModel(Recenze recenze)
        {
            this.Id = recenze.Id;
            this.Hvezdy = recenze.Hvezdy;
            this.Popis = recenze.Popis;
            this.KoloId = recenze.KoloId;
            this.UzivatelId = recenze.UzivatelId;
            this.Uzivatel = recenze.Uzivatel;
            
        }
        
        public Recenze ToDTO()
        {
            Recenze recenze = new Recenze()
            {
                Id = Id,
                Hvezdy = Hvezdy,
                Popis = Popis,
                KoloId = KoloId,
                UzivatelId = UzivatelId,
                Uzivatel = Uzivatel
            };

            return recenze;
        }
    }
}