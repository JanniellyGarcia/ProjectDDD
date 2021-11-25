using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class VendaViewModel
    {
        [JsonPropertyName("Id do Produto")]

        public int PoductId { get; set; }

        [JsonPropertyName("Produto")]
        public ProductViewModel product { get; set; }

        [JsonPropertyName("Id de Cliente")]
        public int ClientId { get; set; }
        public ClientViewModel client { get; set; }
    }
}
