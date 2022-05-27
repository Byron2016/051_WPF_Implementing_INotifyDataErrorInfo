using aah_ValidationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace aah_ValidationMVVM.Commands
{
    public class CreateProductCommand : ICommand
    {
        private readonly CreateProductViewModel _viewModel;

        public event EventHandler? CanExecuteChanged; //Autogenerado

        public CreateProductCommand(CreateProductViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter) //Autogenerado
        {
            return true; //AutogeneradoModificado
        }
        //public bool CanExecute(object parameter) => true;

        public void Execute(object? parameter) //Autogenerado
        {
            MessageBox.Show($"Successfully created '{_viewModel.Name}' for {_viewModel.Price:C}.");
        }
    }
}
