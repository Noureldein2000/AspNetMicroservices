using AutoMapper;
using Basket.API.Entities;
using EventBus.Messages.Events;

namespace Basket.API.Mapper
{
    public class basketProfile:Profile
    {
        public basketProfile()
        {
            CreateMap<BasketCheckout, BasektCheckoutEvent>().ReverseMap();
        }
    }
}
