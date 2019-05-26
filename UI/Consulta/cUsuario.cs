using Shurth.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shurth.Entidades;

namespace Shurth.UI.Consulta
{
    public partial class cUsuario : Form
    {
        public cUsuario()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var listado = new List<Usuarios>();


            if (txtCriterio.Text.Trim().Length > 0)
            {
                switch (cbFiltro.SelectedIndex)
                {

                    case 0://Todo
                        listado = UsuarioBLL.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(txtCriterio.Text);
                        listado = UsuarioBLL.GetList(p => p.UsuarioId == id);
                        break;

                    case 2://Nombre
                        listado = UsuarioBLL.GetList(p => p.Nombre.Contains(txtCriterio.Text));
                        break;

                    case 3://Cedula
                        listado = UsuarioBLL.GetList(p => p.Email.Contains(txtCriterio.Text));
                        break;

                    case 4://Direccion
                         int nivel;
                        nivel = Convert.ToInt32(txtCriterio.Text);
                        listado = UsuarioBLL.GetList(p => p.NivelUsuario == nivel);
                        break;
                    case 5:
                          listado = UsuarioBLL.GetList(p => p.Clave.Contains(txtCriterio.Text));
                     break;
                       
                 }

                listado = listado.Where(c => c.FehaIngreso.Date >= dtpDesde.Value.Date && c.FehaIngreso.Date <= dtpHasta.Value.Date).ToList();
            }
            else
            {
                listado = UsuarioBLL.GetList(p => true);
            }

            dgvConsulta.DataSource = null;
            dgvConsulta.DataSource = listado;
        }
    }
}
