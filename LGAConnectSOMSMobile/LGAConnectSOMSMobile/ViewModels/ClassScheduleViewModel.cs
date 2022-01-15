using LGAConnectSOMSMobile.Models;
using LGAConnectSOMSMobile.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace LGAConnectSOMSMobile.ViewModels
{
    public class ClassScheduleViewModel
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
        public ObservableRangeCollection<ClassSchedule> classschedule { get; }

        public ClassScheduleViewModel()
        {
            classschedule = new ObservableRangeCollection<ClassSchedule>();          
        }
     
        DateTime currentDateTime = DateTime.Now;
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
    }
}
