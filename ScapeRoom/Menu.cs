using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScapeRoom
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HistoriaInicio Historia = new HistoriaInicio();
            Historia.ShowDialog();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Instrucciones instrucciones = new Instrucciones();
            instrucciones.ShowDialog();
        }
    }
}
