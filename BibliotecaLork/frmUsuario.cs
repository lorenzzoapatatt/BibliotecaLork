using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaLork
{
    public partial class frmUsuario : Form
    {
        Usuario? usuarioSelecionado;
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            BuscarUsuario();
        }

        private void BuscarUsuario()
        {
            // conectar no banco de dados
            using (var bd = new ComandaDBContext())
            {
                // consultar a tabela usuario
                var usuarios = bd.Usuarios.ToList();
                // popular o grid com a tabela consultada
                dgvUsuario.DataSource = usuarios;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //pegar o usuario selecionado
                usuarioSelecionado = dgvUsuario.Rows[e.RowIndex].DataBoundItem as Usuario;
                btnEditar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionado != null)
            {
                //abrir o formulario de edição
                var usuarioEditar = new frmUsuarioCad(usuarioSelecionado);
                usuarioEditar.Show();
            }
            //atualizar a lista de cardapios
            BuscarUsuario();
            usuarioSelecionado = null;
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionado != null)
            {
                using (var bancoDeDados = new ComandaDBContext())
                {
                    bancoDeDados.Usuarios.Remove(usuarioSelecionado);
                    bancoDeDados.SaveChanges();
                }
                MessageBox.Show("Cardápio excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuscarUsuario();
                usuarioSelecionado = null;
            }
            else
            {
                MessageBox.Show("Selecione um cardápio para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var frmUsuariosCad = new frmUsuarioCad();
            frmUsuariosCad.ShowDialog();
            BuscarUsuario();
        }

    }
}
