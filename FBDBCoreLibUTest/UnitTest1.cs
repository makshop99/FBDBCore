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
        /*
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
        */

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
            int iSoll = 0;
            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.Equal(iReturn, iSoll);
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

        int iSoll = 100;
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
    }
}
