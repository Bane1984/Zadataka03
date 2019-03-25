using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Zadataka03.Repositories;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TDto> : Controller 
                                                    where T : class 
                                                    where TDto : class
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;


        public BaseController(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        /// <summary>
        /// Uzimanje svega iz tebele.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult Get()
        {
            var result = _mapper.Map<IEnumerable<TDto>>(_repository.GetAll());
            return Ok(result);
        }

        /// <summary>
        /// Pretraga po ID-u.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public IActionResult GetId(int id)
        {
            //var result = _dbSet.Find(id);
            //if (result == null)
            //{
            //    return NotFound($"Sa ID = {id} ne postoji zapis");
            //}

            //return Ok($"Pod ID = {id} se nalazi objekat {result} .");

            var result = _repository.GetId(id);
            var map = _mapper.Map<TDto>(result);
            return Ok(map);
        }


        /// <summary>
        /// Kreiranje objekta.
        /// </summary>
        /// <param name="objekat"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(TDto objekat)
        {

            var result = _mapper.Map<T>(objekat);
            _repository.Create(result);
            return Ok("Kreiran novi entitet.");



            //using (var trans = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        //if (objekat == null)
            //        //{
            //        //    return NoContent();
            //        //}

            //        //var str = typeof(T).FullName;
                    
            //        //if (str == "Osoba")
            //        //{
            //        //    var osDto = new OsobaDTO();
            //        //    var osoba = new Osoba()
            //        //    {
            //        //        Ime = osDto.Ime,
            //        //        Prezime = osDto.Prezime
            //        //    };
            //        //    var os = _mapper.Map<Osoba>(objekat);
            //        //    _context.Add(os);
            //        //    _context.SaveChanges();
            //        //    trans.Commit();
            //        //    return Ok("Osoba je kreirana!");
            //        //}

            //        var obT = _mapper.Map<T>(objekat);
            //        _context.Add(obT);
            //        _context.SaveChanges();
            //        trans.Commit();
            //        return Ok();
            //    }
            //    catch (Exception e)
            //    {
            //        return BadRequest();
            //    }
            //}
        }

        /// <summary>
        /// Mijenjanje objekta.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objekat"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, TDto objekat)
        {
            var result = _repository.GetId(id);
            _mapper.Map(objekat, result);
            return Ok("Entite apdejtovan.");

            //using (var trans = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        var mid = _dbSet.Find(id);
            //        var map = _mapper.Map<Tdto,T>(objekat, mid);
            //        var a = _context.Attach(map).Entity;
            //        _context.Entry(a).State = EntityState.Modified;
            //        _context.SaveChanges();
            //        trans.Commit();
            //        return Ok(a);
            //    }
            //    catch (Exception e)
            //    {
            //        return BadRequest();
            //    }
            //}
        }

        /// <summary>
        /// Brisanje objekta.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok("Entitet obrisan.");

            //var nadji = _dbSet.Find(id);
            //try
            //{
            //    if (nadji == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Remove(nadji);
            //    _context.SaveChanges();
            //    return Ok($"Uredjaj sa ID = {id} je obrisan!");
            //}
            //catch (Exception e)
            //{
            //    return BadRequest();
            //}
            

        }
    }
}