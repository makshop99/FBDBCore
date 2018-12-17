using System;
using FBDBCoreLib.data;
using FBDBCoreLib.exceptions;
using FBDBCoreLib.view;
using Xunit;

namespace FBDBCoreLibUTest
{
    public class UnitTest1
    {
        private TestingProp TestData = new TestingProp();

        // missing test cases
            // using local files - how to set the paths from outside
            // one or both teams have the value of null
            // one or both teams have invalid names like "Chicago Bulls"
            // gameday analysis is missing 


        #region init tests
        /*
        [Fact]
        // local paths passed - OK
        public void FBDBLibInterface_init_FilesOk()
        {
            Assert.Equal(0, new FBDBCoreLibInterface().init(getPath("UseFiles")));
        }
        */

        [Fact]
        // urls passed - ok
        public void FBDBLibInterface_init_URLsOk()
        {
            Assert.Equal(0, new FBDBCoreLibInterface().init(getPath("UseWeb")));
        }

        [Fact]
        // No Schedule Path passed
        public void FBDBLibInterface_init_ScheduleFileEmpty()
        {
            try { int iReturn = new FBDBCoreLibInterface().init(getPath("ScheduleEmpty")); }
            catch (PathException exp) { Assert.Equal(exp.Message, new ExceptionProp().SchedulePath);}
        }

        [Fact]
        // no offense file path passed
        public void FBDBLibInterface_init_OffenseFilesEmpty()
        {
            try { int iReturn = new FBDBCoreLibInterface().init(getPath("OffenseEmpty")); }
            catch (PathException exp) { Assert.Equal(exp.Message, new ExceptionProp().OffensePath); }
        }

        [Fact]
        // no defense file path passed
        public void FBDBLibInterface_init_DefenseFileEmpty()
        {
            try { int iReturn = new FBDBCoreLibInterface().init(getPath("DefenseEmpty")); }
            catch (PathException exp) { Assert.Equal(exp.Message, new ExceptionProp().DefensePath); }
        }
        #endregion

        #region game tests
        [Fact]
        // both teams set correctly
        public void FBDBLibInterface_game_OK()
        {
            try
            {
                // init Lib Interface
                FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
                oPruefling.init(getPath("UseWeb"));

                string[] aryTeam = getTeams("allOK");

                GameProp oReturn = oPruefling.getGame(aryTeam[0], aryTeam[1]);
                int iIst = Convert.ToInt32(oReturn.AwayScore) + Convert.ToInt32(oReturn.HomeScore);
                Assert.Equal(iIst, oPruefling.getMaxPoints());
            }

            catch (Exception) { Assert.True(false); }
        }

        [Fact]
        // hometeam not set
        public void FBDBLibInterface_game_HometeamEmpty()
        {
            try
            {
                // init Lib Interface
                FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
                oPruefling.init(getPath("UseWeb"));
                string[] aryTeam = getTeams("HometeamEmpty");

                GameProp oReturn = oPruefling.getGame(aryTeam[0], aryTeam[1]);
                Assert.True(false);
            }

            catch (GameAnalysisExeption) { Assert.True(true); }
        }

        [Fact]
        // awayteam not set
        public void FBDBLibInterface_game_AwayteamEmpty()
        {
            try
            {
                // init Lib Interface
                FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
                oPruefling.init(getPath("UseWeb"));
                string[] aryTeam = getTeams("AwayteamEmpty");

                GameProp oReturn = oPruefling.getGame(aryTeam[0], aryTeam[1]);
                Assert.True(false);
            }

            catch (GameAnalysisExeption) { Assert.True(true); }

        }

        [Fact]
        // both teams not set
        public void FBDBLibInterface_game_NoData()
        {
            try
            {
                // init Lib Interface
                FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
                oPruefling.init(getPath("UseWeb"));
                string[] aryTeam = getTeams("allnOK");

                GameProp oReturn = oPruefling.getGame(aryTeam[0], aryTeam[1]);
                Assert.True(false);
            }

            catch (GameAnalysisExeption) { Assert.True(true); }
        }

