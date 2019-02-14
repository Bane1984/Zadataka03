using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zadataka03.DTO;
using Zadataka03.Models;

namespace Zadataka03.Models
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Kancelarija, KancelarijaDTO>();
            CreateMap<KancelarijaDTO, Kancelarija>();

            CreateMap<Uredjaj, UredjajDTO>();
            CreateMap<UredjajDTO, Uredjaj>();

            CreateMap<Osoba, OsobaDTO>();
            CreateMap<OsobaDTO, Osoba>();
        }
    }
}
