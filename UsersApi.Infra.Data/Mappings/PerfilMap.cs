using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Entities;

namespace UsersApi.Infra.Data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            //nome da tabela do banco de dados
            builder.ToTable("TB_PERFIS");

            //chave primária
            builder.HasKey(x => x.Id);

            //mapeamento dos campos da tabela
            builder.Property(x => x.Id)
                .HasColumnName("ID");

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(25)
                .IsRequired();

            //defininindo o campo 'Nome' como único na tabela
            builder.HasIndex(x => x.Nome).IsUnique();

            builder.HasData(
                new Perfil
                {
                    Id = Guid.Parse("7108F98B-F360-40FC-8A87-4C4D2BF578F5"),
                    Nome = "ADMINISTRADOR"
                },
                new Perfil
                {
                    Id = Guid.Parse("2D82DFFC-B54C-465B-BC56-DFEB3E5AC375"),
                    Nome = "OPERADOR"
                }
            );
        }
    }
}
