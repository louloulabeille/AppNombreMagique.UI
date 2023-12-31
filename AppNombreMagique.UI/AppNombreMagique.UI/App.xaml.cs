﻿using AppNombreMagique.UI.Services;
using AppNombreMagique.UI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNombreMagique.UI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            //MainPage = new WelcomePage();
            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
