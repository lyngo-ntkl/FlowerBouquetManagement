﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class FUFlowerBouquetManagementContext : DbContext
    {
        public FUFlowerBouquetManagementContext()
        {
        }

        public FUFlowerBouquetManagementContext(DbContextOptions<FUFlowerBouquetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FlowerBouquet> FlowerBouquets { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        public static IConfiguration GetConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
            return configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConfiguration().GetConnectionString("FlowerBouquetStoreDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryDescription).HasMaxLength(150);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(180)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowerBouquet>(entity =>
            {
                entity.ToTable("FlowerBouquet");

                entity.Property(e => e.FlowerBouquetId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FlowerBouquetID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.FlowerBouquetName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FlowerBouquets)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__FlowerBou__Categ__412EB0B6");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.FlowerBouquets)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FlowerBou__Suppl__4222D4EF");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate)
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("datetime");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Order__CustomerI__4316F928");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.FlowerBouquetId })
                    .HasName("PK__OrderDet__C983CA9F0E36EDF7");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.FlowerBouquetId).HasColumnName("FlowerBouquetID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.FlowerBouquet)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FlowerBouquetId)
                    .HasConstraintName("FK__OrderDeta__Flowe__440B1D61");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__44FF419A");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever()
                    .HasColumnName("SupplierID");

                entity.Property(e => e.SupplierAddress).HasMaxLength(150);

                entity.Property(e => e.SupplierName).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
