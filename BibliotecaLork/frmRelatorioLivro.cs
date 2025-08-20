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
    RelatorioLivroEmprestado? relatorioLivroSelecionado;
    public partial class frmRelatorioLivro : Form
    {
        public frmRelatorioLivro()
        {
            InitializeComponent();
        }

        private void BuscarRelatorio()
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;

            if (relatorioLivroSelecionado != null)
            {
                var relatorioEditar = new frmRelatorioLivroCad(relatorioLivroSelecionado);
                relatorioEditar.Show();
                msg.Show("Relatório editado com sucesso!");
                BuscarRelatorio();
                relatorioLivroSelecionado = null;
            }
            else
            {
                msg.Show("Selecione um relatório para editar.");
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var frmRelatorioLivroCad = new frmRelatorioLivroCad();
            frmEmprestimoCad.ShowDialog();
            BuscarRelatorio();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            var.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;

            if (relatorioLivroSelecionado != null)
            {
                using (var bd = new LivrosDBContext())
                {
                    bd.RelatorioLivroEmprestados.Remove(relatorioLivroSelecionado);
                    bd.SaveChanges();
                    msg.Show("Relatório excluído com sucesso!");
                    BuscarRelatorio();
                    relatorioLivroSelecionado = null;
                }
            }
            else
            {
                msg.Show("Selecione um relatório para excluir.");
            }
        }

        private void dgvRelatorioLivro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvRelatorioLivro.Rows[e.RowIndex].IsNewRow)
            {
                var livroEmprestado = dgvRelatorioLivro.Rows[e.RowIndex].DataBoundItem as RelatorioLivroEmprestado;
                if (livroEmprestado != null)
                {
                    relatorioLivroSelecionado = livroEmprestado;
                }
            }
        }

        private void frmRelatorioLivro_Load(object sender, EventArgs e)
        {
            BuscarRelatorio();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            BuscarRelatorio();
        }
    }
}
