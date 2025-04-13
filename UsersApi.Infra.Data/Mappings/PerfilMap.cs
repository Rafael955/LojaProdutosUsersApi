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
        }
    }
}
