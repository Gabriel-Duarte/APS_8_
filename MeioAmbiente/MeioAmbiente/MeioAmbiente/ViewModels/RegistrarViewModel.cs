using MeioAmbiente.Models;
using MeioAmbiente.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeioAmbiente.ViewModels
{
    public class RegistrarViewModel : BaseViewModel
    {
        public Registrar Registrar { get; set; }
        public Pesquisa Pesquisa
        {
            get
            {
                return Registrar.Pesquisa;
            }
            set
            {
                Registrar.Pesquisa = value;
            }
        }
        public DateTime DataRegistro
        {
            get
            {
                return Registrar.DataRegistro;
            }
            set
            {
                Registrar.DataRegistro = value;
            }
        }
        public string TextoQueimada
        {
            get
            {
                return $"Queimada";
            }
        }
        public string TextoAlagamento
        {
            get
            {
                return $"Alagamento";
            }
        }
        public string TextoDeslizamento
        {
            get
            {
                return $"Deslizamento de Terra";
            }
        }
        public string TextoRompimentoBarragem
        {
            get
            {
                return $"Rompimento de Barragem";
            }
        }
        public string TextoOutros
        {
            get
            {
                return $"Outro Desastre";
            }
        }
        public string AreaTexto
        {
            get
            {
                return Registrar.AreaTexto;
            }
            set
            {
                Registrar.AreaTexto = value;
                OnPropertyChanged(); // avisa a pagina que teve um mudanca em uma propriedade do bidding
                ((Command)RegistrarCommand).ChangeCanExecute();
            }
        }
        public Boolean Queimada
        {
            get
            {
                return Registrar.Queimada;
            }
            set
            {
                Registrar.Queimada = value;
                OnPropertyChanged(); // avisa a pagina que teve um mudanca em uma propriedade do bidding
            }
        }
        public Boolean Alagamento
        {
            get
            {
                return Registrar.Alagamento;
            }
            set
            {
                Registrar.Alagamento = value;
                OnPropertyChanged(); // avisa a pagina que teve um mudanca em uma propriedade do bidding
            }
        }
        public Boolean DeslizamentoTerra
        {
            get
            {
                return Registrar.DeslizamentoTerra;
            }
            set
            {
                Registrar.DeslizamentoTerra = value;
                OnPropertyChanged(); // avisa a pagina que teve um mudanca em uma propriedade do bidding
            }
        }
        public Boolean RompimentoBarragem
        {
            get
            {
                return Registrar.RompimentoBarragem;
            }
            set
            {
                Registrar.RompimentoBarragem = value;
                OnPropertyChanged(); // avisa a pagina que teve um mudanca em uma propriedade do bidding
            }
        }
        public Boolean Outros
        {
            get
            {
                return Registrar.Outros;
            }
            set
            {
                Registrar.Outros = value;
                OnPropertyChanged(); // avisa a pagina que teve um mudanca em uma propriedade do bidding
            }
        }
        private bool _Result;
        public bool Result
        {
            get
            {
                return this._IsBusy;
            }
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
        }
        public ICommand RegistrarCommand { get; set; }
        private async Task RegistrarCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var firebaseService = new FirebaseService();
                Result = await firebaseService.AdicionarCatastrofe(this.Registrar);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Desastre registrada com sucesso", "Ok");
                    MessagingCenter.Send(this.Registrar, "Registrar");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Erro", "Falha ao registrar catástrofe", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public RegistrarViewModel(Pesquisa pesquisa)
        {
            this.Registrar = new Registrar();
            this.Registrar.Pesquisa = pesquisa;
            RegistrarCommand = new Command(async () => await RegistrarCommandAsync(),() =>
            {
                return !string.IsNullOrEmpty(this.AreaTexto); // não habilita o botão entrar se o campo n estiver preenchido
            });
        }
    }
}
