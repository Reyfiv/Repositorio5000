﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string ConfirmarContraseña { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime Fecha { get; set; }

        public virtual List<Detalle> Permisos { get; set; }

        public Usuarios()
        {
            UsuarioID = 0;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            ConfirmarContraseña = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Fecha = DateTime.Now;
            this.Permisos = new List<Detalle>();
        }

        public Usuarios(string nombreUsuario, string contraseña)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
        }

        public void AgregarDetalle(int IdDetalle, int ID, string descripcion)
        {
            this.Permisos.Add(new Detalle(IdDetalle,ID, descripcion));
        }
    }
}
