using AutoMapper;
using DrugovichAutoPecas.API.DTO;
using DrugovichAutoPecas.API.Entities;

namespace DrugovichAutoPecas.API.Mapper
{
    public class AutoPecasMapping : Profile
    {
        public AutoPecasMapping()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Grupo, GrupoDTO>().ReverseMap();
        }
    }
}
