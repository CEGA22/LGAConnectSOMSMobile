using LGAConnectSOMSMobile.Models;
using LGAConnectSOMSMobile.Services;
using LGAConnectSOMSMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectSOMSMobile.ViewModels
{
    public class LoginPageViewModel
    {
        public LoginPageViewModel()
        {

        }

        public ICommand _HomePage => new Command(async () => await GotoHomePage());

        public string Username { get; set; }
        public string Password { get; set; }

 
        async Task GotoHomePage()
        {
            //Application.Current.MainPage.Navigation.PushAsync(new DashboardTabbedPage());
            //Application.Current.MainPage = new NavigationPage(new DashboardTabbedPage());


            LoginService loginService = new LoginService();
            var result = await loginService.AccountLogin(new LoginRequest
            {
                Username = Username,
                Password = Password
            });

            if (result.IsSuccess)
            {
                if(result.IsAdmin == 0)
                {
                    PersistentData(result.ID, result.Firstname, result.Lastname, result.Fullname, result.IsAdmin);
                    Application.Current.MainPage = new NavigationPage(new DashboardTabbedPage());
                }

                else
                {

                    await Application.Current.MainPage.DisplayAlert("Unable to Login", "This account is an Administrator account. Please Login in Desktop version", "OK");
                }
                

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wrong Teacher ID or Password", "OK");
            }
        }

        public void PersistentData(int ID, string firstname, string lastname, string fullname, int isadmin)
        {
            Preferences.Set("ID", ID);
            Preferences.Set("Firstname", firstname);
            Preferences.Set("Lastname", lastname);
            Preferences.Set("Fullname", fullname);
            Preferences.Set("IsAdmin", isadmin);
        }
    }
}
