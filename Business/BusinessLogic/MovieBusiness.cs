using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Repository;
using AutoMapper;

namespace Business.BusinessLogic
{
    public class MovieBusiness : IRepository<MovieDetailsDTO>
    {
        MovieRepository movieRepository = new MovieRepository();

        public bool Add(MovieDetailsDTO item)
        {
            Mapper.Map(MovieDetailsDTO)
        }

        public List<MovieDetailsDTO> Find()
        {
            throw new NotImplementedException();
        }

        public MovieDetailsDTO FindSingle(int? id)
        {
            throw new NotImplementedException();
        }

        public List<MovieDetailsDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(MovieDetailsDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
