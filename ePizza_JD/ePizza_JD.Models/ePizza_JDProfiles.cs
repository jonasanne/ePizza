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
        }

        private void InitPizzaMapper()
        {
            //CATEGORY Mapping:------------------------------------------------
            //--- relaties mappen naar vlakke structuur
            //--- Identity Column niet meenemen
            CreateMap<Pizza, PizzaDTO>()
            .ForMember(dest => dest.Id, src => src.MapFrom(rr => rr.PizzaToppings.Select(r => r.ToppingName).ToList()));
            //.ReverseMap();




    }
}
}
