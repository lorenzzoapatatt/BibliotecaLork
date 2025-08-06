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
            ////conecta ao banco
            //using (var banco = new ComandaDBContext())
            //{
            //    //consultar a tabela usuario select * from usuarios where email = ? and senha = ?
            //    var usuario = banco
            //                    .Usuarios
            //                    .FirstOrDefault(u => u.Email.ToLower() == nome.ToLower() && u.Senha == senha);

            //    if (usuario is not null)
            //        usuarioValido = true;
            //}

            //se nome � igual a admin e senha igual a 123
            if (usuarioValido)
            {
                //Retorna verdadeiro
                return true;
            }
            else
            {
                //exibe mensagem de erro
                MessageBox.Show("Login ou senha invalida");
            }
            // retorna false
            return false;
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if (txtLogin.Text == "USU�RIO")
            {
                txtLogin.Text = "";
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "SENHA")
            {
                txtSenha.Text = "";
            }
        }
    }
}
