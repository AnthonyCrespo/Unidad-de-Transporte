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
using System.Configuration;

namespace Unidad_de_Transporte 
{
    public partial class Form1 : Form //MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //----------------- Modificacion codigo Santiago---------------
            //----------------- Cargar el nombre del Ingeniero Responsable----------
            om_firma_LServi_textBox.Text = "EDISON MONTESDEOCA";
            est_firma_TextBox.Text = "EDISON MONTESDEOCA";
            //------------------ Cargar las unidades Administrativas en el comboBOx
            om_unidad_comboBox.Items.Add("CENTRO QUIRÚRGICO");
            om_unidad_comboBox.Items.Add("CENTRO OBSTÉTRICO");
            om_unidad_comboBox.Items.Add("GINECOLOGÍA");
            om_unidad_comboBox.Items.Add("CIRUGÍA");
            om_unidad_comboBox.Items.Add("ENDOSCOPÍA");
            om_unidad_comboBox.Items.Add("MEDICINA INTERNA");
            om_unidad_comboBox.Items.Add("UCI");
            om_unidad_comboBox.Items.Add("UCI (COVID)");
            om_unidad_comboBox.Items.Add("LAVANDERÍA");
            om_unidad_comboBox.Items.Add("REHABILITACIÓN");
            om_unidad_comboBox.Items.Add("MANTENIMIENTO");
            om_unidad_comboBox.Items.Add("PEDIATRÍA");
            om_unidad_comboBox.Items.Add("ODONTOLOGÍA");
            om_unidad_comboBox.Items.Add("EMERGENCIA");
            om_unidad_comboBox.Items.Add("CONSULTA EXTERNA");
            om_unidad_comboBox.Items.Add("RAYOS X");
            om_unidad_comboBox.Items.Add("LABORATORIO");
            om_unidad_comboBox.Items.Add("BODEGA CENTRAL");
            om_unidad_comboBox.Items.Add("TRAUMATOLOGÍA");
            om_unidad_comboBox.Items.Add("ATENCIÓN AL CLIENTE");
            om_unidad_comboBox.Items.Add("ESTADÍSTICA");
            om_unidad_comboBox.Items.Add("BODEGA DE ACTIVOS FIJOS");
            om_unidad_comboBox.Items.Add("ADMINISTRACIÓN FINANCIERA");
            om_unidad_comboBox.Items.Add("GERENCIA");
            om_unidad_comboBox.Items.Add("TALENTO HUMANO");
            om_unidad_comboBox.Items.Add("FARMACIA");
            //------------------Cargar el servicio en el comboBOx
            om_serviciocomboBox.Items.Add("CENTRO QUIRÚRGICO");
            om_serviciocomboBox.Items.Add("CENTRO OBSTÉTRICO");
            om_serviciocomboBox.Items.Add("GINECOLOGÍA");
            om_serviciocomboBox.Items.Add("CIRUGÍA");
            om_serviciocomboBox.Items.Add("ENDOSCOPÍA");
            om_serviciocomboBox.Items.Add("MEDICINA INTERNA");
            om_serviciocomboBox.Items.Add("UCI");
            om_serviciocomboBox.Items.Add("UCI (COVID)");
            om_serviciocomboBox.Items.Add("REHABILITACIÓN");
            om_serviciocomboBox.Items.Add("LAVANDERÍA");
            om_serviciocomboBox.Items.Add("MANTENIMIENTO");
            om_serviciocomboBox.Items.Add("PEDIATRÍA");
            om_serviciocomboBox.Items.Add("ODONTOLOGÍA");
            om_serviciocomboBox.Items.Add("EMERGENCIA");
            om_serviciocomboBox.Items.Add("CONSULTA EXTERNA");
            om_serviciocomboBox.Items.Add("RAYOS X");
            om_serviciocomboBox.Items.Add("LABORATORIO");
            om_serviciocomboBox.Items.Add("BODEGA CENTRAL");
            om_serviciocomboBox.Items.Add("TRAUMATOLOGÍA");
            om_serviciocomboBox.Items.Add("ATENCIÓN AL CLIENTE");
            om_serviciocomboBox.Items.Add("ESTADÍSTICA");
            om_serviciocomboBox.Items.Add("BODEGA DE ACTIVOS FIJOS");
            om_serviciocomboBox.Items.Add("ADMINISTRACION FINANCIERA");
            om_serviciocomboBox.Items.Add("GERENCIA");
            om_serviciocomboBox.Items.Add("TALENTO HUMANO");
            om_serviciocomboBox.Items.Add("FARMACIA");


