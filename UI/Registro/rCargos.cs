using Shurth.BLL;
using Shurth.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shurth.UI.Registro
{
    public partial class rCargos : Form
    {
        public rCargos()
        {
            InitializeComponent();
        }


        public void Limpiar()
        {
            Cargo.Value = 0;
            txtDescripcion.Text = string.Empty;
        }

        private Cargos LlenarClase()
        {
            Cargos us = new Cargos();
            us.CargoId = Convert.ToInt32(Cargo.Value);
            us.Descripcion = txtDescripcion.Text;
            
            return us;
        }
        private void LlenaCampo(Cargos ca)
        {
            Cargo.Value = ca.CargoId;
            txtDescripcion.Text = ca.Descripcion;
            
        }

        private bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();

            if (Cargo.Value == 0)
            {
                ErrorProvider.SetError(Cargo, "El campo cargoid no puede estar vacio");
                Cargo.Focus();
                paso = false;
            }

            //UsuarioId, Nombres, Email, NivelUsuario, Usuario, Clave, FechaIngreso

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                ErrorProvider.SetError(txtDescripcion, "El campo Descripcion no puede estar vacio");
                txtDescripcion.Focus();
                paso = false;
            }

            

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Cargos cargo = CargoBLL.Buscar((int)Cargo.Value);

            return (cargo != null);


        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Cargos cargos = new Cargos();
            CargoBLL.Modificar(cargos);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            int id;
            Cargos cargos = new Cargos();
            int.TryParse(Cargo.Text, out id);

            Limpiar();

            cargos = CargoBLL.Buscar(id);

            if (cargos != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(cargos);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }



        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Cargos cargos;
            bool paso = false;

            if (!Validar())
                return;

            cargos = LlenarClase();
            Limpiar();

            //Determinar si es guardar o modificar
            if (CargoId.Value == 0)
                paso = CargoBLL.Guardar(cargos);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar el cargo que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = CargoBLL.Modificar(cargos);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
