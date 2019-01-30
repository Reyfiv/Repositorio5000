using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetalleRepositorio : RepositorioBase<Usuarios>
    {
        public override Usuarios Buscar(int id)
        {
            Usuarios permisos = new Usuarios();
            try
            {
                permisos = _contexto.Usuarios.Find(id);
                if (permisos != null)
                {
                    permisos.Permisos.Count();
                    foreach (var item in permisos.Permisos)        
                    {
                        string s = item.Descripcion;
                    }
                }
                _contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return permisos;
        }

        public override bool Modificar(Usuarios permiso)
        {
            bool paso = false;
            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = _contexto.Usuarios.Find(permiso.UsuarioID);
                foreach (var item in Anterior.Permisos)
                {
                    if (!permiso.Permisos.Exists(d => d.IdDetalle == item.IdDetalle))
                    {
                        item.Descripcion = null;
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in permiso.Permisos)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                _contexto.Entry(permiso).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                Usuarios Permisos = _contexto.Usuarios.Find(id);

                var Anterior = _contexto.Usuarios.Find(Permisos.UsuarioID);
                foreach (var item in Anterior.Permisos)
                {
                    if (!Permisos.Permisos.Exists(d => d.IdDetalle == item.IdDetalle))
                        _contexto.Entry(item).State = EntityState.Deleted;
                }

                _contexto.Usuarios.Remove(Permisos);

                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
