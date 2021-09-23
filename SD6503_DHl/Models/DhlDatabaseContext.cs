using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



#nullable disable

namespace SD6503_DHl.Models
{
    public partial class DhlDatabaseContext : DbContext
    {
        public DhlDatabaseContext()
        {
        }

        public DhlDatabaseContext(DbContextOptions<DhlDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<LoginAccount> LoginAccounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__AccountD__BE2ACD6E470FED9A");

                entity.Property(e => e.AccountNumber).HasMaxLength(30);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdentifierNavigation)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.Identifier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccountDe__Ident__25869641");
            });

            modelBuilder.Entity<LoginAccount>(entity =>
            {
                entity.HasKey(e => e.Identifier)
                    .HasName("PK__LoginAcc__821FB0188D7497D4");

                entity.ToTable("LoginAccount");

                entity.Property(e => e.Identifier).HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionNumber)
                    .HasName("PK__Transact__95E36B86462D1D3C");

                entity.ToTable("Transaction");

                entity.Property(e => e.TransactionNumber).HasMaxLength(30);

                entity.Property(e => e.FromAccount)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PaymentPeriod)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ToAccount)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.FromAccountNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.FromAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__FromA__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
