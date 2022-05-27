# 051_WPF_Implementing_INotifyDataErrorInfo

- REFERENCIA
	- SingletonSean
		- Implementing INotifyDataErrorInfo (View Model Data Validation) - EASY WPF (.NET CORE)
			- https://www.youtube.com/watch?v=JZth6r2UXLU&list=PLA8ZIAm2I03h8QW3JaGrDBf7cq7F-cT4O&index=8
			
		- Crear un nuevo proyecto	
		- Cambiar nombre de MainWindow y moverla a carpeta Views
		- Crear clase  ViewModels/ViewModelBase que implementa INotifyPropertyChanged
		- Crear DataContext en 
			- Existen dos alternativas, 
				- la primera como lo hicimos en 045_WPF_HandlingRoutedEvents_MVVMCommands
					- En el MainView.xaml.cs colocar DataContext = new MainViewModel();
				- La segunda es trabajando sobre el App.xaml.cs
					- Eliminamos del App.xaml el StartupUri
					- Creamos un método protegido OnStartup el cual inicializa la ventana en el constructor el DataContext
					- Muestra la ventana inicializada.
		- Crear clase ViewModels/CreateProductViewModel que implementa INotifyPropertyChanged
			- Definir las propiedades que tendra la vista (campos)
		- Crear en MainViewModel prop de tipo CreateProductViewModel e inicializarla en constructor.
		- Crear Commands/CreateProductCommand que implementa ICommand
		- Definir propiedad CreateProductCommand en CreateProductViewModel inicializarlo en el constructor
		- Llamar al userControl CreateProductView en el MainView
		
		- Implementar control de errores.
			- En CreateProductViewModel hacer que implemente INotifyDataErrorInfo
			- Definir una propiedad Diccionario que guardará los errores.
			- Implementar método GetErrors retorne la lista de errores.
			- Implementar método HasErrors chequeando si existe alguno
			- Crear método AddError que guardará los errores en el diccionario.
				- Chequeamos si ya existe un errorKey en el diccionario.
				- Agregamos el mensaje de error al errorKey.
			- Crear una validación.
				- Al probar se verifica que no se despliega el mensaje de error, para eso hay que hacer cambios en el textBox.