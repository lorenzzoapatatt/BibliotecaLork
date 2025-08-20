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
    public partial class frmRelatorioLivroCad : Form
    {
        private RelatorioLivroEmprestado? _relatorioLivroEmprestado;
        public frmRelatorioLivroCad(RelatorioLivroEmprestado relatorioLivroEmprestado)
        {
            _relatorioLivroEmprestado = relatorioLivroEmprestado;
            InitializeComponent();
        }

        private void frmRelatorioLivroCad_Load(object sender, EventArgs e)
        {
            BuscarLivros();
            BuscarEmprestimo();
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

        public frmRelatorioLivroCad()
        {
            InitializeComponent();
        }

        private void SalvarForm()
        {
            if (_relatorioLivroEmprestado != null)
                AtualizarRelatorio();
            else
                InserirRelatorio();
        }

        private bool ValidarForm()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (cbLivro.SelectedIndex == -1)
            {
                msg.Show("O campo Livro é obrigatório.");
                return false;
            }
            if (cbEmprestimo.SelectedIndex == -1)
            {
                msg.Show("O campo Empréstimo é obrigatório.");
                return false;
            }
            return true;
        }

        private void InserirRelatorio()
        {
            using (var context = new LivrosDBContext())
            {
                var relatorio = new RelatorioLivroEmprestado
                {
                    LivroId = cbLivro.SelectedValue.ToString(),
                    EmprestimoId = cbEmprestimo.SelectedValue.ToString()
                };
                context.RelatorioLivroEmprestados.Add(relatorio);
                context.SaveChanges();
            }
            this.Close();
        }

        private void AtualizarRelatorio()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Information;

            using (var context = new LivrosDBContext())
            {
                var relatorio = context.RelatorioLivroEmprestados.Find(_relatorioLivroEmprestado.Id);
                if (relatorio != null)
                {
                    relatorio.LivroId = cbLivro.SelectedValue.ToString();
                    relatorio.EmprestimoId = cbEmprestimo.SelectedValue.ToString();
                    context.SaveChanges();
                    msg.Show("Relatório atualizado com sucesso.");
                }
                else
                {
                    msg.Show("Relatório não encontrado.");
                }
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

        private void BuscarEmprestimo()
        {
            using (var bd = new LivrosDBContext())
            {
                var emprestimos = bd.EmprestimoLivros.ToList();
                cbEmprestimo.DataSource = emprestimos;
                cbEmprestimo.DisplayMember = "Id";
                cbEmprestimo.ValueMember = "Id";
            }
        }
    }
}
