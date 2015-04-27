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

namespace TestApp.API
{

    using TestApp.Model;

    public class RestApi
	{
		public RestApi ()
		{
		}

        public async Task<String> SaveImageData(Photo photo, ImageSource source)
        {

            try
            {
                
                var fileName = Path.GetFileName(photo.ImagePath);
                var imageStream = (StreamImageSource)source;
                byte[] byteArray = ReadFully(imageStream.Stream.Invoke(new CancellationToken()).Result);
				string Url = "http://10.0.3.2:7793/api/values/";
                var jsonObj = new JsonPhoto { Comment = photo.Comment, Data = byteArray, Name = fileName };
                var jsonString = JsonConvert.SerializeObject(jsonObj);
                return null;
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
                return null;
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

