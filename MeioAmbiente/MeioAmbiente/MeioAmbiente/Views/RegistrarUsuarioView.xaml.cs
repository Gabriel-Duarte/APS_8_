using MeioAmbiente.Models;
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
    public partial class RegistrarUsuarioView : ContentPage
    {
        public RegistrarUsuarioView()
        {
            InitializeComponent();
            this.BindingContext = new RegistrarUsuarioViewModel();
        }
    }
}
