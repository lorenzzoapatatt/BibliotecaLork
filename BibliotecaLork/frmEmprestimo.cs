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
    public partial class frmEmprestimo : Form
    {
        EmprestimoLivro? emprestimoLivroSelecionado;
        public frmEmprestimo()
        {
            InitializeComponent();
        }

        private void BuscarEmprestimo()
        {
            using (var bd = new LivrosDBContext())
            {
                var emprestimoLivros = bd.EmprestimoLivros.ToList();
                dgvEmprestimos.DataSource = emprestimoLivros;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (emprestimoLivroSelecionado != null)
            {
                var usuarioEditar = new frmUsuarioCad(emprestimoLivroSelecionado);
                usuarioEditar.Show();
            }
            BuscarEmprestimo();
            emprestimoLivroSelecionado = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var frmEmprestimoCad = new frmEmprestimoCad();
            frmEmprestimoCad.ShowDialog();
            BuscarEmprestimo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (emprestimoLivroSelecionado != null)
            {
                using (var bancoDeDados = new LivrosDBContext())
                {
                    bancoDeDados.Usuarios.Remove(emprestimoLivroSelecionado);
                    bancoDeDados.SaveChanges();
                }
                MessageBox.Show("Cardápio excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuscarEmprestimo();
                emprestimoLivroSelecionado = null;
            }
            else
            {
                MessageBox.Show("Selecione um cardápio para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                emprestimoLivroSelecionado = dgvEmprestimo.Rows[e.RowIndex].DataBoundItem as EmprestimoLivro;
                btnEditar.Enabled = true;
            }
        }

        private void frmEmprestimo_Load(object sender, EventArgs e)
        {
            BuscarEmprestimo();
        }
    }
}
