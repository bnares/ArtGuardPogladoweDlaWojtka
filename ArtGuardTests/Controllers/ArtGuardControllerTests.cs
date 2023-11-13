using Xunit;
using ArtGuard.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGuard.Infrastracture.Domain;

namespace ArtGuard.Controllers.Tests
{
    public class ArtGuardControllerTests
    {
        [Fact()]
        public void DodajPracownikaZZwnatrzDoTransakcjiTest()
        {
            var controller = new ArtGuardController();
            var karta = new KartaDostepu() { Imie = "Wojciech", Nazwisko = "Ostrouch", NumerKarty = 345, Id = 1, Placowka = new NazwaPlacowka() { Nazwa = "Centreum", Id = 1 } };
            controller.DodajPracownikaZZwnatrzDoTransakcji(3);
            Assert.True(ArtGuardController._stanOsobWBudynku["transakcji"].Count > 0);
        }

        [Fact()]
        public void DodajPracownikaZTransakcjiDoOperacjiTest()
        {
            var controller = new ArtGuardController();
            controller.DodajPracownikaZTransakcjiDoOperacji(14);
            Assert.True(ArtGuardController._stanOsobWBudynku["operacyjna"].Count > 1);
        }

        [Fact()]
        public void WStrefieZabezpieczonejMozeBycMax2OsobyTest()
        {
            var controller = new ArtGuardController();
            controller.DodajPracownikaZOperacjiDoZabezpieczonej(1);
            Assert.True(ArtGuardController._stanOsobWBudynku["zabezpieczona"].Count == 2);
        }

        [Fact()]
        public void DozorcaNieWchodziJesliNieMaTamInnegoPracownika()
        {
            var controller = new ArtGuardController();
            controller.DodajPracownikaZZwnatrzDoTransakcji(12);
            Assert.True(ArtGuardController._stanOsobWBudynku["transakcji"].Count == 0);
        }
    }
}