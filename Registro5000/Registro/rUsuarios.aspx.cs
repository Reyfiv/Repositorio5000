using BLL;
using Entities;
using Registro5000.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registro5000.Registro
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                    var categoria = repositorio.Buscar(id);

                    if (categoria == null)
                    {
                        MostrarMensaje(TiposMensaje.Error, "Registro no encontrado");
                    }
                    else
                    {
                        LlenaCampos(categoria);
                    }
                }
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

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ContraseñaTextBox.Text = string.Empty;
            ConfirmarContraseñaTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
        }

        private Usuarios LlenaClase(Usuarios usuario)
        {
            int id;
            bool result = int.TryParse(UsuarioIdTextBox.Text, out id);
            if (result == true)
            {
                usuario.UsuarioID = id;
            }
            else
            {
                usuario.UsuarioID = 0;
            }
            usuario.Nombres = NombresTextBox.Text;
            usuario.NombreUsuario = NombreUsuarioTextBox.Text;
            usuario.Contraseña = ContraseñaTextBox.Text;
            usuario.ConfirmarContraseña = ConfirmarContraseñaTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Telefono = TelefonoTextBox.Text;
            usuario.Celular = CelularTextBox.Text;
            DateTime date;
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resultado == true)
                usuario.Fecha = date;
            return usuario;
        }

        private void LlenaCampos(Usuarios usuarios)
        {
            UsuarioIdTextBox.Text = Convert.ToString(usuarios.UsuarioID);
            NombresTextBox.Text = usuarios.Nombres;
            NombreUsuarioTextBox.Text = usuarios.NombreUsuario;
            ContraseñaTextBox.Text = usuarios.Contraseña;
            ConfirmarContraseñaTextBox.Text = usuarios.ConfirmarContraseña;
            EmailTextBox.Text = usuarios.Email;
            TelefonoTextBox.Text = usuarios.Telefono;
            CelularTextBox.Text = usuarios.Celular;
            FechaTextBox.Text = usuarios.Fecha.ToString();
        }

        
        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {

            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            bool paso = false;

            if (IsValid == false)
            {
                MostrarMensaje(TiposMensaje.Error, "Favor revisar todos los campos");
                return;
            }

            LlenaClase(usuario);
            if (usuario.UsuarioID == 0)
                paso = repositorio.Guardar(usuario);
            else
                paso = repositorio.Modificar(usuario);

            if (paso)
            {
                MostrarMensaje(TiposMensaje.Success, "Guardado con Exito!");
                Limpiar();
            }
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(UsuarioIdTextBox.Text);
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            if (repositorio.Eliminar(id))
            {
                MostrarMensaje(TiposMensaje.Success, "Eliminado con Exito!");
            }
            else
                MostrarMensaje(TiposMensaje.Error, "Fallo al Eliminar :(");
            Limpiar();
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(UsuarioIdTextBox.Text);
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = repositorio.Buscar(id);

            if (usuario != null)
            {
                LlenaCampos(usuario);
            }
            else
                MostrarMensaje(TiposMensaje.Error, "Error, No existe");
        }
    }
}