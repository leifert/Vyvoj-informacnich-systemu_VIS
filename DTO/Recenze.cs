namespace DTO
{
    public class Recenze
    {
        public int Id { get; set; }
        public int Hvezdy { get; set; }
        public string Popis { get; set; }
        public int KoloId { get; set; }
        public int UzivatelId { get; set; }
        public string Uzivatel { get; set; }
    }
}