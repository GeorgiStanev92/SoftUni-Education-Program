using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SuppliersInputDto, Supplier>();
            CreateMap<PartsInputDto, Part>();

            CreateMap<Customer, CustomerOutputDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
