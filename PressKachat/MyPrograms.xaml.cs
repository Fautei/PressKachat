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
    public sealed partial class MyPrograms : Page
    {
        private ObservableCollection<ProgramTrainings> _programs;


        public MyPrograms()
        {
            this.InitializeComponent();
            this.Loaded += MyPrograms_Loaded;
            _programs = new ObservableCollection<ProgramTrainings>();
        }

        private async void MyPrograms_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;



            var files = from f in (await folder.GetFilesAsync()) where f.FileType == ".json" select f;
            var n = from _n in files select _n.Name;
            Newtonsoft.Json.JsonSerializer serializer = new JsonSerializer();

            foreach (var item in files)
            {
                using (TextReader reader =new StreamReader(await item.OpenStreamForReadAsync()))
                {
                    var v = (ProgramTrainings)serializer.Deserialize(reader, typeof(ProgramTrainings));
                    _programs.Add(v);
                }
                
            }

            programs.ItemsSource = _programs;

        }

        private void Delete_Item_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProgramsList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
