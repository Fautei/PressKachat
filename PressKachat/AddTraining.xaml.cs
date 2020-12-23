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
using Newtonsoft.Json;
using Windows.Storage;
using System.Collections.ObjectModel;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace PressKachat
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AddTraining : Page
    {
       

        private string _name = "";
        private DateTimeOffset _date= new DateTimeOffset();
        private ObservableCollection<Exercise> _exercises = new ObservableCollection<Exercise>();

        public AddTraining()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            exercises.ItemsSource = _exercises;

            
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {

                if (e.Parameter as Exercise != null)
                {
                    _exercises.Add(e.Parameter as Exercise);
                }
                if (e.Parameter as Training != null)
                {
                    var training = e.Parameter as Training;
                    _name = training.Name;
                    _date = training.Date;
                    _exercises = training.Exercises;

                    name.Text = _name;
                    date.Date = _date;
                    exercises.ItemsSource = _exercises;

                }
            }
        }
 

     

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var exercise = e.ClickedItem as Exercise;
            _exercises.Remove(exercise);
            Frame.Navigate(typeof(AddExercise), exercise);
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _name = ((TextBox)sender).Text;
        }

        private void Date_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (sender.Date.HasValue)
                _date = sender.Date.Value;
        }

        private void AddExercise_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddExercise));
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddProgram), new Training { Date = _date.DateTime, Exercises = _exercises, Name = _name });
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddProgram));
        }


        private async void  Delete_Item_Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog() { Title = "Вы действительно хотите удалить это упражнение?", PrimaryButtonText = "Да", SecondaryButtonText = "Нет" };

            dialog.PrimaryButtonClick += (_sender, _e) =>
            {
                var s = (e.OriginalSource as Button).AccessKey;
                var exercise = _exercises.First(i => i.Name == s);
                _exercises.Remove(exercise);
            };
            await dialog.ShowAsync();
        }
    }
}
