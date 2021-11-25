using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
       

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(prop => prop.Id);
                    

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnName("Nome");

            builder.Property(y => y.Price)
                   .IsRequired()
                   .HasColumnName("Preco")
                   .HasColumnType("double");

            builder.Property(z => z.Weight)
                   .IsRequired()
                   .HasColumnName("Peso")
                   .HasColumnType("double");
        }
    }
}
