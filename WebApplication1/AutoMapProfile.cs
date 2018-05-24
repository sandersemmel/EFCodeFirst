using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EF.Model;
using WebApplication1.Data_Transfer_Object;

namespace WebApplication1
{
    public class AutoMapProfile : AutoMapper.Profile
    {
        public AutoMapProfile()
        {
            CreateMap<PERSON, PersonDTO>();
            CreateMap<PersonDTO, PERSON>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => a.AddProfile<AutoMapProfile>());
        }
    }
}