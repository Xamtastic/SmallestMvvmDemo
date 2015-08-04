using Com.Xamtastic.Patterns.SmallestMvvm;
using Com.Xamtastic.SmallestMvvmDemo.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Com.Xamtastic.SmallestMvvmDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Xamarin.Forms.INavigation Navigation { get; set; }

        private string _message = "Hello SmallestMvvm!";
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged("Message"); }
        }

        private ICommand _navigateToPage;
        public ICommand NavigateToPage
        {
            get { return _navigateToPage; }
            set { _navigateToPage = value; RaisePropertyChanged("NavigateToPage"); }
        }

        public MainPageViewModel()
        {
            this.NavigateToPage = new Command<string>( async(key) => 
            {
                Debug.WriteLine("Navigating ...");
                Navigation.PushAsync(new SecondPage());
            });
        }
    }
}
