using Guna.UI2.WinForms;
using SenacFoods;

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
            //true, false
            bool loginValido = ValidarLogin(txtLogin.Text, txtSenha.Text);
            //se true
            if (loginValido)
            {
                //oculta a tela de login
                this.Hide();
                //criar uma instancia de FrmPrincipal
                var formPrincipal = new frmPrincipal();
                //exibe a tela principal
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
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}
