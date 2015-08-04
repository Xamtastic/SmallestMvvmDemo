using Autofac;
using Com.Xamtastic.SmallestMvvmDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Com.Xamtastic.SmallestMvvmDemo
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var startupPage = new MainPage();
            NavigationPage.SetHasNavigationBar(startupPage, false);
            MainPage = new NavigationPage(startupPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
