using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zadataka03.DTO;
using Zadataka03.Models;
using Zadataka03.Repositories;

//using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KancelarijaController : BaseController<Kancelarija, KancelarijaDTO>
    {
        public readonly IKancelarija _repository;
        public readonly IMapper _mapper;
        public KancelarijaController(IKancelarija repository, IMapper mapper):base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Uzmi kancelarije.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getkancelarija")]
        public IActionResult GetKancelarija()
        {
            return base.Get();
        }

        /// <summary>
        /// Uzmi kancelarije po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("getkancelarija/{id}")]
        public IActionResult GetKancelarija(int id)
        {
            return base.GetId(id);
        }

        /// <summary>
        /// Kreiraj kancelariju.
        /// </summary>
        /// <param name="kancelar">The kancelar.</param>
        /// <returns></returns>
        [HttpPost("postkancelarija")]
        public IActionResult PostKancelarija(KancelarijaDTO kancelar)
        {
            return base.Create(kancelar);
        }

        /// <summary>
        /// Apdejt kancelarije.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="kanc">The kanc.</param>
        /// <returns></returns>
        [HttpPut("putkancelarija")]
        public IActionResult PutKancelarija(int id, KancelarijaDTO kanc)
        {
            var kancel = _repository.GetId(id);
            kancel.Opis = kanc.Opis;
            _repository.Update(id, kancel);
            return Ok("Kancelarija apdejtovan!");
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
        [HttpDelete("deletekancelarija/{id}")]
        public IActionResult DeleteKancelarija(int id)
        {
            return base.Delete(id);
        }
    }
}