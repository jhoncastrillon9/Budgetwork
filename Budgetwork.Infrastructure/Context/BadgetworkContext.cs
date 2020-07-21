using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budgetwork.Infrastructure.Context
{
    public class BadgetworkContext: Context
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Local            
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Inmo;Integrated Security=True", options => { });            
            //Azure
            optionsBuilder.UseSqlServer("Server=tcp:inmoapp.database.windows.net,1433;Initial Catalog=Inmoapp_dev;Persist Security Info=False;User ID=inmoappDev;Password=Inmo8906;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", options => { });
        }
    }
}
