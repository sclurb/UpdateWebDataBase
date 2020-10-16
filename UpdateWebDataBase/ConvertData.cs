using System;
using System.Collections.Generic;
using System.Text;
using UpdateWebDataBase.Domain;

namespace UpdateWebDataBase
{
    public class ConvertData
    {
        /// <summary>
        /// Since the database on the webserver as an autoincrement ID,
        /// it is necessary to create a new model "Reading" without an
        /// Id.   Then populate it with the data from the new database entry.
        /// </summary>
        /// <param name="stuff"></param>
        /// <returns></returns>
        public Reading ConvertToWebFormat(Stuff stuff)
        {
            Reading result = new Reading()
            {
                Temp1 = (decimal)stuff.Temp1,
                Temp2 = (decimal)stuff.Temp2,
                Temp3 = (decimal)stuff.Temp3,
                Temp4 = (decimal)stuff.Temp4,
                Hum1 = (decimal)stuff.Hum1,
                Hum2 = (decimal)stuff.Hum2,
                Hum3 = (decimal)stuff.Hum3,
                Hum4 = (decimal)stuff.Hum4,
                Date = stuff.Date
            };
            return result;
        } 
    }
}
