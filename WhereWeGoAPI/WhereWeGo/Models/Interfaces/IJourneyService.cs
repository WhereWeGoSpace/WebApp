using System.Collections.Generic;
using WhereWeGo.DTOs;

namespace WhereWeGo.Models.Interfaces
{
    public interface IJourneyService
    {
        void SetTravelings(IEnumerable<Traveling> ieTr);

        Traveling GetRandomTraveling();
    }
}
