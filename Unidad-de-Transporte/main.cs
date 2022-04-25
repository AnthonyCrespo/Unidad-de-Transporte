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
    public partial class main : Form
    {
        public static NpgsqlConnection cn = new NpgsqlConnection();
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            string str = "Server = 127.0.0.1;Port = 5432; Database=unidad_transporte; User Id = postgres; Password = 1234;";
            cn.ConnectionString = str;
            cn.Open();

            MaximizeBox = false;
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            Funciones.agregar_formulario(new inspeccion_ambulancia(), "Inspección de Ambulancia");
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            Funciones.agregar_formulario(new reporte(), "Reporte");
        }

        private void main_insertBtn_Click(object sender, EventArgs e)
        {
            Funciones.agregar_formulario(new Form1(), "Orden de movilización");
        }

        private void main_autBtn_Click(object sender, EventArgs e)
        {
            Funciones.agregar_formulario(new Form2(), "Autorización de Salida");
        }

        private void main_informBtn_Click(object sender, EventArgs e)
        {
            Funciones.agregar_formulario(new Form4(), "Informes y Hojas de Ruta");
        }
    }
}
