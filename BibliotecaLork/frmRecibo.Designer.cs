namespace BibliotecaLork
{
    partial class frmRecibo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecibo));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gbRecibo = new Guna.UI2.WinForms.Guna2GroupBox();
            cbLivro = new Guna.UI2.WinForms.Guna2ComboBox();
            cbUsuario = new Guna.UI2.WinForms.Guna2ComboBox();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnImprimir = new Guna.UI2.WinForms.Guna2Button();
            gbRecibo.SuspendLayout();
            SuspendLayout();
            // 
            // gbRecibo
            // 
            gbRecibo.Controls.Add(cbLivro);
            gbRecibo.Controls.Add(cbUsuario);
            gbRecibo.Controls.Add(btnExcluir);
            gbRecibo.Controls.Add(btnImprimir);
            gbRecibo.CustomizableEdges = customizableEdges9;
            gbRecibo.Font = new Font("Segoe UI", 9F);
            gbRecibo.ForeColor = Color.FromArgb(125, 137, 149);
            gbRecibo.Location = new Point(32, 96);
            gbRecibo.Name = "gbRecibo";
            gbRecibo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            gbRecibo.Size = new Size(880, 368);
            gbRecibo.TabIndex = 21;
            gbRecibo.Text = "Recibo";
            // 
            // cbLivro
            // 
            cbLivro.BackColor = Color.Transparent;
            cbLivro.CustomizableEdges = customizableEdges1;
            cbLivro.DrawMode = DrawMode.OwnerDrawFixed;
            cbLivro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLivro.FocusedColor = Color.FromArgb(94, 148, 255);
            cbLivro.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbLivro.Font = new Font("Segoe UI", 10F);
            cbLivro.ForeColor = Color.FromArgb(68, 88, 112);
            cbLivro.ItemHeight = 30;
            cbLivro.Location = new Point(24, 112);
            cbLivro.Name = "cbLivro";
            cbLivro.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbLivro.Size = new Size(320, 36);
            cbLivro.TabIndex = 8;
            // 
            // cbUsuario
            // 
            cbUsuario.BackColor = Color.Transparent;
            cbUsuario.CustomizableEdges = customizableEdges3;
            cbUsuario.DrawMode = DrawMode.OwnerDrawFixed;
            cbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUsuario.FocusedColor = Color.FromArgb(94, 148, 255);
            cbUsuario.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbUsuario.Font = new Font("Segoe UI", 10F);
            cbUsuario.ForeColor = Color.FromArgb(68, 88, 112);
            cbUsuario.ItemHeight = 30;
            cbUsuario.Location = new Point(24, 56);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbUsuario.Size = new Size(320, 36);
            cbUsuario.TabIndex = 7;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.White;
            btnExcluir.BorderRadius = 10;
            btnExcluir.CustomImages.CheckedImage = (Image)resources.GetObject("resource.CheckedImage");
            btnExcluir.CustomizableEdges = customizableEdges5;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(211, 47, 47);
            btnExcluir.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(768, 328);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnExcluir.Size = new Size(104, 32);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Cancelar";
            // 
            // guna2Panel1
            // 
            guna2Panel1.CustomizableEdges = customizableEdges11;
            guna2Panel1.FillColor = Color.FromArgb(25, 118, 210);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel1.Size = new Size(944, 80);
            guna2Panel1.TabIndex = 20;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.BorderRadius = 10;
            btnImprimir.CustomImages.CheckedImage = (Image)resources.GetObject("resource.CheckedImage1");
            btnImprimir.CustomizableEdges = customizableEdges7;
            btnImprimir.DisabledState.BorderColor = Color.DarkGray;
            btnImprimir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnImprimir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnImprimir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnImprimir.FillColor = Color.FromArgb(251, 192, 45);
            btnImprimir.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(656, 328);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnImprimir.Size = new Size(104, 32);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "Imprimir";
            // 
            // frmRecibo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 497);
            Controls.Add(gbRecibo);
            Controls.Add(guna2Panel1);
            Name = "frmRecibo";
            Text = "frmRecibo";
            gbRecibo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbRecibo;
        private Guna.UI2.WinForms.Guna2ComboBox cbLivro;
        private Guna.UI2.WinForms.Guna2ComboBox cbUsuario;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnImprimir;
    }
}