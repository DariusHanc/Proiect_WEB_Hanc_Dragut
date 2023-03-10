// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Dragut_Hanc.Data;

#nullable disable

namespace Proiect_Dragut_Hanc.Migrations
{
    [DbContext(typeof(Proiect_Dragut_HancContext))]
    [Migration("20230102154002_CreateIdentity.Designer")]
    partial class CreateIdentityDesigner
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Buying", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ProductID");

                    b.ToTable("Buying");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int?>("AdminID")
                        .HasColumnType("int");

                    b.Property<DateTime>("AvailabilityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("AdminID");

                    b.HasIndex("StoreID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Store", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreID"), 1L, 1);

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreID");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Buying", b =>
                {
                    b.HasOne("Proiect_Dragut_Hanc.Models.Client", "Client")
                        .WithMany("Borrowings")
                        .HasForeignKey("ClientID");

                    b.HasOne("Proiect_Dragut_Hanc.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Product", b =>
                {
                    b.HasOne("Proiect_Dragut_Hanc.Models.Admin", "Admin")
                        .WithMany("Products")
                        .HasForeignKey("AdminID");

                    b.HasOne("Proiect_Dragut_Hanc.Models.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreID");

                    b.Navigation("Admin");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.ProductCategory", b =>
                {
                    b.HasOne("Proiect_Dragut_Hanc.Models.Category", null)
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Dragut_Hanc.Models.Product", null)
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Admin", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Client", b =>
                {
                    b.Navigation("Borrowings");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Proiect_Dragut_Hanc.Models.Store", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
