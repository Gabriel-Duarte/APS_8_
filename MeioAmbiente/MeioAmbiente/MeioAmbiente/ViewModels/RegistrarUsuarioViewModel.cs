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
    public class RegistrarUsuarioViewModel : BaseViewModel
    {
        public RegistrarUsuario Usuario { get; set; }
        public string Username
        {
            get
            {
                return Usuario.Username;
            }
            set
            {
                Usuario.Username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return Usuario.Password;
            }
            set
            {
                Usuario.Password = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return Usuario.Email;
            }
            set
            {
                Usuario.Email = value;
                OnPropertyChanged();
            }
        }
        public string Telefone
        {
            get
            {
                return Usuario.Telefone;
            }
            set
            {
                Usuario.Telefone = value;
                OnPropertyChanged();
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
        public Command CadastrarCommand { get; set; }
        private async Task CadastrarCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var userService = new FirebaseService();
                Result = await userService.RegistrarUsuario(Username, Password, Telefone, Email);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Usuário Registrado", "Ok");
                    await Application.Current.MainPage.Navigation.PopToRootAsync();
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Erro", "Falha ao registrar usuário", "Ok");
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
        public RegistrarUsuarioViewModel()
        {
            this.Usuario = new RegistrarUsuario();
            CadastrarCommand = new Command(async () => await CadastrarCommandAsync());
        }
    }
}
