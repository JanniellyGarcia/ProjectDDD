using Data.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clientes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Venda> Vendas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure); // Mapeamento de User
            modelBuilder.Entity<Client>(new ClientMap().Configure); // Mapeamento de Client
            modelBuilder.Entity<Product>(new ProductMap().Configure); // Mapeamento de Product
            modelBuilder.Entity<Venda>(new VendaMap().Configure); // Mapeamento de Product


        }
    }
}
