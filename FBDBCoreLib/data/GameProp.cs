using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBCoreLib.data
{
    /// <summary>
    ///  this class includes all props for a game
    /// </summary>
    public class GameProp
    {
        #region fields
        private string sDate;
        private string sOvertime;
        private string sScoreDiff;

        private string sAway;
        private string sAwayScore;
        private string sAwayScoreOffense;
        private string sAwayScoreDefense;
        private string sAwayOffensePassing;
        private string sAwayOffenseRushing;
        private string sAwayOffensePoints;
        private string sAwayDefensePassing;
        private string sAwayDefenseRushing;
        private string sAwayDefensePoints;

        private string sHome;
        private string sHomeScore;
        private string sHomeScoreOffense;
        private string sHomeScoreDefense;
        private string sHomeOffensePassing;
        private string sHomeOffenseRushing;
        private string sHomeOffensePoints;
        private string sHomeDefensePassing;
        private string sHomeDefenseRushing;
        private string sHomeDefensePoints;
        #endregion

        #region encapsulates
        public string Date { get => sDate; set => sDate = value; }
        public string Overtime { get => sOvertime; set => sOvertime = value; }
        public string ScoreDiff { get => sScoreDiff; set => sScoreDiff = value; }

        public string Away { get => sAway; set => sAway = value; }
        public string AwayScore { get => sAwayScore; set => sAwayScore = value; }
        public string AwayScoreOffense { get => sAwayScoreOffense; set => sAwayScoreOffense = value; }
        public string AwayScoreDefense { get => sAwayScoreDefense; set => sAwayScoreDefense = value; }
        public string AwayOffensePassing { get => sAwayOffensePassing; set => sAwayOffensePassing = value; }
        public string AwayOffenseRushsing { get => sAwayOffenseRushing; set => sAwayOffenseRushing = value; }
        public string AwayOffensePoints { get => sAwayOffensePoints; set => sAwayOffensePoints = value; }
        public string AwayDefensePassing { get => sAwayDefensePassing; set => sAwayDefensePassing = value; }
        public string AwayDefenseRushsing { get => sAwayDefenseRushing; set => sAwayDefenseRushing = value; }
        public string AwayDefensePoints { get => sAwayDefensePoints; set => sAwayDefensePoints = value; }

        public string Home { get => sHome; set => sHome = value; }
        public string HomeScore { get => sHomeScore; set => sHomeScore = value; }
        public string HomeScoreOffense { get => sHomeScoreOffense; set => sHomeScoreOffense = value; }
        public string HomeScoreDefense { get => sHomeScoreDefense; set => sHomeScoreDefense = value; }
        public string HomeOffensePassing { get => sHomeOffensePassing; set => sHomeOffensePassing = value; }
        public string HomeOffenseRushsing { get => sHomeOffenseRushing; set => sHomeOffenseRushing = value; }
        public string HomeOffensePoints { get => sHomeOffensePoints; set => sHomeOffensePoints = value; }
        public string HomeDefensePassing { get => sHomeDefensePassing; set => sHomeDefensePassing = value; }
        public string HomeDefenseRushsing { get => sHomeDefenseRushing; set => sHomeDefenseRushing = value; }
        public string HomeDefensePoints { get => sHomeDefensePoints; set => sHomeDefensePoints = value; }
        #endregion
    }
}
