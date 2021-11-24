using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class UserViewModel
    {
        [JsonPropertyName("Cpf")]
        public string CPF { get; set; }

        [JsonPropertyName("Endereço")]
        public string Andress { get; set; }

        [JsonPropertyName("Cep")]
        public string CEP { get; set; }

        [JsonPropertyName("Id Usuário")]
        public int UserId { get; set; }
        [JsonPropertyName("Usuário")]
        public UserViewModel user { get; set; }



    }
}
