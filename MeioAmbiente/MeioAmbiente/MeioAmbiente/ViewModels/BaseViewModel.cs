using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MeioAmbiente.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // avisa a view na mudança de algum dado
        public void OnPropertyChanged([CallerMemberName] string name = "") // SE NAO PASSAR NADA NA CHAMADA O NOME DA PROPRIEDADE SERA O QUE VAI SER PASSADO 01
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); // ? operador nulo condicional
        }
    }
}
