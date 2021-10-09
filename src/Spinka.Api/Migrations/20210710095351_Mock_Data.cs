using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Mock_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Custom.sql"); 
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
            
            var sqlFileOne = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Proc_1.sql"); 
            migrationBuilder.Sql(File.ReadAllText(sqlFileOne));
            
            var sqlFileTwo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Proc_2.sql"); 
            migrationBuilder.Sql(File.ReadAllText(sqlFileTwo));
            
            var sqlFileThree = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Proc_3.sql"); 
            migrationBuilder.Sql(File.ReadAllText(sqlFileThree));
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
