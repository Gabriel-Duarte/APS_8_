using Firebase.Database;
using Firebase.Database.Query;
using MeioAmbiente.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioAmbiente.Services
{
    public class FirebaseService
    {
        FirebaseClient client;

        public FirebaseService()
        {
            client = new FirebaseClient("https://meioambientexamarin.firebaseio.com/");
        }

        /// <summary>
        /// Metodo para Registrar a pesquisa e as informações da catastrofe no banco
        /// </summary>
        /// <param name="registrar">Objeto que sera enviado para o banco como catastrofe</param>
        /// <returns></returns>
        public async Task<bool> AdicionarCatastrofe(Registrar registrar)
        {
            await client.Child("Registros")
                .PostAsync(new Registrar()
                {
                    DeslizamentoTerra = registrar.DeslizamentoTerra,
                    Queimada = registrar.Queimada,
                    RompimentoBarragem = registrar.RompimentoBarragem,
                    DataRegistro = registrar.DataRegistro,
                    Alagamento = registrar.Alagamento,
                    Outros = registrar.Outros,
                    AreaTexto = registrar.AreaTexto,
                    Pesquisa = registrar.Pesquisa
                });
            return true;
        }

        /// <summary>
        /// Metodo para Gerar uma lista de catastrofes registradas no banco
        /// </summary>
        /// <returns></returns>
        public async Task <List<Registrar>> RecuperarLista()
        {
            var list = (await client
                .Child("Registros")
                .OnceAsync<Registrar>())
                .Select(item =>
                        new Registrar
                        {
                            Alagamento = item.Object.Alagamento,
                            Queimada = item.Object.Queimada,
                            DeslizamentoTerra = item.Object.DeslizamentoTerra,
                            RompimentoBarragem = item.Object.RompimentoBarragem,
                            Outros = item.Object.Outros,
                            DataRegistro = item.Object.DataRegistro,
                            AreaTexto = item.Object.AreaTexto,
                            Pesquisa = item.Object.Pesquisa
                        }).ToList();
            return list;
        }

        /// <summary>
        /// Metodo de Login do Usuario
        /// </summary>
        /// <param name="name">Nome do usuario</param>
        /// <param name="password">Senha do usuario</param>
        /// <returns></returns>
        public async Task<bool> LoginUsuario(string name, string password)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>())
                .Where(u => u.Object.Username == name)
                .Where(u => u.Object.Password == password)
                .FirstOrDefault();

            return (user != null);
        }

        /// <summary>
        /// Metodo para registrar o usuario no banco de dados
        /// </summary>
        /// <param name="name">Nome do usuario</param>
        /// <param name="password">Senha do usuario</param>
        /// <param name="telefone">Telefone do usuario</param>
        /// <param name="email">Email do usuario</param>
        /// <returns></returns>
        public async Task<bool> RegistrarUsuario(string name, string password,string telefone, string email)
        {
            if(await LoginUsuario(name,password)==false)
            {
                await client.Child("Users")
                    .PostAsync(new RegistrarUsuario()
                    {
                        Username = name,
                        Password = password,
                        Email = email,
                        Telefone = telefone
                    });
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
