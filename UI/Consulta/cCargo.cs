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

namespace Shurth.UI.Consulta
{
    public partial class cCargo : Form
    {
        public cCargo()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var listado = new List<Cargos>();


            if (txtCriterio.Text.Trim().Length > 0)
            {
                switch (cbFiltro.SelectedIndex)
                {

                    case 0://Todo
                        listado = CargoBLL.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(txtCriterio.Text);
                        listado = CargoBLL.GetList(p => p.CargoId == id);
                        break;

                    case 2://Descripcion
                        listado = CargoBLL.GetList(p => p.Descripcion.Contains(txtCriterio.Text));
                        break;

                   
                }

              
            }
            else
            {
                listado = CargoBLL.GetList(p => true);
            }

            dgvConsulta.DataSource = null;
            dgvConsulta.DataSource = listado;

        }
    }
}
