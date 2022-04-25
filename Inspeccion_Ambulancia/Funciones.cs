using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Inspeccion_Ambulancia
{
    class Funciones
    {

        //--------------------------------------------------------------------------------------
        //--------------------------  Agregar Elementos ComboBox -------------------------------
        //--------------------------------------------------------------------------------------

        //Añadir elementos a un ComboBox.
        public static void cargaComboBox(string SQL, ComboBox c)
        {

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = main.cn;
            NpgsqlDataReader dr = cmd.ExecuteReader();

            //Fill combobox with the query data
            while (dr.Read())
            {
                c.Items.Add(dr[0]);
            }
            dr.Close();
        }


        ////Añadir formularios hijos sin que se abran varias instancias del mismo.(Formulario de Agregar_Curso)
        public static void agregar_formulario(Form form, string nombre)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == nombre)
                {
                    f.BringToFront();
                    return;
                }
            }
            form.Show();
            form.BringToFront();
        }


        public static void Mensaje_Llenar_Campos(string tab)
        {
            MessageBox.Show("La sección "+tab+" contiene campos obligatorios sin completar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public static void Mensaje_Registro_Insertado()
        {
            MessageBox.Show("La información ha sido ingresada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Mensaje_No_Registros()
        {
            MessageBox.Show("No se han encontrado resultados para la búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
