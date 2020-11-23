using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaServices.Models;

namespace ePizza_JD.Models
{
    public class ePizza_JDProfiles : Profile
    {
        public ePizza_JDProfiles()
        {
            InitPizzaMapper();
            InitToppingMapper();
            //InitCustomerMapper();
            InitReviewMapper();
        }

        private void InitReviewMapper()
        {
            CreateMap<Review, ReviewDTO>()
            .ReverseMap()
            .ForMember(dest => dest.ReviewId, src => src.Ignore());
            
        }

        //private void InitCustomerMapper()
        //{
        //    CreateMap<Customer, CustomerDTO>()
        //        .ForMember(dest => dest.Id, src => src.MapFrom(t => t.CustomerId))
        //        .ReverseMap();
        //}

        private void InitToppingMapper()
        {
            //Topping Mapping:------------------------------------------------
            //--- relaties mappen naar vlakke structuur
            //--- Identity Column niet meenemen
            CreateMap<Topping, ToppingDTO>()
                .ReverseMap();

        }

        private void InitPizzaMapper()
        {
            //Pizza Mapping:------------------------------------------------
            CreateMap<Pizza, PizzaDTO>()
            .ForMember(dest => dest.Id, src => src.MapFrom(p => p.PizzaId))
            .ForMember(dest => dest.Topppings, src => src.MapFrom(src => src.PizzaToppings.Select(e => e.Topping.Name)))
            .ForMember(dest => dest.Reviews, src => src.MapFrom(src => src.Reviews.ToList()))
            .ReverseMap();

            CreateMap<Pizza, PizzaEditCreateDTO>()
            .ForMember(dest => dest.Id, src => src.MapFrom(p => p.PizzaId))
            .ForMember(dest => dest.Toppings, src => src.MapFrom(src => src.PizzaToppings.Select(e => e.Topping.Name)))
            .ReverseMap()
            .ForMember(dest => dest.Reviews, src => src.Ignore());
        }

}
}
