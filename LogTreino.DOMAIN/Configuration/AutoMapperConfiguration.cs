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
            CreateMap<Atleta,Atleta_Insert>().ReverseMap();
            CreateMap<Medida,MedidasDTO>().ForMember(x=> x.DataMedicao,y => y.MapFrom(_ => DateTime.Now)).ReverseMap();
        }
    }
}