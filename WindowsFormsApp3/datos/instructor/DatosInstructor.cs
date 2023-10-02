using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using SenatiPractica.common.instructor;

namespace SenatiPractica.common.instructor
{
    internal class DatosInstructor
    {
        public EntidadInstructor ObtenerInstructor(int idInstructor)
        {
            return null;
        }
        public int InsertarInstructor(EntidadInstructor instructor)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand("insertarInstructor", Connection.Singleton.SqlConnetionFactory))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dni", instructor.Dni);
                    cmd.Parameters.AddWithValue("@Nombres", instructor.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", instructor.Apellidos);
                    cmd.Parameters.AddWithValue("@Edad", instructor.Edad);
                    cmd.Parameters.AddWithValue("@Curso", instructor.Curso);
                    cmd.Parameters.AddWithValue("@Genero", instructor.Genero);
                    int numRes = cmd.ExecuteNonQuery();
                    return numRes;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int EditarInstructor(EntidadInstructor instructor)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand("editarInstructor", Connection.Singleton.SqlConnetionFactory))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", instructor.Id);
                    cmd.Parameters.AddWithValue("@Dni", instructor.Dni);
                    cmd.Parameters.AddWithValue("@Nombres", instructor.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", instructor.Apellidos);
                    cmd.Parameters.AddWithValue("@Edad", instructor.Edad);
                    cmd.Parameters.AddWithValue("@Curso", instructor.Curso);
                    cmd.Parameters.AddWithValue("@Genero", instructor.Genero);
                    int numRes = cmd.ExecuteNonQuery();
                    return numRes;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int EliminarInstructor(int idInstructor)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand("eliminarInstructor", Connection.Singleton.SqlConnetionFactory))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", idInstructor);
                    int numRes = cmd.ExecuteNonQuery();
                    return numRes;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public DataTable ObtenerTodosInstructores()
        {

            try
            {

                using (SqlCommand cmd = new SqlCommand("obtenerTodosInstructores", Connection.Singleton.SqlConnetionFactory))
                {
                    DataTable dtData = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                    sqlSda.Fill(dtData);
                    return dtData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public DataTable BuscarInstructorByTipoAndParametro(ETipoBusquedaInstructor tipoBusquedaInstructor, string parametro)
        {

            try
            {
                int tipo = -1;
                switch (tipoBusquedaInstructor)
                {
                    case ETipoBusquedaInstructor.Dni: tipo = 1; break;
                    case ETipoBusquedaInstructor.Nombres: tipo = 2; break;
                    case ETipoBusquedaInstructor.Apellidos: tipo = 3; break;
                    case ETipoBusquedaInstructor.Edad: tipo = 4; break;
                    case ETipoBusquedaInstructor.Curso: tipo = 5; break;
                    case ETipoBusquedaInstructor.Genero: tipo = 6; break;
                }

                using (SqlCommand cmd = new SqlCommand("buscarInstructorByTipoAndParametro", Connection.Singleton.SqlConnetionFactory))
                {
                    DataTable dtData = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.Parameters.AddWithValue("@Parametro", parametro);
                    SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                    sqlSda.Fill(dtData);
                    return dtData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
