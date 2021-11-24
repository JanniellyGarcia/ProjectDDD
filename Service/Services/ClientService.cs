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
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientViewModel> GetClientes()
        {
            var client = _clientRepository.GetClientes();
            return _mapper.Map<IEnumerable<ClientViewModel>>(client); //mapeado objetos de model para viewmodel
        }
    }
}
