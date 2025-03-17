using System;
using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Context
{
	public class ApiContext: DbContext

	{
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TR-N-PF2H3Q1S\\SQLEXPRESS;initial Catalog=ApiDb;Trusted_Connection=True;");
        }

        public DbSet<Customer> Customer { get; set; }
}
}
