using LGAConnectSOMSMobile.Models;
using LGAConnectSOMSMobile.Services;
using LGAConnectSOMSMobile.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectSOMSMobile.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public AsyncCommand HomePageCommand { get; }
        public LoginPageViewModel()
        {
            HomePageCommand = new AsyncCommand(GotoHomePage);
        }

        //public ICommand _HomePage => new Command(async () => await GotoHomePage());

        public string Username { get; set; }
        public string Password { get; set; }
 
        async Task GotoHomePage()
        {
            //Application.Current.MainPage.Navigation.PushAsync(new DashboardTabbedPage());
            //Application.Current.MainPage = new NavigationPage(new DashboardTabbedPage());
            IsBusy = true;
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
                    PersistentData(result.ID, result.Firstname, result.Lastname, result.Fullname, result.IsAdmin, result.Password, result.TeacherProfile);
                    IsBusy = false;
                    Application.Current.MainPage = new NavigationPage(new DashboardTabbedPage());
                }

                else
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Unable to Login", "This account is an Administrator account. Please Login in Desktop version", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wrong Teacher ID or Password", "OK");
            }
        }

        public void PersistentData(int ID, string firstname, string lastname, string fullname, int isadmin, string password, byte[] TeacherProfile)
        {
            string teacherprofile = System.Convert.ToBase64String(TeacherProfile);
            Preferences.Set("ID", ID);
            Preferences.Set("Firstname", firstname);
            Preferences.Set("Lastname", lastname);
            Preferences.Set("Fullname", fullname);
            Preferences.Set("IsAdmin", isadmin);
            Preferences.Set("Password", password);
            Preferences.Set("TeacherProfile", teacherprofile);
        }
    }
}
