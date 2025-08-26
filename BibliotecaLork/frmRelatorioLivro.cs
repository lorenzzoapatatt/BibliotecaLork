using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaLork
{
    public partial class frmRelatorioLivro : Form
    {
        public frmRelatorioLivro()
        {
            InitializeComponent();
        }

        public void BuscarEmprestimo()
        {
            using (var bd = new LivrosDBContext())
            {
                var emprestimoLivros = bd.EmprestimoLivros.ToList();
                dgvRelatorio.DataSource = emprestimoLivros;
                if (!string.IsNullOrEmpty(txtPesquisar.Text))
                {
                    emprestimoLivros = emprestimoLivros.Where(e => e.Livro.Titulo.Contains(txtPesquisar.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    dgvRelatorio.DataSource = emprestimoLivros.ToList();
                }
                else
                {
                    dgvRelatorio.DataSource = emprestimoLivros.ToList();
                }
            }
        }

        private void BuscarLivro()
        {
            using (var bd = new LivrosDBContext())
            {
                var livros = bd.Livros.ToList();
                dgvRelatorio.DataSource = livros;
                if (!string.IsNullOrEmpty(txtPesquisar.Text))
                {
                    livros = livros.Where(l => l.Titulo.Contains(txtPesquisar.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    dgvRelatorio.DataSource = livros.ToList();
                }
                else
                {
                    dgvRelatorio.DataSource = livros.ToList();
                }
            }
        }

        private void frmRelatorioLivro_Load(object sender, EventArgs e)
        {
            BuscarEmprestimo();
            BuscarLivro();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
