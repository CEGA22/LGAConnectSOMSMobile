using LGAConnectSOMSMobile.Services;
using LGAConnectSOMSMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LGAConnectSOMSMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : ContentPage
    {
        public HomePageView()
        {
            InitializeComponent();
            var profile = Preferences.Get("TeacherProfile", string.Empty);
            byte[] convertprofile = System.Convert.FromBase64String(profile);
            var imageMemoryStream = new MemoryStream(convertprofile);
            DateTime currentDateTime = DateTime.Now;
            TodayClasses.Text = currentDateTime.DayOfWeek.ToString();
            txtGreetings.Text = "Good Day,\n" + Preferences.Get("Firstname", string.Empty);
            btnTeacherProfile.Source = ImageSource.FromStream(() => imageMemoryStream);
            LoadData();
        }

        public async void LoadData()
        {
            DateTime currentDateTime = DateTime.Now;
            var todaysweek = currentDateTime.DayOfWeek.ToString();
            if (BindingContext is HomeViewModel vm)
            {
                await vm.DisplayClassSchedule(todaysweek.ToString());
                lblNoRecords.IsVisible = !vm.classschedule.Any();
                lblNoRecords.IsVisible = !vm.classschedule.Any();
            }

            var ID = Preferences.Get("ID", 0);
            SectionsCount.Text = "...";
            var result = await SectionsHandledService.GetSectionsHandled(ID);
            var count = result.Count();
            SectionsCount.Text = count.ToString();
        }
    }
}