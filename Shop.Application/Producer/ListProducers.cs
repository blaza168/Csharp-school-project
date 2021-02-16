using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Shop.Application.Producer.ViewModels;
using Shop.Application.Products;
using Shop.Application.Products.ViewModels;
using Shop.Database.Repositories;
using Shop.Domain.Models;

namespace Shop.Application.Producer
{
    [Service]
    public class ListProducers
    {
        private readonly ProducerRepository _producerRepository;

        public ListProducers(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public IEnumerable<ProducerViewModel> Do()
        {
            return _producerRepository.GetProducers(selector: p => new ProducerViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Country = p.Country,
                Products = p.Products.Select(product => new ProductViewModel
                {
                    Id = product.Id
                }).ToList(),
            });
        }
    }
}