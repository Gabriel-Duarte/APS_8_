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
    public partial class DadosPesquisaView : ContentPage
    {
        public Pesquisa Pesquisa { get; set; }
        public DadosPesquisaView(Pesquisa Pesquisa)
        {
            InitializeComponent();
            this.Pesquisa = Pesquisa;
            this.BindingContext = new DadosPesquisaViewModel(Pesquisa);
        }
        protected override void OnAppearing() //OneAppearing significa o momento em que a pagina esta aparecendo
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Pesquisa>(this, "Entrar", (msg) => // THIS EH A PAGINA, ENTRAR EH A MENSAGEM QUE ELE ENVIA
            {
                Navigation.PushAsync(new RegistrarView(msg)); // pushasync permiti empilhar mais uma pag de navegacao para navegar
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Pesquisa>(this, "Entrar");
        }
    }
}