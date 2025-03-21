using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PokePet.Model;

namespace PokePet.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pokemon, PokemonDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Wheight))
                .ForMember(dest => dest.Types, opt => opt.MapFrom(src => src.Types.Select(a => new TypeInfo { Name = a.TypeInfo.Name })));
        }

       
    }


    public class MascoteService
    {
        private readonly IMapper _mapper;

        public MascoteService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PokemonDTO CriarMascote(Pokemon pokemon)
        {
            return _mapper.Map<PokemonDTO>(pokemon);
        }


    }
}

