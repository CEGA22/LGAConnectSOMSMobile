using LGAConnectSOMSMobile.Models;
using LGAConnectSOMSMobile.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectSOMSMobile.ViewModels
{
    public class AccountSettingsViewModel
    {
        public AsyncCommand UpdatePasswordCommand { get; }
        public AccountSettingsViewModel()
        {
            UpdatePasswordCommand = new AsyncCommand(UpdatePassword);
        }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string RetypeNewPassword { get; set; }

        async Task UpdatePassword()
        {
            var ID = Preferences.Get("ID", 0);
            var password = Preferences.Get("Password", string.Empty);
            if (CurrentPassword == null)
            {
                await Application.Current.MainPage.DisplayAlert("LGA Connect SOMS", "Please enter your current password", "OK");
            }

            else if (NewPassword == null)
            {
                await Application.Current.MainPage.DisplayAlert("LGA Connect SOMS", "Please enter new password", "OK");
            }

            else if (RetypeNewPassword == null)
            {
                await Application.Current.MainPage.DisplayAlert("LGA Connect SOMS", "Please Re-type new password", "OK");
            }

            else
            {
                try
                {
                    if (CurrentPassword == password)
                    {
                        SchoolAccountService studentService = new SchoolAccountService();
                        var IsSucess = await studentService.UpdateStudentPassword(new SchoolAccountRequest
                        {
                            id = ID,
                            Password = NewPassword
                        });

                        if (IsSucess)
                        {
                            await Application.Current.MainPage.DisplayAlert("LGA Connect SOMS Mobile", "Updated Successfully", "OK");
                            Preferences.Set("Password", NewPassword);
                        }

                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("LGA Connect SOMS Mobile", "Error. Please Try Again", "OK");
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
