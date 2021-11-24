using LGAConnectSOMSMobile.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LGAConnectSOMSMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var ID = Preferences.Get("ID", 0);
            var isadmin = Preferences.Get("IsAdmin", 0);
            if (ID != 0)
            {   
                
              MainPage = new NavigationPage(new DashboardTabbedPage());            
            }

            else
            {
                MainPage = new NavigationPage(new LogInPageView());
            }
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
