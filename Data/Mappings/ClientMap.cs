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
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clientes"); //Nome da Tabela

            builder.HasKey(prop => prop.Id); //Identificar a Chave Primária

            builder.Property(prop => prop.CPF)
                .IsRequired() //Não aceita nulo
                .HasColumnName("Cpf") // Nome da coluna
                .HasColumnType("varchar(11)"); //Quantidade máxima de caracteres
        }
    }
}
