using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateWebDataBase.Domain
{
    /// <summary>
    /// Simple model with no Id property.   
    /// The database on the server wil auto increment.
    /// It should be noted that the Date will be passed on to the 
    /// web server database.
    /// </summary>
    public class Reading
    {
        public  decimal Temp1 { get; set; }
        public decimal Temp2 { get; set; }
        public decimal Temp3 { get; set; }
        public decimal Temp4 { get; set; }
        public decimal Hum1 { get; set; }
        public decimal Hum2 { get; set; }
        public decimal Hum3 { get; set; }
        public decimal Hum4 { get; set; }
        public DateTime Date { get; set; }
    }
}
