using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P03AplikacjaPogodaClientAPI.ViewModels.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        public SearchCommand(WeatherVM VM)
        {
            this.VM = VM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
            //throw new NotImplementedException();
        }

        // klikniecie w przyccisk
        public void Execute(object? parameter)
        {
            VM.FindCities();
        }
    }
}
