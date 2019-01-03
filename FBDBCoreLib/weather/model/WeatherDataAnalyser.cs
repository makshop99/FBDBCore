using System;
using FBDBCoreLib.weather.data;

namespace FBDBCoreLib.weather.model
{
    public class WeatherDataAnalyser
    {
        public WeatherDataAnalyser()
        {
        }

        public WeatherProp getWeatherData(string sData, string sCityId)
        {
            WeatherProp oReturn = new WeatherProp();
            oReturn.WeatherCode = sCityId;

            //name = "City of London" >
            // name=\\\"
            string sPattern = "name=";
            int iStart = sData.IndexOf(sPattern) + sPattern.Length + 1;
            int iStop = sData.IndexOf(">", iStart) - 1;
            oReturn.City = sData.Substring(iStart, iStop - iStart);

            // temprature
            sPattern = "<temperature value=";
            iStart = sData.IndexOf(sPattern) + sPattern.Length + 1;
            iStop = sData.IndexOf(" ", iStart) - 1;
            oReturn.Temp = sData.Substring(iStart, iStop - iStart);

            return oReturn;
        }
    }
}
