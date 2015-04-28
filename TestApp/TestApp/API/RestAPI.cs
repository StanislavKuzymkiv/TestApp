using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Net.Http.Headers;
using System.Diagnostics;
using TestApp.Services;
using TestApp.Models;
using XLabs.Forms;

namespace TestApp.API
{
    public class RestApi
    {
        private IPictureManager _pictureManager;
		public RestApi ()
		{
		    _pictureManager = DependencyService.Get<IPictureManager>();
		}

        public async Task<String> SaveImageData(Photo photo)
        {

            try
            {
                return null;
                var fileName = Path.GetFileName(photo.ImagePath);
                var imageStream = _pictureManager.GetPictureStream(photo.ImagePath);
                byte[] byteArray = ReadFully(imageStream);
				string Url = "http://10.0.3.2:7793/api/values/";
                var jsonObj = new JsonPhoto { Comment = photo.Comment, Data = byteArray, Name = fileName };
                var jsonString = JsonConvert.SerializeObject(jsonObj);

                HttpClientHandler objch = new HttpClientHandler(){ 
					UseDefaultCredentials=true};
                using (var client = new HttpClient(objch))
                {
                    
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("API key", "Key");
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        using (						
                           var message =
                               await client.PostAsync(Url, content))
                        {
                            var input = await message.Content.ReadAsStringAsync();                           
                        }
                    }
             }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }
      public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
	}
}

