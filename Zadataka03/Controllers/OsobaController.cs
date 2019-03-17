using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadataka03.Models;
using Zadataka03.DTO;
using AutoMapper;
using Zadataka03.Repositories;
using Zadataka03.UnitOfWork;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobaController : BaseController<Osoba, OsobaDTO>
    {
        public readonly IOsoba _repository;
        public readonly IKancelarija _kancelarija;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public OsobaController(IOsoba repository, IUnitOfWork unitOfWork, IKancelarija kancelarija, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _kancelarija = kancelarija;
        }

        /// <summary>
        /// Uzmi osobe.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult Get()
        {

            return base.Get();
        }

        /// <summary>
        /// Uzmi osobu po ID-u sa informacijom u kojoj je kancelariji i koje uredjaje koristi..
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetOsobu(int id)
        {
            var osoba = base.GetId(id);
            return Ok(osoba);

            //var osoba = base._dbSet
            //    .Where(c => c.OsobaId == id)
            //    .Select(b => new
            //    {
            //        Ime = b.Ime,
            //        Prezime = b.Prezime,
            //        Kancelarija = b.Kancelarija.Opis,
            //        Uredjaji = b.UzetiUredjaji.Select(n => new
            //        {
            //            ImeUredjaja = n.Uredjaj.ImeUredjaja,
            //            Uzet = n.Uzet,
            //            Vracen = n.Vracen
            //        })
            //    })
            //    .ToList();

            //if (osoba == null)
            //{
            //    return NotFound();
            //}

            //return Ok(osoba);
        }



        /// <summary>
        /// Kreiraj osobu.
        /// </summary>
        /// <param name="osob">The osob.</param>
        /// <returns></returns>
        [HttpPost("PostOsoba")]
        public IActionResult PostOsoba(OsobaDTO osob)
        {
            var kreirati = base.Create(osob);
            return Ok("Osoba kreirana.");
        }

        ///// <summary>
        ///// Kreiraj osobu.
        ///// </summary>
        ///// <param name="os">The os.</param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult PostOsoba(OsobaDTO os)
        //{
        //    using(var trans = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            if (os != null)
        //            {
        //                var osoba = new Osoba()
        //                {
        //                    Ime = os.Ime,
        //                    Prezime = os.Prezime
        //                };
        //                _context.Osobe.Add(osoba);
        //                _context.SaveChanges();

        //                trans.Commit();

        //                return Ok();
        //            }
                    
        //        }
        //        catch (Exception ex)
        //        {

        //            return BadRequest();
        //        }
        //    }
            

        //    //bool kancelarije = _context.Kancelarije.Select(c => c.Opis).Contains(os.Kancelarijadto.Opis);

        //    //if (kancelarije)
        //    //{
        //    //    int kanc = _context.Kancelarije.Where(c => c.Opis.Contains(os.Kancelarijadto.Opis)).Select(c => c.KancelarijaId).FirstOrDefault();

        //    //}
        //    //else
        //    //{

        //    //}


        //    return Ok();
        //}

        ///// <summary>
        ///// Apdejt osobe.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="osob">The osob.</param>
        ///// <returns></returns>
        //[HttpPut]
        //public IActionResult PutOsoba(int id, Osoba osob)
        //{
        //    using (var trans = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            if (id != osob.OsobaId)
        //            {
        //                return BadRequest();
        //            }

        //            var o = _context.Osobe.Find(id);
        //            o.Ime = osob.Ime;
        //            o.Prezime = osob.Prezime;
        //            _context.SaveChanges();
        //            return Ok(o);
        //        }
        //        catch (Exception)
        //        {

        //            return BadRequest();
        //        }
        //    }
        //    return Ok();
        //}

        /// <summary>
        /// Brisanje osobe sa proslijedjenim ID-em.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Odgovor kao rezultat brisanja osobe.</returns>
        /// <response code="200">Ako je osoba obrisana uspjesno.</response>
        /// <response code="500">Ako je bilo greske na serveru.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("deleteosobe/{id}")]
        public IActionResult DeleteOsobe(int id)
        {
            return base.Delete(id);
        }

        /// <summary>
        /// Updates the osoba.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="update">The update.</param>
        /// <returns></returns>
        [HttpPut("updateosobe")]
        public IActionResult UpdateOsoba(int id, OsobaDTO update)
        {
            var osoba = _repository.GetId(id);
            _mapper.Map<OsobaDTO, Osoba>(update, osoba);
            return Ok(osoba);
        }
    }
}