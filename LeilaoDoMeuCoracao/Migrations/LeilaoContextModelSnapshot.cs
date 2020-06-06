﻿// <auto-generated />
using System;
using LeilaoDoMeuCoracao.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeilaoDoMeuCoracao.Migrations
{
    [DbContext(typeof(LeilaoContext))]
    partial class LeilaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoBreve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoCompleta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("LeilaoId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.Lance", b =>
                {
                    b.Property<int>("LanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aceito")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataHoraLance")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeilaoId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("LanceId");

                    b.HasIndex("LeilaoId");

                    b.HasIndex("UserId");

                    b.ToTable("Lances");
                });

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.Leilao", b =>
                {
                    b.Property<int>("LeilaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataMaxLances")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusLeilaoEnum")
                        .HasColumnType("int");

                    b.Property<int>("TipoLeilaoEnum")
                        .HasColumnType("int");

                    b.Property<int?>("UserCriadorUserId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("LeilaoId");

                    b.HasIndex("UserCriadorUserId");

                    b.ToTable("Leiloes");
                });

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.Item", b =>
                {
                    b.HasOne("LeilaoDoMeuCoracao.PL.Categoria", "Categoria")
                        .WithMany("Items")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("LeilaoDoMeuCoracao.PL.Leilao", "Leilao")
                        .WithMany("Itens")
                        .HasForeignKey("LeilaoId");
                });

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.Lance", b =>
                {
                    b.HasOne("LeilaoDoMeuCoracao.PL.Leilao", "Leilao")
                        .WithMany("Lances")
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeilaoDoMeuCoracao.PL.User", "User")
                        .WithMany("Lances")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LeilaoDoMeuCoracao.PL.Leilao", b =>
                {
                    b.HasOne("LeilaoDoMeuCoracao.PL.User", "UserCriador")
                        .WithMany("Leiloes")
                        .HasForeignKey("UserCriadorUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
