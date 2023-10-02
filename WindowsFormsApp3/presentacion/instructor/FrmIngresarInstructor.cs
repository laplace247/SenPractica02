using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.common;
using SenatiPractica.common.instructor;
using SenatiPractica.negocio.instructor;
using SenatiPractica.negocio;

namespace WindowsFormsApp3.presentacion.instructor
{
    public partial class FrmIngresarInstructor : MaterialSkin.Controls.MaterialForm
    {
        private NegocioInstructor _negocioInstructor = new NegocioInstructor();

        public delegate void InstructorGrillaLoadEventHandler();
        public event InstructorGrillaLoadEventHandler InstructorGrillaLoaded;
        public FrmIngresarInstructor()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadInstructor alumno = new EntidadIntructor(txtDni.Text, txtNombres.Text, txtApellidos.Text, txtEdad.Text, cpCurso, cpGenero);
            //alumno.Dni = txtDni.Text;
            //alumno.Nombres = txtNombres.Text;
            //alumno.Apellidos = txtApellidos.Text;
            int num = _negocioInstructor.InsertarInstructorN(alumno);

            if (num != 0)
            {
                MessageBox.Show("Operacion Satisfactoria");
                txtDni.Text = "";
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtEdad.Text = "";
                cpCurso.Text="";
                cpGenero.Text = "";

                if (InstructorGrillaLoaded != null)
                {
                    InstructorGrillaLoaded(); //Invoco al evento refrescar grilla
                }
            }
        }
        private void FrmIngresarInstructor_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

    }
}
