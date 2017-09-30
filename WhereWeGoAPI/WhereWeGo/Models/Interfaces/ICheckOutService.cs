using WhereWeGo.DTOs;

namespace WhereWeGo.Models.Interfaces
{
    public interface ICheckOutService
    {
        bool Pay(decimal amount);
        bool BookTraveling(Traveling tr, UserInfo userInfo);
    }
}
