using CasoPractico1_JorgeMorua.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CasoPractico1_JorgeMorua.DataAccess
{
    public class Context : DbContext //trabajar con Entity Framework
    {
        public Context()
        {
             Database.SetInitializer<Context>(null);
        }

        public DbSet<RoomsDA> Rooms { get; set; }
        public DbSet<ReservationsDA> Reservations { get; set; }
    }
}