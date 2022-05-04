using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Unidad_de_Transporte 
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string str1 = "select * from entrada_salida.orden_mov where num = " + Form5.numero_orden;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = str1;
            cmd.Connection = main.cn;
            NpgsqlDataReader check_info = cmd.ExecuteReader();
            check_info.Read();
            //  Cuando no moviliza a un paciente 
            if (check_info[11].ToString() == "" && check_info[5].ToString() == "")
            {
                check_info.Close();
                im_actividades.Items.Clear();
                string str2 = "select * from entrada_salida.orden_mov O inner join ";
                str2 = str2 + "entrada_salida.info_solicitud I on O.num = I.num inner join ";
                str2 = str2 + "entrada_salida.autorizacion A on I.num = A.num inner join ";
                str2 = str2 + "entrada_salida.vehiculo V on I.vehiculo = V.cod_inst inner join ";
                str2 = str2 + "entrada_salida.conductor C on I.conductor = C.cedula inner join ";
                str2 = str2 + "entrada_salida.solicitante_sin_destino S on S.numero = A.num ";
                str2 = str2 + "where O.num = " + Form5.numero_orden + " and I.estado = 'APROBADA'";
                NpgsqlCommand cmd2 = new NpgsqlCommand();
                cmd2.CommandText = str2;
                cmd2.Connection = main.cn;
                NpgsqlDataReader load_info1 = cmd2.ExecuteReader();
                while (load_info1.Read())
                {
                    //Datos Informe de Movilización
                    im_conductor.Text = load_info1[50].ToString();
                    im_numuero.Text = load_info1[0].ToString();
                    im_solicitante.Text = load_info1[2].ToString();
                    im_paramedico.Text = load_info1[22].ToString();
                    im_ciudad.Text = load_info1[57].ToString();                                              
                    im_actividades.Items.Add(load_info1[4].ToString());
                    im_actividades.Items.Add(load_info1[10].ToString());
                    im_fechaSalida.Text = load_info1[14].ToString();
                    im_horaSalida.Text = load_info1[12].ToString();
                    im_fechaLlegada.Text = load_info1[17].ToString();
                    im_horaLlegada.Text = load_info1[16].ToString();
                    im_fechaLlegadaMed.Text = load_info1[17].ToString();
                    im_horaLlegadaMed.Text = load_info1[15].ToString();
                    im_fechaSalidaMed.Text = load_info1[14].ToString();
                    im_horaSalidaMed.Text = load_info1[13].ToString();
                    im_observaciones.Text = load_info1[23].ToString();
                    im_kmSalida.Text = load_info1[29].ToString();
                    im_kmLlegada.Text = load_info1[30].ToString();

                }
                load_info1.Close();
            }
            //  Cuando moviliza a un paciente pero el destino no esta en la BD
            else if (check_info[11].ToString() == "" && check_info[5].ToString() != "")
            {
                check_info.Close();
                im_actividades.Items.Clear();
                string str4 = "select * from entrada_salida.orden_mov O inner join ";
                str4 = str4 + "entrada_salida.info_solicitud I on O.num = I.num inner join ";
                str4 = str4 + "entrada_salida.autorizacion A on I.num = A.num inner join ";
                str4 = str4 + "entrada_salida.vehiculo V on I.vehiculo = V.cod_inst inner join ";
                str4 = str4 + "entrada_salida.conductor C on I.conductor = C.cedula inner join ";
                str4 = str4 + "entrada_salida.destino_no_bd ND on ND.num_sol = A.num ";
                str4 = str4 + "where O.num = " + Form5.numero_orden + " and I.estado = 'APROBADA'";
                NpgsqlCommand cmd4 = new NpgsqlCommand();
                cmd4.CommandText = str4;
                cmd4.Connection = main.cn;
                NpgsqlDataReader load_info3 = cmd4.ExecuteReader();
                while (load_info3.Read())
                {
                    // Datos Informe de Movilización
                    im_conductor.Text = load_info3[50].ToString();
                    im_numuero.Text = load_info3[0].ToString();
                    im_solicitante.Text = load_info3[2].ToString();
                    im_paramedico.Text = load_info3[22].ToString();
                    im_ciudad.Text = load_info3[58].ToString();
                    im_actividades.Items.Add(load_info3[4].ToString());
                    im_actividades.Items.Add(load_info3[10].ToString());
                    im_fechaSalida.Text = load_info3[14].ToString();
                    im_horaSalida.Text = load_info3[12].ToString();
                    im_fechaLlegada.Text = load_info3[17].ToString();
                    im_horaLlegada.Text = load_info3[16].ToString();
                    im_fechaLlegadaMed.Text = load_info3[17].ToString();
                    im_horaLlegadaMed.Text = load_info3[15].ToString();
                    im_fechaSalidaMed.Text = load_info3[14].ToString();
                    im_horaSalidaMed.Text = load_info3[13].ToString();
                    im_observaciones.Text = load_info3[23].ToString();
                    im_kmSalida.Text = load_info3[29].ToString();
                    im_kmLlegada.Text = load_info3[30].ToString();
                }
                load_info3.Close();
            }
            //  Cuando moviliza un paciente
            else if (check_info[11].ToString() != "")
            {
                check_info.Close();
                im_actividades.Items.Clear();
                string str3 = "select * from entrada_salida.orden_mov O inner join ";
                str3 = str3 + "entrada_salida.info_solicitud I on O.num=I.num inner join ";
                str3 = str3 + "entrada_salida.autorizacion A on I.num = A.num inner join ";
                str3 = str3 + "entrada_salida.vehiculo V on I.vehiculo = V.cod_inst inner join ";
                str3 = str3 + "entrada_salida.conductor C on I.conductor = C.cedula inner join ";
                str3 = str3 + "entrada_salida.destino D on O.destino = D.cod_des ";
                str3 = str3 + "where O.num = " + Form5.numero_orden + " and I.estado = 'APROBADA'";
                NpgsqlCommand cmd3 = new NpgsqlCommand();
                cmd3.CommandText = str3;
                cmd3.Connection = main.cn;
                NpgsqlDataReader load_info2 = cmd3.ExecuteReader();

                while (load_info2.Read())
                {
                    // Datos Informe de Movilización
                    im_conductor.Text = load_info2[50].ToString();
                    im_numuero.Text = load_info2[0].ToString();
                    im_solicitante.Text = load_info2[2].ToString();
                    im_paramedico.Text = load_info2[22].ToString();
                    im_ciudad.Text = load_info2[58].ToString();
                    im_actividades.Items.Add(load_info2[4].ToString());
                    im_actividades.Items.Add(load_info2[10].ToString());
                    im_fechaSalida.Text = load_info2[14].ToString();
                    im_horaSalida.Text = load_info2[12].ToString();
                    im_fechaLlegada.Text = load_info2[17].ToString();
                    im_horaLlegada.Text = load_info2[16].ToString();
                    im_fechaLlegadaMed.Text = load_info2[17].ToString();
                    im_horaLlegadaMed.Text = load_info2[15].ToString();
                    im_fechaSalidaMed.Text = load_info2[14].ToString();
                    im_horaSalidaMed.Text = load_info2[13].ToString();
                    im_observaciones.Text = load_info2[23].ToString();
                    im_kmSalida.Text = load_info2[29].ToString();
                    im_kmLlegada.Text = load_info2[30].ToString();
                }
                load_info2.Close();
            }
        }
    }
}
