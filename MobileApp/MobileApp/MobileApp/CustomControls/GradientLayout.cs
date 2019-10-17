using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.CustomControls
{
   public class GradientLayout:StackLayout
    {
        public Color StartColor
        {
            get;
            set;
        }
        public Color EndColor
        {
            get;
            set;
        }
    }
}
