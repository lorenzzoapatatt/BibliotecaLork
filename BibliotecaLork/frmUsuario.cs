using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace BibliotecaLork
{
    public partial class frmUsuario : Form
    {
        Usuario? usuarioSelecionado;
        public frmUsuario()
        {
            InitializeComponent();
        }



        private void BuscarUsuario()
        {
            using (var bd = new LivrosDBContext())
            {
                var usuarios = bd.Usuarios.ToList();
                dgvUsuario.DataSource = usuarios;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (usuarioSelecionado != null)
            {
                var usuarioEditar = new frmUsuarioCad(usuarioSelecionado);
                usuarioEditar.Show();
                BuscarUsuario();
                usuarioSelecionado = null;
            }
            else
            {
                msg.Show("Selecione um cardápio para editar.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var frmUsuariosCad = new frmUsuarioCad();
            frmUsuariosCad.ShowDialog();
            BuscarUsuario();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = MessageDialogIcon.Error;

            if (usuarioSelecionado != null)
            {
                using (var bancoDeDados = new LivrosDBContext())
                {
                    bancoDeDados.Usuarios.Remove(usuarioSelecionado);
                    bancoDeDados.SaveChanges();
                }
                msg.Show("Cardápio excluído com sucesso!");
                BuscarUsuario();
                usuarioSelecionado = null;
            }
            else
            {
                msg.Show("Selecione um cardápio para excluir.");
            }
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //pegar o usuario selecionado
                usuarioSelecionado = dgvUsuario.Rows[e.RowIndex].DataBoundItem as Usuario;
                btnEditar.Enabled = true;
            }
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            BuscarUsuario();
        }
    }
}
