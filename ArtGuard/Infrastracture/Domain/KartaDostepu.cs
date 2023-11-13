namespace ArtGuard.Infrastracture.Domain
{
    public class KartaDostepu
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public NazwaPlacowka  Placowka { get; set; }
        public int NumerKarty  { get; set; }



    }
}