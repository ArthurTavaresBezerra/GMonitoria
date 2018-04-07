using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GMonitoria.Infrastructure.Data.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // new InitialCreate().Public_Up(migrationBuilder); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //new InitialCreate().Public_Down(migrationBuilder);
        }
    }
}
