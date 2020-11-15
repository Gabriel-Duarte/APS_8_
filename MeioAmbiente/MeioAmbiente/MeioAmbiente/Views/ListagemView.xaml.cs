using MeioAmbiente.Models;
using MeioAmbiente.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeioAmbiente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListagemView : ContentPage
    {
        FirebaseService FirebaseService = new FirebaseService();
        public ListagemView()
        {
            InitializeComponent();
        }
        
        //quando a tela aparecer Onappearing é chamado e em seguida carrega a lista de desastres
        protected async override void OnAppearing()
        {
            await ExibeDesastre();
        }

        private async Task ExibeDesastre()
        {
            var lista = await FirebaseService.RecuperarLista();
            _lst.BindingContext = lista;
        }
    }
}