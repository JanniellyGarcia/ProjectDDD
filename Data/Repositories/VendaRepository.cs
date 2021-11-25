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
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(SqlContext context) : base(context)
        {

        }


        public Venda GetId(int id1, int id2)
        {
            var obj = CurrentSet
                  .Include(x => x.product)
                  .Include(y => y.client)
                  .Where(x => x.Id == id1)
                  .Where(y => y.Id == id2)
                  .FirstOrDefault();
            return obj;
        }

        public IEnumerable<Venda> GetVendas()
        {
            var obj = CurrentSet
                      .Include(x => x.product)
                      .Include(y => y.client)
                      .ToList();
            return obj;
        }
    }
}
