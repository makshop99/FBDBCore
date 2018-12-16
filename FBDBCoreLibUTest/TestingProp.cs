using System;
namespace FBDBCoreLibUTest
{
    public class TestingProp
    {
        #region local paths
        public string OffenseFile_Local { get => @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\offense.htm"; }
        public string DefenseFile_Local { get => @"C:\\Users\\PeterPiper07\\workspace\\CSharp\\FBDBSolution\\defense.htm"; }
        public string ScheduleFile_Local { get => @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\schedule.htm"; }

        public string OffenseFile_Web { get => @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T"; }
        public string DefenseFile_Web { get => @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T"; }
        public string ScheduleFile_Web { get => @"https://www.footballdb.com/games/index.html"; }

        public string EmptyPath { get => ""; }
        #endregion




    }
}
