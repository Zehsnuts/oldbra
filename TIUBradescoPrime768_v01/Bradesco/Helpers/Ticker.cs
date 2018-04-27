using System;
using System.ComponentModel;
using System.Timers;

namespace Bradesco.Helpers
{
    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public string Now
        {
            get { return DateTime.Now.ToString("HH:mm"); }
        }

        public string Today
        {
            get { return DateTime.Now.ToString("dddd ', ' dd 'de' MMMM 'de' yyyy"); }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Now"));
                PropertyChanged(this, new PropertyChangedEventArgs("Today"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
