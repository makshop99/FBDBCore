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

        #region init tests
        [Fact]
        // local paths passed - OK
        public void FBDBLibInterface_init_FilesOk()
        {
            Assert.Equal(0, new FBDBCoreLibInterface().init(getPath("UseFiles")));
        }

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
        public void FBDBLibInterface_game_OK()
        {
            // init Lib Interface
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";
            int iReturn = oPruefling.init(oData);

            int iSoll = 200;
            GameProp oReturn = oPruefling.getGame("Detroit Lions", "Chicago Bears");
            int iIst = Convert.ToInt32(oReturn.AwayScore) + Convert.ToInt32(oReturn.HomeScore);
            Assert.Equal(iIst, iSoll);
        }



        [Fact]
        public void FBDBLibInterface_game_HometeamEmpty()
        {
            // init Lib Interface
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";
            int iReturn = oPruefling.init(oData);

            GameProp oIst = oPruefling.getGame("Atlanta Falcons", "");
            GameProp oSoll = null;
            Assert.Equal(oIst, oSoll);
        }

        [Fact]
        public void FBDBLibInterface_game_AwayteamEmpty()
        {
            // init Lib Interface
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";
            int iReturn = oPruefling.init(oData);

            GameProp oIst = oPruefling.getGame("", "Atlanta Falcons");
            GameProp oSoll = null;
            Assert.Equal(oIst, oSoll);

        }

        [Fact]
        public void FBDBLibInterface_game_NoData()
        {
            // init Lib Interface
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";
            int iReturn = oPruefling.init(oData);

            GameProp oIst = oPruefling.getGame("", "");
            GameProp oSoll = null;
            Assert.Equal(oIst, oSoll);
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
        #endregion
    }
}
