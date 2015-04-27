using System;

using XLabs.Ioc;
using XLabs.Platform.Services.Media;

namespace TestApp.View
{
    using System.Diagnostics;

    using TestApp.API;
    using TestApp.Core;
    using TestApp.Model;
    using TestApp.ViewModel;

    using Xamarin.Forms;

    public partial class ConfirmPage : ContentPage
    {
        private IPictureManager _pictureManager;

        public static MediaFile _mediFile;
        private RestApi _api;
        public ConfirmPage(MediaFile file)
        {
            _mediFile = file;
            var service = new DependencyServiceManager();
            _pictureManager = service.PictureManager;
            _api = new RestApi();
            this.BindingContext = new ConfirmViewModel(file);
            InitializeComponent();
        }
        private async void Add(object sender, EventArgs e)
        {
            var imageItem = new Photo { Comment = CommentText.Text, ImagePath = _pictureManager.GetImagePath(_mediFile.Path) };
            App.repo.SaveItem(imageItem);
            try
            {
                await _api.SaveImageData(imageItem, ImageValue.Source);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            await Navigation.PushAsync(new GalleryPage());
        }
    }
}

