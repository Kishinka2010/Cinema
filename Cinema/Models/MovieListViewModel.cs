using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Dal.Dbo;

namespace Cinema.Models
{
    public class MovieListViewModel
    {
        public List<MovieDbo> Movies { get; set; }

    }
}
