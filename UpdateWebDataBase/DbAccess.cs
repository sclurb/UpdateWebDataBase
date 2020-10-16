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
    class DbAccess
    {
        private readonly LocalDbContext _ctx; 

        public DbAccess(LocalDbContext ctx)
        {
            _ctx = ctx;
        }

        public Stuff GetReading()
        {
            var reading = _ctx.Stuff.OrderByDescending(d => d.Date).First();
            return reading;
        }
    }
}
