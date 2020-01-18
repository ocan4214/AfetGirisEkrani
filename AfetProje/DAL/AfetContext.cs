using AfetProje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AfetProje.DAL
{
    public class AfetContext : DbContext
    {
        public AfetContext() : base("AfetContextDatabase")
        {
        }

        public DbSet<Afet> Afets { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<il> iller { get; set; }
        public DbSet<ilce> ilceler { get; set; }
        public DbSet<mahalle_koy> mahalle_koyler { get; set; }
        public DbSet<semt> semtler { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}