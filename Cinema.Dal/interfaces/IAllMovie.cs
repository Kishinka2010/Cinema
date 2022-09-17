using System;
using System.Collections.Generic;
using Cinema.Dal.Dbo;

namespace Cinema.Dal.interfaces
{
    public interface IAllMovie
    {
        List<MovieDbo> Movies { get; }

        MovieDbo GetMoviesId(Guid id);
    }
}