        //--
        [Fact]
        // hometeam is null
        public void FBDBLibInterface_game_HometeamNull()
        {
            try
            {
                // init Lib Interface
                FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
                oPruefling.init(getPath("UseWeb"));
                string[] aryTeam = getTeams("HometeamNull");

                GameProp oReturn = oPruefling.getGame(aryTeam[0], aryTeam[1]);
                Assert.True(false);
            }

            catch (GameAnalysisExeption) { Assert.True(true); }
        }

        [Fact]
        // awayteam is null
        public void FBDBLibInterface_game_AwayteamNull()
        {
            try
            {
                // init Lib Interface
                FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
                oPruefling.init(getPath("UseWeb"));
                string[] aryTeam = getTeams("AwayteamNull");

                GameProp oReturn = oPruefling.getGame(aryTeam[0], aryTeam[1]);
                Assert.True(false);
            }

            catch (GameAnalysisExeption) { Assert.True(true); }

        }

        [Fact]
        // both teams are null
        public void FBDBLibInterface_game_Null()
        {
            try
            {
                // init Lib Interface
                FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
                oPruefling.init(getPath("UseWeb"));
                string[] aryTeam = getTeams("allNull");

                GameProp oReturn = oPruefling.getGame(aryTeam[0], aryTeam[1]);
                Assert.True(false);
            }

            catch (GameAnalysisExeption) { Assert.True(true); }
        }

        #endregion

        #region get testdata
        private FileProp getPath(string sPathType)
        {
            FileProp oReturn = new FileProp();

            switch (sPathType)
            {
                case "ScheduleEmpty":
                    oReturn.Offense = TestData.OffenseFile_Local;
                    oReturn.Defense = TestData.DefenseFile_Local;
                    break;
                case "OffenseEmpty":
                    oReturn.Gameday = TestData.ScheduleFile_Local;
                    oReturn.Defense = TestData.DefenseFile_Local;
                    break;
                case "DefenseEmpty":
                    oReturn.Offense = TestData.OffenseFile_Local;
                    oReturn.Gameday = TestData.ScheduleFile_Local;
                    break;

                case "UseFiles":
                    oReturn.Offense = TestData.OffenseFile_Local;
                    oReturn.Defense = TestData.DefenseFile_Local;
                    oReturn.Gameday = TestData.ScheduleFile_Local;
                    break;

                case "UseWeb":
                    oReturn.Offense = TestData.OffenseFile_Web;
                    oReturn.Defense = TestData.DefenseFile_Web;
                    oReturn.Gameday = TestData.ScheduleFile_Web;
                    break;

                default:
                    break;
            }
            
            return oReturn;
        }

        private string[] getTeams(string TestCase)
        {
            string[] aryReturn = new string[2];
            switch (TestCase)
            {
                case "allOK":
                    aryReturn[0] = "Detroit Lions";
                    aryReturn[1] = "Chicago Bears";
                    break;

                case "HometeamEmpty":
                    aryReturn[0] = "";
                    aryReturn[1] = "Chicago Bears";
                    break;
                case "AwayteamEmpty":
                    aryReturn[0] = "Detroit Lions";
                    aryReturn[1] = "";
                    break;
                case "allnOK":
                    aryReturn[0] = "";
                    aryReturn[1] = "";
                    break;

                case "HometeamNull":
                    aryReturn[0] = null;
                    aryReturn[1] = "Chicago Bears";
                    break;
                case "AwayteamNull":
                    aryReturn[0] = "Detroit Lions";
                    aryReturn[1] = null;
                    break;
                case "allNull":
                    aryReturn[0] = null;
                    aryReturn[1] = null;
                    break;


                default:
                    return null;
            }

            return aryReturn;
        }
        #endregion
    }
}
