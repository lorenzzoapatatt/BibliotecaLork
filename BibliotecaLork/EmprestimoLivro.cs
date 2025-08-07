using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaLork
{
    internal class EmprestimoLivro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public string Status { get; set; }
        public int AlunoId { get; set; }
        public int LivroId { get; set; }
    }
}
