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
                new Traveling{ From="Berlin", To="Munchen", Price=200   },
                new Traveling { From="Frankfurt", To="Paris", Price = 100 }
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