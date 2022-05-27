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
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

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

                ClearErrors(nameof(Price));
                if(_price > 50)
                {
                    AddError(nameof(Price), "Invalid price. The max product price is 50 dolars");
                }

                OnPropertyChanged(nameof(Price));
            }
        }

        public bool CanCreate => !HasErrors; //solo permite crear si no hay errores.

        public ICommand CreateProductCommand { get; }

        public bool HasErrors => _propertyErrors.Any();  //Generado INotifyDataErrorInfo

        public CreateProductViewModel()
        {
            CreateProductCommand = new CreateProductCommand(this);
        }

        public IEnumerable GetErrors(string? propertyName) //Generado INotifyDataErrorInfo
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {
            // remover el propertyName key del diccionario.
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorChanged(propertyName);
            }
            
        }

        private void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(CanCreate));
        }
    }
}
