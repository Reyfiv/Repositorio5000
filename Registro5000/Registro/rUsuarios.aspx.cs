using BLL;
using Entities;
using Registro5000.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
                LlenaCombo();
                //int id = Utils.ToInt(Request.QueryString["id"]);
                //if (id > 0)
                //{
                //    RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                //    var registro = repositorio.Buscar(id);

                //    if (categoria == null)
                //    {
                //        Utils.ShowToastr(this.Page, "Registro no encontrado", "Error", "error");
                //    }
                //    else
                //    {
                //        LlenaCampos(registro);
                //    }
                //}
            }
        }


        //private void MostrarMensaje(TiposMensaje tipo, string mensaje)
        //{

        //    ErrorLabel.Text = mensaje;

        //    if (tipo == TiposMensaje.Success)
        //        ErrorLabel.CssClass = "alert-success";
        //    else
        //        ErrorLabel.CssClass = "alert-danger";
        //}
        protected void LlenaCombo()
        {
            RepositorioBase<Permisos> repositorioBase = new RepositorioBase<Permisos>();

            PermisosDropDownList.DataSource = repositorioBase.GetList(t => true);
            PermisosDropDownList.DataValueField = "ID";
            PermisosDropDownList.DataTextField = "Descripcion";
            PermisosDropDownList.DataBind();

            ViewState["Usuarios"] = new Usuarios();
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
            ViewState["Usuarios"] = new Usuarios();
            this.BindGrid();
        }

        private Usuarios LlenaClase(Usuarios usuario)
        {
            int id;
            usuario = (Usuarios)ViewState["Usuarios"];
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
            RepositorioBase<Detalle> repositorioBase = new RepositorioBase<Detalle>();
            DatosGridView.DataSource = repositorioBase.GetList(t => true);
            DatosGridView.DataBind();

        }

        protected void BindGrid()
        {
            DatosGridView.DataSource = ((Usuarios)ViewState["Usuarios"]).Permisos;
            DatosGridView.DataBind();
        }

        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {

            DetalleRepositorio repositorio = new DetalleRepositorio();
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            bool paso = false;

            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }

            usuario = LlenaClase(usuario);
            if (usuario.UsuarioID == 0)
                paso = repositorioBase.Guardar(usuario);
            else
                paso = repositorio.Modificar(usuario);
            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                Limpiar();
            }
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(UsuarioIdTextBox.Text);
            DetalleRepositorio repositorio = new DetalleRepositorio();
            if (repositorio.Eliminar(id))
            {
                Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
            }
            else
                Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
            Limpiar();
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            
            DetalleRepositorio repositorio = new DetalleRepositorio();
            var usuario = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if (usuario != null)
            {
                Limpiar();
                LlenaCampos(usuario);
                
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
                Utils.ShowToastr(this.Page, "El usuario que intenta buscar no existe", "Error", "error");
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios = (Usuarios)ViewState["Usuarios"];
            usuarios.AgregarDetalle(0,Convert.ToInt32(PermisosDropDownList.SelectedValue),PermisosDropDownList.SelectedItem.Text);
            ViewState["Usuario"] = usuarios;
            this.BindGrid();
        }

        //protected void ValidaExiste_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    Usuarios user = new Usuarios();
        //    BLL.LoginRepositorio repositorio = new LoginRepositorio();

        //    if (repositorio.UsuarioAuntenticar(NombreUsuarioTextBox.Text))
        //    {
        //        args.IsValid = true;
        //    }
        //    else
        //        args.IsValid = false;
        //}

    }
}