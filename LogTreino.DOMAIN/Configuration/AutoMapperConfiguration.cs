using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
// using LogTreino.DATA;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Configuration
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Atleta,Atleta_Insert>()
                .ForMember(x=>x.MedidasDTO, y=>y.MapFrom(x=>x.Medida))
                .ForMember(x=>x.TreinoDiaDTO, y=>y.MapFrom(x=>x.TreinoDia))
                .ReverseMap();

            CreateMap<TreinoDia,TreinoDiaDTO>()
                .ForMember(x=>x.SeriesDTO, y=>y.MapFrom(x=>x.Series))
                .ReverseMap();

            CreateMap<Serie,SerieDTO>().ReverseMap();
            
            CreateMap<Medida,MedidasDTO>()
                // .ForMember(x=> x.DataMedicao,y => y.MapFrom(_ => DateTime.Now))
                .ReverseMap();
        }
    }
}