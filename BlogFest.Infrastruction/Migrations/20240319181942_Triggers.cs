using System;
using BlogFest.Infrastruction.Persistance;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogFest.Infrastruction.Migrations
{
    public partial class Triggers : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddTriggers();
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTriggers();
		}
	}
}
