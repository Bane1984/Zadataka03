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
    public class KancelarijaController : BaseController<Kancelarija>
    {
        public KancelarijaController(ZadatakContext context):base(context)
        {
        }

        /// <summary>
        /// Uzmi kancelarije.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult Get()
        {
            
            return Ok(base.Get());
        }

        /// <summary>
        /// Uzmi kancelarije po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("GetKancelarija/{id}")]
        public IActionResult GetKancelarija(int id)
        {
            return Ok(base.Get(id));
        }

        /// <summary>
        /// Kreiraj kancelariju.
        /// </summary>
        /// <param name="kancelar">The kancelar.</param>
        /// <returns></returns>
        [HttpPost("PostKancelarija/{kancelar}")]
        public IActionResult PostKancelarija(Kancelarija kancelar)
        {
            return Ok(base.Create(kancelar));
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
            return Ok(base.Update(id, kanc));
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
        [HttpDelete("DeleteKancelarija/{id}")]
        public IActionResult DeleteKancelarija(int id)
        {
            return Ok(base.Delete(id));
        }
    }
}