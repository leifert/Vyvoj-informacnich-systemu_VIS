using System;

namespace DTO
{
    public class Vypujcka
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
    }
}