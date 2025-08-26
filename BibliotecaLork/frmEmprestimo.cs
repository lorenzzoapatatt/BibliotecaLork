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
        private void frmEmprestimo_Load(object sender, EventArgs e)
        {
            BuscarEmprestimo();
        }
        private void frmEmprestimo_Activated(object sender, EventArgs e)
        {
            BuscarEmprestimo();
        }
        private void BuscarEmprestimo()
        {
            using (var bd = new LivrosDBContext())
            {

                var consultaEmprestimos = (from empLiv in bd.EmprestimoLivros
                                          join usuarios in bd.Usuarios on empLiv.UsuarioId equals usuarios.Id
                                          join livro in bd.Livros on empLiv.LivroId equals livro.Id
                                           select new {
                                              empLiv,
                                              usuarios,
                                              livro
                                          });

                if (!string.IsNullOrEmpty(txtPesquisar.Text))
                {
                    consultaEmprestimos = consultaEmprestimos.Where(e => e.empLiv.Status.Contains(txtPesquisar.Text, StringComparison.OrdinalIgnoreCase));
                }

                var dadosEmprestimoLivro = consultaEmprestimos.Select(s => new
                {
                    Id = s.empLiv.Id,
                    DataEmprestimo = s.empLiv.DataEmprestimo,
                    DataDevolucao = s.empLiv.DataDevolucao,
                    Status = s.empLiv.Status,
                    Usuario = s.usuarios.Nome,
                    Livro = s.livro.Titulo
                });

                dgvEmprestimos.DataSource = dadosEmprestimoLivro.ToList();
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
            if (e.RowIndex >= 0)
            {
                emprestimoLivroSelecionado = dgvEmprestimos.Rows[e.RowIndex].DataBoundItem as EmprestimoLivro;
                btnEditar.Enabled = true;
            }
        }


        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            BuscarEmprestimo();
        }

        
    }
}
