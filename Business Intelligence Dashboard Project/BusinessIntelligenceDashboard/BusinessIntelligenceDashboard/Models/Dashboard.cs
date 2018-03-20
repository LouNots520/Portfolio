using DotNet.Highcharts;
using System.Collections.Generic;

namespace BusinessIntelligenceDashboard.Models
{
    //This class is for Dashboards
    public class Dashboard
    {
        //Data Memebrs
        public string name;                     //Name of Dashboard
        public List<GraphModel> cObjects;       //Chart Objects
        public List<Highcharts> charts;         //Graphs in Dashboard
        public bool active;                     //Active Dashboard

        public Dashboard() { }
    }
}