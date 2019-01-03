using FBDBCoreLib.data;
using FBDBCoreLib.model;
using FBDBCoreLib.code.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBDBCoreLib.model.weather;
using FBDBCoreLib.weather.data;
using FBDBCoreLib.weather.model;

namespace FBDBCoreLib.controller
{
    public class FTDBLibController
    {
        #region tasks
        /*
         * methode init() 
         * ist fertig
         * 
         * methode analyzeGameday()
         * aufruf der analyse methode in der statiistik klasse muss noch
         * eingebaut werden. ausserdem der output als string.
         * 
         * analyzeGame()
         * die gesamte methode muss noch implementiert werden.
         */
        #endregion

        #region members
        private DataReader oFileAccess = new DataReader();
        private FileProp oRawData = new FileProp();
        private ContentReader oContent = new ContentReader();
        private DataAnalyser oAnalyser = new DataAnalyser();
        #endregion

        #region public interface

        /// <summary>
        /// this method initialises the class. it reads out the raw data and converts it to content data.
        /// </summary>
        /// <param name="oData"></param>
        /// <returns>
        ///  0 - initialsation ok
        /// -1 - parameters empty
        /// -2 -  error while reading raw data
        /// </returns>
        /// <status>ready</status>
        public int init(FileProp oData)
        {
            // read raw file contents
            if (oFileAccess.init(oData) != 0) return -2;
            oRawData = oFileAccess.getAllRawData();
            if (oRawData == null) return -2;

            // read content data
            return oContent.init(oRawData);
        }
        

        /// <summary>
        /// this method runs the analysis of a copmplete gameday.
        /// </summary>
        /// <param name="sGameday"></param>
        /// <returns></returns>
        public List<GameProp> analyzeGameday(string sGameday)
        {
            List<GameProp> oReturn = new List<GameProp>();

            // read raw data from file/url
            string sRawSchedule = oFileAccess.getScheduleDataRaw();

            // read out GameProp objects for given gameday
            List<GameProp> oGameday = oContent.readGameday(sGameday, sRawSchedule);

            // for each GameProp 
            foreach (var oGame in oGameday)
            {
                // analyseGame game, add result to return value
                GameProp oData = analyseGame(oGame.Away, oGame.Home);
                oData.Date = oGame.Date;
                oReturn.Add(oData);
            }
            return oReturn;
        }

        /// <summary>
        /// this method runs the analysis of a single game.
        /// </summary>
        /// <param name="sAwayTeam"></param>
        /// <param name="sHomeTeam"></param>
        /// <returns></returns>
        public GameProp analyseGame(string sAwayTeam, string sHomeTeam)
        {                
            return analyseSingleGame(sAwayTeam, sHomeTeam);
        }

        public int getMaxPoint()
        {
            return oAnalyser.getMaxPoints();
        }

        public WeatherProp readWeather(string sCityId)
        {
            string sURL = @"http://api.openweathermap.org/data/2.5/weather";
            string sKey = "3baf3e928e678e3677196c25f8538e6f";
            WeatherDataReader oData = new WeatherDataReader(sURL, sKey);

            // read raw data
            string sRawData = oData.readWeather(sCityId);
            WeatherProp oReturn = new WeatherDataAnalyser().getWeatherData(sRawData, sCityId);
            return oReturn;
        }

        #endregion

        #region data validation
        // checks the content of the paths again
        private int checkPaths(FileProp oData)
        {
            if (oData.Offense.Length == 0) return -1;
            if (oData.Defense.Length == 0) return -1;
            if (oData.Gameday.Length == 0) return -1;
            return 0;
        }
        #endregion

        #region analyse game
        /// <summary>
        /// this method starts the analysis of a game and returns the result
        /// </summary>
        /// <param name="sAway"></param>
        /// <param name="sHome"></param>
        /// <returns></returns>
        private GameProp analyseSingleGame(string sAway, string sHome)
        {
            GameProp oReturn = new GameProp();
            TeamData oAway = oContent.getTeamData(sAway); // read stats for away team
            TeamData oHome = oContent.getTeamData(sHome); // read stats for home team
            return new DataAnalyser().analyseGame(oAway, oHome); // run analysis
        }
        #endregion

    }
}
