using FBDBCoreLib.data;
using FBDBCoreLib.code.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBCoreLib.model
{
    public class DataAnalyser
    {

        #region members
        private Double iOffenseMax = 100;
        private Double iDefenseMax = 100;
        #endregion

        #region interface
        /// <summary>
        /// this method analyses the game of two teams by their stats
        /// </summary>
        /// <param name="tdAway"></param>
        /// <param name="tdHome"></param>
        /// <returns></returns>
        /// <changes>
        /// 13.12.18
        /// implementation of the story 420
        /// https://makbuch.visualstudio.com/FBDB%20App/_workitems/edit/420
        /// </changes>     
        public GameProp analyseGame(TeamData tdAway, TeamData tdHome)
        {
            GameProp oReturn = new GameProp();

            // calculate offense
            Double dHome = calculateOffense(tdAway, tdHome);
            oReturn.HomeScoreOffense = dHome.ToString();
            Double dAway = iOffenseMax - dHome;
            oReturn.AwayScoreOffense = dAway.ToString();

            // calcutale defense
            Double idummy = calculateDefense(tdAway, tdHome);
            dHome += idummy;
            dAway += iDefenseMax - idummy;
            oReturn.HomeScoreDefense = idummy.ToString();
            oReturn.AwayScoreDefense = (iDefenseMax - idummy).ToString();


            // homefield advantage (deactivated)
            // dHome += 10;
            int iHome = Convert.ToInt32(dHome);
            int iAway = Convert.ToInt32(dAway);

            // fill the return object
            oReturn.Away = tdAway.TeamName;
            oReturn.AwayScore = iAway.ToString();
            oReturn.Home = tdHome.TeamName;
            oReturn.HomeScore = iHome.ToString();
            oReturn.ScoreDiff = (iHome - iAway).ToString();

            // stats 
            oReturn.AwayOffensePassing = tdAway.OffensePssG;
            oReturn.AwayOffenseRushsing = tdAway.OffenseRshG;
            oReturn.AwayOffensePoints = tdAway.OffensePntG;
            oReturn.AwayDefensePassing = tdAway.DefensePssG;
            oReturn.AwayDefenseRushsing = tdAway.DefenseRshG;
            oReturn.AwayDefensePoints = tdAway.DefensePntG;
            oReturn.HomeOffensePassing = tdHome.OffensePssG;
            oReturn.HomeOffenseRushsing = tdHome.OffenseRshG;
            oReturn.HomeOffensePoints = tdHome.OffensePntG;
            oReturn.HomeDefensePassing = tdHome.DefensePssG;
            oReturn.HomeDefenseRushsing = tdHome.DefenseRshG;
            oReturn.HomeDefensePoints = tdHome.DefensePntG;

            return oReturn;
        }

        public int getMaxPoints()
        {
            return Convert.ToInt32(iOffenseMax + iDefenseMax);
        }
        #endregion

        #region stats methods
        /// <summary>
        /// this method compares the offense stats of both teams and calculates the chances for both teams offensively
        /// </summary>
        /// <param name="tdAway"></param>
        /// <param name="tdHome"></param>
        /// <returns></returns>
        private Double calculateOffense(TeamData tdAway, TeamData tdHome)
        {
            // 100, 40 for Points/Game; 35 for PassingYards/Game; 25 for RushYards/Game

            Double iPointsHome = Convert.ToDouble(tdHome.OffensePntG);
            Double iPassingHome = Convert.ToDouble(tdHome.OffensePssG);
            Double iRushingHome = Convert.ToDouble(tdHome.OffenseRshG);

            Double iPointsAway = Convert.ToDouble(tdAway.OffensePntG);
            Double iPassingAway = Convert.ToDouble(tdAway.OffensePssG);
            Double iRushingAway = Convert.ToDouble(tdAway.OffenseRshG);

            Double iPoints = (iPointsHome / (iPointsHome + iPointsAway)) * 40;
            Double iPassing = (iPassingHome / (iPassingHome + iPassingAway)) * 35;
            Double iRushing = (iRushingHome / (iRushingHome + iRushingAway)) * 25;

            // returns the points of the hometeam --> awayteam then is iOffenseMax - hometeam
            return (iPoints + iPassing + iRushing);
        }

        /// <summary>
        /// this method compares the defenses stats of both teams and calculates the chances for both teams defensively
        /// </summary>
        /// <param name="tdAway"></param>
        /// <param name="tdHome"></param>
        /// <returns></returns>
        private Double calculateDefense(TeamData tdAway, TeamData tdHome)
        {
            // 100, 40 for Points/Game; 35 for PassingYards/Game; 25 for RushYards/Game
            Double iPointsHome = Convert.ToDouble(tdHome.DefensePntG);
            Double iPassingHome = Convert.ToDouble(tdHome.DefensePssG);
            Double iRushingHome = Convert.ToDouble(tdHome.DefenseRshG);

            Double iPointsAway = Convert.ToDouble(tdAway.DefensePntG);
            Double iPassingAway = Convert.ToDouble(tdAway.DefensePssG);
            Double iRushingAway = Convert.ToDouble(tdAway.DefenseRshG);

            Double iPoints = (iPointsAway / (iPointsHome + iPointsAway)) * 40;
            Double iPassing = (iPassingAway / (iPassingHome + iPassingAway)) * 35;
            Double iRushing = (iRushingAway / (iRushingHome + iRushingAway)) * 25;

            // returns the points of the hometeam --> awayteam then is DeffenseMax - hometeam
            return (iPoints + iPassing + iRushing);
        }
        #endregion
    }
}

