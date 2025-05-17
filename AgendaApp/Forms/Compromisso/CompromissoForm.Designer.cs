namespace AgendaApp.Forms
{
    partial class CompromissoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DateTimePicker dtpDataHora;
        private System.Windows.Forms.Button btnSalvar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.dtpDataHora = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(38, 13);
            this.lblTitulo.Text = "Título";
            // txtTitulo
            this.txtTitulo.Location = new System.Drawing.Point(20, 40);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(260, 20);
            // lblDescricao
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(20, 75);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.Text = "Descrição";
            // txtDescricao
            this.txtDescricao.Location = new System.Drawing.Point(20, 95);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(260, 80);
            // lblDataHora
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Location = new System.Drawing.Point(20, 190);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(56, 13);
            this.lblDataHora.Text = "Data/Hora";
            // dtpDataHora
            this.dtpDataHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataHora.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataHora.ShowUpDown = true;
            this.dtpDataHora.Location = new System.Drawing.Point(20, 210);
            this.dtpDataHora.Name = "dtpDataHora";
            this.dtpDataHora.Size = new System.Drawing.Size(260, 20);
            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(205, 250);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // CompromissoForm
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 290);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.dtpDataHora);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompromissoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Novo Compromisso";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}