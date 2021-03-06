﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Zadataka03.DTO;
using Zadataka03.Expressionss;
using Zadataka03.Models;
using Zadataka03.Repositories;
using Zadataka03.UnitOfWork;


//PUT i POST nisu realizovani
namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UredjajUzetVracenController : BaseController<UredjajUzetVracen, UredjajUzetVracenDTO>
    {
        public readonly IUredjajUzetVracen _repository;
        public readonly IOsoba _osoba;
        public readonly IUredjaj _uredjaj;
        public readonly IMapper _mapper;
        public readonly ZadatakContext _context;

        public UredjajUzetVracenController(IRepository<UredjajUzetVracen> repository, IMapper mapper, IUredjajUzetVracen uredjajuzetvracen, IOsoba osoba, IUredjaj uredjaj, IUnitOfWork unitofwork) : base(repository, mapper)
        {
            _repository = uredjajuzetvracen;
            _osoba = osoba;
            _uredjaj = uredjaj;
            _mapper = mapper;   
        }

        

        /// <summary>
        /// Uzmi UredjajUzetVraceni.
        /// </summary>
        /// <returns></returns>
        [HttpGet("geturedjajuzetvracen")]
        public ActionResult GetUredjajUzetVracen()
        {
            var uredj = base.Get();
            return Ok(uredj);
        }

        /// <summary>
        /// Uzmi UredjajUzetVraceni po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("geturedjajuzetvracen/{id}")]
        public ActionResult<UredjajUzetVracen> GetUredjajUzetVracen(int id)
        {
            var ured = base.GetId(id);

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

        /// <summary>
        /// Uvid kada je koja osoba koristila koji uredja (u periodu od-do).
        /// </summary>
        /// <param name="godinaA">The godina a.</param>
        /// <param name="godinaB">The godina b.</param>
        /// <returns></returns>
        [HttpGet("GetODDO/{godinaA}/{godinaB}")]
        public IActionResult GetODDO(string godinaA, string godinaB)
        {
            var uredjajA =
                _context.UredjajUzetVraceni
                    .Where(c => c.Uzet.Year.ToString().Contains(godinaA) || c.Uzet.Year.ToString().Contains(godinaB)).Select(n=>new
                    {
                        Ime = n.Osoba.Ime,
                        Prezime = n.Osoba.Prezime,
                        Uredjaj = n.Uredjaj.ImeUredjaja,
                        Kancelarija = n.Osoba.Kancelarija.Opis
                    }).ToList();


            return Ok(uredjajA);

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

        ///// <summary>
        ///// Brisanje UredjajUzetVraceni.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public IActionResult DeleteUredjaja(int id)
        //{
        //    var uredjaj = _context.UredjajUzetVraceni.Find(id);

        //    if (uredjaj == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UredjajUzetVraceni.Remove(uredjaj);
        //    _context.SaveChanges();

        //    return Ok($"Uredjaj {uredjaj} je obrisan.");
        //}


        /// <summary>
        /// Brisanje objekta.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("obrisati")]
        public IActionResult DeleteUzetVracen(int id)
        {
            return base.Delete(id);
        }


        /// <summary>
        /// Poziv QueryInfo
        /// </summary>
        /// <param name="query"></param>
        /// <param name="upit"></param>
        /// <returns></returns>
        [HttpPost("bassboosted")]
        public IQueryable BassBoosted([FromBody] QueryInfo upit)
        {
            var query = _repository.QueryInfooo(upit);
            return query;
        }

    }
}