using FBDBCoreLib.controller;
using FBDBCoreLib.data;
using FBDBCoreLib.exceptions;
using System;
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

        public int getMaxPoints()
        {
            return oController.getMaxPoint();
        }
    }
}


