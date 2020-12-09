using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Models
{
    public class CartServicesProfiles : Profile
    {

        public CartServicesProfiles()
        {
            InitCartMapper();
            InitCartItemMapper();
        }

        private void InitCartItemMapper()
        {
            CreateMap<CartItemDTO, CartItem>()
                .ReverseMap();

        }

        private void InitCartMapper()
        {
            CreateMap<Cart, CartDTO>()
                .ForMember(dest => dest.CartItems, src => src.MapFrom(src => src.CartItems.ToList()))
                .ReverseMap();
        }
    }
}
