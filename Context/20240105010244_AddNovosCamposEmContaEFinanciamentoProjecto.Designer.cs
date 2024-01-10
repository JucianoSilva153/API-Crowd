﻿// <auto-generated />
using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Context
{
    [DbContext(typeof(BdContext))]
    [Migration("20240105010244_AddNovosCamposEmContaEFinanciamentoProjecto")]
    partial class AddNovosCamposEmContaEFinanciamentoProjecto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Models.ContaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BilheteIdentidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FinanciadorId")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ocupacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RealizadorId")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("API.Models.DetalheModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FinanciamentoProjectoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinanciamentoProjectoId");

                    b.ToTable("Detalhes");
                });

            modelBuilder.Entity("API.Models.FinanciadorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoFinanciadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.HasIndex("TipoFinanciadorId");

                    b.ToTable("Financiadores");
                });

            modelBuilder.Entity("API.Models.FinanciamentoProjectoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DataCriacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FinanciadorId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoFinanciamentoId")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FinanciadorId");

                    b.HasIndex("ProjectoId");

                    b.HasIndex("TipoFinanciamentoId");

                    b.ToTable("FinanciamentosProjecto");
                });

            modelBuilder.Entity("API.Models.ProjectoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FundoPretendido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RealizadorId")
                        .HasColumnType("int");

                    b.Property<int>("TipoProjectoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RealizadorId");

                    b.HasIndex("TipoProjectoId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("API.Models.RealizadorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.ToTable("Realizadores");
                });

            modelBuilder.Entity("API.Models.TipoFinanciadorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TiposFinanciador");
                });

            modelBuilder.Entity("API.Models.TipoFinanciamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FinanciamentoProjectoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TiposFinanciamento");
                });

            modelBuilder.Entity("API.Models.TipoProjectoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TiposProjecto");
                });

            modelBuilder.Entity("API.Models.VerificacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FinanciamentoProjectoId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectoId")
                        .HasColumnType("int");

                    b.Property<string>("TipoVerificacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Verificado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FinanciamentoProjectoId");

                    b.HasIndex("ProjectoId");

                    b.ToTable("Verificacoes");
                });

            modelBuilder.Entity("API.Models.DetalheModel", b =>
                {
                    b.HasOne("API.Models.FinanciamentoProjectoModel", "FinanciamentoProjecto")
                        .WithMany("Detalhes")
                        .HasForeignKey("FinanciamentoProjectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinanciamentoProjecto");
                });

            modelBuilder.Entity("API.Models.FinanciadorModel", b =>
                {
                    b.HasOne("API.Models.ContaModel", "Conta")
                        .WithOne("Financiador")
                        .HasForeignKey("API.Models.FinanciadorModel", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.TipoFinanciadorModel", "TipoFinanciador")
                        .WithMany("Financiadores")
                        .HasForeignKey("TipoFinanciadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");

                    b.Navigation("TipoFinanciador");
                });

            modelBuilder.Entity("API.Models.FinanciamentoProjectoModel", b =>
                {
                    b.HasOne("API.Models.FinanciadorModel", "Financiador")
                        .WithMany("FinanciamentosProjecto")
                        .HasForeignKey("FinanciadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.ProjectoModel", "Projecto")
                        .WithMany("Financiamentos")
                        .HasForeignKey("ProjectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.TipoFinanciamentoModel", "TipoFinanciamento")
                        .WithMany("FinanciamentoProjecto")
                        .HasForeignKey("TipoFinanciamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Financiador");

                    b.Navigation("Projecto");

                    b.Navigation("TipoFinanciamento");
                });

            modelBuilder.Entity("API.Models.ProjectoModel", b =>
                {
                    b.HasOne("API.Models.RealizadorModel", "Realizador")
                        .WithMany("Projectos")
                        .HasForeignKey("RealizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.TipoProjectoModel", "TipoProjecto")
                        .WithMany("Projectos")
                        .HasForeignKey("TipoProjectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Realizador");

                    b.Navigation("TipoProjecto");
                });

            modelBuilder.Entity("API.Models.RealizadorModel", b =>
                {
                    b.HasOne("API.Models.ContaModel", "Conta")
                        .WithOne("Realizador")
                        .HasForeignKey("API.Models.RealizadorModel", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("API.Models.VerificacaoModel", b =>
                {
                    b.HasOne("API.Models.FinanciamentoProjectoModel", "FinanciamentoProjecto")
                        .WithMany()
                        .HasForeignKey("FinanciamentoProjectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.ProjectoModel", "Projecto")
                        .WithMany("Verificoes")
                        .HasForeignKey("ProjectoId");

                    b.Navigation("FinanciamentoProjecto");

                    b.Navigation("Projecto");
                });

            modelBuilder.Entity("API.Models.ContaModel", b =>
                {
                    b.Navigation("Financiador")
                        .IsRequired();

                    b.Navigation("Realizador")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.FinanciadorModel", b =>
                {
                    b.Navigation("FinanciamentosProjecto");
                });

            modelBuilder.Entity("API.Models.FinanciamentoProjectoModel", b =>
                {
                    b.Navigation("Detalhes");
                });

            modelBuilder.Entity("API.Models.ProjectoModel", b =>
                {
                    b.Navigation("Financiamentos");

                    b.Navigation("Verificoes");
                });

            modelBuilder.Entity("API.Models.RealizadorModel", b =>
                {
                    b.Navigation("Projectos");
                });

            modelBuilder.Entity("API.Models.TipoFinanciadorModel", b =>
                {
                    b.Navigation("Financiadores");
                });

            modelBuilder.Entity("API.Models.TipoFinanciamentoModel", b =>
                {
                    b.Navigation("FinanciamentoProjecto");
                });

            modelBuilder.Entity("API.Models.TipoProjectoModel", b =>
                {
                    b.Navigation("Projectos");
                });
#pragma warning restore 612, 618
        }
    }
}
