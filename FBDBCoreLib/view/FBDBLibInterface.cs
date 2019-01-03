using FBDBCoreLib.controller;
using FBDBCoreLib.data;
using FBDBCoreLib.exceptions;
using FBDBCoreLib.weather.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// added a comment for testing azure devops ci build.
// and another comment added.
namespace FBDBCoreLib.view
{
    public class FBDBCoreLibInterface
    {
        private FTDBLibController oController;

        /// <summary>
        /// this method takes init data and initializes the class
        /// </summary>
        /// <param name="sData"></param>
        /// <returns>
        ///  0 -> no error 
        /// -1 -> no offense file delivered
        /// -2 -> no defense path delivered
        /// -3 -> no gameday path delivered 
        /// </returns>
        public int init(FileProp oData)
        {
            // check data
            if (oData.Offense.Length < 1) throw new PathException(new ExceptionProp().OffensePath);
            if (oData.Defense.Length < 1) throw new PathException(new ExceptionProp().DefensePath);
            if (oData.Gameday.Length < 1) throw new PathException(new ExceptionProp().SchedulePath);

            // init controller
            oController = new FTDBLibController();  

            if (oController.init(oData) == -2) throw new RawDataException();

            return 0;
        }

        /// <summary>
        ///  this method gets data and calculates a whole gameday
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public List<GameProp> getGameDay(string sGameday)
        {
            if (sGameday.Length <= 0) throw new GamedayException();
            return oController.analyzeGameday(sGameday);
        }


        /// <summary>
        ///  this method calculates a single game
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public GameProp getGame(string sAwayTeam, string sHomeTeam)
        {
            try
            {
                if (sHomeTeam.Length <= 0) throw new GameAnalysisExeption();
                if (sAwayTeam.Length <= 0) throw new GameAnalysisExeption();
            }
            catch (Exception) { throw new GameAnalysisExeption(); }

            return oController.analyseGame(sAwayTeam,sHomeTeam);
        }

        /// <summary>
        /// Gets the max points.
        /// </summary>
        /// <returns>The max points.</returns>
        public int getMaxPoints()
        {
            return oController.getMaxPoint();
        }

        /// <summary>
        /// this method reads out the weather for all 32 nfl teams
        /// </summary>
        /// <returns>List of WeatherProp Objects</returns>
        public Hashtable getWeather()
        {
            Hashtable oReturn = new Hashtable();
            string[] oData = new string[32];
            oData[0] = "Arizona Cardinals";
            oData[1] = "Atlanta Falcons";
            oData[2] = "Baltimore Ravens";
            oData[3] = "Buffalo Bills";
            oData[4] = "Carolina Panthers";
            oData[5] = "Chicago Bears";
            oData[6] = "Cincinnati Bengals";
            oData[7] = "Cleveland Browns";
            oData[8] = "Dallas Cowboys";
            oData[9] = "Denver Broncos";
            oData[10] = "Detroit Lions";
            oData[11] = "Green Bay Packers";
            oData[12] = "Houston Texans";
            oData[13] = "Indianapolis Colts";
            oData[14] = "Jacksonville Jaguars";
            oData[15] = "Kansas City Chiefs";
            oData[16] = "Los Angeles Chargers";
            oData[17] = "Los Angeles Rams";
            oData[18] = "Miami Dolphins";
            oData[19] = "Minnesota Vikings";
            oData[20] = "New England Patriots";
            oData[21] = "New Orleans Saints";
            oData[22] = "New York Giants";
            oData[23] = "New York Jets";
            oData[24] = "Oakland Raiders";
            oData[25] = "Philadelphia Eagles";
            oData[26] = "Pittsburgh Steelers";
            oData[27] = "San Francisco 49ers";
            oData[28] = "Seattle Seahawks";
            oData[29] = "Tampa Bay Buccaneers";
            oData[30] = "Tennessee Titans";
            oData[31] = "Washington Redskins";

            FTDBLibController oController = new FTDBLibController();
            foreach (string sCity in oData)
            {
                string sCode = new WeatherCodes().getCityId(sCity);
                WeatherProp oWeather = oController.readWeather(sCode);
                oReturn.Add(sCity, oWeather.Temp);
            }
            return oReturn;
        }
    }
}


