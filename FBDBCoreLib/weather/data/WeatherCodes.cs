using System;
using System.Collections;

namespace FBDBCoreLib.weather.data
{
    public class WeatherCodes
    {
        private Hashtable oCities = new Hashtable();

        #region interface
        /// <summary>
        /// Constructor for this class. Sets up all city codes. 
        /// </summary>
        public WeatherCodes()
        {
            oCities.Add("Arizona Cardinals", "5308655");                                                                    
            oCities.Add("Atlanta Falcons", "4180439");                                                                     
            oCities.Add("Baltimore Ravens", "4347778");                                                                    
            oCities.Add("Buffalo Bills", "5110629");                                                                   
            oCities.Add("Carolina Panthers", "4460243");                                                               
            oCities.Add("Chicago Bears", "4887398");                                                                   
            oCities.Add("Cincinnati Bengals", "4508722");                                                              
            oCities.Add("Cleveland Browns", "5150529");   
            oCities.Add("Dallas Cowboys", "4684888");     
            oCities.Add("Denver Broncos", "5419384");
            oCities.Add("Detroit Lions", "4990729");
            oCities.Add("Green Bay Packers", "5254962");  
            oCities.Add("Houston Texans", "4699066");     
            oCities.Add("Indianapolis Colts", "4259418"); 
            oCities.Add("Jacksonville Jaguars", "4160021");
            oCities.Add("Kansas City Chiefs", "4393217");  
            oCities.Add("Los Angeles Chargers", "5368361");
            oCities.Add("Los Angeles Rams", "5368361");    
            oCities.Add("Miami Dolphins", "4164138");      
            oCities.Add("Minnesota Vikings", "5037649");   
            oCities.Add("New England Patriots", "4930956");
            oCities.Add("New Orleans Saints", "4335045");  
            oCities.Add("New York Giants", "5128581");     
            oCities.Add("New York Jets", "5128581");       
            oCities.Add("Oakland Raiders", "5378538");     
            oCities.Add("Philadelphia Eagles", "4560349");   
            oCities.Add("Pittsburgh Steelers", "5206379");   
            oCities.Add("San Francisco 49ers", "5391959");   
            oCities.Add("Seattle Seahawks", "5809844");      
            oCities.Add("Tampa Bay Buccaneers", "4174757");  
            oCities.Add("Tennessee Titans", "4644585");      
            oCities.Add("Washington Redskins", "4366164");   
        }

        /// <summary>
        /// this methode delivers the code for a city
        /// </summary>
        /// <returns>The city identifier.</returns>
        /// <param name="sCity">S city.</param>
        public string getCityId (string sCity)
        {
            return oCities[sCity].ToString();

        }

        #endregion
    }
}
