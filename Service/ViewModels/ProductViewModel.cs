using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class ProductViewModel
    {

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Preco")]
        public double Price { get; set; }

        [JsonPropertyName("Peso")]
        public double Weight { get; set; }

    }
}
