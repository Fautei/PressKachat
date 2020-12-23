using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PressKachat.Models;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace PressKachat
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AddExercise : Page
    {
        private TimeSpan _time;
        private string _name;
        private ushort _repeats;

        public AddExercise()
        {

            this.InitializeComponent();
        }

     

        private void TimePicker_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            
            _time = e.NewTime;
            if (_time.TotalSeconds == 0)
            {
                throw new NotImplementedException();
            }
        }

       

   

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                if (e.Parameter as Exercise != null)
                {
                    var _exercise = e.Parameter as Exercise;
                    _name = _exercise.Name;
                    _repeats = _exercise.Repeats;
                    _time = _exercise.Time;

                    name.Text = _name;
                    time.Time = _time;
                    repeats.Text = _repeats.ToString();
                }
                
            }
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _name = ((TextBox)sender).Text;
            if (_name.Length == 0)
            {
                ((TextBox)sender).Header = "Введите название упражнения";

            }
            else
            {
                ((TextBox)sender).Header = "";
            }
        }

        private void Repeats_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ((TextBox)sender).Header = "";
                _repeats = ushort.Parse(((TextBox)sender).Text);
            }
            catch
            {
                ((TextBox)sender).Header = "Необходимо ввести число";
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTraining), new Exercise { Name = _name, Time = _time, Repeats = _repeats });
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
