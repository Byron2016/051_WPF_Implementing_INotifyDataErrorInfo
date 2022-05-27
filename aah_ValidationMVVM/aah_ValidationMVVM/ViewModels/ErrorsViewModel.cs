using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aah_ValidationMVVM.ViewModels
{
    public class ErrorsViewModel : INotifyDataErrorInfo
    {

        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertyErrors.Any();  //Generado INotifyDataErrorInfo

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged; //Generado INotifyDataErrorInfo

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
        }
    }
}
