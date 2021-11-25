using AutoMapper;
using Domain.Interface;
using Service.Intefaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var product = _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductViewModel>>(product);
        }
    }
}
