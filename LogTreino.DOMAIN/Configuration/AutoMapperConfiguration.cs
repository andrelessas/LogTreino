using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
// using LogTreino.DATA;
using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Configuration
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Atleta,Atleta_Insert>().ReverseMap();
        }
    }
}