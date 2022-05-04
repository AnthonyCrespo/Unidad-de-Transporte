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

namespace Unidad_de_Transporte 
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
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
                    // Datos Hoja de Ruta
                    hr_lugar.Text = "IBARRA";
                    hr_num.Text = load_info1[0].ToString();
                    hr_datePicker.Text = load_info1[24].ToString();
                    hr_solicitante.Text = load_info1[2].ToString();
                    hr_unidad.Text = load_info1[3].ToString();
                    hr_motivo.Text = load_info1[4].ToString();
                    hr_conductor.Text = load_info1[50].ToString();
                    hr_vehiculo.Text = load_info1[42].ToString();
                    hr_numVehi.Text = load_info1[38].ToString();
                    hr_marcaVehi.Text = load_info1[40].ToString();
                    hr_placaVehi.Text = load_info1[41].ToString();
                    hr_observaciones.Text = load_info1[23].ToString();
                    hr_lugarSalida1.Text = "IBARRA (BASE)";
                    hr_fechaSalida1.Text = load_info1[14].ToString();
                    hr_horaSalida1.Text = load_info1[12].ToString();
                    hr_kmSalida1.Text = load_info1[29].ToString();
                    hr_lugarLlegada1.Text = load_info1[57].ToString(); //Ciudad destino
                    hr_fechaLlegada1.Text = load_info1[17].ToString();
                    hr_horaLlegada1.Text = load_info1[15].ToString();
                    hr_lugarSalida2.Text = load_info1[57].ToString(); //Ciudad destino
                    hr_fechaSalida2.Text = load_info1[14].ToString();
                    hr_horaSalida2.Text = load_info1[13].ToString();
                    hr_lugarLlegada2.Text = "IBARRA (BASE)";
                    hr_fechaLlegada2.Text = load_info1[17].ToString();
                    hr_horaLlegada2.Text = load_info1[16].ToString();
                    hr_kmLlegada2.Text = load_info1[30].ToString();

                }
                load_info1.Close();
            }
            //  Cuando moviliza a un paciente pero el destino no esta en la BD
            else if (check_info[11].ToString() == "" && check_info[5].ToString() != "")
            {
                check_info.Close();
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
                    // Datos Hoja de Ruta
                    hr_lugar.Text = "IBARRA";
                    hr_num.Text = load_info3[0].ToString();
                    hr_datePicker.Text = load_info3[24].ToString();
                    hr_solicitante.Text = load_info3[2].ToString();
                    hr_unidad.Text = load_info3[3].ToString();
                    hr_motivo.Text = load_info3[4].ToString();
                    hr_conductor.Text = load_info3[50].ToString();
                    hr_vehiculo.Text = load_info3[42].ToString();
                    hr_numVehi.Text = load_info3[38].ToString();
                    hr_marcaVehi.Text = load_info3[40].ToString();
                    hr_placaVehi.Text = load_info3[41].ToString();
                    hr_observaciones.Text = load_info3[23].ToString();
                    hr_lugarSalida1.Text = "IBARRA (BASE)";
                    hr_fechaSalida1.Text = load_info3[14].ToString();
                    hr_horaSalida1.Text = load_info3[12].ToString();
                    hr_kmSalida1.Text = load_info3[29].ToString();
                    hr_lugarLlegada1.Text = load_info3[58].ToString(); //Ciudad destino
                    hr_fechaLlegada1.Text = load_info3[17].ToString();
                    hr_horaLlegada1.Text = load_info3[15].ToString();
                    hr_lugarSalida2.Text = load_info3[58].ToString(); //Ciudad destino
                    hr_fechaSalida2.Text = load_info3[14].ToString();
                    hr_horaSalida2.Text = load_info3[13].ToString();
                    hr_lugarLlegada2.Text = "IBARRA (BASE)";
                    hr_fechaLlegada2.Text = load_info3[17].ToString();
                    hr_horaLlegada2.Text = load_info3[16].ToString();
                    hr_kmLlegada2.Text = load_info3[30].ToString();
                }
                load_info3.Close();
            }
            //  Cuando moviliza un paciente y el destino esta en la base de datos
            else if (check_info[11].ToString() != "")
            {
                check_info.Close();
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
                    // Datos Hoja de Ruta
                    hr_lugar.Text = "IBARRA";
                    hr_num.Text = load_info2[0].ToString();
                    hr_datePicker.Text = load_info2[24].ToString();
                    hr_solicitante.Text = load_info2[2].ToString();
                    hr_unidad.Text = load_info2[3].ToString();
                    hr_motivo.Text = load_info2[4].ToString();
                    hr_conductor.Text = load_info2[50].ToString();
                    hr_vehiculo.Text = load_info2[42].ToString();
                    hr_numVehi.Text = load_info2[38].ToString();
                    hr_marcaVehi.Text = load_info2[40].ToString();
                    hr_placaVehi.Text = load_info2[41].ToString();
                    hr_observaciones.Text = load_info2[23].ToString();
                    hr_lugarSalida1.Text = "IBARRA (BASE)";
                    hr_fechaSalida1.Text = load_info2[14].ToString();
                    hr_horaSalida1.Text = load_info2[12].ToString();
                    hr_kmSalida1.Text = load_info2[29].ToString();
                    hr_lugarLlegada1.Text = load_info2[58].ToString();
                    hr_fechaLlegada1.Text = load_info2[17].ToString();
                    hr_horaLlegada1.Text = load_info2[15].ToString();
                    //hr_kmLlegada1.Text = "";
                    hr_lugarSalida2.Text = load_info2[58].ToString();
                    hr_fechaSalida2.Text = load_info2[14].ToString();
                    hr_horaSalida2.Text = load_info2[13].ToString();
                    //hr_kmSalida2.Text = "";
                    hr_lugarLlegada2.Text = "IBARRA (BASE)";
                    hr_fechaLlegada2.Text = load_info2[17].ToString();
                    hr_horaLlegada2.Text = load_info2[16].ToString();
                    hr_kmLlegada2.Text = load_info2[30].ToString();
                }
                load_info2.Close();
            }

        }
    }
}
