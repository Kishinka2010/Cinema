using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Dal.Dbo;

namespace Cinema.Dal.Dbo
{
    public class SessionMovieDbo: BaseDbo
    {
        public Guid HallId { get; set; }

        public HallDbo Hall { get; set; }

        public Guid MovieId { get; set; }

        public MovieDbo Movie { get; set; }

        public DateTime SessionTime { get; set; }

        public int Price { get; set; }
    }
}
