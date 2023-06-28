using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPiPessoa.Repository.Models;

namespace WebAPiPessoa.Repository
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options) { }

        public DbSet<TabUsuario> Usuarios { get; set; }

        public DbSet<TabPessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>().ToTable("TabUsuario");
            modelBuilder.Entity<TabPessoa>().ToTable("TabPessoa");
        }
    }
}
