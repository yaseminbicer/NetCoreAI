using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAI.Project01_ApiDemo.Entities
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerSurname { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CustomerBalance { get; set; }
	
	}
}

