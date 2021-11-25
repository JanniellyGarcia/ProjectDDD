using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Venda : BaseEntity
    {
        public int PoductId { get; set; }
        public Product product { get; set; }
        public int ClientId { get; set; }
        public Client client { get; set; }
    }
}
