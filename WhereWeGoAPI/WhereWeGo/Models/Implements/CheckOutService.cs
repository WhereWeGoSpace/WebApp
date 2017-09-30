using WhereWeGo.DTOs;
using WhereWeGo.Models.Interfaces;

namespace WhereWeGo.Models.Implements
{
    public class CheckOutService : ICheckOutService
    {
        public bool BookTraveling(Traveling tr, UserInfo userInfo)
        {
            return true;
        }

        public bool Pay(decimal amount)
        {
            return true;
        }
    }
}