using System;
using System.Collections.Generic;
using Cinema.Dal.Dbo;

namespace Cinema.Dal.Dbo
{
    public class HallDbo: BaseDbo
    {
        public string Title { get; set; }

        public List<SessionMovieDbo> SessionMovies { get; set; }

        public CinemaDbo Cinema { get; set; }

        public Guid CinemaId { get; set; }

    }
}