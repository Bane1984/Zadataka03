using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.EntityFrameworkCore;
using Zadataka03.Models;
using Zadataka03.DTO;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDTOController<T, Tdto> : Controller
        where T : class
        where Tdto : class
    {
        private readonly ZadatakContext _context;
        private readonly DbSet<T> _dbSet;
        protected IMapper _mapper;

        public BaseDTOController(ZadatakContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        protected virtual IActionResult GetAll()
        {
            var result = _dbSet.ProjectTo<Tdto>(_mapper.ConfigurationProvider).ToList();

            return Ok(result);
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        protected virtual IActionResult GetId(int id)
        {
            var nadji = _dbSet.Find(id);
            var map = _mapper.Map<Tdto>(nadji);
            return Ok(map);
        }

        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        [HttpPost("create")]
        protected virtual IActionResult Create(Tdto obj)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    if (obj==null)
                    {
                        return NoContent();
                    }


                    var map = _mapper.Map<T>(obj);

                    _context.Add(map);
                    _context.SaveChanges();
                    trans.Commit();
                    return Ok("Kreirana nova osoba!");
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        [HttpPut("update")]
        protected virtual IActionResult Update(int id, Tdto obj)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var find = _dbSet.Find(id);
                    _mapper.Map<Tdto, T>(obj, find);

                    //Dejo mi naveo primjer kako preko refleksije moze da se promijeni samo jedna stavka u zapisu.

                    //var sourceProps = typeof(Tdto).GetProperties();
                    //var destinationProps = typeof(T).GetProperties().ToDictionary(x => x.Name);
                    //foreach (var sourceProp in sourceProps)
                    //{
                    //    var sourceValue = sourceProp.GetValue(obj);
                    //    var destinationProp = destinationProps[sourceProp.Name];
                    //    var destinationValue = destinationProp.GetValue(find);
                    //    if (Equals(sourceValue, destinationValue))
                    //    {
                    //        continue;
                    //    }

                    //    destinationProp.SetValue(find, sourceValue);
                    //}

                    _context.SaveChanges();
                    trans.Commit();
                    return Ok("Zapis apdejtovan!");
                }
                catch (Exception e)
                {
                    return BadRequest("Greska pri apdejtu.");
                }
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("delete")]
        protected virtual IActionResult Delete(int id)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var find = _dbSet.Find(id);
                    _dbSet.Remove(find);
                    _context.SaveChanges();
                    trans.Commit();
                    return Ok("Korisnik obrisan!");
                }
                catch (Exception e)
                {
                    return BadRequest("Korisnik nije obrisan!");
                }
            }
        }
    }
}