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
            InitCustomerMapper();

        }

        private void InitCustomerMapper()
        {
            CreateMap<CustomerDTO, Customer >()
                .ForMember(dest => dest.CustomerId, src => src.Ignore())
                .ReverseMap();
        }


    }
}
