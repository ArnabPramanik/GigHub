using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; } 
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime DateTime
        {
            get
            {
                Debug.WriteLine(Date);
                Debug.WriteLine(Time);
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }
        }

    }
}