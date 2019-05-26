using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shurth.Entidades;
using Shurth.DAL;

namespace Shurth.BLL
{
    public class UsuarioBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            bool paso = false;
          
            Contexto db = new Contexto();
            try
            {
                if (db.Usuarios.Add(usuarios) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        //Este es el metodo para modificar en la base de datosC:\Users\Walder Reyes\source\repos\ProyectoFinal\App.config
        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = db.Usuarios.Find(usuarios.UsuarioId);
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        //Este es el metodo para eliminar en la base de datos
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Usuarios.Find(id);
                db.Entry(eliminar).State = System.Data.Entity.EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        //Este es el metodo para buscar en la base de datos
        public static Usuarios Buscar(int id)
        {
            Contexto db = new Contexto();
             Usuarios usuarios = new Usuarios();
            try
            {
                usuarios = db.Usuarios.Find(id);
                // El Count() lo que hace es engañar al lazyloading y obligarlo a cargar los detalles 
               

                //persona = db.Personas
                //     .Include(x => x.Telefonos.Select(c => c.PersonaId))
                //             .Where(p => p.PersonaId == id)
                //             .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuarios;
        }

        //Este es el metodo para listar o consultar lo que tenemos en la base de datos
        public static List<Usuarios> GetList(Expression <Func<Usuarios, bool>> usuarios)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Usuarios.Where(usuarios).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
