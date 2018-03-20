using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessIntelligenceDashboard.Models
{
    // This Class is for Graphs
    public class GraphModel
    {
        //Data Members
        [Required]
        public string DashID { get; set; }          // Dashboard Name Graph is Being Created For
        [Required]
        public int gType { get; set; }              // Graph Type (Line - 0 | Vbar - 4 | Hbar - 5 | Pie - 6)
        [Required]
        public int range { get; set; }              // Range (0 - None | 1 - Range)
        [Required]
        public DateTime startDate { get; set; }     // "From:" Field
        [Required]
        public DateTime endDate { get; set; }       // "To:" Field
        [Required]
        public int timeInt { get; set; }            // Time Interval (0 - None | 1 - Monthly | 2 - Yearly)
        [Required]
        public int amount { get; set; }             // (1 - Sum | 2 - Count)
        [Required]
        public string sField { get; set; }          // "of:" Field When "Sum" is Selected
        [Required]
        public string cField { get; set; }          // "for:" Field when "Sum" is Selected | "of:" Field when "Count" is Selected
        [Required]
        public string[] cSubField { get; set; }     // "for:" Specific Field 
        [Required]
        public string gbField { get; set; }         // "Group By:" Field
        [Required]
        public string[] gbSubField { get; set; }    // "Group By:" Specific Field

        public GraphModel() { }
    }
}