            //------------------ Autogenerar el numero de orden-------------
            NpgsqlCommand cmd_num_O = new NpgsqlCommand();
            cmd_num_O.CommandText = "select max(num)+1 from entrada_salida.info_solicitud;";
            cmd_num_O.Connection = main.cn;
            NpgsqlDataReader dr_num_O = cmd_num_O.ExecuteReader();
            dr_num_O.Read();
            if (dr_num_O[0] != DBNull.Value)
            {
                om_num_tbox.Text = dr_num_O[0].ToString();
            }
            else
            {
                om_num_tbox.Text = 1.ToString();
            }
            dr_num_O.Close();
            om_num_tbox.Enabled = false;
            //---------------- VISIBILIDAD DEL LABEL Y TEXBOX CUANDO EL HOSPITAL NO ESTA EN LA BD-------
            label39.Visible = false;
            txtBox_Hos_Desti.Visible = false;
            label38.Visible = false;
            txtBox_UnidadM.Visible = false;

            cbo_MovPaciente.Items.Add("SI");
            cbo_MovPaciente.Items.Add("NO");
            //Visibilidad acerca del destino
            label37.Visible = false;
            txBox_Destino.Visible = false;
            //Deshabilitar los campos del paciente
            om_ci_textBox.Enabled = false;
            om_paciente_textBox.Enabled = false;
            om_paciente_textBox.Text = "";
            om_edad_textBox.Enabled = false;
            om_edad_textBox.Text = "";
            om_nac_comboBox.Enabled = false;
            om_nac_comboBox.Text = "";
            om_codNacTextBox.Text = "";
            om_serviciocomboBox.Enabled = false;
            om_serviciocomboBox.Text = "";
            om_cie_comboBox.Enabled = false;
            om_cie_comboBox.Text = "";
            om_traslado_comboBox.Enabled = false;
            om_traslado_comboBox.Text = "";
            om_codDestinoTextBox.Text = "";



            // Llenado de combobox con nacionalidades
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = "select GENTILICIO_NAC from entrada_salida.nacionalidad ORDER BY GENTILICIO_NAC ASC;";
            cmd.Connection = main.cn;
            NpgsqlDataReader nac = cmd.ExecuteReader();
            while (nac.Read())
            {
                om_nac_comboBox.Items.Add(nac[0]);
            }
            nac.Close();

            // Llenado de combobox de destinos a trasladar
            //NpgsqlCommand cmd_tras = new NpgsqlCommand();
            cmd.CommandText = "select nombre from entrada_salida.destino order by nombre ASC;";
            //cmd_tras.Connection = main.cn;
            NpgsqlDataReader tras = cmd.ExecuteReader();
            while (tras.Read())
            {
                om_traslado_comboBox.Items.Add(tras[0]);
            }
            tras.Close();
            //------ Agregar otra opcion----
            om_traslado_comboBox.Items.Add("OTRO");

            // Llenado de combobox de estado de solicitud
            est_solicitudComboBox.Items.Add("APROBADA");
            est_solicitudComboBox.Items.Add("NEGADA");

            // Llenado de combobox de nombres de conductores
            //NpgsqlCommand cmd_conduct = new NpgsqlCommand();
            cmd.CommandText = "select nombre from entrada_salida.conductor order by nombre asc;";
            //cmd_conduct.Connection = main.cn;
            NpgsqlDataReader conduct = cmd.ExecuteReader();
            while (conduct.Read())
            {
                est_conductComboBox.Items.Add(conduct[0]);
            }
            conduct.Close();

            // Llenado de combobox de número de vehiculos
            //NpgsqlCommand cmd_numVehi = new NpgsqlCommand();
            cmd.CommandText = "select num from entrada_salida.vehiculo;";
            //cmd_numVehi.Connection = main.cn;
            NpgsqlDataReader numVehi = cmd.ExecuteReader();
            while (numVehi.Read())
            {
                est_vehiNumComboBox.Items.Add(numVehi[0]);
            }
            numVehi.Close();





            // Cargar combobox de cie y generar

            om_cie_comboBox.Items.AddRange(cie10.cie);
            cbo_diagnostico.Items.AddRange(cie10.cie_description);
            //AutoCompleteStringCollection datacie10 = new AutoCompleteStringCollection();
            //datacie10.AddRange(cie);
            om_cie_comboBox.AutoCompleteCustomSource.AddRange(cie10.cie);
            om_cie_comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            om_cie_comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        private void est_vehiNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cargar placa de vehiculo en textbox cuando se selecciona un número
            string stringSQL = "select placa::text from entrada_salida.vehiculo where num = " + est_vehiNumComboBox.Text;
            NpgsqlCommand cmd_placaVehi = new NpgsqlCommand();
            cmd_placaVehi.CommandText = stringSQL;
            cmd_placaVehi.Connection = main.cn;
            NpgsqlDataReader placaVehi = cmd_placaVehi.ExecuteReader();
            placaVehi.Read();
            est_placaTextBox.Text = placaVehi[0].ToString();
            placaVehi.Close();

