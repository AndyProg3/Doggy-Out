using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoggyOut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Index : ContentPage
    {
        private int Min = 0;
        private int Sec = 0;

        public Index()
        {
            InitializeComponent();

            var timeList = new List<int>();
            for(int c = 0; c <= 60; c++)
            {
                timeList.Add(c);
            }

            Minutes.ItemsSource = timeList;
            Minutes.SelectedIndex = 0;

            Seconds.ItemsSource = timeList;
            Minutes.SelectedIndex = 0;
        }

        private void Paw_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Cat", "I thought this was the dog app", "Cancle");

            Min = Minutes.SelectedIndex;
            Sec = Seconds.SelectedIndex;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Sec--;

                if (Sec < 0)
                {
                    Sec = 60;
                    Min--;

                    if (Min < 0)
                        Min = 0;
                }
                    
                if(Sec == 0 && Min == 0)
                {
                    //Timer complete
                    return false;
                }

                Timer.Text = "" + Min + ":" + Sec;
                
                return true;
            });
        }
    }
}