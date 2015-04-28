using System;
using Xamarin.Forms;
using TestApp.Data;
using TestApp.Views;


namespace TestApp
{
    public class App : Application
	{
		public static ImageRepository repo;
		public App ()
		{
			repo = new ImageRepository("gallery.db");
			this.MainPage = new NavigationPage(new StartPage ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

