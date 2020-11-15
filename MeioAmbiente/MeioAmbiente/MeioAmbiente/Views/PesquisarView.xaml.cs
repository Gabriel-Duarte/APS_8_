using MeioAmbiente.Models;
using MeioAmbiente.Services;
using MeioAmbiente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeioAmbiente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PesquisarView : ContentPage
    {
        public PesquisarView()
        {
            InitializeComponent();
            BindingContext = new PesquisaViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CacelarMensagens();
        }
        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<PesquisaException>(this, "FalhaPesquisa",
             async (exc) =>
             {
                 await DisplayAlert("Pesquisa", exc.Message, "Ok"); // envia a mensagem de erro na tela que vem da PesquisaViewModel
                                                                    // await Navigation.PopToRootAsync(); // desempilha as paginas ate a primeira pagina
             });

            MessagingCenter.Subscribe<Pesquisa>(this, "Pesquisar", async (msg) => // THIS EH A PAGINA, ENTRAR EH A MENSAGEM QUE ELE ENVIA
            {
                indi.IsRunning = true;

                await DandoUmTempo(2000);
                await Navigation.PushAsync(new DadosPesquisaView(msg)); // pushasync permiti empilhar mais uma pag de navegacao para navegar

            });
        }
        private void CacelarMensagens()
        {
            MessagingCenter.Unsubscribe<Pesquisa>(this, "Pesquisar");
            MessagingCenter.Unsubscribe<PesquisaException>(this, "FalhaPesquisa");
        }

        /// <summary>
        /// Metodo para ActivityIndicator aparecer
        /// </summary>
        /// <param name="valor">tempo de espera que o ActivityIndicator vai aparacer</param>
        /// <returns></returns>
        async Task DandoUmTempo(int valor)
        {
            await Task.Delay(valor);
            indi.IsRunning = false;
        }
    }
}