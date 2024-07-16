using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Repositories;
using AutoMapper;
using Application.Pipeline.Logging;
namespace Application.Features.Brands.Commands.Create
{
    //Unit, fonksiyondaki voide denk geliyor.
    public class CreateBrandCommand : IRequest<CreatedBrandResponse> , ILoggableRequest
    {
        //Komutun işlevini yerine getirmesi için  alması gereken argümanlar
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            //Gerekli bağımlılıklar
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                //İlgili request ile istedğimiz işlemi yapabiliriz.
                //map

                //eğer isimler aynıysa automapper bunu otomatize eder.
                //Brand brand = new Brand()
                //{
                //    Name = request.Name
                //};

                Brand brand = _mapper.Map<Brand>(request);

                Brand addedBrand = await _brandRepository.AddAsync(brand);

                //map
                //CreatedBrandResponse response = new()
                //{
                //    Id = addedBrand.Id,
                //    Name = addedBrand.Name
                //};

                CreatedBrandResponse response = _mapper.Map<CreatedBrandResponse>(addedBrand);

                return response;
            }
        }
    }
}
