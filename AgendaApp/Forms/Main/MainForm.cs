using System;
using System.Windows.Forms;
using AgendaApp.Models;
using AgendaApp.Data;

namespace AgendaApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly Usuarios _usuario;
        private readonly CompromissoRepository _repo;
        private bool _logout = false;

        public bool Logout => _logout;

        public MainForm(Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            _repo = new CompromissoRepository();
            lblBemVindo.Text = $"Bem-vindo, {_usuario.Usuario}";
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            dgvCompromissos.DataSource = null;
            dgvCompromissos.DataSource = _repo.ListarPorUsuario(_usuario.Id);
            dgvCompromissos.Columns["Id"].Visible = false;
            dgvCompromissos.Columns["UsuarioId"].Visible = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = new CompromissoForm(_usuario.Id);
            if (form.ShowDialog() == DialogResult.OK)
                CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCompromissos.CurrentRow == null) return;
            var comp = (Compromisso)dgvCompromissos.CurrentRow.DataBoundItem;
            var form = new CompromissoForm(_usuario.Id, comp);
            if (form.ShowDialog() == DialogResult.OK)
                CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCompromissos.CurrentRow == null) return;
            var comp = (Compromisso)dgvCompromissos.CurrentRow.DataBoundItem;
            if (MessageBox.Show("Deseja realmente excluir este compromisso?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repo.Remover(comp.Id);
                CarregarGrid();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _logout = true;
            this.Close();
        }
    }
}