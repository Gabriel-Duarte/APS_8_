using MeioAmbiente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeioAmbiente.Services
{
    public class ViaCepService
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        /// <summary>
        /// Metodo para trazer informacoes a partir do Cep informado
        /// </summary>
        /// <param name="cep">Que a api vai trazer informações </param>
        /// <returns></returns>
        public static Pesquisa BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            try
            {
                string Conteudo = wc.DownloadString(NovoEnderecoURL);
                Pesquisa end = JsonConvert.DeserializeObject<Pesquisa>(Conteudo);
                if (end.Cep == null)
                {
                    MessagingCenter.Send<PesquisaException>(new PesquisaException("cep incorreto, por favor colocar um valido"), "FalhaPesquisa");
                }
                return end;
            }
            catch // CEP ESTIVER ERRADO RETORNA NULL 
            {
                MessagingCenter.Send<PesquisaException>(new PesquisaException("cep incorreto, por favor colocar um valido"), "FalhaPesquisa");
                return null;
            }
        }
    }

    // CLASSE PARA PEGAR A MENSAGEM DE ERRO DA REQUISIÇÃO 
    public class PesquisaException : Exception
    {
        public PesquisaException(string message) : base(message)
        {

        }
    }
}


