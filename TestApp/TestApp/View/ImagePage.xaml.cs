using System;
using Xamarin.Forms;

namespace TestApp.View
{
    using System.Globalization;
    using System.IO;
    using System.Threading;

    using TestApp.Core;
    using TestApp.Model;

    using XLabs.Forms;
    using XLabs.Forms.Controls;
    using XLabs.Ioc;
    using XLabs.Platform.Device;
    using XLabs.Platform.Services.IO;
    using XLabs.Platform.Services.Media;

    public partial class ImagePage : ContentPage
    {
        public int Ident { get; set; }

        public ImagePage(int id)
        {
            
           
            InitializeComponent();
            Photo photo = App.repo.GetItem(id);
            if (photo != null)
            {
               
                Imagesource.Source = photo.imageSource;
                Coment.Text = photo.Comment;
                Ident = id;
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

    }
}

