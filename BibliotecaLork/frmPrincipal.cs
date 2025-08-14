using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace BibliotecaLork
{
    public partial class frmPrincipal : Form
    {
        private Livro? LivroSelecionado;
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
                var livros = bd.Livros.ToList();
                dgvLivros.DataSource = livros;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (LivroSelecionado != null)
            {
                using (var bancoDeDados = new LivrosDBContext())
                {
                    bancoDeDados.Livros.Remove(LivroSelecionado);
                    bancoDeDados.SaveChanges();
                }
                msg.Show("Cardápio excluído com sucesso!");
                BuscarLivro();
                LivroSelecionado = null;
            }
            else
            {
                msg.Show("Selecione um cardápio para excluir.");
            }
        }

        private void dgvLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LivroSelecionado = dgvLivros.Rows[e.RowIndex].DataBoundItem as Livro;
                btnEditar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (LivroSelecionado != null)
            {
                //abrir o formulario de edição
                var livroEditar = new frmCadastroLivro(LivroSelecionado);
                livroEditar.Show();
                //atualizar a lista de cardapios
                BuscarLivro();
                LivroSelecionado = null;
            }
            else
            {
                msg.Show("Selecione um cardápio para editar.");
            }
        }

        private void btnCadastroLivros_Click(object sender, EventArgs e)
        {
            var frmCadastroLivro = new frmCadastroLivro();
            frmCadastroLivro.ShowDialog();
        }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            var frmUsuario = new frmUsuario();
            frmUsuario.ShowDialog();
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
