using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaDeNegocio;

namespace frmAlumno
{
    public partial class Form2 : Form
    {
        ClsAlumno Al = new ClsAlumno();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = Al.ListadoAlumnos();
            dataGridView1.DataSource = dt;
        }

       
    }
}
