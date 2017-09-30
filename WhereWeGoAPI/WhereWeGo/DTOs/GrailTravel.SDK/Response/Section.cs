using System.Collections.Generic;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Section
    {
        public IList<Offer> offers { get; set; }
        public IList<Train> trains { get; set; }
    }
}