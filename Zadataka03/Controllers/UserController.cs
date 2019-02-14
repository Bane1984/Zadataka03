using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadataka03.DTO;
using Zadataka03.Models;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:BaseDTOController<User,UserDTO>
    {
        public UserController(ZadatakContext context, IMapper mapper) : base(context, mapper)
        {
        }
        //public readonly ZadatakContext _context;
        //private readonly IMapper _mapper;

        //public UserController(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

        //public UserController(ZadatakContext context)
        //{
        //    _context = context;
        //    _context.Database.EnsureCreated();
        //}

        //[ProducesResponseType(200, Type = typeof(UserDTO))]
        //[HttpGet("uzmiKorisnike")]
        //public ActionResult<UserDTO> Get()
        //{
        //    var use = new User
        //    {
        //        Ime = "Bane",
        //        Prezime = "Vujovic",
        //        Email = "bane@gmail.com"
        //    };
        //    //return OkResult(_mapper.Map<UserDTO>());
        //    return _mapper.Map<UserDTO>(use);
        //}

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult Get()
        {
            return base.GetAll();
        }

        /// <summary>
        /// Pretraga po ID-u.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return base.GetId(id);
        }

        /// <summary>
        /// Kreiraj korisnnika.
        /// </summary>
        /// <param name="use">The use.</param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(UserDTO use)
        {
            return base.Create(use);
        }

        /// <summary>
        /// Update korisnika.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update(int id, UserDTO user)
        {
            return base.Update(id, user);
        }

        /// <summary>
        /// Brisanje korisnika.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}