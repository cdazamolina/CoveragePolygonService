﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoveragePolygonService.Infraestructure.Migrations
{
    public partial class AddingHistoryOfRouteDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "HistoryOfRoutes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "HistoryOfRoutes");
        }
    }
}
