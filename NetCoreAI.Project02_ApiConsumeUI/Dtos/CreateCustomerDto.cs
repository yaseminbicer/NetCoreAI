using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAI.Project02_ApiConsumeUI.Dtos
{
	public class CreateCustomerDto
	{
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CustomerBalance { get; set; }
    }
}

