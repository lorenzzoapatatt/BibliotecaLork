using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SenacFoods;

namespace BibliotecaLork
{
    public partial class frmEmprestimoCad : Form
    {
        public frmEmprestimoCad()
        {
            InitializeComponent();
        }

        private void frmEmprestimoCad_Load(object sender, EventArgs e)
        {
            CarregarLivros();
        }

        private void CarregarLivros()
        {
            using (var bd = new LivrosDBContext())
            {
                var livros = bd.Livros
                    .AsNoTracking()
                    .Select(l => new
                    {
                        l.Id,
                        l.Titulo
                    })
                    .ToList();

                cbLivro.DataSource = livros;
            }
        }
    }
}
