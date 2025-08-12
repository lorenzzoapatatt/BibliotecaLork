using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenacFoods;

namespace BibliotecaLork
{
    public partial class frmPrincipal : Form
    {
        private CadastroLivro? LivroSelecionado;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            BuscarLivro();
        }

        private void BuscarLivro()
        {
            using (var bd = new LivrosDBContext())
            {
                var livros = bd.CadastroLivros.ToList();
                dgvLivros.DataSource = livros;
            }
        }

        private void dgvLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //pegar o usuario selecionado
                LivroSelecionado = dgvLivros.Rows[e.RowIndex].DataBoundItem as CadastroLivro;
                btnEditar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (LivroSelecionado != null)
            {
                //abrir o formulario de edição
                var livroEditar = new frmCadastroLivro(LivroSelecionado);
                livroEditar.Show();
            }
            //atualizar a lista de cardapios
            BuscarLivro();
            LivroSelecionado = null;
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
            var frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            BuscarLivro();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            var frmLogin = new frmLogin();
            frmLogin.Show();
        }
    }
}
