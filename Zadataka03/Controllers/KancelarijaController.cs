using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Zadataka03.DTO;
using Zadataka03.Models;
//using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KancelarijaController : ControllerBase
    {
        public readonly ZadatakContext _context;

        public KancelarijaController(ZadatakContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Uzmi kancelarije.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<KancelarijaDTO>> GetKancelarija()
        {
            var kanc = from os in _context.Kancelarije
                select new KancelarijaDTO()
                {
                    Opis = os.Opis
                };
            return Ok(kanc);
        }

        /// <summary>
        /// Uzmi kancelarije po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<KancelarijaDTO>> GetKancelarija(int id)
        {
            //var kancelarija = _context.Kancelarije.FindAsync(id);

            //var kancelarija = _context.Kancelarije.Include(c => c.Osobe).Where(c => c.KancelarijaId == id);
            //var kancelarija = _context.Kancelarije.Where(c => c.KancelarijaId == id).Select(c => c.Osobe);

            var kancelarija = _context.Kancelarije.Where(c => c.KancelarijaId == id);

            if (kancelarija == null)
            {
                return NotFound();
            }

            return Ok(kancelarija.ToList());
        }

        /// <summary>
        /// Kreiraj kancelariju.
        /// </summary>
        /// <param name="kancelar">The kancelar.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostKancelarija(Kancelarija kancelar)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var dtokancel = new KancelarijaDTO()
                    {
                        Opis = kancelar.Opis
                    };
                    _context.Kancelarije.Add(kancelar);
                    _context.SaveChanges();
                    trans.Commit();
                    return Ok(_context.Kancelarije.Where(c => c.Opis == dtokancel.Opis));
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }

        }

        /// <summary>
        /// Apdejt kancelarije.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="kanc">The kanc.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutKancelarija(int id, Kancelarija kanc)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    if (id != kanc.KancelarijaId)
                    {
                        return BadRequest();
                    }

                    var kancelarija = _context.Kancelarije.Find(id);
                    kancelarija.Opis = kanc.Opis;
                    _context.SaveChanges();

                    return Ok($"Kancelarija {kancelarija} je apdejtovana!");
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
                
        }

        /// <summary>
        /// DBrisanje kancelarije sa proslijedjenim ID-em.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Odgovor kao rezultat brisanja kancelarije.</returns>
        /// <response code="200">Ako je kancelarija obrisana uspjesno.</response>
        /// <response code="500">Ako je bilo greske na serveru.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult DeleteKancelarija(int id)
        {
                var kancel = _context.Kancelarije.Find(id);

                if (kancel == null)
                {
                    return NotFound();
                }

                _context.Kancelarije.Remove(kancel);
                _context.SaveChanges();
           

            return Ok($"Kancelarija {kancel.Opis} je obrisana.");
        }
    }
}