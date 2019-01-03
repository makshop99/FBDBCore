using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using FBDBCoreLib.weather.data;
using FBDBCoreLib.weather.exceptions;

namespace FBDBCoreLib.model.weather
{
    public class WeatherDataReader
    {
        private WeatherAPIProp oAPIData = new WeatherAPIProp();

        #region Interface
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FBDBCoreLib.model.weather.WeatherDataReader"/> class.
        /// </summary>
        public WeatherDataReader(string sServiceAPI, string sAPIKey)
        {
            if (!checkValue(sServiceAPI) || !checkValue(sAPIKey)) throw new WeatherInitException();

            oAPIData.ServiceAPI = sServiceAPI;
            oAPIData.APIKey = sAPIKey;
        }

        public string readWeather(string sCityId)
        {
            // Aufruf der API
            string sReturn = readAPI(sCityId);


            // Rueckgabe der JSON Daten
            return sReturn;
        }
        #endregion

        #region REST methods
        private string readAPI(string sCityId)
        {
            string sReturn = "";

 
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(oAPIData.ServiceAPI);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // build parameter list
            string sParameters = "?APPID=" + oAPIData.APIKey + "&id=" + sCityId + "&units=metric&mode=xml";

            // List data response.
            HttpResponseMessage response = client.GetAsync(sParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var oDummy = response.Content.ReadAsStringAsync();
                sReturn = oDummy.Result;
            }
            else { throw new WeatherCallException(); }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();



            return sReturn;
        }
        #endregion




        #region check methodes
        private bool checkValue(string sParameter)
        {
            if (sParameter == null) return false;
            if (sParameter.Length <= 0) return false;
            return true;
        }
        #endregion


    }
}
