using ProyectoFinal.UI.Registro;
using Shurth.UI.Consulta;
using Shurth.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shurth
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

      
        private void Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.Show();


        }

        private void UsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuario us = new cUsuario();
            us.Show();
            
        }

        private void CargoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rCargos c = new rCargos();
            c.Show();
        }

        private void CargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cCargo car = new cCargo();
            car.Show();
        }
    }
}
