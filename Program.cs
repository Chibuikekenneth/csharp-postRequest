using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace postRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData();
            Console.ReadLine();
            Console.ReadKey();
        }

        static async void GetData()
        {
             var contents  = new {
                                "name"= "Chibuike Kenneth",
                                "email"= "chibuikekenneth003@gmail.com",
                                }

            var jsonContent = JsonConvert.SerializeObject(contents);

            string baseUrl  = "http://example-http.com/post";

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl);

            requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            requestMessage.Headers.Add("ApiKey", "value");
            requestMessage.Headers.Add("Token", "value");
        
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            string responseAsString = await responseMessage.Content.ReadAsStringAsync();
            if(responseAsString != null ) {
                Console.WriteLine(responseAsString);
            }

        }
        
    }
}
