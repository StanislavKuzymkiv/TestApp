using System;

using Xamarin.Forms;

namespace TestApp
{
    using TestApp.Data;
    using TestApp.View;

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

