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
using Microsoft.EntityFrameworkCore;

namespace BibliotecaLork
{
    public partial class frmEmprestimoCad : Form
    {
        private EmprestimoLivro? _emprestimoLivro;
        public frmEmprestimoCad()
        {
            InitializeComponent();
        }

        public frmEmprestimoCad(EmprestimoLivro emprestimoLivro)
        {
            _emprestimoLivro = emprestimoLivro;
            InitializeComponent();

            CarregarDadosDaTela();
        }

        private void CarregarDadosDaTela()
        {
            if (_emprestimoLivro != null)
            {
                txtDataDevolucao.Text = _emprestimoLivro.DataDevolucao;
                txtDataEmprestimo.Text = _emprestimoLivro.DataEmprestimo;
                txtStatus.Text = _emprestimoLivro.Status;
            }
        }

        private void SalvarForm()
        {
            if (_emprestimoLivro != null)
                AtualizarEmprestimo();
            else
                InserirUsuario();
        }

        private bool ValidarForm()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (txtDataDevolucao.Text == "")
            {
                msg.Show("O campo email é obrigatório");
                return false;
            }
            else if (txtDataEmprestimo.Text == "")
            {
                msg.Show("O campo usuario é obrigatório");
                return false;
            }
            else if (txtStatus.Text == "")
            {
                msg.Show("O campo senha é obrigatório");
                return false;
            }



            return true;
        }

        private void AtualizarEmprestimo()
        {
            using (var banco = new LivrosDBContext())
            {
                string dataDevolucao = txtDataDevolucao.Text;
                string dataEmprestimo = txtDataEmprestimo.Text;
                string status = txtStatus.Text;
                _emprestimoLivro.DataDevolucao = dataDevolucao;
                _emprestimoLivro.DataEmprestimo = dataEmprestimo;
                _emprestimoLivro.Status = status;
                banco.EmprestimoLivros.Update(_emprestimoLivro);
                banco.SaveChanges();
            }
            MessageBox.Show("Cardápio salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void InserirUsuario()
        {
            using (var banco = new LivrosDBContext())
            {
                string dataDevolucao = txtDataDevolucao.Text;
                string dataEmprestimo = txtDataEmprestimo.Text;
                string status = txtStatus.Text;

                var emprestimoLivro = new EmprestimoLivro()
                {
                    DataDevolucao = dataDevolucao,
                    DataEmprestimo = dataEmprestimo,
                    Status = status
                };

                banco.EmprestimoLivros.Add(emprestimoLivro);
                banco.SaveChanges();
            }

            MessageBox.Show("Usuário salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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
    }
}
