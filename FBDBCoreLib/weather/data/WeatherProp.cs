using System;
namespace FBDBCoreLib.weather.data
{
    public class WeatherProp
    {

        // weather data
        private string sCity;
        private string sWeatherCode;
        private string iTemp;
       

        public WeatherProp() {}
        public string City { get => sCity; set => sCity = value; }
        public string WeatherCode { get => sWeatherCode; set => sWeatherCode = value; }
        public string Temp { get => iTemp; set => iTemp = value; }

        /*
       private string iMaxTemp;
       private string iRain;
       public string MaxTemp { get => iMaxTemp; set => iMaxTemp = value; }
       public string Rain { get => iRain; set => iRain = value; }
       */
    }
}
