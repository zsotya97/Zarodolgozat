using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Areas.Identity.Data;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly Projekt.Data.ProjektContext _context;
        private readonly SignInManager<ProjektUser> _signInManager;
        private readonly UserManager<ProjektUser> _UserManager;
        private static  ProjektUser profil;
        private readonly NovenyContext _Noveny;

        [BindProperty]
        private  IEnumerable<Osszesitett> osszesitett { get; set; }

        public IActionResult Control()
        {
            return View();
        }

        public AdminController(Projekt.Data.ProjektContext context,SignInManager<ProjektUser> signInManager, UserManager<ProjektUser> usermanager, NovenyContext noveny)
        {
            _context = context;
            _signInManager = signInManager;
            _UserManager = usermanager;
            _Noveny = noveny;
            osszesitett =
                from felhasznalas in _Noveny.Felhasznalas
                join elofordulas in _Noveny.Elofordulas on felhasznalas.Elo_Id equals elofordulas.ID
                join novenyek in _Noveny.Novenyek on felhasznalas.ID equals novenyek.Felh_Id
                join betegseg in _Noveny.Betegseg on felhasznalas.Betegseg_ID equals betegseg.ID
                join gyujtott in _Noveny.Gyujtott on felhasznalas.Gyujtott_id equals gyujtott.ID
                select new Osszesitett
                {
                    ID = novenyek.ID,
                    Magyar = novenyek.Magyar,
                    Latin = novenyek.Latin,
                    Honap = elofordulas.Honap,
                    Resz = gyujtott.Resz,
                    Tipus = betegseg.Tipus,
                    Kep=novenyek.Kep,
                    Leiras=novenyek.Informacio
                  


                };





        }
      
        

        // GET: profil
        public async Task<IActionResult> Index()
        {
            
           if(_signInManager.IsSignedIn(User))
            {
                profil = await _UserManager.GetUserAsync(User);
                if (profil.Email == "Admin@admin.eu") 
                {
                    return View(await _context.Users.ToListAsync());
                    
                }
                
            }
             return View("Control");

        }

        // GET: profil/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profil = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profil == null)
            {
                return NotFound();
            }

            return View(profil);
        }




        // GET: profil/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profil = await _context.Users.FindAsync(id);
            if (profil == null)
            {
                return NotFound();
            }
            return View(profil);
        }

        // POST: profil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,  Projekt.Areas.Identity.Data.ProjektUser profil)
        {
            if (id != profil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!profilExists(profil.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profil);
        }

        // GET: profil/Delete/5
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profil = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profil == null)
            {
                return NotFound();
            }

            return View(profil);
        }

        // POST: profil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profil = await _context.Users.FindAsync(id);
            _context.Users.Remove(profil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Torles")]
        [ValidateAntiForgeryToken]
        public IActionResult Fajlok()
        {
            DirectoryInfo torles = new DirectoryInfo("wwwroot/images/novenyek");
            foreach (FileInfo file in torles.GetFiles())
            {
                bool volt = osszesitett.Any(x => x.Kep == file.Name);
                if(!volt) file.Delete();
            }
            return RedirectToAction(nameof(Search));
        }



        [HttpPost, ActionName("DeleteNoveny")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Noveny(int id)
        {
            var novenyek = await _Noveny.Novenyek.FindAsync(id);
            var felhasznalas = await _Noveny.Felhasznalas.FindAsync(id);
            _Noveny.Novenyek.Remove(novenyek);
            _Noveny.Felhasznalas.Remove(felhasznalas);
            await _Noveny.SaveChangesAsync();
            return RedirectToAction(nameof(Search));
        }

        private bool profilExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }




        [HttpPost, ActionName("Magyar")]
        public IActionResult ListMagyar(string magyar)
        {
            if (magyar is null) magyar = "";
            IEnumerable<Osszesitett> adatok = osszesitett.Where(x => x.Magyar.ToLower().Contains(magyar.ToLower()));
            
            return View("Search", adatok);


        }

        [HttpPost, ActionName("Latin")]
        public IActionResult ListLatin(string latin )
        {
            if (latin is null) latin = "";
            IEnumerable<Osszesitett> adatok = osszesitett.Where(x => x.Latin.ToLower().Contains(latin.ToLower()));
            
            return View("Search", adatok);



        }

        public async Task<IActionResult> Search()
        {
            profil = await _UserManager.GetUserAsync(User);
            try
            {
                if (profil.Email == "Admin@admin.eu")
                {
                    return View(osszesitett);

                }
            }
            catch (Exception)
            {

                
            }

            return View("Control");
        }
    }
}
