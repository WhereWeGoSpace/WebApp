using System.Collections.Generic;
using WhereWeGoAPI.DTOs;

namespace WhereWeGoAPI.Models.Interfaces
{
    public interface IJourneyService
    {
        void SetTravelings(IEnumerable<Traveling> ieTr);

        Traveling GetRandomTraveling();
    }
}
