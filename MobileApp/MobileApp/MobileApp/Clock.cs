using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp
{
  public delegate void DelOnTick();
  public  class Clock:BaseNotify
    {
        public event DelOnTick OnTick;
        public Clock(DateTime date)
        {
            Current = date;
            Device.StartTimer(TimeSpan.FromSeconds(1), onTick);
        }

        private bool onTick()
        {
            Current= Current.AddSeconds(1);
            if (OnTick != null)
                OnTick();
            return true;

        }

        private DateTime current;
        public DateTime Current
        {
            get { return current; }
            set {SetProperty(ref current ,value); }
        }

    }
}
