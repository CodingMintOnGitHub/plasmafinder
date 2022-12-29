using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlasmaFinder
{
    public partial class App : Application
    {

        public static string SELECTED_STATE_ID { get; set; } = "0";
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
        }
    }
}
