using ArtGuard.DaneWstepne;
using ArtGuard.Infrastracture;
using ArtGuard.Infrastracture.Domain;
using ArtGuard.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArtGuard.Controllers
{

    public class ArtGuardController : Controller
    {
        public static  Dictionary<string, List<KartaDostepu>> _stanOsobWBudynku = StanOsobWBudynku.StanOsobowy;
        public  NazwyStref[] _dostepneStrefyWBudynku = DanePoczatkowe.GenerujNazwyStref();
        public  RodzajeKart[] _dostepneRodzajeKart = DanePoczatkowe.GenerujNazwyKart();


        
        public IActionResult Index()
        {
            
            return View(_stanOsobWBudynku);
        }

        

        [HttpGet]
        public IActionResult DanePracownikWTransakcji(int id)
        {
            var karta = _stanOsobWBudynku["transakcji"].FirstOrDefault(x=>x.Id == id);
            if(karta==null) return NotFound();
            return View(karta); 
            
        }

        public IActionResult DanePracownikWTransakcji(KartaDostepu karta)
        {
            return View(karta);
        }

        [HttpGet]
        public IActionResult DanePracownikWZewnetrznej(int id)
        {
            
            var karta = _stanOsobWBudynku["zewnetrzna"].FirstOrDefault(x => x.Id == id);
            if (karta == null) return NotFound();
            return View(karta);
            
        }

        public IActionResult DanePracownikWZewnetrznej(KartaDostepu karta)
        {
            return View(karta);
        }

        [HttpGet]
        public IActionResult DanePracownikWOperacyjnej(int id)
        {
            var karta = _stanOsobWBudynku["operacyjna"].FirstOrDefault(x => x.Id == id);
            if (karta == null) return NotFound();
            return View(karta);
            
        }


        public IActionResult DanePracownikWOperacyjnej(KartaDostepu karta)
        {
            return View(karta);
        }

        [HttpGet]
        public IActionResult DanePracownikWZabezpieczonej(int id)
        {
            var karta = _stanOsobWBudynku["zabezpieczona"].FirstOrDefault(x => x.Id == id);
            if (karta == null) return NotFound();
            return View(karta);
        }

        public IActionResult DanePracownikWZabezpieczonej(KartaDostepu karta)
        {
            return View(karta);
        }

        public IActionResult UsunPracownikaZZabezpieczona(int id)
        {
            var karta = _stanOsobWBudynku["zabezpieczona"].FirstOrDefault(x => x.Id == id);
            Notification notification;
            if (_stanOsobWBudynku["operacyjna"].Count < _dostepneStrefyWBudynku.First(x=>x.Nazwa=="operacyjna").MaxPojemnosc)
            {
                _stanOsobWBudynku["zabezpieczona"].Remove(karta);
                _stanOsobWBudynku["operacyjna"].Add(karta);
                notification = new Notification("warning", $"{karta.Nazwisko} Usuniety z Zabezpieczonej");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            notification = new Notification("error", $"Upss cos poszlo nie tak");
            TempData["Notification"] = JsonConvert.SerializeObject(notification);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UsunPracownikaZOperacyjna(int id)
        {
            var karta = _stanOsobWBudynku["operacyjna"].FirstOrDefault(x => x.Id == id);
            Notification notification;
            if (_stanOsobWBudynku["transakcji"].Count < _dostepneStrefyWBudynku.First(x => x.Nazwa == "transakcji").MaxPojemnosc)
            {
                _stanOsobWBudynku["operacyjna"].Remove(karta);
                _stanOsobWBudynku["transakcji"].Add(karta);
                notification = new Notification("warning", $"{karta.Nazwisko} Usuniety z Operacyjnej");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction("Index", _stanOsobWBudynku);
            }
            notification = new Notification("error", $"Upss cos poszlo nie tak");
            TempData["Notification"] = JsonConvert.SerializeObject(notification);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UsunPracownikaZTransakcyjna(int id)
        {
            var karta = _stanOsobWBudynku["transakcji"].FirstOrDefault(x => x.Id == id);
            Notification notification;
            if (_stanOsobWBudynku["zewnetrzna"].Count < _dostepneStrefyWBudynku.First(x => x.Nazwa == "zewnetrzna").MaxPojemnosc)
            {
                _stanOsobWBudynku["transakcji"].Remove(karta);
                _stanOsobWBudynku["zewnetrzna"].Add(karta);
                notification = new Notification("warning", $"{karta.Nazwisko} Usuniety z Transakcji");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            notification = new Notification("error", $"Upss cos poszlo nie tak");
            TempData["Notification"] = JsonConvert.SerializeObject(notification);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UsunPracownikaZZewnetrzna(int id)
        {
            var karta = _stanOsobWBudynku["zewnetrzna"].FirstOrDefault(x => x.Id == id);
            var kartaZabezpieczona = _stanOsobWBudynku["zabezpieczona"].FirstOrDefault(x => x.Id == id);
            Notification notification;
            if (karta!=null)
            {
                _stanOsobWBudynku["zewnetrzna"].Remove(karta);
                notification = new Notification("warning", $"{karta.Nazwisko} Usuniety z Zewnatrz");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            notification = new Notification("error", $"Upss cos poszlo nie tak");
            TempData["Notification"] = JsonConvert.SerializeObject(notification);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DodajPracownikaZZwnatrzDoTransakcji(int id)
        {
            var karta = _stanOsobWBudynku["zewnetrzna"].FirstOrDefault(x => x.Id == id);
            Notification notification;
            if(karta==null) return RedirectToAction(nameof(Index));
            if(karta.NumerKarty>=1 && karta.NumerKarty<=999 && _stanOsobWBudynku["transakcji"].Count<_dostepneStrefyWBudynku.First(x=>x.Nazwa== "transakcji").MaxPojemnosc)
            {
                _stanOsobWBudynku["transakcji"].Add(karta);
                _stanOsobWBudynku["zewnetrzna"].Remove(karta);
                notification = new Notification("success", $"{karta.Nazwisko} Preszedł do Transakcji");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            if(karta.NumerKarty>=1000 && _stanOsobWBudynku["transakcji"].Any(x=>x.NumerKarty<1000))
            {
                _stanOsobWBudynku["transakcji"].Add(karta);
                _stanOsobWBudynku["zewnetrzna"].Remove(karta);
                notification = new Notification("success", $"{karta.Nazwisko} Preszedł do Transakcji");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            notification = new Notification("error", $"Zbyt duzo lub brak uprawnien");
            TempData["Notification"] = JsonConvert.SerializeObject(notification);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DodajPracownikaZTransakcjiDoOperacji(int id)
        {
            var karta = _stanOsobWBudynku["transakcji"].FirstOrDefault(x => x.Id == id);
            Notification notification;
            if (karta == null) return RedirectToAction(nameof(Index));
            if (karta.NumerKarty <= 200 && karta.NumerKarty>=1 && _stanOsobWBudynku["operacyjna"].Count < _dostepneStrefyWBudynku.First(x => x.Nazwa == "operacyjna").MaxPojemnosc)
            {
                _stanOsobWBudynku["operacyjna"].Add(karta);
                _stanOsobWBudynku["transakcji"].Remove(karta);
                notification = new Notification("success", $"{karta.Nazwisko} Preszedł do Operacyjnej");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            if (karta.NumerKarty >= 1000 && _stanOsobWBudynku["operacyjna"].Any(x => x.NumerKarty <= 200))
            {
                _stanOsobWBudynku["operacyjna"].Add(karta);
                _stanOsobWBudynku["transakcji"].Remove(karta);
                notification = new Notification("success", $"{karta.Nazwisko} Preszedł do Operacyjnej");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            notification = new Notification("error", $"Zbyt duzo lub brak uprawnien");
            TempData["Notification"] = JsonConvert.SerializeObject(notification);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult DodajPracownikaZOperacjiDoZabezpieczonej(int id)
        {
            var karta = _stanOsobWBudynku["operacyjna"].FirstOrDefault(x => x.Id == id);
            Notification notification;
            if (karta == null) return RedirectToAction(nameof(Index));
            if (karta.NumerKarty < 100 && karta.NumerKarty >= 1 && _stanOsobWBudynku["zabezpieczona"].Count < _dostepneStrefyWBudynku.First(x => x.Nazwa == "zabezpieczona").MaxPojemnosc)
            {
                _stanOsobWBudynku["zabezpieczona"].Add(karta);
                _stanOsobWBudynku["operacyjna"].Remove(karta);
                notification = new Notification("success", $"{karta.Nazwisko} Preszedł do Zabezpieczonej");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            if (karta.NumerKarty >= 1000 && _stanOsobWBudynku["zabezpieczona"].Any(x => x.NumerKarty < 100))
            {
                _stanOsobWBudynku["zabezpieczona"].Add(karta);
                _stanOsobWBudynku["operacyjna"].Remove(karta);
                notification = new Notification("success", $"{karta.Nazwisko} Preszedł do Zabezpieczonej");
                TempData["Notification"] = JsonConvert.SerializeObject(notification);
                return RedirectToAction(nameof(Index));
            }
            notification = new Notification("error", $"Zbyt duzo lub brak uprawnien");
            TempData["Notification"] = JsonConvert.SerializeObject(notification);
            return RedirectToAction(nameof(Index));
        }

    }
}
