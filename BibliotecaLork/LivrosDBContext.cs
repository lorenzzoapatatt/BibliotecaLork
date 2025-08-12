using BibliotecaLork;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SenacFoods
{
    public class LivrosDBContext : DbContext
    {
        public LivrosDBContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = "Server=localhost;Database=biblioteca;User=root;Password=";

            optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmprestimoLivro>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId);
            modelBuilder.Entity<EmprestimoLivro>()
                .HasOne(e => e.Livro)
                .WithMany()
                .HasForeignKey(e => e.LivroId);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<EmprestimoLivro> EmprestimoLivros { get; set; }
        public DbSet<RelatorioLivroEmprestado> RelatorioLivroEmprestados { get; set; }
    }
}