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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastroLivros_Click(object sender, EventArgs e)
        {
            var frmCadastroLivro = new frmCadastroLivro();
            frmCadastroLivro.ShowDialog();
        }

        private void btnEmprestimoLivro_Click(object sender, EventArgs e)
        {
            var frmEmprestimo = new frmEmprestimo();
            frmEmprestimo.ShowDialog();
        }

        private void btnRelatorioLivros_Click(object sender, EventArgs e)
        {
            var frmRelatorioLivro = new frmRelatorioLivro();
            frmRelatorioLivro.ShowDialog();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            var frmUsuario = new frmUsuario();
            frmUsuario.ShowDialog();
        }
    }
}
