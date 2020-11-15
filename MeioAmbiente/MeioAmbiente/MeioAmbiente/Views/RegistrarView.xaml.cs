using MeioAmbiente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeioAmbiente.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeioAmbiente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarView : ContentPage
    {
        public Pesquisa Pesquisa{ get; set; } //vai receber propriedades da pagina anterior -------------
        public RegistrarView(Pesquisa pesquisa) // recebe o objeto pesquisa da pesquisaViewModel             |
        {                                           //                                                       |
            InitializeComponent();                  //                 ---------------------------------------                                    
            this.Pesquisa = pesquisa;           //               <-| catastrofe da pagina anterior passa as propriedades para o Catastroe dessa pagina atual
            this.BindingContext = new RegistrarViewModel(pesquisa);
        }
        protected override void OnAppearing() //OneAppearing significa o momento em que a pagina esta aparecendo
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Registrar>(this, "Registrar", async (msg) => 
            {
                await Navigation.PopToRootAsync();
            });
        }
    }
}