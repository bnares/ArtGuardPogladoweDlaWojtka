namespace ArtGuard.DaneWstepne
{
    public static class DanePoczatkowe
    {
        public static NazwyStref[] GenerujNazwyStref()
        {
            var dane = new NazwyStref[]
            {
                new NazwyStref(){Nazwa="zabezpieczona", DostepDlaPracownikowTypu=new string[]{"Guard","Menadżer","Dozorca"}, MaxPojemnosc=2},
                new NazwyStref(){Nazwa="operacyjna", DostepDlaPracownikowTypu=new string[]{"Guard","Operator","Menadżer","Dozorca"}, MaxPojemnosc=5},
                new NazwyStref(){Nazwa="transakcji", DostepDlaPracownikowTypu=new string[]{"Guard","Operator","Handlarz","Menadżer","Dozorca"}, MaxPojemnosc=7},
                new NazwyStref(){Nazwa="zewnetrzna", DostepDlaPracownikowTypu=new string[]{"Guard","Operator","Handlarz","Menadżer","Klient","Dozorca"}, MaxPojemnosc=int.MaxValue},

            };
            return dane;
        }

        public static RodzajeKart[] GenerujNazwyKart()
        {
            var dane = new RodzajeKart[]
            {
                new RodzajeKart("Menadzerowie",1,99),
                new RodzajeKart("Guard",100,100),
                new RodzajeKart("Operator",201,299),
                new RodzajeKart("Handlarz",501,498),
                new RodzajeKart("Dozorca",1000,3000),
            };
            return dane;
        }
    }
}
