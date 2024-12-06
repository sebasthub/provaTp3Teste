using AutoMapper;
using ProvaTp3Teste.DTO;
using ProvaTp3Teste.Model;

namespace ProvaTp3Teste.Mapping
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Unidade, UnidadePost>().ReverseMap();
        }
    }
}
