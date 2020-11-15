using System;
using System.Collections.Generic;
using System.Text;

namespace MeioAmbiente.Models
{
    public class Registrar
    {
        public Pesquisa Pesquisa { get; set; }
        public DateTime DataRegistro
        {
            get
            {
                return dataRegistro;
            }
            set
            {
                dataRegistro = value;
            }
        }
        public bool Queimada { get; set; }
        public bool Alagamento { get; set; }
        public bool DeslizamentoTerra { get; set; }
        public bool RompimentoBarragem { get; set; }
        public bool Outros { get; set; }
        public string AreaTexto { get; set; }

        DateTime dataRegistro = DateTime.Now;
    }
}
