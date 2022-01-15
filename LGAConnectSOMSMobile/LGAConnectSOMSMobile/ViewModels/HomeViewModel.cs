﻿using LGAConnectSOMSMobile.Models;
using LGAConnectSOMSMobile.Services;
using LGAConnectSOMSMobile.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LGAConnectSOMSMobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        private List<string> tileColors = new List<string>
        {
            "#f03434",
            "#fabe58",
            "#8E44AD",
            "#1ba39c",
            "#f27935",
            "#f2784b",
            "#2c82c9",
            "#22313f",
            "#9f5afd",
            "#674172"
        };

        public bool IsNoRecordToShow { get; set; }
        private Random _random = new Random();
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public ObservableRangeCollection<Models.ClassSchedule> classschedule { get; }
        public ObservableRangeCollection<NewsAndAnnouncements> newsAndAnnouncements { get; }
        public AsyncCommand AccounCommand { get; set; }
        public AsyncCommand NewsCommand { get; set; }
        //public ICommand _latestNewsandAnnouncement => new Command(async () => await GotoLatestNewsandAnnouncementPage());
        //public ICommand _viewGrades => new Command(async () => await GotoViewGrades());

        public HomeViewModel()
        {
            classschedule = new ObservableRangeCollection<Models.ClassSchedule>();
            newsAndAnnouncements = new ObservableRangeCollection<NewsAndAnnouncements>();
            AccounCommand = new AsyncCommand(GotoMenuPage);
            NewsCommand = new AsyncCommand(GotoLatestNewsandAnnouncementPage);
            PreparePageBindings();
        }

        private async void PreparePageBindings()
        {
            await DisplayNewsAndAnnouncements();
        }

        public async Task DisplayClassSchedule(string weekDay = "Entire Week")
        {
            var ID = Preferences.Get("ID", 0);
            var classscheduleservice = await ClassScheduleService.GetClassScheduleDetailsFaculty(ID);
            var classScheduleList = classscheduleservice.ToList();
            classScheduleList.ForEach(x => { x.TileColor = Color.FromHex(tileColors[RandomNumber(0, 10)]); });
            classschedule.Clear();

            if (weekDay == "Entire Week")
            {
                classschedule.AddRange(classScheduleList);
            }
            else
            {
                var filteredScheduleList = classScheduleList.Where(x => x.WeekDay == weekDay);
                classschedule.AddRange(filteredScheduleList);
            }
        }

        public async Task DisplayNewsAndAnnouncements()
        {
            try
            {
                IsBusy = true;
                var result = await Task.Run(() => NewsAndAnnouncementsService.GetNewsAndAnnouncements());
                var latestnewsandannouncementsOrder = result.OrderByDescending(x => x.DateCreated);
                var latestnewsandannouncement = latestnewsandannouncementsOrder.FirstOrDefault();
                newsAndAnnouncements.Add(latestnewsandannouncement);
                IsBusy = false;
            }

            catch (Exception e)
            {

            }
        }

        async Task GotoMenuPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());
        }

        async Task GotoLatestNewsandAnnouncementPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LatestNewsAndAnnouncementsPage());
        }

        //async Task GotoLatestNewsandAnnouncementPage()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new LatestNewsandAnnouncementPage());
        //}

        //async Task GotoViewGrades()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new ViewGrades());
        //}
    }
}
