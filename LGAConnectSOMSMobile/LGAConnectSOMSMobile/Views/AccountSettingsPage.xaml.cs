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
    public partial class AccountSettingsPage : ContentPage
    {
        public AccountSettingsPage()
        {
            InitializeComponent();
            var profile = Preferences.Get("TeacherProfile", string.Empty);
            byte[] convertprofile = System.Convert.FromBase64String(profile);
            var imageMemoryStream = new MemoryStream(convertprofile);
            btnStudentProfile.Source = ImageSource.FromStream(() => imageMemoryStream);
            StudentName.Text = Preferences.Get("Fullname", string.Empty);          
        }
    }
}