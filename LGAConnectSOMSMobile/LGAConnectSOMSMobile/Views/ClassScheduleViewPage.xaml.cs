using LGAConnectSOMSMobile.ViewModels;
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
    public partial class ClassScheduleViewPage : ContentPage
    {
        public ClassScheduleViewPage()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            DateTime currentDateTime = DateTime.Now;
            selectedWeekDay.Text = currentDateTime.DayOfWeek.ToString();
            var todaysweek = currentDateTime.DayOfWeek.ToString();
            if (BindingContext is ClassScheduleViewModel vm)
            {

                await vm.DisplayClassSchedule(todaysweek.ToString());
                lblNoRecords.IsVisible = !vm.classschedule.Any();
                lblNoRecords.IsVisible = !vm.classschedule.Any();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Weekdays.Focus();
        }

        private async void Weekdays_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                var selectedItem = picker.SelectedItem;
                selectedWeekDay.Text = selectedItem.ToString();

                if (BindingContext is ClassScheduleViewModel vm)
                {
                    await vm.DisplayClassSchedule(selectedItem.ToString());
                    lblNoRecords.IsVisible = !vm.classschedule.Any();
                    lblNoRecords.IsVisible = !vm.classschedule.Any();
                }
            }
            catch (Exception x)
            {

                throw;
            }
        }

        
    }
}