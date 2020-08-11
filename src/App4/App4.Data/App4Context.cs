using App4.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Data
{
    public class App4Context : DbContext
    {
        public App4Context()
        {

        }

        public App4Context(DbContextOptions<App4Context> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }
    }
}
