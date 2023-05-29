using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ap1_main.Domain;

namespace ap1_main.Data
{
    public class DataContext : DbContext
    {
        public string DbPath {get;}

        public DataContext()
        {
            var path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "ap2_db.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite($"Data Source ={DbPath}");
        
        public DbSet<Cliente> Cliente { get; set;}
        public DbSet<Conta> Conta { get; set;}
        public DbSet<Transacao> Transacao { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Conta>()
        .HasOne(c => c.cliente)
        .WithMany(c => c.Contas)
        .HasForeignKey(c => c.clienteId);
        }
    
    }
}