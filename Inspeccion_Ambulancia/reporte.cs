using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Inspeccion_Ambulancia
{
    public partial class reporte : Form
    {
        public reporte()
        {
            InitializeComponent();
        }

        private void reporte_Load(object sender, EventArgs e)
        {
            grd.ColumnCount = 6;
            grd.Columns[0].HeaderText = "No. de reporte";
            grd.Columns[1].HeaderText = "Entrega";
            grd.Columns[2].HeaderText = "Recibe";
            grd.Columns[3].HeaderText = "Base Operativa";
            grd.Columns[4].HeaderText = "Hora";
            grd.Columns[5].HeaderText = "Fecha";
            // Format for the data column
            grd.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";

            fecha.CustomFormat = " dd/MM/yyyy";

            //Desactivar No. de reporte y fecha.
            fecha.Enabled = no_reporte.Enabled = false;
            //Desactivar boton generar_reporte

            btn_generar_reporte.Enabled = false;

            //Valores por defecto
            no_reporte.Value = 1;
            no_reporte.Minimum = 1;



            MaximizeBox = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {



            // ---------------------- Buscar por no. reporte ------------------------------
            if (buscar_por.SelectedIndex == 0)
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                //Query
                string str = "select no_reporte, conductor_entrega, conductor_recibe, unidad_operativa, hora, fecha from inspeccion_ambulancia.datos_generales where no_reporte = " + no_reporte.Value.ToString();
                cmd.CommandText = str;
                cmd.Connection = main.cn;
                grd.Rows.Clear(); //Grid Rows are always cleared
                NpgsqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        grd.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                    }
                }
                else
                {
                    Funciones.Mensaje_No_Registros();
                }
                dr.Close();
            }


            // ---------------------- Buscar por fecha ------------------------------
            else if (buscar_por.SelectedIndex == 1)
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                //Query
                string str = "select no_reporte, conductor_entrega, conductor_recibe, unidad_operativa, hora, fecha from inspeccion_ambulancia.datos_generales where fecha = '" + fecha.Value.Date + "'";
                cmd.CommandText = str;
                cmd.Connection = main.cn;
                grd.Rows.Clear(); //Grid Rows are always cleared
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        grd.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                    }
                }
                else
                {
                    Funciones.Mensaje_No_Registros();
                }
                dr.Close();
            }

            if (grd.SelectedRows.Count > 0)
                btn_generar_reporte.Enabled = true;
            else
                btn_generar_reporte.Enabled = false;
        }




        private void buscar_por_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buscar_por.SelectedIndex == 0)
            {
                no_reporte.Enabled = true;
                fecha.Enabled = false;    
            }
            else if (buscar_por.SelectedIndex == 1)
            {
                no_reporte.Enabled = false;
                fecha.Enabled = true;
            }
            else
            {
                no_reporte.Enabled = fecha.Enabled = false;
            }
        }

        private void btn_generar_reporte_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(grd.CurrentRow.Cells[0].Value.ToString());
            Funciones.agregar_formulario(new documento(this), "Visualizador");
        }
    }
}
