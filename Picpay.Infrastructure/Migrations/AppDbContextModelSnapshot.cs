﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Picpay.Infrastructure.Context;

#nullable disable

namespace Picpay.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Picpay.Domain.Entities.CarteiraEntity", b =>
                {
                    b.Property<int>("PkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkId"));

                    b.Property<int>("FkUsuario")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.HasKey("PkId");

                    b.HasIndex("FkUsuario");

                    b.ToTable("TB_CARTEIRA", (string)null);
                });

            modelBuilder.Entity("Picpay.Domain.Entities.TransferenciaEntity", b =>
                {
                    b.Property<int>("PkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkId"));

                    b.Property<int>("FkPagador")
                        .HasColumnType("int");

                    b.Property<int>("FkRecebidor")
                        .HasColumnType("int");

                    b.Property<double>("NrValor")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.HasKey("PkId");

                    b.HasIndex("FkPagador");

                    b.HasIndex("FkRecebidor");

                    b.ToTable("TB_TRANSFERENCIA", (string)null);
                });

            modelBuilder.Entity("Picpay.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("PkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkId"));

                    b.Property<string>("DsCPF")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsNome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DsSenha")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TgTipo")
                        .HasColumnType("int");

                    b.HasKey("PkId");

                    b.ToTable("TB_USUARIO", (string)null);
                });

            modelBuilder.Entity("Picpay.Domain.Entities.CarteiraEntity", b =>
                {
                    b.HasOne("Picpay.Domain.Entities.UsuarioEntity", "Usuario")
                        .WithMany("CarteiraEntities")
                        .HasForeignKey("FkUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Picpay.Domain.Entities.TransferenciaEntity", b =>
                {
                    b.HasOne("Picpay.Domain.Entities.CarteiraEntity", "Pagador")
                        .WithMany("TransferenciasComoPagador")
                        .HasForeignKey("FkPagador")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Picpay.Domain.Entities.CarteiraEntity", "Recebedor")
                        .WithMany("TransferenciasComoRecebedor")
                        .HasForeignKey("FkRecebidor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pagador");

                    b.Navigation("Recebedor");
                });

            modelBuilder.Entity("Picpay.Domain.Entities.CarteiraEntity", b =>
                {
                    b.Navigation("TransferenciasComoPagador");

                    b.Navigation("TransferenciasComoRecebedor");
                });

            modelBuilder.Entity("Picpay.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Navigation("CarteiraEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
