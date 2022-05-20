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
    public partial class Form5 : Form
    {
        public static string numero_orden;
       public static NpgsqlConnection cn = new NpgsqlConnection();      
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string str = "Server = 127.0.0.1; Port=5432; Database=unidad_transporte; User Id=postgres; Password=hgsvp;";

            cn.ConnectionString = str;
            cn.Open();
        }
        private void main_insertBtn_Click(object sender, EventArgs e)
        {

        }

        private void main_informBtn_Click(object sender, EventArgs e)
        {

        }
        private void main_autBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
