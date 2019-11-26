using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using Watsons_Telegram.Models;

namespace Watson_WebService
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TelegramUser> TelegramUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=watsonsdb;user=root;password=12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TelegramUser>(e =>
            {
                e.HasKey(x => x.UserId)
                .HasName("PrimaryKey_UserId");

                e.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                e.Property(x => x.ChatId)
                .HasColumnName("ChatId")
                .HasColumnType("VARCHAR(15)")
                .IsRequired(true);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}