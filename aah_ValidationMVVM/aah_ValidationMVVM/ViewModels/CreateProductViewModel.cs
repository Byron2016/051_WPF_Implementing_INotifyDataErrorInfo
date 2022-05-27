using aah_ValidationMVVM.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace aah_ValidationMVVM.ViewModels
{
    public  class CreateProductViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly ErrorsViewModel _errorsViewModel;

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private double _price;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged; //Generado INotifyDataErrorInfo

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;

                _errorsViewModel.ClearErrors(nameof(Price));
                if(_price > 50)
                {
                    _errorsViewModel.AddError(nameof(Price), "Invalid price. The max product price is 50 dolars");
                }

                OnPropertyChanged(nameof(Price));
            }
        }

        public bool CanCreate => !HasErrors; //solo permite crear si no hay errores.

        public ICommand CreateProductCommand { get; }

        public bool HasErrors => _errorsViewModel.HasErrors;

        public CreateProductViewModel()
        {
            CreateProductCommand = new CreateProductCommand(this);

            _errorsViewModel = new ErrorsViewModel();
            //Para poder levantar el ErrorsChanged event. Nos suscrivimos 
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        public IEnumerable GetErrors(string? propertyName) //Generado INotifyDataErrorInfo
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }
    }
}
