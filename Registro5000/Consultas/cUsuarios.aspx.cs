using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registro5000.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MetodoBuscar();
        }

        private DateTime ToFecha(string fecha)
        {
            DateTime resul;
            var resultado = DateTime.TryParse(fecha, out resul);
            return resul;
        }

        private void MetodoBuscar()
        {
            Expression<Func<Usuarios, bool>> filtro = x => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();

            int id;
            var desdeDatetime = ToFecha(DesdeTextBox.Text);
            var hastaDatetime = ToFecha(HastaTextBox.Text);
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    repositorio.GetList(c => true);
                    break;
                case 1://UsuarioId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.UsuarioID == id;
                    break;
                case 2://Nombres
                    filtro = c => c.NombreUsuario.Contains(CriterioTextBox.Text);
                    break;
                case 3: //NombreUsuario
                    filtro = c => c.NombreUsuario.Contains(CriterioTextBox.Text);
                    break;
                case 4: //Email
                    filtro = c => c.Email.Contains(CriterioTextBox.Text);
                    break;
                case 5: //Telefono
                    filtro = c => c.Telefono.Equals(CriterioTextBox.Text);
                    break;
                case 6: //Celular
                    filtro = c => c.Celular.Equals(CriterioTextBox.Text);
                    break;
                case 7: //Fecha
                    filtro = pa => pa.Fecha >= desdeDatetime.Date && pa.Fecha <= hastaDatetime.Date;
                    break;
            }
            //var desdeDatetime = ToFecha(DesdeTextBox.Text);
            //var hastaDatetime = ToFecha(HastaTextBox.Text);
            //switch (FiltroDropDownList.SelectedIndex)
            //{
            //    case 0://UsuarioId
            //        id = Convert.ToInt32(CriterioTextBox.Text);
            //        filtro = t => t.UsuarioID == id && (t.Fecha >= desdeDatetime.Date) && (t.Fecha <= hastaDatetime.Date);
            //        break;
            //    case 1://Nombres
            //        filtro = t => t.Nombres.Contains(CriterioTextBox.Text) && (t.Fecha >= desdeDatetime.Date) && (t.Fecha <= hastaDatetime.Date);
            //        break;
            //    case 2: //NombreUsuario
            //        filtro = t => t.NombreUsuario.Contains(CriterioTextBox.Text) && (t.Fecha >= desdeDatetime.Date) && (t.Fecha <= hastaDatetime.Date);
            //        break;
            //    case 3: //Email
            //        filtro = t => t.Email.Contains(CriterioTextBox.Text) && (t.Fecha >= desdeDatetime.Date) && (t.Fecha <= hastaDatetime.Date);
            //        break;
            //    case 4: //Telefono       
            //        filtro = t => t.Telefono.Contains(CriterioTextBox.Text) && (t.Fecha >= desdeDatetime.Date) && (t.Fecha <= hastaDatetime.Date);
            //        break;
            //    case 5: //Celular
            //        filtro = t => t.Celular.Contains(CriterioTextBox.Text) && (t.Fecha >= desdeDatetime.Date) && (t.Fecha <= hastaDatetime.Date);
            //        break;
            //    case 6: //Fecha
            //        filtro = pa => pa.Fecha >= desdeDatetime.Date && pa.Fecha <= hastaDatetime.Date;
            //        break;
            //}

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            MetodoBuscar();
        }

        protected void FiltroDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroDropDownList.SelectedIndex == 7)
            {

                CriterioTextBox.Visible = false;
                CriterioTextBox.ReadOnly = true;
            }
            else
            {
                CriterioTextBox.Visible = true;
                CriterioTextBox.ReadOnly = false;
            }
        }
    }
}