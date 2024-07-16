using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();

            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();

            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, DeletedBrandResponse>().ReverseMap();

            CreateMap<Brand, GetAllBrandItemResponse>().ReverseMap();
            CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();

        }
    }
}
