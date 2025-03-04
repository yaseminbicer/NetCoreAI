using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreAI.Project01_ApiDemo.Migrations
{
    public partial class UpdateCustomerBalancePrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CustomerBalance",
                table: "Customer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerBalance",
                table: "Customer");
        }
    }
}
