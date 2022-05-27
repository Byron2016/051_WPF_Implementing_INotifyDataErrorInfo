using aah_ValidationMVVM.Commands;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace aah_ValidationMVVM.ViewModels
{
    public  class CreateProductViewModel : ViewModelBase, INotifyDataErrorInfo
    {
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
                OnPropertyChanged(nameof(Price));
            }
        }

        public ICommand CreateProductCommand { get; }

        public bool HasErrors => throw new NotImplementedException(); //Generado INotifyDataErrorInfo

        public CreateProductViewModel()
        {
            CreateProductCommand = new CreateProductCommand(this);
        }

        public IEnumerable GetErrors(string? propertyName) //Generado INotifyDataErrorInfo
        {
            throw new NotImplementedException();
        }
    }
}
