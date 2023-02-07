﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiFranceTest.Models;

namespace TuiFranceTest.Dal
{
    public class TuiFranceTestContext : DbContext
    {
        public TuiFranceTestContext() : base(Constants.TuiFranceTestContext)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasRequired(f => f.DepartureAirport).WithMany(f=>f.DepartureFlights).WillCascadeOnDelete(false);
            modelBuilder.Entity<Flight>().HasRequired(f => f.ArrivalAirport).WithMany(f => f.ArrivalFlights).WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Airport> Airports { get; set; }
    }
}
