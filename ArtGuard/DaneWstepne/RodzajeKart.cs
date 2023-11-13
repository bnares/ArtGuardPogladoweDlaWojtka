namespace ArtGuard.DaneWstepne
{
    public class RodzajeKart
    {
        public string WydawanaDlaPracownikow { get; set; }
       
        public int[] NumeryKart { get; set; }

        public RodzajeKart(string wydawanaDla, int dolnyZakresNumerowKart, int gornyZakresNumerowKart)
        {
            WydawanaDlaPracownikow = wydawanaDla;
            
            NumeryKart =Enumerable.Range(dolnyZakresNumerowKart,gornyZakresNumerowKart).ToArray();
        }

    }
}
