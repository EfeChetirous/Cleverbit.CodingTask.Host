﻿// <auto-generated />
using Cleverbit.CodingTask.Data.DBProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cleverbit.CodingTask.Host.Migrations
{
    [DbContext(typeof(CleverbitDBContext))]
    [Migration("20210608185826_CleverbitDBSql")]
    partial class CleverbitDBSql
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cleverbit.CodingTask.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "123456",
                            Username = "User1"
                        },
                        new
                        {
                            Id = 2,
                            Password = "123456",
                            Username = "User2"
                        },
                        new
                        {
                            Id = 3,
                            Password = "123456",
                            Username = "User3"
                        },
                        new
                        {
                            Id = 4,
                            Password = "123456",
                            Username = "User4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
