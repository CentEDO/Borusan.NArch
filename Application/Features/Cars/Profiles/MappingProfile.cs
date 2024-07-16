using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetAll;
using Application.Features.Cars.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, CreatedCarResponse>().ReverseMap();

            CreateMap<Car, DeletedCarResponse>().ReverseMap();

            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, UpdatedCarResponse>().ReverseMap();

            CreateMap<Car, GetAllCarItemResponse>().ReverseMap();

            CreateMap<Car, GetByIdCarResponse>().ReverseMap();
        }
    }
}
