using ArtGuard.Infrastracture.Domain;

namespace ArtGuard.Infrastracture
{
    public static class StanOsobWBudynku
    {
        

        public static Dictionary<string, List<KartaDostepu>> StanOsobowy = new Dictionary<string, List<KartaDostepu>>
        {
            { "zabezpieczona" ,new List<KartaDostepu>()
                 {
                    new KartaDostepu() { Id = 12, Imie = "Barbara", Nazwisko = "Mucha", NumerKarty = 4, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 75, Imie = "Cyprian", Nazwisko = "Norwid", NumerKarty = 4, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }}
                 }
            },

            { "operacyjna" ,new List<KartaDostepu>(){ 
                new KartaDostepu() { Id = 1, Imie = "Tymon", Nazwisko = "Gawryl", NumerKarty = 25, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 } } } 
            },
            { "transakcji" ,new List<KartaDostepu>(){
               // new KartaDostepu() { Id = 14, Imie = "Antoni", Nazwisko = "Wałbrzych", NumerKarty = 29, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }}

            }},
            { "zewnetrzna" ,new List<KartaDostepu>()
                {
                    new KartaDostepu() { Id = 2, Imie = "Marek", Nazwisko = "Nowak", NumerKarty = 22, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 11, Imie = "Andrzej", Nazwisko = "Dawydzik", NumerKarty = 72, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 13, Imie = "Anna", Nazwisko = "Kowalska", NumerKarty = 123, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 3, Imie = "Aleksandra", Nazwisko = "Dworzak", NumerKarty = 153, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 4, Imie = "Krzysztof", Nazwisko = "Jankowski", NumerKarty = 107, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 5, Imie = "Agnieszka", Nazwisko = "Wójcik", NumerKarty = 230, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 6, Imie = "Paweł", Nazwisko = "Nowiski", NumerKarty = 412, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 7, Imie = "Katarzyna", Nazwisko = "Kaczmarek", NumerKarty = 351, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 8, Imie = "TOmasz", Nazwisko = "Adamczyk", NumerKarty = 665, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 9, Imie = "Joanna", Nazwisko = "Sikora", NumerKarty = 725, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 10, Imie = "Piotr", Nazwisko = "Gorski", NumerKarty = 1128, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},
                    new KartaDostepu() { Id = 12, Imie = "Marta", Nazwisko = "Zawadzki", NumerKarty = 1032, Placowka = new NazwaPlacowka() { Nazwa = "Centruem", Id = 1 }},

                }
            }
        };


    }
}
