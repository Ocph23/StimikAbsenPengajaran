using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.CustomControls
{

    public delegate void delChangeValue(bool isAdd,int value);

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumberPicker : ContentView
    {

        public static readonly BindableProperty NilaiProperty = BindableProperty.Create("Nilai", typeof(Int32), typeof(NumberPicker),0);
        public static readonly BindableProperty DataProperty = BindableProperty.Create("Data", typeof(Int32), typeof(AbsenView), 0,BindingMode.TwoWay);

        public event delChangeValue onChangeValue;
        public NumberPicker()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public int Nilai
        {
            get => (Int32)GetValue(NilaiProperty);
            set => SetValue(NilaiProperty, value);
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Nilai++;
            if(onChangeValue!=null)
            {
                onChangeValue(true,Nilai);
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (Nilai > 0)
            {
                Nilai--;
                onChangeValue(true, Nilai);
            }
        }

    }


}