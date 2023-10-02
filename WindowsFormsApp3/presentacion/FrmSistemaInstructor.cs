using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.common.alumno;
using SenatiPractica.common.instructor;
using SenatiPractica.negocio;
using SenatiPractica.negocio.alumno;
using SenatiPractica.negocio.instructor;
using SenatiPractica.presentacion.instructor;

namespace SenatiPractica.presentacion
{
    public partial class FrmSistemaInstructor : MaterialSkin.Controls.MaterialForm
    {
        private NegocioInstructor _negocioInstructor = new NegocioInstructor();

        private EntidadInstructor _alumnoSeleccionado = new EntidadInstructor();
        public FrmSistemaInstructor()
        {
            InitializeComponent();
        }
        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmSistemaInstructor_Shown(object sender, EventArgs e)
        {
            CargarTodosInstructores();
            MessageBox.Show("Bienvenido al Sistema", "Acceso al Sistema",
            MessageBoxButtons.OK);
        }

        private void CargarTodosInstructores()
        {
            dgvInstructores.DataSource = _negocioInstructor.ObtenerTodosInstructoresN();
            SeleccionarInstructoresLoad();
        }

        private void SeleccionarInstructoresLoad()
        {
            if (dgvInstructores.Rows.Count == 0)
            {
                return;
            }

            string id = dgvInstructores.CurrentRow.Cells[0].Value.ToString();
            string dni = dgvInstructores.CurrentRow.Cells[1].Value.ToString();
            string nombres = dgvInstructores.CurrentRow.Cells[2].Value.ToString();
            string apellidos = dgvInstructores.CurrentRow.Cells[3].Value.ToString();
            string edad = dgvInstructores.CurrentRow.Cells[4].Value.ToString();
            string curso= dgvInstructores.CurrentRow.Cells[5].Value.ToString();
            string genero = dgvInstructores.CurrentRow.Cells[6].Value.ToString();

            _alumnoSeleccionado.Id = Convert.ToInt32(id);
            _alumnoSeleccionado.Dni = dni;
            _alumnoSeleccionado.Nombres = nombres;
            _alumnoSeleccionado.Apellidos = apellidos;
            _alumnoSeleccionado.Edad = edad;
            _alumnoSeleccionado.Curso = curso;
            _alumnoSeleccionado.Genero = genero;

        }

        private void dgvInstructores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
