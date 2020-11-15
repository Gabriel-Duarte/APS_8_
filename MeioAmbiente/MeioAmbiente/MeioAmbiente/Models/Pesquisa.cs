using System;
using System.Collections.Generic;
using System.Text;

namespace MeioAmbiente.Models
{
    public class Pesquisa
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
    }
}

