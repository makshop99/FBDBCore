﻿using System;
using System.Collections.Generic;
using FBDBCoreLib.data;
using FBDBCoreLib.view;
namespace FBDBWeb.Models
{
    public class WebModel
    {
        public GameProp analyseGame(string sAwayTeam, string sHomeTeam)
        {
            FBDBCoreLibInterface oModel = new FBDBCoreLibInterface();
            FileProp oPaths = new FileProp();


            string sOffenseFile = "https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            string sDefenseFile = "https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            string sScheduleFile = "https://www.footballdb.com/games/index.html"; // use only reely...
            oPaths.Offense = sOffenseFile;
            oPaths.Defense = sDefenseFile;
            oPaths.Gameday = sScheduleFile;


            oModel.init(oPaths);
            GameProp oResult = oModel.getGame(sAwayTeam, sHomeTeam);

            return oResult;

        }

        public List<GameProp> analyseGameday(string sGameday)
        {
            // initializing the model
            FBDBCoreLibInterface oModel = new FBDBCoreLibInterface();
            FileProp oPaths = new FileProp();
            string sOffenseFile = "https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            string sDefenseFile = "https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            string sScheduleFile = "https://www.footballdb.com/games/index.html"; // use only reely...
            oPaths.Offense = sOffenseFile;
            oPaths.Defense = sDefenseFile;
//sScheduleFile = @"~/data/schedule.htm\";
            oPaths.Gameday = sScheduleFile;
            oModel.init(oPaths);

            return oModel.getGameDay(sGameday);
        }


        private string createGameOutput(GameProp oData)
        {
            string sReturn = oData.Away + " at " + oData.Home + " - " + oData.AwayScore + ":" + oData.HomeScore;
            sReturn += "((" + oData.ScoreDiff + "))";

            return sReturn;

        }
    }
}
