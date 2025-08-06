using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BibliotecaLork
{
    public class ComandaDBContext : DbContext
    {
        //1-construtor do banco de dados
        public ComandaDBContext() : base()
        {

        }
        //2-configurar a conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 2.1 String de Conexão
            var conexao = "Server=localhost;Database=biblioteca;User=root;Password=";

            // 2.2 Configurar o provedor de banco de dados
            optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
