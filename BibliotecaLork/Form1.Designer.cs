namespace BibliotecaLork
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnFechar = new Button();
            txtLogin = new TextBox();
            txtSenha = new TextBox();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Franklin Gothic Medium Cond", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFechar.Location = new Point(759, 12);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(29, 34);
            btnFechar.TabIndex = 0;
            btnFechar.Text = "X";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(332, 152);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(442, 31);
            txtLogin.TabIndex = 1;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(332, 222);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(442, 31);
            txtSenha.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 118, 210);
            panel1.Location = new Point(-5, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(307, 479);
            panel1.TabIndex = 3;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(txtSenha);
            Controls.Add(txtLogin);
            Controls.Add(btnFechar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            Text = "frmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFechar;
        private TextBox txtLogin;
        private TextBox txtSenha;
        private Panel panel1;
    }
}
