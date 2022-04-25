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
using Microsoft.VisualBasic.PowerPacks.Printing;
using System.Drawing.Printing;

namespace Unidad_de_Transporte 
{
    public partial class documento : Form
    {
        reporte frm1;
        public documento(reporte f)
        {
            InitializeComponent();
            frm1 = f;
        }

        private void documento_Load(object sender, EventArgs e)
        {
            int no_reporte = Convert.ToInt32(frm1.grd.CurrentRow.Cells[0].Value);

            Text = "Reporte No. " + no_reporte.ToString();
            //MaximizeBox = false;

            //Cargar datos generales de la base de datos
            NpgsqlCommand cmd = new NpgsqlCommand();
            //Query
            string str = "select * from inspeccion_ambulancia.datos_generales where no_reporte = " + no_reporte.ToString();
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            NpgsqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            List<Label> label_list = new List<Label>(){
            g1, g2, g3, g4, g5, g6, g7, g8, g9, g10
            };

            for (int i = 0; i < 9; i++)
                label_list[i].Text = dr[i].ToString();
            g10.Text = DateTime.Parse(dr[9].ToString()).ToString("dd-MM-yyyy");
            dr.Close();


            label_list = new List<Label>(){
            l1, l2, l3, l4
            };

            List<Label> observaciones = new List<Label>(){
            lo_1, lo_2
            };


            // Limpieza
            str = "select * from inspeccion_ambulancia.limpieza where no_reporte = " + no_reporte.ToString() + " order by no_pregunta";
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            int j = 0; //Numero de pregunta
            int k = 0; //Numero de observación
            while (dr.Read()) {
                if (dr[2].ToString() == "True")
                    label_list[j].Visible = true;
                else if (dr[2].ToString() == "False")
                    label_list[j + 1].Visible = true;

                j+=2;
                observaciones[k].Text = dr[3].ToString();
                k++;
            };
            dr.Close();

            // Cabina Interior
            label_list = new List<Label>(){ 
                ci1, ci2, ci3, ci4, ci5, ci6, ci7, ci8, ci9, ci10, ci11, ci12, ci13, ci14, ci15, ci16, ci17, ci18, ci19, ci20,
                ci21, ci22, ci23, ci24, ci25, ci26, ci27, ci28, ci29, ci30, ci31, ci32, ci33, ci34, ci35, ci36, ci37, ci38
            };
            observaciones = new List<Label>(){
                 cio1, cio2, cio3, cio4, cio5, cio6, cio7, cio8, cio9, cio10, cio11, cio12, cio13, cio14, cio15, cio16, cio17, cio18, cio19
            };

            str = "select * from inspeccion_ambulancia.cabina_interior where no_reporte = " + no_reporte.ToString() + " order by no_pregunta";
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            j = 0; //Numero de pregunta
            k = 0; //Numero de observación
            while (dr.Read())
            {
                if (dr[2].ToString() == "True")
                    label_list[j].Visible = true;
                else if (dr[2].ToString() == "False")
                    label_list[j + 1].Visible = true;

                j += 2;
                observaciones[k].Text = dr[3].ToString();
                k++;
            };
            dr.Close();



            //Cabina Exterior
            label_list = new List<Label>(){
                ce1, ce2, ce3, ce4, ce5, ce6, ce7, ce8, ce9, ce10, ce11, ce12, ce13, ce14, ce15, ce16, ce17, ce18, ce19, ce20, ce21, ce22,
                ce23, ce24, ce25, ce26, ce27, ce28, ce29, ce30, ce31, ce32, ce33, ce34, ce35, ce36, ce37, ce38, ce39, ce40, ce41, ce42, ce43, ce44
            };
            observaciones = new List<Label>(){
                ceo1, ceo2, ceo3, ceo4, ceo5, ceo6, ceo7, ceo8, ceo9, ceo10, ceo11, ceo12, ceo13, ceo14, ceo15, ceo16, ceo17, ceo18, ceo19, ceo20, ceo21, ceo22
            };

            str = "select * from inspeccion_ambulancia.cabina_exterior where no_reporte = " + no_reporte.ToString() + " order by no_pregunta";
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            j = 0; //Numero de pregunta
            k = 0; //Numero de observación
            while (dr.Read())
            {
                if (dr[2].ToString() == "True")
                    label_list[j].Visible = true;
                else if (dr[2].ToString() == "False")
                    label_list[j + 1].Visible = true;

                j += 2;
                observaciones[k].Text = dr[3].ToString();
                k++;
            };
            dr.Close();
            


            //Documentos

            label_list = new List<Label>(){
                d1, d2, d3, d4, d5, d6, d7, d8
            };

            observaciones = new List<Label>(){
                 do1, do2, do3, do4
            };

            str = "select * from inspeccion_ambulancia.documentos where no_reporte = " + no_reporte.ToString() + " order by no_pregunta";
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            j = 0; //Numero de pregunta
            k = 0; //Numero de observación
            while (dr.Read())
            {
                if (dr[2].ToString() == "True")
                    label_list[j].Visible = true;
                else if (dr[2].ToString() == "False")
                    label_list[j + 1].Visible = true;

                j += 2;
                observaciones[k].Text = dr[3].ToString();
                k++;
            };
            dr.Close();

            // Otros datos

            str = "select * from inspeccion_ambulancia.otros_datos where no_reporte = " + no_reporte.ToString();
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            dr.Read();
            combustible.Text = dr[1].ToString() + " %";
            temperatura.Text = dr[2].ToString();
            kilometraje.Text = dr[3].ToString() + " KM";
            observaciones_generales.Text = dr[4].ToString();
            dr.Close();

            // Daños

            label_list = new List<Label>(){
                de1, de2, de3, de4, de5, de6, de7, de8, de9, de10
            };

            str = "select * from inspeccion_ambulancia.danos where no_reporte = " + no_reporte.ToString() + " order by id_descripcion";
            cmd.CommandText = str;
            cmd.Connection = main.cn;
            dr = cmd.ExecuteReader();
            j = 0; //Numero de pregunta
            while (dr.Read())
            {
                label_list[Convert.ToInt32(dr[1])-1].Text = dr[2].ToString();
                label_list[Convert.ToInt32(dr[1]) - 1].Visible = true;
                j ++;
            };
            dr.Close();
        }


    }

}
