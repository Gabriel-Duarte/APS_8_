using MeioAmbiente.Models;
using MeioAmbiente.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeioAmbiente.ViewModels
{
    public class DadosPesquisaViewModel : BaseViewModel
    {
        public Pesquisa Pesquisa { get; set; }
        public string Logradouro
        {
            get
            {
                return Pesquisa.Logradouro;
            }
            set
            {
                Pesquisa.Logradouro = value;
                OnPropertyChanged();
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        public string Bairro
        {
            get
            {
                return Pesquisa.Bairro;
            }
            set
            {
                Pesquisa.Bairro = value;
                OnPropertyChanged();
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        public string Localidade
        {
            get
            {
                return Pesquisa.Localidade;
            }
            set
            {
                Pesquisa.Localidade = value;
                OnPropertyChanged();
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        public string Uf
        {
            get
            {
                return Pesquisa.Uf;
            }
            set
            {
                Pesquisa.Uf = value;
                OnPropertyChanged();
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
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
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        public ICommand EntrarCommand { get; set; }
        public ICommand VerMapaCommand { get; set; }
        public DadosPesquisaViewModel(Pesquisa pesquisa)
        {
            this.Pesquisa = new Pesquisa();
            this.Pesquisa = pesquisa;

            VerMapaCommand = new Command(() =>
            {
                MapaService.PoeEnderecoMapa(this.Pesquisa);
            });

            EntrarCommand = new Command(() =>
            {
                MessagingCenter.Send(this.Pesquisa, "Entrar");// ENVIA O OBJETO PARA PROXIMA PAGINA
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Logradouro) // não habilita o botão entrar se o campo n estiver preenchido
                    && !string.IsNullOrEmpty(this.Localidade)
                    && !string.IsNullOrEmpty(this.Bairro)
                    && !string.IsNullOrEmpty(this.Cep)
                    && !string.IsNullOrEmpty(this.Uf);
            });
        }
    }
}
