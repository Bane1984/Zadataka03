using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using Zadataka03.Models;
using Zadataka03.DTO;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : Controller where T : class
    {
        private readonly ZadatakContext _context;
        public readonly DbSet<T> _dbSet;

        public BaseController(ZadatakContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Uzimanje svega iz tebele.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        protected virtual IActionResult Get()
        {
            return Ok(_dbSet.Select(c => c).ToList());
        }

        /// <summary>
        /// Pretraga po ID-u.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        protected virtual IActionResult Get(int id)
        {
            var result = _dbSet.Find(id);
            if (result == null)
            {
                return NotFound($"Sa ID = {id} ne postoji zapis");
            }

            return Ok($"Navedeni ID= {id} nosi u sebi zapis {result}.");
        }

        /// <summary>
        /// Kreiranje objekta.
        /// </summary>
        /// <param name="objekat"></param>
        /// <returns></returns>
        [HttpPost("create")]
        protected virtual IActionResult Create(T objekat)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    if (objekat == null)
                    {
                        return NoContent();
                    }

                    var str = typeof(T).FullName;
                    
                    if (str == "Osoba")
                    {
                        var osDto = new OsobaDTO();
                        var osoba = new Osoba()
                        {
                            Ime = osDto.Ime,
                            Prezime = osDto.Prezime
                        };
                        _context.Add(osoba);
                        _context.SaveChanges();
                        trans.Commit();
                        return Ok("Osoba je kreirana!");
                    }
                    _context.Add(objekat);
                    _context.SaveChanges();
                    trans.Commit();
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// Mijenjanje objekta.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objekat"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        protected virtual IActionResult Update(int id, T objekat)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var a = _context.Attach(objekat).Entity;
                    _context.Entry(a).State = EntityState.Modified;
                    _context.SaveChanges();
                    trans.Commit();
                    return Ok(a);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// Brisanje objekta.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        protected virtual IActionResult Delete(int id)
        {
            var nadji = _dbSet.Find(id);
            try
            {
                if (nadji == null)
                {
                    return NotFound();
                }

                _context.Remove(nadji);
                _context.SaveChanges();
                return Ok($"Uredjaj sa ID = {id} je obrisan!");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            

        }
    }
}