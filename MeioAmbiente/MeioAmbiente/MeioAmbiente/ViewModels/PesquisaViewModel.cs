using MeioAmbiente.Models;
using MeioAmbiente.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MeioAmbiente.Views;

namespace MeioAmbiente.ViewModels
{
    public class PesquisaViewModel : BaseViewModel
    {
        public Pesquisa Pesquisa { get; set; }
        public string Cep
        {
            get
            {
                return Pesquisa.Cep;
            }
            set
            {
                Pesquisa.Cep = value;
                OnPropertyChanged();
                ((Command)PesquisarCommand).ChangeCanExecute();
            }
        }
        public ICommand PesquisarCommand { get; set; } // utlizando comando para o botao Entrar
        public PesquisaViewModel()
        {
            this.Pesquisa = new Pesquisa();

            PesquisarCommand = new Command(async () =>
            {
                var viaCepService = new ViaCepService();
                try
                {
                    this.Pesquisa = ViaCepService.BuscarEnderecoViaCEP(Pesquisa.Cep);

                    if (Pesquisa.Cep != null)
                    {
                        MessagingCenter.Send(this.Pesquisa, "Pesquisar"); // ENVIA O OBJETO PARA PROXIMA PAGINA
                    }
                }
                catch
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Cep); // não habilita o botão entrar se o campo n estiver preenchido
            });
        }
    }
}
