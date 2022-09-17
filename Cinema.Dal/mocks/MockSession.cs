using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Dal.Data;
using Cinema.Dal.Dbo;
using Cinema.Dal.interfaces;

namespace Cinema.Dal.mocks
{
    public class MockSession : ISessionMovie
    {

        private readonly CinemaDbContext _context;

        public MockSession(CinemaDbContext context)
        {
            _context = context;
        }

        //public List<SessionMovieDbo> AllSessionMovies
        //{
        //    get
        //    {
        //       //return _context.SessionMovieDbos.Select(a => a).ToList();
        //    }
        //}

}
}
