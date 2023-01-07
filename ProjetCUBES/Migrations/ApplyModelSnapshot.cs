﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetCUBES.Helpers;

#nullable disable

namespace ProjetCUBES.Migrations
{
    [DbContext(typeof(Class.Apply))]
    partial class ApplyModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetCUBES.Model.Article", b =>
                {
                    b.Property<int>("ID_Article")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DateFill")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<string>("Grape")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdFamily")
                        .HasColumnType("int");

                    b.Property<int>("IdProvider")
                        .HasColumnType("int");

                    b.Property<string>("Ladder")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameArticle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<double>("PriceSup")
                        .HasColumnType("double");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.Property<int>("StockProv")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("ID_Article");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ProjetCUBES.Model.Command", b =>
                {
                    b.Property<int>("Id_Command")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date_Command")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price_Command")
                        .HasColumnType("double");

                    b.Property<int>("RefCommand")
                        .HasColumnType("int");

                    b.Property<int>("Status_Comman")
                        .HasColumnType("int");

                    b.Property<int>("id_customer")
                        .HasColumnType("int");

                    b.HasKey("Id_Command");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("ProjetCUBES.Model.Customer", b =>
                {
                    b.Property<int>("ID_Customer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstNameCus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LogInCus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameCus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PassWordCus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID_Customer");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProjetCUBES.Model.Employer", b =>
                {
                    b.Property<int>("ID_Employer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstNameEmp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Idjob")
                        .HasColumnType("int");

                    b.Property<string>("LogInEmp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameEmp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PassWordEmp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID_Employer");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("ProjetCUBES.Model.Family", b =>
                {
                    b.Property<int>("ID_Family")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameFamily")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID_Family");

                    b.ToTable("Familys");
                });

            modelBuilder.Entity("ProjetCUBES.Model.Job", b =>
                {
                    b.Property<int>("ID_Job")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID_Job");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ProjetCUBES.Model.LineCommand", b =>
                {
                    b.Property<int>("Id_LineCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Id_article")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Ref_Command")
                        .HasColumnType("int");

                    b.HasKey("Id_LineCommande");

                    b.ToTable("LineCommands");
                });

            modelBuilder.Entity("ProjetCUBES.Model.StatusCommand", b =>
                {
                    b.Property<int>("Id_StatusCommand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_StatusCommand");

                    b.ToTable("StatusCommands");
                });

            modelBuilder.Entity("ProjetCUBES.Model.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
