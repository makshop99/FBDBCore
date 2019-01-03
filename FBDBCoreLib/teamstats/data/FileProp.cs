using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBCoreLib.data
{
    public class FileProp
    {
        public FileProp()
        {
            sOffenseFile = "";
            sDefenseFile = "";
            sGamedayFile = "";
        }

        private string sOffenseFile;
        private string sDefenseFile;
        private string sGamedayFile;

        public string Offense { get => sOffenseFile; set => sOffenseFile = value; }
        public string Defense { get => sDefenseFile; set => sDefenseFile = value; }
        public string Gameday { get => sGamedayFile; set => sGamedayFile = value; }
    }
}
