using AutoMapper;
using Domain.Interface;
using Domain.Models;
using Service.Intefaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public int PoductId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Product product { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ClientId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Client client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public VendaService(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public IEnumerable<VendaViewModel> GetProducts()
        {
            var vendas = _vendaRepository.GetVendas();
            return _mapper.Map<IEnumerable<VendaViewModel>>(vendas);
        }
    }
}
