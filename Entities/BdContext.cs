using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace API.Entities;

public partial class BdContext : DbContext
{
    public DbSet<ProjectoModel> Projetos { get; set; }
    public DbSet<TipoProjectoModel> TiposProjecto { get; set; }
    public DbSet<DetalheModel> Detalhes { get; set; }
    public DbSet<FinanciadorModel> Financiadores { get; set; }
    public DbSet<FinanciamentoProjectoModel> FinanciamentosProjecto { get; set; }
    public DbSet<TipoFinanciadorModel> TiposFinanciador { get; set; }
    public DbSet<TipoFinanciamentoModel> TiposFinanciamento { get; set; }
    public DbSet<VerificacaoModel> Verificacoes { get; set; }
    public DbSet<RealizadorModel> Realizadores { get; set; }
    public DbSet<ContaModel> Contas { get; set; }

    public BdContext()
    {
    }

    public BdContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;Database=bd_crowd;uid=root",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<FinanciadorModel>()
            .HasOne<ContaModel>(c => c.Conta)
            .WithOne(c => c.Financiador)
            .HasForeignKey<FinanciadorModel>(f => f.ContaId);

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<RealizadorModel>()
            .HasOne<ContaModel>(c => c.Conta)
            .WithOne(c => c.Realizador)
            .HasForeignKey<RealizadorModel>(f => f.ContaId);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}