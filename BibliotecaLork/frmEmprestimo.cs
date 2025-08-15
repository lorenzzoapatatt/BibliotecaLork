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
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Information;

            if (emprestimoLivroSelecionado != null)
            {
                var emprestimoEditar = new frmEmprestimoCad(emprestimoLivroSelecionado);
                emprestimoEditar.Show();
                msg.Show("Livro editado com sucesso!");
                BuscarEmprestimo();
                emprestimoLivroSelecionado = null;
            }
            else
            {
                msg.Show("Selecione um livro para editar.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var frmEmprestimoCad = new frmEmprestimoCad();
            frmEmprestimoCad.ShowDialog();
            BuscarEmprestimo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Information;

            if (emprestimoLivroSelecionado != null)
            {
                using (var bancoDeDados = new LivrosDBContext())
                {
                    bancoDeDados.EmprestimoLivros.Remove(emprestimoLivroSelecionado);
                    bancoDeDados.SaveChanges();
                }
                msg.Show("Cardápio excluído com sucesso!");
                BuscarEmprestimo();
                emprestimoLivroSelecionado = null;
            }
            else
            {
                msg.Show("Selecione um cardápio para excluir.");
            }
        }

        private void dgvEmprestimos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvEmprestimos.Rows[e.RowIndex].IsNewRow)
            {
                var emprestimoSelecionado = dgvEmprestimos.Rows[e.RowIndex].DataBoundItem as EmprestimoLivro;
                if (emprestimoSelecionado != null)
                {
                    emprestimoLivroSelecionado = emprestimoSelecionado;
                }
            }
        }
        private void frmEmprestimo_Load(object sender, EventArgs e)
        {
            BuscarEmprestimo();
        }


    }
}
