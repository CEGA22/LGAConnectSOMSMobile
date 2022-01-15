using LGAConnectSOMSMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LGAConnectSOMSMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LatestNewsAndAnnouncementsPage : ContentPage
    {
        public LatestNewsAndAnnouncementsPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as NewsAndAnnouncements;
            await Navigation.PushAsync(new NewsAndAnnouncementView(details.Thumbnail, details.Title, details.Content, details.DateCreated));
        }
    }
}