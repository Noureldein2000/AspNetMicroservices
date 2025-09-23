using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Order.Commands.CheckoutOrder;

namespace Ordering.API.Mapper
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<CheckoutOrderCommand, BasektCheckoutEvent>().ReverseMap();
        }
    }
}
