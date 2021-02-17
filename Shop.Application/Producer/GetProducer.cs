using System;
using System.Linq;
using System.Linq.Expressions;
using Shop.Application.Producer.ViewModels;
using Shop.Application.Products.ViewModels;
using Shop.Database.Repositories;

namespace Shop.Application.Producer
{
    [Service]
    public class GetProducer
    {
        public static readonly Expression<Func<Domain.Models.Producer, ProducerViewModel>> ProducerMapper = p =>
            new ProducerViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Country = p.Country,
                Products = p.Products.Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Name = p.Name,
                }).ToList(),
            };

        private readonly ProducerRepository _producerRepository;

        public GetProducer(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public ProducerViewModel Do(int producerId)
        {
            return _producerRepository.GetProducerById(producerId, ProducerMapper);
        }
    }
}