using System;
using FBDBCoreLib.data;
using FBDBCoreLib.view;
using Xunit;

namespace FBDBCoreLibUTest
{
    public class UnitTest1
    {
        private string sOffenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\offense.htm";
        private string sDefenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\defense.htm";
        private string sScheduleFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\schedule.htm";

        #region init tests - local paths
        //[Fact]
        public void FBDBLibInterface_init_FilesOk()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = sOffenseFile;
            oData.Defense = sDefenseFile;
            oData.Gameday = sScheduleFile;

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, 0);
        }

        [Fact]
        public void FBDBLibInterface_init_ScheduleFileEmpty()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = sOffenseFile;
            oData.Defense = sDefenseFile;
            oData.Gameday = @"";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, -3);
        }

        [Fact]
        public void FBDBLibInterface_init_OffenseFilesEmpty()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"";
            oData.Defense = sDefenseFile;
            oData.Gameday = sScheduleFile;

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, -1);
        }

        [Fact]
        public void FBDBLibInterface_init_DefenseFileEmpty()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = sOffenseFile;
            oData.Defense = @"";
            oData.Gameday = sScheduleFile;

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, -2);
        }
        #endregion

        #region init tests - URL
        [Fact]
        public void FBDBLibInterface_init_URLsOk()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, 0);
        }

        [Fact]
        public void FBDBLibInterface_init_DefensURLEmpty()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, -2);
        }

        [Fact]
        public void FBDBLibInterface_init_OffensURLEmpty()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, -1);
        }

        [Fact]
        public void FBDBLibInterface_init_ScheduleURLEmpty()
        {
            FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, -3);
        }
        #endregion


    }


    /*

    #region gameday tests
    #endregion

    #region game tests
    [Fact]
    public void FBDBLibInterface_game_OK()
    {
        FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
        FileProp pPaths = new FileProp();
        pPaths.Offense = sOffenseFile;
        pPaths.Defense = sDefenseFile;
        pPaths.Gameday = sScheduleFile;
        int iReturn = oPruefling.init(pPaths);

        GameProp oData = new GameProp();
        oData.Home = "Detroit Lions";
        oData.Away = "Atlanta Falcons";
        string sSoll = "stats of a single game";
        string sIst = oPruefling.getGame(oData);
        Assert.Equal(sIst, sSoll);
    }

    [Fact]
    public void FBDBLibInterface_game_HometeamEmpty()
    {
        FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
        FileProp pPaths = new FileProp();
        pPaths.Offense = sOffenseFile;
        pPaths.Defense = sDefenseFile;
        pPaths.Gameday = sScheduleFile;
        int iReturn = oPruefling.init(pPaths);

        GameProp oData = new GameProp();
        oData.Home = "";
        oData.Away = "Atlanta Falcons";
        string sSoll = "error: no hometeam passed";
        string sIst = oPruefling.getGame(oData);
        Assert.Equal(sIst, sSoll);
    }

    [Fact]
    public void FBDBLibInterface_game_AwayteamEmpty()
    {
        FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
        FileProp pPaths = new FileProp();
        pPaths.Offense = sOffenseFile;
        pPaths.Defense = sDefenseFile;
        pPaths.Gameday = sScheduleFile;
        int iReturn = oPruefling.init(pPaths);

        GameProp oData = new GameProp();
        oData.Home = "Detroit Lions";
        oData.Away = "";
        string sSoll = "error: no awayteam passed";
        string sIst = oPruefling.getGame(oData);
        Assert.Equal(sIst, sSoll);
    }

    [Fact]
    public void FBDBLibInterface_game_NoData()
    {
        FBDBCoreLibInterface oPruefling = new FBDBCoreLibInterface();
        FileProp pPaths = new FileProp();
        pPaths.Offense = sOffenseFile;
        pPaths.Defense = sDefenseFile;
        pPaths.Gameday = sScheduleFile;
        int iReturn = oPruefling.init(pPaths);

        string sSoll = "error: no gameday passed";
        string sIst = oPruefling.getGame(null);
        Assert.Equal(sIst, sSoll);
    }
    #endregion

    */



}
