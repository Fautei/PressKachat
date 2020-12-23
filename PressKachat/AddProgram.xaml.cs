using Newtonsoft.Json;
using PressKachat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace PressKachat
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AddProgram : Page
    {
        private ObservableCollection<Training> _trainings = new ObservableCollection<Training>();

        private string _name = "";



        public AddProgram()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            trainings.ItemsSource = _trainings;
        }

     

       

        private void trainings_ItemClick(object sender, ItemClickEventArgs e)
        {
            _trainings.Remove(e.ClickedItem as Training);
            Frame.Navigate(typeof(AddTraining), e.ClickedItem as Training);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();

            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync(_name + ".json", CreationCollisionOption.OpenIfExists);

            using (StreamWriter writer = new StreamWriter(await sampleFile.OpenStreamForWriteAsync()))
            {
                serializer.Serialize(writer, new ProgramTrainings { Name = _name,  Trainings = _trainings });
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {

                if (e.Parameter as Training != null)
                {
                    _trainings.Add(e.Parameter as Training);
                }

            }
        }


        private void Add_Training_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTraining));
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _name = ((TextBox)sender).Text;
        }
    }
}
