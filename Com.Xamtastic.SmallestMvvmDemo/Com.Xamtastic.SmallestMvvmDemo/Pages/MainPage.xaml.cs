using Com.Xamtastic.Patterns.SmallestMvvm;
using Com.Xamtastic.SmallestMvvmDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Com.Xamtastic.SmallestMvvmDemo.Pages
{
    [ViewModelType(typeof(MainPageViewModel))]
    public partial class MainPage : PageBase
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
