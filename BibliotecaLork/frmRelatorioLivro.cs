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
    public partial class frmRelatorioLivro : Form
    {
        public frmRelatorioLivro()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var frmRelatorioLivroCad = new frmRelatorioLivroCad();
            frmRelatorioLivroCad.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void dgvRelatorioLivro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
