using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Dal.Data;
using Cinema.Dal.Dbo;
using Cinema.Dal.interfaces;

namespace Cinema.Dal.mocks
{
   public class MockMovie : IAllMovie
    {
        private readonly CinemaDbContext _context;

        public MockMovie(CinemaDbContext context)
        {
            _context = context;
        }

        public List<MovieDbo> Movies 
        {
            get
            {
                return _context.Movies.Select(a => a).ToList();
               
            }
        }

        public MovieDbo GetMoviesId(Guid id)
        {
            return _context.Movies.FirstOrDefault(a => a.Id == id);
        }
    }
}
