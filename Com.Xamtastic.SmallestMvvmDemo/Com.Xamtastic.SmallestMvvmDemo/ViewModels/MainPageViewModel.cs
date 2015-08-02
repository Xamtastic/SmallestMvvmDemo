using Com.Xamtastic.Patterns.SmallestMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Xamtastic.SmallestMvvmDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _message = "Hello SmallestMvvm!";
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
