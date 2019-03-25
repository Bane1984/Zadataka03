using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zadataka03.DTO;
using Zadataka03.Models;
using Zadataka03.Repositories;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UredjajController : BaseController<Uredjaj, UredjajDTO>
    {
        public readonly IUredjaj _repository;
        public readonly IMapper _mapper;

        public UredjajController(IUredjaj repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Uzmi uredjaje.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult GetUredjaje()
        {

            return base.Get();
        }

        /// <summary>
        /// Uzmi uredjaje po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("geturedjaj/{id}")]
        public IActionResult GetUredjaj(int id)
        {
            return base.GetId(id);
        }

        /// <summary>
        /// Kreiraj uredjaj.
        /// </summary>
        /// <param name="ured">The ured.</param>
        /// <returns></returns>
        [HttpPost("posturedjaj/{ured}")]
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
        [HttpPut("puturedjaj/{id}")]
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
        [HttpDelete("deleteuredjaj/{id}")]
        public IActionResult DeleteUredjaj(int id)
        {
            return base.Delete(id);
        }
    }
}