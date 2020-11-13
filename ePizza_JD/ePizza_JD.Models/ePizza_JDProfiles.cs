using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ePizza_JD.Models
{
    public class ePizza_JDProfiles : Profile
    {
        public ePizza_JDProfiles()
        {
            InitPizzaMapper();
            InitToppingMapper();

        }

        private void InitToppingMapper()
        {
            //CATEGORY Mapping:------------------------------------------------
            //--- relaties mappen naar vlakke structuur
            //--- Identity Column niet meenemen
            CreateMap<Topping, ToppingDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(t => t.ToppingId))
                .ReverseMap();

        }

        private void InitPizzaMapper()
        {
            //CATEGORY Mapping:------------------------------------------------
            //--- relaties mappen naar vlakke structuur
            //--- Identity Column niet meenemen
            CreateMap<Pizza, PizzaDTO>()
            .ForMember(dest => dest.Id, src => src.MapFrom(p => p.PizzaId))
            //.ForMember(dest=> dest.Topppings, src => src.MapFrom(p => p.PizzaToppings))
            .ReverseMap();




        }

}
}
