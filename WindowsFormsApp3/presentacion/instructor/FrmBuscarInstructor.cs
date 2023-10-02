﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SenatiPractica.common.instructor;

namespace SenatiPractica.presentacion.instructor
{
    public partial class FrmBuscarInstructor : MaterialSkin.Controls.MaterialForm
    {
        public ETipoBusquedaInstructor Tipo { get; set; }
        public string Parametro { get; set; }

        public FrmBuscarInstructor()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            //0 DNI 
            //1 NOMBRES
            //2 APELLIDOS
            //3 EDAD
            //4 CURSO
            //5 GENERO
            switch (cbTipo.SelectedIndex)
            {
                case 0: Tipo = ETipoBusquedaInstructor.Dni; break;
                case 1: Tipo = ETipoBusquedaInstructor.Nombres; break;
                case 2: Tipo = ETipoBusquedaInstructor.Apellidos; break;
                case 3: Tipo = ETipoBusquedaInstructor.Edad; break;
                case 4: Tipo = ETipoBusquedaInstructor.Curso; break;
                case 5: Tipo = ETipoBusquedaInstructor.Genero; break;
            }

            Parametro = txtBusqueda.Text;
            this.DialogResult = DialogResult.OK; // Establecer el resultado del diálogo.
            this.Close();
        }
        private void FrmBuscarInstructor_Shown(object sender, EventArgs e)
        {
            CenterToScreen();
            cbTipo.SelectedIndex = 0;//Seleccionamos DNI por defecto
            txtBusqueda.Focus();
        }

        
    }
}
