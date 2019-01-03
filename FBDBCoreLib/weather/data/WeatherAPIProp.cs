using System;
namespace FBDBCoreLib.weather.data
{
    public class WeatherAPIProp
    {
        private string sServiceAPI = @"http://api.openweathermap.org/data/2.5/weather";
        private string sAPIKey = "3baf3e928e678e3677196c25f8538e6f";

        public string ServiceAPI { get => sServiceAPI; set => sServiceAPI = value; }
        public string APIKey { get => sAPIKey; set => sAPIKey = value; }

    }
}
