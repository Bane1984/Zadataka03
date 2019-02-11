using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadataka03.Models;
using Zadataka03.DTO;


//PUT i POST nisu realizovani
namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UredjajUzetVracenController : ControllerBase
    {
        public readonly ZadatakContext _context;

        public UredjajUzetVracenController(ZadatakContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Uzmi UredjajUzetVraceni.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUredjajUzetVracen()
        {
            return Ok(_context.UredjajUzetVraceni.Select(c => c).ToList());
        }

        /// <summary>
        /// Uzmi UredjajUzetVraceni po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UredjajUzetVracen> GetUredjajUzetVracen(int id)
        {
            var ured = _context.UredjajUzetVraceni.Find(id);

            if (ured == null)
            {
                return NotFound();
            }

            return Ok(ured);
        }

        /// <summary>
        /// Uzima sve osobe kao i koriscene uredjaje i kancelarije u kojima su se nalazili u navedenoj godini.
        /// </summary>
        /// <param name="godina">The godina.</param>
        /// <returns></returns>
        [HttpGet("GetODDO/{godina}")]
        public IActionResult GetODDO(string godina/*, string mjesec, string dan*/)
        {
            var uredjajiG = _context.UredjajUzetVraceni
                                .Where(c => c.Uzet.Year.ToString() == godina)
                                .Select(n=> new
                                {
                                    Ime = n.Osoba.Ime, 
                                    Prezime = n.Osoba.Prezime,
                                    Uredjaj = n.Uredjaj.ImeUredjaja,
                                    Kancelarija = n.Osoba.Kancelarija.Opis
                                }).ToList();
            //var uredjajiM = _context.UredjajUzetVraceni.Where(c => c.Uzet.Month.ToString() == mjesec);
            //var uredjajiD = _context.UredjajUzetVraceni.Where(c => c.Uzet.Day.ToString() == dan);
            //if (mjesec == null && dan == null)
            //{
            //    return Ok(uredjajiG);
            //}
            //else if (godina == null && dan == null)
            //{
            //    return Ok(uredjajiM);
            //}
            //else
            //    return Ok(uredjajiD);

            return Ok(uredjajiG);
        }




        ///// <summary>
        ///// Kreiraj UredjajUzetVraceni.
        ///// </summary>
        ///// <param name="ured">The ured.</param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult<UredjajUzetVracen>> PostUredjajUzetVracen(UredjajUzetVracen ured)
        //{
        //    _context.UredjajUzetVraceni.Add(ured);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetUredjajUzetVracen), new { id = ured.UredjajUzetVracenId }, ured);
        //}

        ///// <summary>
        ///// Apdejt UredjajUzetVraceni.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="uredj">The uredj.</param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<IActionResult> PutUredjaj(int id, Uredjaj uredj)
        //{
        //    if (id != uredj.UredjajId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(uredj).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        /// <summary>
        /// Brisanje UredjajUzetVraceni.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUredjaja(int id)
        {
            var uredjaj = _context.UredjajUzetVraceni.Find(id);

            if (uredjaj == null)
            {
                return NotFound();
            }

            _context.UredjajUzetVraceni.Remove(uredjaj);
            _context.SaveChanges();

            return Ok($"Uredjaj {uredjaj} je obrisan.");
        }
    }
}