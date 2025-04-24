using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Enums;
using UsersApi.Infra.Data.Helpers;
using UsersApi.Infra.Data.Repositories;

namespace UsersApi.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //nome da tabela do banco de dados
            builder.ToTable("TB_USUARIOS");

            //mapeamento da chave primária
            builder.HasKey(x => x.Id);

            //mapeamento dos demais campos
            builder.Property(x => x.Id)
                .HasColumnName("ID");

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            //criando indice para definir o campo email como único
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Property(x => x.PerfilId)
                .HasColumnName("PERFIL_ID")
                .IsRequired();

            //mapeamento do relacionamento (1 para muitos)
            builder.HasOne(x => x.Perfil)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.PerfilId);

            builder.HasData(
                new Usuario{
                    Id = Guid.Parse("C3610A1A-1FB1-44A6-A7A4-311D05C3C61D"), 
                    Nome = "Admin",
                    Email = "admin@lojaprodutosapp.com",
                    Senha = "Admin@123",
                    Status = Status.Ativo,
                    PerfilId = Guid.Parse("7108F98B-F360-40FC-8A87-4C4D2BF578F5")
                }
            );
        }
    }
}
