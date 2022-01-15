﻿using LGAConnectSOMSMobile.Models;
using LGAConnectSOMSMobile.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<About> abouts { get; }
        public AsyncCommand DisplayCommand { get; set; }
        public AboutPageViewModel()
        {
            abouts = new ObservableRangeCollection<About>();
            DisplayCommand = new AsyncCommand(DisplayAbout);
            PreparePageBindings();
        }

        private async void PreparePageBindings()
        {
            await DisplayAbout();
        }

        public async Task DisplayAbout()
        {
            var aboutservice = await AboutService.GetAboutDetails();
            var aboutItem = aboutservice.ToList();
            abouts.AddRange(aboutItem);
        }
    }
}
