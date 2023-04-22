using System;

namespace DTO
{
    public class Servis
    {
        public int Id { get; set; }
        public DateTime Zacatek { get; set; }
        public DateTime Konec { get; set; }
        public string Popis { get; set; }
        public int KoloId { get; set; }
        public int ZamestnanecId { get; set; }
        public string Zamestnanec { get; set; }
    }
}