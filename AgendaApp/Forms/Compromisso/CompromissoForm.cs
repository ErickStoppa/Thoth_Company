using System;
using System.Windows.Forms;
using AgendaApp.Models;
using AgendaApp.Data;

namespace AgendaApp.Forms
{
    public partial class CompromissoForm : Form
    {
        private readonly int _usuarioId;
        private readonly CompromissoRepository _repo;
        private readonly Compromisso _compromisso;

        public CompromissoForm(int usuarioId, Compromisso compromisso = null)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
            _repo = new CompromissoRepository();
            _compromisso = compromisso;

            if (_compromisso != null)
            {
                txtTitulo.Text = _compromisso.Titulo;
                txtDescricao.Text = _compromisso.Descricao;
                dtpDataHora.Value = _compromisso.DataHora;
                this.Text = "Editar Compromisso";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação dos campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Título e descrição são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_compromisso == null)
            {
                var novo = new Compromisso
                {
                    UsuarioId = _usuarioId,
                    Titulo = txtTitulo.Text,
                    Descricao = txtDescricao.Text,
                    DataHora = dtpDataHora.Value
                };
                _repo.Inserir(novo);
            }
            else
            {
                _compromisso.Titulo = txtTitulo.Text;
                _compromisso.Descricao = txtDescricao.Text;
                _compromisso.DataHora = dtpDataHora.Value;
                _repo.Atualizar(_compromisso);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}