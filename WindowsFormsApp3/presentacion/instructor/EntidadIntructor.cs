using SenatiPractica.common.instructor;
using System.Windows.Forms;

namespace WindowsFormsApp3.presentacion.instructor
{
    internal class EntidadIntructor : EntidadInstructor
    {
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private ComboBox cpCurso;
        private ComboBox cpGenero;
        private TextBox txtCurso;
        private object value;

        public EntidadIntructor(string text1, string text2, string text3, string text4, ComboBox cpCurso, ComboBox cpGenero)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
            this.cpCurso = cpCurso;
            this.cpGenero = cpGenero;
        }

        public EntidadIntructor(string text1, string text2, string text3, string text4, TextBox txtCurso, object value)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
            this.txtCurso = txtCurso;
            this.value = value;
        }
    }
}