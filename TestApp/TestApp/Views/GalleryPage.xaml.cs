using Xamarin.Forms;
using TestApp.Models;
using System.Collections.Generic;
using System.Linq;
using XLabs.Forms.Controls;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.IO;


namespace TestApp.Views
{
    public partial class GalleryPage : ContentPage
    {
        public GalleryPage()
        {
           
            InitializeComponent();
            
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Photo photo = (Photo)e.SelectedItem;
            this.Navigation.PushAsync(new ImagePage(photo.Id));
        }

        
        protected override void OnAppearing()
        {
            Imagelist.ItemsSource = App.repo.GetItems();
            base.OnAppearing();
            
        }

        protected override bool OnBackButtonPressed()
        {
            this.Navigation.PushAsync(new StartPage());
            return true;
        }
    }
}
