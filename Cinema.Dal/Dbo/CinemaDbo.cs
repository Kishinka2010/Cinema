using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Dal.Dbo
{
    public class CinemaDbo: BaseDbo
    {
        public string Title { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public List<HallDbo> Halls { get; set; }

    }
}
