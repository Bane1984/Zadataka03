using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadataka03.DTO;
using Zadataka03.Models;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UredjajController : ControllerBase
    {
        public readonly ZadatakContext _context;

        public UredjajController(ZadatakContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Uzmi uredjaje.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Uredjaj>> GetUredjaj()
        {
            return _context.Uredjaji.ToList();
        }

        /// <summary>
        /// Uzmi uredjaje po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Uredjaj>> GetUredjaj(int id)
        {
            var ured = _context.Uredjaji.Where(c => c.UredjajId == id);

            if (ured == null)
            {
                return NotFound();
            }

            return Ok(ured);
        }

        /// <summary>
        /// Kreiraj Uredjaj.
        /// </summary>
        /// <param name="ured">The ured.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UredjajDTO>> PostUredjaj(Uredjaj ured)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var postUredjaj = new UredjajDTO
                    {
                        ImeUredjaja = ured.ImeUredjaja
                    };
                    _context.Uredjaji.Add(ured);
                    await _context.SaveChangesAsync();

                    return Ok("Uredjaj kreiran!");
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
                
        }

        /// <summary>
        /// Apdejt Uredjaja.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="uredj">The uredj.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutUredjaj(int id, Uredjaj uredj)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    if (id != uredj.UredjajId)
                    {
                        return BadRequest();
                    }

                    var ure = _context.Uredjaji.Find(id);
                    ure.ImeUredjaja = uredj.ImeUredjaja;
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
                
        }

        /// <summary>
        /// Brisanje uredjaja.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUredjaja(int id)
        {
            var uredjaj = _context.Uredjaji.Find(id);

            if (uredjaj == null)
            {
                return NotFound();
            }

            _context.Uredjaji.Remove(uredjaj);
            _context.SaveChanges();

            return Ok($"Urdjaj {uredjaj.ImeUredjaja} je obrisan!");
        }
    }
}