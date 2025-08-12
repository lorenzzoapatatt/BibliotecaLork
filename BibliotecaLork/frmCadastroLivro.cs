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
using SenacFoods;

namespace BibliotecaLork
{
    public partial class frmCadastroLivro : Form
    {
        private CadastroLivro? _CadastroLivro;
        public frmCadastroLivro()
        {
            InitializeComponent();
        }

        public frmCadastroLivro(CadastroLivro cadastroLivro)
        {
            _CadastroLivro = cadastroLivro;
            InitializeComponent();

            CarregarDadosDaTela();
        }

        private void CarregarDadosDaTela()
        {
            if (_CadastroLivro != null)
            {
                txtTitulo.Text = _CadastroLivro.Titulo;
                txtAutor.Text = _CadastroLivro.Autor;
                txtCategoria.Text = _CadastroLivro.Categoria;
                txtQuantidade.Text = _CadastroLivro.Quantidade;
                txtIsbn.Text = _CadastroLivro.Isbn;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
                SalvarForm();
        }

        private bool ValidarForm()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (txtTitulo.Text == "")
            {
                msg.Show("O campo Titulo é obrigatório");
                txtTitulo.Focus();
                return false;
            }
            else if (txtAutor.Text == "")
            {
                msg.Show("O campo Autor é obrigatório");
                txtAutor.Focus();
                return false;
            }
            else if (txtCategoria.Text == "")
            {
                msg.Show("O campo Categoria é obrigatório");
                txtCategoria.Focus();
                return false;
            }
            else if (txtQuantidade.Text == "")
            {
                msg.Show("O campo Quantidade é obrigatório");
                txtQuantidade.Focus();
                return false;
            }
            else if (txtIsbn.Text == "")
            {
                msg.Show("O campo Isbn é obrigatório");
                txtIsbn.Focus();
                return false;
            }
            else if (txtIsbn.Text.Length < 13)
            {
                msg.Show("O campo Isbn deve ter no mínimo 13 caracteres");
                txtIsbn.Focus();
                return false;
            }

                return true;
        }

        private void SalvarForm()
        {
            if (_CadastroLivro != null)
                AtualizarCadLivro();
            else
                InserirCadLivro();
        }

        private void AtualizarCadLivro()
        {
            using (var banco = new LivrosDBContext())
            {
                string titulo = txtTitulo.Text;
                string autor = txtAutor.Text;
                string categoria = txtCategoria.Text;
                string quantidade = txtQuantidade.Text;
                string isbn = txtIsbn.Text;
                _CadastroLivro.Titulo = titulo;
                _CadastroLivro.Autor = autor;
                _CadastroLivro.Categoria = categoria;
                _CadastroLivro.Quantidade = quantidade;
                _CadastroLivro.Isbn = isbn;
                banco.CadastroLivros.Update(_CadastroLivro);
                banco.SaveChanges();
            }
            MessageBox.Show("Cardápio salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void InserirCadLivro()
        {
            using (var banco = new LivrosDBContext())
            {
                string titulo = txtTitulo.Text;
                string autor = txtAutor.Text;
                string categoria = txtCategoria.Text;
                string quantidade = txtQuantidade.Text;
                string isbn = txtIsbn.Text;

                var cadastroLivro = new CadastroLivro()
                {
                    Titulo = titulo,
                    Autor = autor,
                    Categoria = categoria,
                    Quantidade = quantidade,
                    Isbn = isbn
                };
                banco.CadastroLivros.Add(cadastroLivro);
                banco.SaveChanges();
            }
            MessageBox.Show("Cardápio salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
