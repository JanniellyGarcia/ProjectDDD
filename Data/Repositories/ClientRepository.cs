using Data.Context;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(SqlContext context) : base (context)
        {
            
        }

        public Client GetById(int id)
        {
            var obj = CurrentSet
                .Include(x => x.User) // inner join com usuário
                .Where(x => x.Id == id) // Pega do banco de dados e no campo de id coloca o id recebido
                .FirstOrDefault(); // Seleciona somente 1, o primeiro.
            return obj;
        }

        public IEnumerable<Client> GetClientes()
        {
            var obj = CurrentSet
                .Include(x => x.User) // inner join com usuário pois o BaseRepository não consegue identificar essa relações
                .ToList();            // Lista os clientes

            return obj;
        }
    }
}
