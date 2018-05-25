using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EF.Model;
using Data_Transfer_Object;

namespace Mapper.MapProfile
{
    public class AutoMapProfile : AutoMapper.Profile
    {
        public AutoMapProfile()
        {
            CreateMap<PERSON, PersonDTO>();
            CreateMap<PersonDTO, PERSON>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<MOVIEREVIEW, MovieReviewDTO>();
            CreateMap<MovieReviewDTO, MOVIEREVIEW>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => a.AddProfile<AutoMapProfile>());
        }
    }
}