using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using Projekt.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Projekt.Controllers
{

    
    public class HomeController : Controller
    {
        /// <summary>
        /// Az összes adat, amit felfogunk használni a program folyamata közben
        /// </summary>
        [BindProperty]
        private IEnumerable<Osszesitett> osszesitett { get; set; }
        private readonly UserManager<ProjektUser> _userManager;
        private readonly SignInManager<ProjektUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly NovenyContext _context;
        public HomeController(ILogger<HomeController> logger, NovenyContext context, SignInManager<ProjektUser> signInManager,UserManager<ProjektUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            

            ///A betegség, az előfordulás, és a kigyűjtött kifejezéseket
            ///egy listába elmentjük külön-külön,ez azért érdemes, mivel
            ///a legőrdülőmenüben mindegyiknek megkell majd jelenni a feltöltés
            ///oldalon
            Osszesitett.betegseg = _context.Betegseg.ToList();
            Osszesitett.elofordulas = _context.Elofordulas.ToList();
            Osszesitett.gyujtott = _context.Gyujtott.ToList();
            osszesitett =
                     from felhasznalas in _context.Felhasznalas join elofordulas in _context.Elofordulas on felhasznalas.Elo_Id equals elofordulas.ID
                     join novenyek in _context.Novenyek on felhasznalas.ID equals novenyek.Felh_Id
                     join betegseg in _context.Betegseg on felhasznalas.Betegseg_ID equals betegseg.ID
                     join gyujtott in _context.Gyujtott on felhasznalas.Gyujtott_id equals gyujtott.ID
                     select new Osszesitett
                     {
                         ID = novenyek.ID,
                         Magyar = novenyek.Magyar,
                         Latin = novenyek.Latin,
                         Honap = elofordulas.Honap,
                         Resz = gyujtott.Resz,
                         Tipus = betegseg.Tipus,
                         Kep = novenyek.Kep,
                         Leiras=novenyek.Informacio


                     };

        }

        /// <summary>
        /// Feltöltés oldalnak a BackEnd része:
        /// Minten paraméter POST metódussal lesz átadva
        /// </summary>
        /// <param name="Latin">latin neve a növénynek</param>
        /// <param name="Magyar">magyar neve a növénynek</param>
        /// <param name="Honap">a növény átadott hónapja</param>
        /// <param name="Resz">a növény átadott része</param>
        /// <param name="Tipus">a növény átadott típusa</param>
        /// <param name="file">feltöltött kép bináris kódja</param>
        /// <param name="leiras">a növény átadott leírása</param>
        /// <returns></returns>
        [HttpPost, ActionName("Upload")]
        public async Task<IActionResult> Add(string Latin, string Magyar, string Honap, string Resz, string Tipus, IFormFile file,string leiras)
        {
            ///Ezek lesznek a legőrdülő menük
            IEnumerable<Betegseg> betegseg = _context.Betegseg.ToList();
            IEnumerable<Elofordulas> elofordulas = _context.Elofordulas.ToList();
            IEnumerable<Gyujtott> gyujtott = _context.Gyujtott.ToList();


            ///id ket keresünk a legürdőlőmenükben megadott adatot alapján
            int eId, gyId, bId;
            eId = gyId = bId = 0;
            eId = elofordulas.First(x => x.Honap == Honap).ID;
            gyId = gyujtott.First(x => x.Resz == Resz).ID;
            bId = betegseg.First(x => x.Tipus == Tipus).ID;
            var size = file.Length;
            var kepnev = file.FileName;

            var path = Path.Combine("wwwroot/images/novenyek", file.FileName);
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            ///A felhasználás táblába ezeket az id ket idegenkucs
            ///formájába feltöltjük, és elmentjük
            await _context.Felhasznalas.AddAsync(new Felhasznalas
            {
                Gyujtott_id = gyId,
                Betegseg_ID = bId,
                Elo_Id = eId
            });
            await _context.SaveChangesAsync(); //Adatbázis mentése: Felhasznalas
            IEnumerable<Felhasznalas> felhasznalas = _context.Felhasznalas.ToList();
            int id = felhasznalas.Last().ID; //Ez lesz az az id, ami majd a növényeknek a következő id je lesz


            ///Amiket megtaláltunk LINQ val kifejezéseket, és amiket
            ///megadtunk feltöltés előtt magyar és latin nevet,
            ///feltöltjük a Növények adatbázisba
            await _context.Novenyek.AddAsync(new Novenyek
            {
                Magyar = Magyar,
                Latin = Latin,
                Kep = kepnev,
                Felh_Id = id,
                Informacio=leiras
            }) ; 
            
            await _context.SaveChangesAsync(); //Adatbázis elmentése: Növenyek

            return View("Feltoltes");
        }

        /// <summary>
        /// Növényeket kilistázzuk
        /// </summary>
        /// <returns>Az oldalra megkapja a model adatait</returns>
        public IActionResult Index()
        {
            
            return View(osszesitett.ToList());

        }
        /// <summary>
        /// Történet oldal
        /// </summary>
        /// <returns>nincs modell hozzárendelve, visszatérit a html oldalra</returns>
        public IActionResult Tortenet()
        {
            return View();
        }

        /// <summary>
        /// csak akkor érhető el az oldal, ha bevan jelentkezve a felhasználó
        /// </summary>
        /// <returns></returns>
        public IActionResult Feltoltes()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View(osszesitett);
            }
            return View(typeof(Index));
                
        }
        /// <summary>
        /// Leírás oldal kezelője
        /// </summary>
        /// <returns></returns>
        public IActionResult Leiras()
        {
            
            return View(osszesitett.ToList());
        }
        /// <summary>
        /// Amit megkeresünk betegséget a legördülő menüben, 
        /// azokat listázza ki
        /// </summary>
        /// <param name="Betegseg">megkeresett betegség</param>
        /// <returns>csak a keresett betegségekkel tér vissza az oldalra</returns>
        [HttpPost,ActionName("LeirasKeres")]
        public IActionResult LeirasKeres(string Betegseg)
        {

            var list = osszesitett.Where(x => x.Tipus == Betegseg).ToList();
            return View("Leiras",list);
        }
        public IActionResult Ismerteto()
        {
            return View(osszesitett.ToList());
        }
        public IActionResult Feldolgozas()
        {
            return View();
        }

        /// <summary>
        /// A növény nevére a leírásban rákattintunk, ,s minden adatát
        /// kiírja nekünk
        /// </summary>
        /// <param name="id">id a rákattintott neve alapján</param>
        /// <returns>visszadja az oldalt a növény adataival</returns>
        [HttpGet]
        public IActionResult Single(int id)
        {
            return View(osszesitett.First(x=>x.ID==id));
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
