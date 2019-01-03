using System;
using System.Collections;
using System.Collections.Generic;
using FBDBCoreLib.data;
using FBDBCoreLib.view;
using FBDBCoreLib.weather.data;

namespace FBDBWeb.Models
{
    public class WebModel
    {
        #region members
        FBDBCoreLibInterface oModel = new FBDBCoreLibInterface();
        FileProp oPaths = new FileProp();
        #endregion

        // Konstruktor erzeugen
        public WebModel()
        {
            oPaths.Offense = "https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oPaths.Defense = "https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oPaths.Gameday = "https://www.footballdb.com/games/index.html";
            oModel.init(oPaths);
        }

        public GameProp analyseGame(string sAwayTeam, string sHomeTeam)
        {
            return oModel.getGame(sAwayTeam, sHomeTeam);
        }

        public List<GameProp> analyseGameday(string sGameday)
        {
            return oModel.getGameDay(sGameday);
        }

        public Hashtable getWeather()
        {
            return new FBDBCoreLibInterface().getWeather();
        }

        private string createGameOutput(GameProp oData)
        {
            string sReturn = oData.Away + " at " + oData.Home + " - " + oData.AwayScore + ":" + oData.HomeScore;
            sReturn += "((" + oData.ScoreDiff + "))";

            return sReturn;

        }
    }
}