            // Cargar clase de vehiculo en textbox cuando se selecciona un número
            NpgsqlCommand cmd_clasVehi = new NpgsqlCommand();
            cmd_clasVehi.CommandText = "select upper(clase::text) from entrada_salida.vehiculo where num = " + est_vehiNumComboBox.Text;
            cmd_clasVehi.Connection = main.cn;
            NpgsqlDataReader clasVehi = cmd_clasVehi.ExecuteReader();
            clasVehi.Read();
            est_vehiClassTextBox.Text = clasVehi[0].ToString();
            clasVehi.Close();

            // Cargar codigo institucional de vehiculo en textbox cuando se selecciona un número
            NpgsqlCommand cmd_codVehi = new NpgsqlCommand();
            cmd_codVehi.CommandText = "select cod_inst from entrada_salida.vehiculo where num = " + est_vehiNumComboBox.Text;
            cmd_codVehi.Connection = main.cn;
            NpgsqlDataReader codVehi = cmd_codVehi.ExecuteReader();
            codVehi.Read();
            est_codVehiTextBox.Text = codVehi[0].ToString();
            codVehi.Close();
        }



        private void om_solicitantetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ' '))
            { e.Handled = true; return; }
        }

        private void om_paciente_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ' '))
            { e.Handled = true; return; }
        }
        private void om_edad_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            { e.Handled = true; }
        }
        private void om_ci_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            { e.Handled = true; }
        }
        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ' '))
            { e.Handled = true; return; }
        }
        private void est_obsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ' '))
            { e.Handled = true; return; }
        }

        private void est_solicitudComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // habilitar controles requeridos solo si la solicitud es aprobada o caso contrario dejarlos vacíos
            if (est_solicitudComboBox.Text == "APROBADA")
            {
                est_vehiNumComboBox.Enabled = true;
                est_conductComboBox.Enabled = true;
                est_ParamTextBox.Enabled = true;
                est_obsTextBox.Enabled = true;
                est_gruardarBtn.Enabled = true;
            }
            else
            {
                est_vehiNumComboBox.Enabled = false;
                est_vehiNumComboBox.Text = "";
                est_codVehiTextBox.Text = "";
                est_conductComboBox.Enabled = false;
                est_conductComboBox.Text = "";
                est_cedConductorTextBox.Text = "";
                est_ParamTextBox.Enabled = false;
                est_ParamTextBox.Text = "";
                est_obsTextBox.Enabled = false;
                est_obsTextBox.Text = "";
                est_vehiClassTextBox.Text = "";
                est_placaTextBox.Text = "";
                est_gruardarBtn.Enabled = true;
            }
        }
        //-----------Condiciones para que no se pueda escribir en los comboxs
        private void om_nac_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void om_traslado_comboBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void est_solicitudComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void est_vehiNumComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void om_unidad_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void om_serviciocomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        //---------------------Guardar los Datos en la bases de datos respectivas-----------------
        private void est_gruardarBtn_Click(object sender, EventArgs e)
        {
            String str1;
            String str2;
            String str3;
            String str4;
            String str5;
            str1 = "insert into entrada_salida.orden_mov values ( ";
            str2 = "insert into entrada_salida.info_solicitud values ( ";
            str3 = "insert into entrada_salida.solicitante_cargo values ( ";
            str4 = "insert into entrada_salida.solicitante_sin_destino values ( ";
            str5 = "insert into entrada_salida.destino_no_BD values ( ";
            if (om_num_tbox.Text == "" || om_solicitantetextBox.Text == "" || om_unidad_comboBox.Text == "" || om_motivo_textBox.Text == "" || om_cargo_textBox.Text == "")
            {
                MessageBox.Show("El número de orden, el solicitante, el cargo, la unidad administrativa o el motivo no pueden estar vacíos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //LLENAMOS EL N ORDER, FECHA, SOLICITANTE, UNIDAD ADMINISTRATIVA Y MOTIVO
                str1 = str1 + om_num_tbox.Text + ", ";
                str1 = str1 + "'" + om_datePicker.Text + "'" + ", ";
                str1 = str1 + "'" + om_solicitantetextBox.Text + "'" + ", ";
                str1 = str1 + "'" + om_unidad_comboBox.Text + "'" + ", ";
                str1 = str1 + "'" + om_motivo_textBox.Text + "'" + ", ";
                //LLENAMOS LA TABLA QUE CONTIENE EL CARGO DE SOLICITANTE
                str3 = str3 + om_num_tbox.Text + ", ";
                str3 = str3 + "'" + om_solicitantetextBox.Text + "'" + ", ";
                str3 = str3 + "'" + om_cargo_textBox.Text + "');";

                if (cbo_MovPaciente.Text == "NO")
                {
                    if (txBox_Destino.Text == "")
                    {
                        MessageBox.Show("El destino no puede estar vacío",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //LLENAMOS LA TABLA DE SOLICITANTE SIN DESTINO
                        str4 = str4 + om_num_tbox.Text + ", ";
                        str4 = str4 + "'" + om_solicitantetextBox.Text + "'" + ", ";
                        str4 = str4 + "'" + txBox_Destino.Text + "'" + ");";
                        //LLENAMOS LA TABLA DE ORDEN MOV
                        str1 = str1 + "null" + ", ";
                        str1 = str1 + "null" + ", ";
                        str1 = str1 + "null" + ", ";
                        str1 = str1 + "null" + ", ";
                        str1 = str1 + "null" + ", ";
                        str1 = str1 + "null" + ", ";
                        str1 = str1 + "null" + ", ";
                        str1 = str1 + "'" + om_horaSalidaBase.Text + "'" + ", ";
                        str1 = str1 + "'" + om_horaSalidaDestino.Text + "'" + ", ";
                        str1 = str1 + "'" + om_fechaSalida.Text + "'" + ", ";
                        str1 = str1 + "'" + om_horaLlegadaDestino.Text + "'" + ", ";
                        str1 = str1 + "'" + om_horaLlegadaBase.Text + "'" + ", ";
                        str1 = str1 + "'" + om_fechaEntrada.Text + "'" + ");";

                        //LLENAMOS TABLA INFO_SOLICITUD
                        if (est_solicitudComboBox.Text == "NEGADA")
                        {
                            str2 = str2 + om_num_tbox.Text + ", ";
                            str2 = str2 + "'" + est_solicitudComboBox.Text + "'" + ", ";
                            str2 = str2 + "null" + ", ";
                            str2 = str2 + "null" + ", ";
                            str2 = str2 + "null" + ", ";
                            if (est_obsTextBox.Text == "")
                            {
                                str2 = str2 + "null" + ", ";
                            }
                            else
                            {
                                str2 = str2 + "'" + est_obsTextBox.Text + "'" + ", ";
                            }
                            str2 = str2 + "'" + est_datePicker.Text + "'" + ");";
                            try
                            {
                                NpgsqlCommand cmd1 = new NpgsqlCommand();
                                cmd1.CommandText = str1;
                                cmd1.Connection = main.cn;
                                cmd1.ExecuteNonQuery();

                                NpgsqlCommand cmd2 = new NpgsqlCommand();
                                cmd2.CommandText = str2;
                                cmd2.Connection = main.cn;
                                cmd2.ExecuteNonQuery();

                                NpgsqlCommand cmd3 = new NpgsqlCommand();
                                cmd3.CommandText = str3;
                                cmd3.Connection = main.cn;
                                cmd3.ExecuteNonQuery();

                                NpgsqlCommand cmd4 = new NpgsqlCommand();
                                cmd4.CommandText = str4;
                                cmd4.Connection = main.cn;
                                cmd4.ExecuteNonQuery();

                                MessageBox.Show("Registro Insertado.",
                                    "Registro insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                MessageBox.Show("Ya existe una Orden de Movilización guardada con el número que se intenta insertar. Comprobar que el número ingresado es el correcto.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        //SOLICITUD APROVADA
                        else
                        {
                            if (est_vehiNumComboBox.Text == "" || est_conductComboBox.Text == "")
                            {
                                MessageBox.Show("Por favor seleccione el número de vehículo asignado y/o a su conductor.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                //LLENAMOS TABLA INFO SOLICITUD
                                str2 = str2 + om_num_tbox.Text + ", ";
                                str2 = str2 + "'" + est_solicitudComboBox.Text + "'" + ", ";
                                str2 = str2 + est_codVehiTextBox.Text + ", ";
                                str2 = str2 + "'" + est_cedConductorTextBox.Text + "'" + ", ";

                                if (est_ParamTextBox.Text == "") { str2 = str2 + "null" + ", "; }
                                else { str2 = str2 + "'" + est_ParamTextBox.Text + "'" + ", "; }
                                if (est_obsTextBox.Text == "") { str2 = str2 + "null" + ", "; }
                                else { str2 = str2 + "'" + est_obsTextBox.Text + "'" + ", "; }

                                str2 = str2 + "'" + est_datePicker.Text + "'" + ");";

                                try
                                {
                                    NpgsqlCommand cmd1 = new NpgsqlCommand();
                                    cmd1.CommandText = str1;
                                    cmd1.Connection = main.cn;
                                    cmd1.ExecuteNonQuery();
                                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                                    cmd2.CommandText = str2;
                                    cmd2.Connection = main.cn;
                                    cmd2.ExecuteNonQuery();

                                    NpgsqlCommand cmd3 = new NpgsqlCommand();
                                    cmd3.CommandText = str3;
                                    cmd3.Connection = main.cn;
                                    cmd3.ExecuteNonQuery();

                                    NpgsqlCommand cmd4 = new NpgsqlCommand();
                                    cmd4.CommandText = str4;
                                    cmd4.Connection = main.cn;
                                    cmd4.ExecuteNonQuery();

                                    MessageBox.Show("Registro Insertado.",
                                    "Registro insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    MessageBox.Show("Ya existe una Orden de Movilización guardada con el número que se intenta insertar. Comprobar que el número ingresado es el correcto.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }


                }
                //CUANDO SI MOVILIZA A UN PACIENTE
                else
                {
                    if (om_traslado_comboBox.Text != "OTRO")
                    {
                        if (om_ci_textBox.Text.Length == 10 &&
                        (om_paciente_textBox.Text == "" || om_edad_textBox.Text == "" || om_serviciocomboBox.Text == "" ||
                        om_cie_comboBox.Text == "" || om_codNacTextBox.Text == "" ||
                        om_diag_textBox.Text == ""))
                        {
                            MessageBox.Show("Los datos del paciente trasladado no pueden quedar vacíos si se ingresa su número de cédula. Compruebe que el cie10 es válido.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //LLENANDO LA TABLA DE ORDEN MOV
                            str1 = str1 + "'" + om_paciente_textBox.Text + "'" + ", ";
                            str1 = str1 + om_edad_textBox.Text + ", ";
                            str1 = str1 + "'" + om_codNacTextBox.Text + "'" + ", ";
                            str1 = str1 + "'" + om_ci_textBox.Text + "'" + ", ";
                            str1 = str1 + "'" + om_cie_comboBox.Text + "'" + ", ";
                            str1 = str1 + "'" + om_serviciocomboBox.Text + "'" + ", ";
                            if (om_codDestinoTextBox.Text == "") { str1 = str1 + "null" + ", "; }
                            else { str1 = str1 + om_codDestinoTextBox.Text + ", "; }
                            str1 = str1 + "'" + om_horaSalidaBase.Text + "'" + ", ";
                            str1 = str1 + "'" + om_horaSalidaDestino.Text + "'" + ", ";
                            str1 = str1 + "'" + om_fechaSalida.Text + "'" + ", ";
                            str1 = str1 + "'" + om_horaLlegadaDestino.Text + "'" + ", ";
                            str1 = str1 + "'" + om_horaLlegadaBase.Text + "'" + ", ";
                            str1 = str1 + "'" + om_fechaEntrada.Text + "'" + ");";
                            //SOLICITUD NEGADA
                            if (est_solicitudComboBox.Text == "NEGADA")
                            {
                                //LLENANDO TABLA DE INFO_SOLICITUD
                                str2 = str2 + om_num_tbox.Text + ", ";
                                str2 = str2 + "'" + est_solicitudComboBox.Text + "'" + ", ";
                                str2 = str2 + "null" + ", ";
                                str2 = str2 + "null" + ", ";
                                str2 = str2 + "null" + ", ";
                                if (est_obsTextBox.Text == "")
                                {
                                    str2 = str2 + "null" + ", ";
                                }
                                else
                                {
                                    str2 = str2 + "'" + est_obsTextBox.Text + "'" + ", ";
                                }
                                str2 = str2 + "'" + est_datePicker.Text + "'" + ");";
                                try
                                {
                                    NpgsqlCommand cmd1 = new NpgsqlCommand();
                                    cmd1.CommandText = str1;
                                    cmd1.Connection = main.cn;
                                    cmd1.ExecuteNonQuery();

                                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                                    cmd2.CommandText = str2;
                                    cmd2.Connection = main.cn;
                                    cmd2.ExecuteNonQuery();

                                    NpgsqlCommand cmd3 = new NpgsqlCommand();
                                    cmd3.CommandText = str3;
                                    cmd3.Connection = main.cn;
                                    cmd3.ExecuteNonQuery();

                                    MessageBox.Show("Registro Insertado.",
                                        "Registro insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    MessageBox.Show("Ya existe una Orden de Movilización guardada con el número que se intenta insertar. Comprobar que el número ingresado es el correcto.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            // ----------------------ESTADO DE SOLICITUD APROVADA-------------------
                            else
                            {
                                if (est_vehiNumComboBox.Text == "" || est_conductComboBox.Text == "")
                                {
                                    MessageBox.Show("Por favor seleccione el número de vehículo asignado y/o a su conductor.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    str2 = str2 + om_num_tbox.Text + ", ";
                                    str2 = str2 + "'" + est_solicitudComboBox.Text + "'" + ", ";
                                    str2 = str2 + est_codVehiTextBox.Text + ", ";
                                    str2 = str2 + "'" + est_cedConductorTextBox.Text + "'" + ", ";

                                    if (est_ParamTextBox.Text == "") { str2 = str2 + "null" + ", "; }
                                    else { str2 = str2 + "'" + est_ParamTextBox.Text + "'" + ", "; }
                                    if (est_obsTextBox.Text == "") { str2 = str2 + "null" + ", "; }
                                    else { str2 = str2 + "'" + est_obsTextBox.Text + "'" + ", "; }

                                    str2 = str2 + "'" + est_datePicker.Text + "'" + ");";

                                    try
                                    {
                                        NpgsqlCommand cmd1 = new NpgsqlCommand();
                                        cmd1.CommandText = str1;
                                        cmd1.Connection = main.cn;
                                        cmd1.ExecuteNonQuery();
                                        NpgsqlCommand cmd2 = new NpgsqlCommand();
                                        cmd2.CommandText = str2;
                                        cmd2.Connection = main.cn;
                                        cmd2.ExecuteNonQuery();

                                        NpgsqlCommand cmd3 = new NpgsqlCommand();
                                        cmd3.CommandText = str3;
                                        cmd3.Connection = main.cn;
                                        cmd3.ExecuteNonQuery();

                                        MessageBox.Show("Registro Insertado.",
                                        "Registro insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                        MessageBox.Show("Ya existe una Orden de Movilización guardada con el número que se intenta insertar. Comprobar que el número ingresado es el correcto.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }


                    }
                    //EL DESTINO NO ESTA EN LA BASE DE DATOS
                    else
                    {
                        if (txtBox_UnidadM.Text == "" || txtBox_Hos_Desti.Text == "")
                        {
                            MessageBox.Show("La unidad médica o el destino no pueden estar vacío",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //LENANDO LA TABLA DE DESTINOS NO EN LA BD
                            str5 = str5 + om_num_tbox.Text + ", ";
                            str5 = str5 + "'" + om_solicitantetextBox.Text + "'" + ", ";
                            str5 = str5 + "'" + txtBox_UnidadM.Text + "'" + ", ";
                            str5 = str5 + "'" + txtBox_Hos_Desti.Text + "'" + ");";
                            //LLENANDO LA TABLA DE ORDEN MOV
                            str1 = str1 + "'" + om_paciente_textBox.Text + "'" + ", ";
                            str1 = str1 + om_edad_textBox.Text + ", ";
                            str1 = str1 + "'" + om_codNacTextBox.Text + "'" + ", ";
                            str1 = str1 + "'" + om_ci_textBox.Text + "'" + ", ";
                            str1 = str1 + "'" + om_cie_comboBox.Text + "'" + ", ";
                            str1 = str1 + "'" + om_serviciocomboBox.Text + "'" + ", ";
                            if (om_codDestinoTextBox.Text == "") { str1 = str1 + "null" + ", "; }
                            else { str1 = str1 + om_codDestinoTextBox.Text + ", "; }
                            str1 = str1 + "'" + om_horaSalidaBase.Text + "'" + ", ";
                            str1 = str1 + "'" + om_horaSalidaDestino.Text + "'" + ", ";
                            str1 = str1 + "'" + om_fechaSalida.Text + "'" + ", ";
                            str1 = str1 + "'" + om_horaLlegadaDestino.Text + "'" + ", ";
                            str1 = str1 + "'" + om_horaLlegadaBase.Text + "'" + ", ";
                            str1 = str1 + "'" + om_fechaEntrada.Text + "'" + ");";
                            //SOLICITUD NEGADA
                            if (est_solicitudComboBox.Text == "NEGADA")
                            {
                                //LLENANDO TABLA ORDEN MOV
                                str2 = str2 + om_num_tbox.Text + ", ";
                                str2 = str2 + "'" + est_solicitudComboBox.Text + "'" + ", ";
                                str2 = str2 + "null" + ", ";
                                str2 = str2 + "null" + ", ";
                                str2 = str2 + "null" + ", ";
                                if (est_obsTextBox.Text == "")
                                {
                                    str2 = str2 + "null" + ", ";
                                }
                                else
                                {
                                    str2 = str2 + "'" + est_obsTextBox.Text + "'" + ", ";
                                }
                                str2 = str2 + "'" + est_datePicker.Text + "'" + ");";
                                try
                                {
                                    NpgsqlCommand cmd1 = new NpgsqlCommand();
                                    cmd1.CommandText = str1;
                                    cmd1.Connection = main.cn;
                                    cmd1.ExecuteNonQuery();

                                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                                    cmd2.CommandText = str2;
                                    cmd2.Connection = main.cn;
                                    cmd2.ExecuteNonQuery();

                                    NpgsqlCommand cmd3 = new NpgsqlCommand();
                                    cmd3.CommandText = str3;
                                    cmd3.Connection = main.cn;
                                    cmd3.ExecuteNonQuery();

                                    NpgsqlCommand cmd5 = new NpgsqlCommand();
                                    cmd5.CommandText = str5;
                                    cmd5.Connection = main.cn;
                                    cmd5.ExecuteNonQuery();

                                    MessageBox.Show("Registro Insertado.",
                                        "Registro insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    MessageBox.Show("Ya existe una Orden de Movilización guardada con el número que se intenta insertar. Comprobar que el número ingresado es el correcto.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            // ----------------------ESTADO DE SOLICITUD APROVADA-------------------
                            else
                            {
                                if (est_vehiNumComboBox.Text == "" || est_conductComboBox.Text == "")
                                {
                                    MessageBox.Show("Por favor seleccione el número de vehículo asignado y/o a su conductor.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    str2 = str2 + om_num_tbox.Text + ", ";
                                    str2 = str2 + "'" + est_solicitudComboBox.Text + "'" + ", ";
                                    str2 = str2 + est_codVehiTextBox.Text + ", ";
                                    str2 = str2 + "'" + est_cedConductorTextBox.Text + "'" + ", ";

                                    if (est_ParamTextBox.Text == "") { str2 = str2 + "null" + ", "; }
                                    else { str2 = str2 + "'" + est_ParamTextBox.Text + "'" + ", "; }
                                    if (est_obsTextBox.Text == "") { str2 = str2 + "null" + ", "; }
                                    else { str2 = str2 + "'" + est_obsTextBox.Text + "'" + ", "; }

                                    str2 = str2 + "'" + est_datePicker.Text + "'" + ");";

                                    try
                                    {
                                        NpgsqlCommand cmd1 = new NpgsqlCommand();
                                        cmd1.CommandText = str1;
                                        cmd1.Connection = main.cn;
                                        cmd1.ExecuteNonQuery();
                                        NpgsqlCommand cmd2 = new NpgsqlCommand();
                                        cmd2.CommandText = str2;
                                        cmd2.Connection = main.cn;
                                        cmd2.ExecuteNonQuery();

                                        NpgsqlCommand cmd3 = new NpgsqlCommand();
                                        cmd3.CommandText = str3;
                                        cmd3.Connection = main.cn;
                                        cmd3.ExecuteNonQuery();

                                        NpgsqlCommand cmd5 = new NpgsqlCommand();
                                        cmd5.CommandText = str5;
                                        cmd5.Connection = main.cn;
                                        cmd5.ExecuteNonQuery();

                                        MessageBox.Show("Registro Insertado.",
                                        "Registro insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                        MessageBox.Show("Ya existe una Orden de Movilización guardada con el número que se intenta insertar. Comprobar que el número ingresado es el correcto.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void om_cie_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void om_cie_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_diagnostico.SelectedIndex = om_cie_comboBox.SelectedIndex;
            om_diag_textBox.Text = cbo_diagnostico.Text;
        }

        private void om_traslado_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (om_traslado_comboBox.Text != "OTRO")
            {
                NpgsqlCommand cmd_ccodtras = new NpgsqlCommand();
                cmd_ccodtras.CommandText = "select cod_des from entrada_salida.destino where nombre = " + "'" + om_traslado_comboBox.Text + "';";
                cmd_ccodtras.Connection = main.cn;
                NpgsqlDataReader ccodtras = cmd_ccodtras.ExecuteReader();
                ccodtras.Read();
                om_codDestinoTextBox.Text = ccodtras[0].ToString();
                ccodtras.Close();
                //Visibilidad
                label39.Visible = false;
                txtBox_Hos_Desti.Visible = false;
                label38.Visible = false;
                txtBox_UnidadM.Visible = false;

            }
            else
            {
                label39.Visible = true;
                txtBox_Hos_Desti.Visible = true;
                label38.Visible = true;
                txtBox_UnidadM.Visible = true;
                om_codDestinoTextBox.Text = "";

            }

        }

        private void est_conductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlCommand cmd_cedCondu = new NpgsqlCommand();
            cmd_cedCondu.CommandText = "select cedula from entrada_salida.conductor where nombre = " + "'" + est_conductComboBox.Text + "';";
            cmd_cedCondu.Connection = main.cn;
            NpgsqlDataReader cedCondu = cmd_cedCondu.ExecuteReader();
            cedCondu.Read();
            est_cedConductorTextBox.Text = cedCondu[0].ToString();
            cedCondu.Close();
        }

        private void om_nac_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlCommand cmd_codNac = new NpgsqlCommand();
            cmd_codNac.CommandText = "select ISO_NAC from entrada_salida.nacionalidad where GENTILICIO_NAC = " + "'" + om_nac_comboBox.Text + "';";
            cmd_codNac.Connection = main.cn;
            NpgsqlDataReader codNac = cmd_codNac.ExecuteReader();
            codNac.Read();
            om_codNacTextBox.Text = codNac[0].ToString();
            codNac.Close();
        }
        private void om_ci_textBox_TextChanged(object sender, EventArgs e)
        {
            if (om_ci_textBox.Text.Length == 10)
            {
                om_paciente_textBox.Enabled = true;
                om_edad_textBox.Enabled = true;
                om_nac_comboBox.Enabled = true;
                om_serviciocomboBox.Enabled = true;
                om_cie_comboBox.Enabled = true;
                om_traslado_comboBox.Enabled = true;
            }
            else
            {
                om_paciente_textBox.Enabled = false;
                om_paciente_textBox.Text = "";
                om_edad_textBox.Enabled = false;
                om_edad_textBox.Text = "";
                om_nac_comboBox.Enabled = false;
                om_nac_comboBox.Text = "";
                om_codNacTextBox.Text = "";
                om_serviciocomboBox.Enabled = false;
                om_serviciocomboBox.Text = "";
                om_cie_comboBox.Enabled = false;
                om_cie_comboBox.Text = "";
                om_traslado_comboBox.Enabled = false;
                om_traslado_comboBox.Text = "";
                om_codDestinoTextBox.Text = "";
            }
        }
        // --------------------------   Modificacion Destino by Santiago ------------------------- 
        private void cbo_MovPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_MovPaciente.Text == "NO")
            {
                //hacer visible para ingresar el destino
                label37.Visible = true;
                txBox_Destino.Visible = true;
                //Deshabilitar los campos del paciente
                om_ci_textBox.Enabled = false;
                om_ci_textBox.Text = "";
                om_paciente_textBox.Enabled = false;
                om_paciente_textBox.Text = "";
                om_edad_textBox.Enabled = false;
                om_edad_textBox.Text = "";
                om_nac_comboBox.Enabled = false;
                om_nac_comboBox.Text = "";
                om_codNacTextBox.Text = "";
                om_serviciocomboBox.Enabled = false;
                om_serviciocomboBox.Text = "";
                om_cie_comboBox.Enabled = false;
                om_cie_comboBox.Text = "";
                om_diag_textBox.Text = "";
                om_traslado_comboBox.Enabled = false;
                om_traslado_comboBox.Text = "";
                om_codDestinoTextBox.Text = "";
                label39.Visible = false;
                txtBox_Hos_Desti.Visible = false;
                txtBox_Hos_Desti.Text = "";
                label38.Visible = false;
                txtBox_UnidadM.Visible = false;
                txtBox_UnidadM.Text = "";

            }
            else
            {
                label37.Visible = false;
                txBox_Destino.Visible = false;
                om_ci_textBox.Enabled = true;

                //Mensaje para que se coloque primero la CI
                MessageBox.Show("En la sección 2 por favor primero ingrese el número de cédula",
                                "Sección 2", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
        }
        //Propiedad para que no se pueda escribir en los combobox y en las cajas de texto
        private void cbo_MovPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txBox_Destino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ' '))
            { e.Handled = true; return; }
        }
        //LLENAR EL NOMBRE DEL SOLICITANTE COMO FIRMA
        private void om_solicitantetextBox_TextChanged(object sender, EventArgs e)
        {
            om_firma_solicitante_textBox.Text = om_solicitantetextBox.Text.ToString();
        }
        //--------- Condiciones para no poder escribir en las cajas de texto
        private void om_firma_solicitante_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void om_firma_LServi_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void est_firma_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
