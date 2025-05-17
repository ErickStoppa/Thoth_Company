using System;
using System.Windows.Forms;
using AgendaApp.Data;
using AgendaApp.Services;
using AgendaApp.Models;

namespace AgendaApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public Usuarios UsuarioLogado { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuarioRepo = new UsuarioRepository();
            var usuario = usuarioRepo.ObterPorNome(txtUsuario.Text.Trim());

            if (usuario == null)
            {
                MessageBox.Show("Usuário não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool valido = AuthService.VerificarSenha(txtSenha.Text, usuario.SenhaHash, usuario.Salt);
            if (!valido)
            {
                MessageBox.Show("Senha incorreta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var usuarioConverted = new Usuarios
            {
                Id = usuario.Id,
                Usuario = usuario.Usuario,
                SenhaHash = usuario.SenhaHash,
                Salt = usuario.Salt
            };

            this.UsuarioLogado = usuarioConverted;
            this.DialogResult = DialogResult.OK;
            this.Hide();
            
        }

        private void linkCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var regForm = new RegisterForm())
                regForm.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                Application.Exit();
        }
    }
}