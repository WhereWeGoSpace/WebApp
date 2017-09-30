using System;
using System.Collections.Generic;
using System.Linq;
using WhereWeGo.DTOs;
using WhereWeGo.Models.Interfaces;

namespace WhereWeGo.Models.Implements
{
    public class JourneyService : IJourneyService
    {
        private IEnumerable<Traveling> _favorit;

        public JourneyService()
        {
            this._favorit = new List<Traveling> {
                //德国
                new Traveling{ From="Berlin Hbf", To="München Hbf", Price=200   },
                new Traveling { From="Frankfurt(Main)Hbf", To="München Hbf", Price = 100 },
                new Traveling { From="Frankfurt(M) Flughafen", To="München Hbf", Price = 100 },
                new Traveling { From="Frankfurt(Main)Hbf", To="Stuttgart Hbf", Price = 100 },
                new Traveling { From="Frankfurt(Main)Hbf", To="Köln Hbf", Price = 100 },
                new Traveling { From="Frankfurt(Main)Hbf", To="Düsseldorf Hbf", Price = 100 },
                new Traveling { From="Frankfurt(Main)Hbf", To="Berlin Hbf", Price = 100 },
                new Traveling { From="Berlin Hbf", To="Hamburg Hbf", Price = 100 },

                //意大利
                new Traveling { From="Roma Termini", To="Venezia S. Lucia", Price = 100 },
                new Traveling { From="Roma Termini", To="Milano Centrale", Price = 100 },

                //跨国线路-德国出发
                new Traveling { From="Frankfurt(Main)Hbf", To="Paris Est", Price = 100 },
                new Traveling { From="Hamburg Hbf", To="Amsterdam Centraal", Price = 100 },
                new Traveling { From="Frankfurt(Main)Hbf", To="Amsterdam Centraal", Price = 100 },
                new Traveling { From="Frankfurt(Main)Hbf", To="Bruxelles-Midi", Price = 100 },
                new Traveling { From="München Hbf", To="Wien Hbf", Price = 100 },
                new Traveling { From="München Hbf", To="Praha hl.n.(Prag HBF)", Price = 100 },
                new Traveling { From="München Hbf", To="Venezia S. Lucia", Price = 100 },
            };
        }

        public object Random { get; private set; }

        public void SetTravelings(IEnumerable<Traveling> ieTr)
        {
            this._favorit = ieTr;
        }

        public Traveling GetRandomTraveling()
        {
            Traveling result = null;

            Random random = new Random();
            int num = random.Next() % this._favorit.Count();

            result = this._favorit.ElementAt(num);

            return result;
        }
    }
}