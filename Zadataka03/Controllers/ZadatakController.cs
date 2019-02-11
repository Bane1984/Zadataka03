using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadataka03.Models;

namespace Zadataka03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZadatakController : ControllerBase
    {
        public readonly ZadatakContext _context;

        public ZadatakController(ZadatakContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        

    }
}