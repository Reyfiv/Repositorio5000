using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registro5000
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            BLL.LoginRepositorio repositorio = new LoginRepositorio();
          
            if (repositorio.Auntenticar(UsuarioTextBox.Text, ContraseñaTextBox.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(user.NombreUsuario, true);
            }
            else
                MostrarMensaje(TiposMensaje.Error, "Usuario no existe");

            if (IsValid == false)
            {
                MostrarMensaje(TiposMensaje.Error, "Favor revisar todos los campos");
                return;
            }
        }

        private void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {

            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensaje.Success)
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }
    }
}