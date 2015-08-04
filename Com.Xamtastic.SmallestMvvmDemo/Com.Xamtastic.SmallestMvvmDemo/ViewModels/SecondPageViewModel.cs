using Com.Xamtastic.Patterns.SmallestMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Xamtastic.SmallestMvvmDemo.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        private string _message = "Hello Second Page!";
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged("Message"); }
        }
    }
}
