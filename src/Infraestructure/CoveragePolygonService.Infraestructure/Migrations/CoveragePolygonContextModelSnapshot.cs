﻿// <auto-generated />
using CoveragePolygonService.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoveragePolygonService.Infraestructure.Migrations
{
    [DbContext(typeof(CoveragePolygonContext))]
    partial class CoveragePolygonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoveragePolygonService.Core.Entities.Geoposition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<long>("RouteCoverageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RouteCoverageId");

                    b.ToTable("Geopositions");
                });

            modelBuilder.Entity("CoveragePolygonService.Core.Entities.HistoryOfRoute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RouteFound")
                        .HasColumnType("bit");

                    b.Property<string>("RouteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HistoryOfRoutes");
                });

            modelBuilder.Entity("CoveragePolygonService.Core.Entities.RouteCoverage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("RouteCoverages");
                });

            modelBuilder.Entity("CoveragePolygonService.Core.Entities.Geoposition", b =>
                {
                    b.HasOne("CoveragePolygonService.Core.Entities.RouteCoverage", "RouteCoverage")
                        .WithMany("Positions")
                        .HasForeignKey("RouteCoverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteCoverage");
                });

            modelBuilder.Entity("CoveragePolygonService.Core.Entities.RouteCoverage", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
