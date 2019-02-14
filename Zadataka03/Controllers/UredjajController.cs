using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadataka03.DTO;
using Zadataka03.Models;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UredjajController : BaseController<Uredjaj, UredjajDTO>
    {


        public UredjajController(ZadatakContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <summary>
        /// Uzmi uredjaje.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult Get()
        {

            return base.Get();
        }

        /// <summary>
        /// Uzmi uredjaje po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("GetUredjaje/{id}")]
        public IActionResult GetUredjaje(int id)
        {
            return base.Get(id);
        }

        /// <summary>
        /// Kreiraj uredjaj.
        /// </summary>
        /// <param name="ured">The ured.</param>
        /// <returns></returns>
        [HttpPost("PostUredjaj/{ured}")]
        public IActionResult PostUredjaj(UredjajDTO ured)
        {
            return base.Create(ured);
        }

        /// <summary>
        /// Apdejt Uredjaj.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ured">The ured.</param>
        /// <returns></returns>
        [HttpPut("PutUredjaj/{id}")]
        public IActionResult PutUredjaj(int id, UredjajDTO ured)
        {
            return base.Update(id, ured);
        }

        /// <summary>
        /// Brisanje uredjaja sa proslijedjenim ID-em.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Odgovor kao rezultat brisanja uredjaja.</returns>
        /// <response code="200">Ako je uredjaj obrisan uspjesno.</response>
        /// <response code="500">Ako je bilo greske na serveru.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("DeleteUredjaj/{id}")]
        public IActionResult DeleteUredjaj(int id)
        {
            return base.Delete(id);
        }
    }
}