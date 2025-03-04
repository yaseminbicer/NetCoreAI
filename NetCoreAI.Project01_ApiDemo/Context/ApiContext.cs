using System;
using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Context
{
	public class ApiContext: DbContext

	{
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=ApiDb;User=sa;Password=Yaso1203@");
        }

        public DbSet<Customer> Customer { get; set; }
}
}
