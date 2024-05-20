﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using PrevisaoEcommerce.Persistence;

#nullable disable

namespace PrevisaoEcommerce.Migrations
{
    [DbContext(typeof(SprintDbContext))]
    partial class SprintDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrevisaoEcommerce.Models.Cadastro", b =>
                {
                    b.Property<int>("IdCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCadastro"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("IdCadastro");

                    b.ToTable("TB_Cadastro");
                });

            modelBuilder.Entity("PrevisaoEcommerce.Models.DadosMercado", b =>
                {
                    b.Property<int>("IdDadosMerc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDadosMerc"));

                    b.Property<int>("AnoPrevisao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("IdDadosMerc");

                    b.ToTable("TB_DadosMercado");
                });

            modelBuilder.Entity("PrevisaoEcommerce.Models.LogChat", b =>
                {
                    b.Property<int>("IdLogChat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLogChat"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdLogChat");

                    b.ToTable("TB_LogsChat");
                });

            modelBuilder.Entity("PrevisaoEcommerce.Models.Login", b =>
                {
                    b.Property<int>("IdLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLogin"));

                    b.Property<int?>("CadastroIdCadastro")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<int>("IdCadastro")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("IdLogin");

                    b.HasIndex("CadastroIdCadastro");

                    b.ToTable("TB_Login");
                });

            modelBuilder.Entity("PrevisaoEcommerce.Models.Login", b =>
                {
                    b.HasOne("PrevisaoEcommerce.Models.Cadastro", "Cadastro")
                        .WithMany()
                        .HasForeignKey("CadastroIdCadastro");

                    b.Navigation("Cadastro");
                });
#pragma warning restore 612, 618
        }
    }
}