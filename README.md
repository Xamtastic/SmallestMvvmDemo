# SmallestMvvmDemo
Hello SmallestMvvm demonstration of SmallestMvvm available at Nuget at https://www.nuget.org/packages/Com.Xamtastic.Patterns.SmallestMvvm

ViewModel injection is achieved via a page class decoration, where the page implements PageBase, which itself implements ContentPage:

```
    [ViewModelType(typeof(MainPageViewModel))]
    public partial class MainPage : PageBase
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
```

Changing a page's 'ContentPage' declaration to 'PageBase' means that the Xaml must reflect the same change, as follows:

```
<?xml version="1.0" encoding="utf-8" ?>
<mvvm:PageBase xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:mvvm="clr-namespace:Com.Xamtastic.Patterns.SmallestMvvm;assembly=Com.Xamtastic.Patterns.SmallestMvvm"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Com.Xamtastic.SmallestMvvmDemo.Pages.MainPage">
  <Label Text="{Binding Message}" VerticalOptions="Center" HorizontalOptions="Center" />
</mvvm:PageBase>
```

The page's binding to a View Model is as per usual:

```
    public class MainPageViewModel : ViewModelBase
    {
        private string _message = "Hello SmallestMvvm!";
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged("Message"); }
        }
    }
```

The View Model injection into the page isn't magical, the ViewModelType attribute is declared in the Nuget package as follows:

```
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewModelTypeAttribute : Attribute
    {
        public ViewModelTypeAttribute(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }

        public Type ViewModelType { get; private set; }
    }
```

This allows it to be detected, instantiated, and bound, in the PageBase, which in the Nuget package is declared as follows:

```
    public class PageBase : ContentPage
    {
        public static PageBase CurrentPage { get; set; }

        protected PageBase()
        {
            CurrentPage = this;

            #region ViewModel injection
            var viewModelTypeAttribute = GetType().GetTypeInfo().GetCustomAttribute<ViewModelTypeAttribute>();

            if (viewModelTypeAttribute == null) throw new Exception(string.Format("Xamtastic Exception: ViewModelTypeAttribute class decoration missing in {0}", this.GetType().ToString()));

            var viewModel = Activator.CreateInstance(viewModelTypeAttribute.ViewModelType);

            BindingContext = viewModel;
            #endregion
        }

        protected object NavigationParameter { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Initialize();

            if (!ViewModel.IsInitialized)
            {
                ViewModel.Initialize(NavigationParameter).ContinueWith(t =>
                {
                    if (t.Exception != null)
                    {

                    }

                    ViewModel.IsInitialized = true;
                });
            }
        }

        public ViewModelBase ViewModel
        {
            get { return (ViewModelBase)BindingContext; }
        }

        protected virtual void Initialize()
        {


        }
    }
```

Veterans will realise that for an absolutely minimal solution, the View Model could have implemented the PropertyChangedBase, however for scalability the ViewModelBase caters for Page Navigation Parameters, hence a ViewModelBase is utilised to allow for an INavigationManager to be injected, cf PageBase and ViewModelBase, however it is intended that an Implementation of INavigationManager will be made available in another Nuget package so that this remains the smallest but scalable MVVM framework.
