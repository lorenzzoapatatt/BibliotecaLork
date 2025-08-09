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
    public partial class frmUsuarioCad : Form
    {
        private Usuario? _usuario;
        public frmUsuarioCad()
        {
            InitializeComponent();
        }

        public frmUsuarioCad(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();

            CarregarDadosDaTela();
        }

        private void CarregarDadosDaTela()
        {
            if (_usuario != null)
            {
                txtUsuario.Text = _usuario.Nome;
                txtEmail.Text = _usuario.Email;
                txtSenha.Text = _usuario.Senha;
                txtConfirmarSenha.Text = _usuario.Senha;
            }
        }

        private void SalvarForm()
        {
            if (_usuario != null)
                AtualizarUsuario();
            else
                InserirUsuario();
        }

        private bool ValidarForm()
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Text = "Login ou senha invalida";
            msg.Caption = "falha";
            msg.Icon = MessageDialogIcon.Error;
            msg.Show();

            if (txtEmail.Text == "")
            {
                MessageBox.Show("O campo email é obrigatório");
                txtEmail.Focus();
                return false;
            }
            else if (txtUsuario.Text == "")
            {
                MessageBox.Show("O campo usuario é obrigatório");
                txtEmail.Focus();
                return false;
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("O campo senha é obrigatório");
                txtSenha.Focus();
                return false;
            }
            else if (txtConfirmarSenha.Text == "")
            {
                MessageBox.Show("O campo senha é obrigatório");
                txtConfirmarSenha.Focus();
                return false;
            }

            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As senhas não conferem");
                txtSenha.Focus();
                return false;
            }

            if (txtSenha.Text.Length < 6)
            {
                MessageBox.Show("A senha deve ter no mínimo 6 caracteres");
                txtSenha.Focus();
                return false;
            }



            return true;
        }

        private void AtualizarUsuario()
        {
            using (var banco = new LivrosDBContext())
            {
                string nome = txtUsuario.Text;
                string email = txtEmail.Text;
                string senha = txtSenha.Text;
                _usuario.Nome = nome;
                _usuario.Email = email;
                _usuario.Senha = senha;
                banco.Usuarios.Update(_usuario);
                banco.SaveChanges();
            }
            MessageBox.Show("Cardápio salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void InserirUsuario()
        {
            using (var banco = new LivrosDBContext())
            {
                string nome = txtUsuario.Text;
                string email = txtEmail.Text;
                string senha = txtSenha.Text;

                var usu = new Usuario()
                {
                    Nome = nome,
                    Email = email,
                    Senha = senha,
                    Ativo = true
                };

                banco.Usuarios.Add(usu);
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
