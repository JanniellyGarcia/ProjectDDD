using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> GetVendas();
        Venda GetId(int id1, int id2);
    }
}
