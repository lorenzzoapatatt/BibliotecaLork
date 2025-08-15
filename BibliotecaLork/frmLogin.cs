using Guna.UI2.WinForms;

namespace BibliotecaLork
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginValido = ValidarLogin(txtLogin.Text, txtSenha.Text);
            if (loginValido)
            {
                this.Hide();
                var formPrincipal = new frmPrincipal();
                formPrincipal.Show();
            }
        }

        private bool ValidarLogin(string nome, string senha)
        {
            bool usuarioValido = false;
            //conecta ao banco
            using (var banco = new LivrosDBContext())
            {
                //consultar a tabela usuario select * from usuarios where email = ? and senha = ?
                var usuario = banco
                                .Usuarios
                                .FirstOrDefault(u => u.Email.ToLower() == nome.ToLower() && u.Senha == senha);

                if (usuario is not null)
                    usuarioValido = true;
            }

            //se nome é igual a admin e senha igual a 123
            if (usuarioValido)
            {
                //Retorna verdadeiro
                return true;
            }
            else
            {
                var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
                msg.Text = "Login ou senha invalida";
                msg.Caption = "falha";
                msg.Icon = MessageDialogIcon.Error;
                msg.Show();
            }
            // retorna false
            return false;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEsqueceuSenha_Click(object sender, EventArgs e)
        {
            var frmUsuarioCadastrar = new frmUsuarioCad();
            frmUsuarioCadastrar.ShowDialog();
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
                var formPrincipal = new frmPrincipal();
                formPrincipal.Show();
            }
        }
    }
}
