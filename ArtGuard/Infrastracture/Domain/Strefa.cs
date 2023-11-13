namespace ArtGuard.Infrastracture.Domain
{
    public class Strefa
    {
        public int Id { get; set; }
        public string NazwaStrefy { get; set; }
        public int MaksymalnaLiczbaPracownikow { get; set; }
        public List<KartaDostepu> KartaDostepu { get; set; }
        public NazwaPlacowka Placowka { get; set; }

    }
}
