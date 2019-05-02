using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace AspNetAngularAuth.Models
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbluser> Tbluser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=BookStore;port=3306;Uid=root;Pwd=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbluser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("tbluser");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FullName).HasColumnType("varchar(50)");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(128);

                entity.Property(e => e.Salt).HasMaxLength(128);
            });
            modelBuilder.Query<Users>();
        }

        public List<Users> GetUsersByproc(){

            try
            {
                string sqlQuery = "CALL testproc"; 
               var listofUser = this.Query<Users>().FromSql(sqlQuery).ToList();  
               return listofUser; 
            }
            catch (System.Exception ex)
            {
                throw;
            }
        } 
    }
}
