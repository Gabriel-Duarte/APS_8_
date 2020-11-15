using MeioAmbiente.Models;
using MeioAmbiente.Services;
using MeioAmbiente.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeioAmbiente.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public User User { get; set; }
        public string Username
        {
            get
            {
                return User.Username;
            }
            set
            {
                User.Username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return User.Password;
            }
            set
            {
                User.Password = value;
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
        public Command LoginCommand { get; set; }
        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var userService = new FirebaseService();
                Result = await userService.LoginUsuario(Username, Password);
                if (Result)
                {
                    MessagingCenter.Send<User>(this.User, "SucessoLogin");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Erro", "Usuário/Senha inválido(s)", "Ok");
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
        public LoginViewModel()
        {
            this.User = new User();
            LoginCommand = new Command(async () => await LoginCommandAsync());

        }
    }
}
