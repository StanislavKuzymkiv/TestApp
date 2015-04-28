using System;
using Xamarin.Forms;
using System.Globalization;
using System.IO;
using System.Threading;
using TestApp.Services;
using TestApp.Models;

namespace TestApp.Views
{
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

