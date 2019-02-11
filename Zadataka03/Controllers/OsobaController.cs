using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadataka03.Models;
using Zadataka03.DTO;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobaController : ControllerBase
    {
        public readonly ZadatakContext _context;

        public OsobaController(ZadatakContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Uzmi osobe.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetOsoba()
        {
            var osobe = from os in _context.Osobe
                select new
                {
                    Ime = os.Ime,
                    Prezime = os.Prezime,
                    Kancelarijadto = os.Kancelarija.Opis
                };
            return Ok(osobe.ToList());  
        }

        /// <summary>
        /// Uzmi osobu po ID-u sa informacijom u kojoj je kancelariji i koje uredjaje koristi..
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetOsobu(int id)
        {

            var osoba = _context.Osobe
                .Where(c => c.OsobaId == id)
                .Select(b => new
                {
                    Ime = b.Ime,
                    Prezime = b.Prezime,
                    Kancelarija = b.Kancelarija.Opis,
                    Uredjaji = b.UzetiUredjaji.Select(n => new
                    {
                        ImeUredjaja = n.Uredjaj.ImeUredjaja,
                        Uzet = n.Uzet,
                        Vracen = n.Vracen
                    })
                })
                .ToList();

            if (osoba == null)
            {
                return NotFound();
            }

            return Ok(osoba);
        }

        /// <summary>
        /// Kreiraj osobu.
        /// </summary>
        /// <param name="os">The os.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostOsoba(OsobaDTO os)
        {
            using(var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    if (os != null)
                    {
                        var osoba = new Osoba()
                        {
                            Ime = os.Ime,
                            Prezime = os.Prezime
                        };
                        _context.Osobe.Add(osoba);
                        _context.SaveChanges();

                        trans.Commit();

                        return Ok();
                    }
                    
                }
                catch (Exception ex)
                {

                    return BadRequest();
                }
            }
            

            //bool kancelarije = _context.Kancelarije.Select(c => c.Opis).Contains(os.Kancelarijadto.Opis);

            //if (kancelarije)
            //{
            //    int kanc = _context.Kancelarije.Where(c => c.Opis.Contains(os.Kancelarijadto.Opis)).Select(c => c.KancelarijaId).FirstOrDefault();

            //}
            //else
            //{

            //}


            return Ok();
        }

        /// <summary>
        /// Apdejt osobe.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="osob">The osob.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutOsoba(int id, Osoba osob)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    if (id != osob.OsobaId)
                    {
                        return BadRequest();
                    }

                    var o = _context.Osobe.Find(id);
                    o.Ime = osob.Ime;
                    o.Prezime = osob.Prezime;
                    _context.SaveChanges();
                    return Ok(o);
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return Ok();
        }

        /// <summary>
        /// Brisanje osobe.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsobe(int id)
        {
            var osoba = await _context.Osobe.FindAsync(id);

            if (osoba == null)
            {
                return NotFound();
            }

            _context.Osobe.Remove(osoba);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}