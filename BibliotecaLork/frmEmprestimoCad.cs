using System;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaLork
{
    public partial class frmEmprestimoCad : Form
    {
        private EmprestimoLivro? _emprestimoLivro;
        public frmEmprestimoCad(EmprestimoLivro emprestimoLivro)
        {
            _emprestimoLivro = emprestimoLivro;
            InitializeComponent();
        }
        private void frmEmprestimoCad_Load(object sender, EventArgs e)
        {
            BuscarUsuarios();
            BuscarLivros();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
                SalvarForm();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmEmprestimoCad()
        {
            InitializeComponent();
        }
        private void SalvarForm()
        {
            if (_emprestimoLivro != null)
                AtualizarEmprestimo();
            else
                InserirEmprestimo();
        }

        private bool ValidarForm()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (txtDataEmprestimo.Text == "")
            {
                msg.Show("O campo Data de Empréstimo é obrigatório.");
                return false;
            }
            if (txtDataDevolucao.Text == "")
            {
                msg.Show("O campo Data de Devolução é obrigatório.");
                return false;
            }
            if (txtStatus.Text == "")
            {
                msg.Show("O campo Status é obrigatório.");
                return false;
            }
            if (cbUsuario.SelectedValue == null)
            {
                msg.Show("Selecione um Usuário.");
                return false;
            }
            if (cbLivro.SelectedValue == null)
            {
                msg.Show("Selecione um Livro.");
                return false;
            }

            return true;
        }
        private void InserirEmprestimo()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Information;

            using (var bd = new LivrosDBContext())
            {
                var emprestimoLivro = new EmprestimoLivro
                {
                    DataEmprestimo = txtDataEmprestimo.Text,
                    DataDevolucao = txtDataDevolucao.Text,
                    Status = txtStatus.Text,
                    UsuarioId = (int)cbUsuario.SelectedValue,
                    LivroId = (int)cbLivro.SelectedValue
                };

                bd.EmprestimoLivros.Add(emprestimoLivro);
                bd.SaveChanges();
            }
            msg.Show("Empréstimo salvo com sucesso!");
            this.Close();
        }

        private void AtualizarEmprestimo()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Information;

            using (var bd = new LivrosDBContext())
            {
                var entidade = bd.EmprestimoLivros.FirstOrDefault(e => e.Id == _emprestimoLivro!.Id);
                entidade.DataEmprestimo = txtDataEmprestimo.Text;
                entidade.DataDevolucao = txtDataDevolucao.Text;
                entidade.Status = txtStatus.Text;
                bd.EmprestimoLivros.Update(entidade);
                bd.SaveChanges();
            }
            msg.Show("Empréstimo atualizado com sucesso!");
            this.Close();
        }
        private void BuscarUsuarios()
        {
            using (var bd = new LivrosDBContext())
            {
                var usuarios = bd.Usuarios.ToList();
                cbUsuario.DataSource = usuarios;
                cbUsuario.DisplayMember = "Nome";
                cbUsuario.ValueMember = "Id";
            }
        }

        private void BuscarLivros()
        {
            using (var bd = new LivrosDBContext())
            {
                var livros = bd.Livros.ToList();
                cbLivro.DataSource = livros;
                cbLivro.DisplayMember = "Titulo";
                cbLivro.ValueMember = "Id";
            }
        }
    }
}
