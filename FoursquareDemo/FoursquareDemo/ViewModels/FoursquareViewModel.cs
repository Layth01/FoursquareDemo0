﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FoursquareDemo.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace FoursquareDemo.ViewModels
{
   public class FoursquareViewModel : INotifyPropertyChanged
    {
        private string FoursquareUrl = "https://api.foursquare.com/v2/venues/explore?ll=40.7,-74&client_id=V55LBHU05XE1R3VRZFH5MWJA5THSPDF0XCL0HSML5QWIPGQ1&client_secret=JZ44Z41EOYMZO5RCSB40S5DHA2NLCAW4E4B0DKTQ42CPWNUS&venuePhotos=1&v=20170207";

       
        private FoursquareVenues _foursquareVenues;
        public FoursquareVenues FoursquareVenues
        {
            get { return _foursquareVenues; }
            set {
                _foursquareVenues = value;
                OnPropertyChanged();
                }
        }
        public FoursquareViewModel()
        {
            InitDataAsync();

        }

        private async Task InitDataAsync()
        {
            HttpClient httpclient = new HttpClient();
            string json = await httpclient.GetStringAsync(FoursquareUrl);
            FoursquareVenues = JsonConvert.DeserializeObject<FoursquareVenues>(json);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
