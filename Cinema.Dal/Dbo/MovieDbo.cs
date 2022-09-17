using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Dal.Dbo;

namespace Cinema.Dal.Dbo
{
    public class MovieDbo: BaseDbo
    {
        public string Title { set; get; }
      
        public DateTime ReleaseDate { set; get; }
       
        public ushort Duration { set; get; }
        
        public string Starring { set; get; }
       
        public string Producer { set; get; }

        public List<SessionMovieDbo> SessionMovies;
    }
}

