using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Badgetwork.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;

namespace Badgetwork.Infrastructure.Context
{
    public class BadgetworkContext: DbContext
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="options">opciones</param>
        public BadgetworkContext(DbContextOptions<BadgetworkContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Badget>()
                .Property(p => p.Total)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Badget> Badget { get; set; }
        public DbSet<BadgetItem> BadgetItem { get; set; }
        public DbSet<UnitaryPrice> UnitaryPrice { get; set; }
    }
}
