using Xamarin.Forms;
namespace TestApp.View
{
    using System.Collections.Generic;
    using System.Linq;

    using TestApp.Model;

    using XLabs.Forms.Controls;
    using XLabs.Ioc;
    using XLabs.Platform.Device;
    using XLabs.Platform.Services.IO;

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
