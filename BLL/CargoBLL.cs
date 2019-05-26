using Shurth.DAL;
using Shurth.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shurth.BLL
{
    public class CargoBLL
    {
        public static bool Guardar(Cargos cargo)
        {
            bool paso = false;

            Contexto db = new Contexto();
            try
            {
                if (db.Cargos.Add(cargo) != null)
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
        public static bool Modificar(Cargos cargos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = db.Cargos.Find(cargos.CargoId);

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
                var eliminar = db.Cargos.Find(id);
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
        public static Cargos Buscar(int id)
        {
            Contexto db = new Contexto();
            Cargos cargos = new Cargos();
            try
            {
                cargos = db.Cargos.Find(id);
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return cargos;
        }

        //Este es el metodo para listar o consultar lo que tenemos en la base de datos
        public static List<Cargos> GetList(Expression<Func<Cargos, bool>> cargos)
        {
            List<Cargos> Lista = new List<Cargos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Cargos.Where(cargos).ToList();
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
