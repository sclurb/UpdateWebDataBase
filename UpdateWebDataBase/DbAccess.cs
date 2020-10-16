using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UpdateWebDatabase.Data;
using UpdateWebDataBase.Domain;

namespace UpdateWebDataBase
{
    /// <summary>
    /// This is a simple "repository" (should have called as such)
    /// containing a method to query the database and get the latest reading
    /// </summary>
    class DbAccess
    {
        private readonly LocalDbContext _ctx; 

        public DbAccess(LocalDbContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// simple method containing a simple query retrieving only one row.   The lastest row added.
        /// </summary>
        /// <returns></returns>
        public Stuff GetReading()
        {
            var reading = _ctx.Stuff.OrderByDescending(d => d.Date).First();
            return reading;
        }
    }
}
