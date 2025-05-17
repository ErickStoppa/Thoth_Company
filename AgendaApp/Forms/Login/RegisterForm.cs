using System;
using System.Windows.Forms;
using AgendaApp.Data;
using AgendaApp.Services;
using AgendaApp.Models;

namespace AgendaApp.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim().Length == 0 || txtSenha.Text.Length == 0)
            {
                MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var usuarioRepo = new UsuarioRepository();
            if (usuarioRepo.ObterPorNome(txtUsuario.Text.Trim()) != null)
            {
                MessageBox.Show("Usuário já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AuthService.CriarSenha(txtSenha.Text, out byte[] hash, out byte[] salt);
            var novo = new Usuarios
            {
                Usuario = txtUsuario.Text.Trim(),
                SenhaHash = hash,
                Salt = salt
            };
            usuarioRepo.Inserir(novo);

            MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}