using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


namespace WeatherForecastConsole
{
    internal class Program
    {
        static async Task Main()
    {
        const string APIKEY = "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.436962&lon=24.753574";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET HttpClient");

            HttpResponseMessage response = await httpClient.GetAsync(APIKEY);
                response.EnsureSuccessStatusCode();
            
            string jsonResult = await response.Content.ReadAsStringAsync();
            dynamic jsonData = JObject.Parse(jsonResult);
                    for(int i = 0; i<jsonData.properties.timeseries.Count; i++)
            {
                Console.Write(i+1 + ".    ");
                    Console.Write(jsonData.properties.timeseries[i].data.instant.details.air_temperature + " °C     ");
                    Console.WriteLine(jsonData.properties.timeseries[i].time);
                
            }
                    
                
            
    }
    }
}