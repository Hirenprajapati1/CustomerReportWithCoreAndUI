using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustmorReportCore.Models.Entity
{
    public partial class CustomerDBContext : DbContext
    {
        public CustomerDBContext()
        {
        }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("Customer_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerNo)
                    .IsRequired()
                    .HasColumnName("Customer_No")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomerNo)
                    .IsRequired()
                    .HasColumnName("Customer_No")
                    .HasMaxLength(10);

                entity.Property(e => e.InvoiceAmount).HasColumnName("Invoice_Amount");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("Invoice_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasColumnName("Invoice_No")
                    .HasMaxLength(10);

                entity.Property(e => e.PaymentDueDate)
                    .HasColumnName("Payment_Due_Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasColumnName("Invoice_No")
                    .HasMaxLength(10);

                entity.Property(e => e.PaymentAmount).HasColumnName("Payment_Amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("Payment_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentNo)
                    .IsRequired()
                    .HasColumnName("Payment_No")
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
