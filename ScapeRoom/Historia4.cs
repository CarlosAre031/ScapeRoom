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
    public partial class Historia4 : Form
    {
        private int indiceImagen = 1;
        public Historia4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parte1.Visible = false;

            if (indiceImagen < 2)
            {
                // Actualiza la imagen en el PictureBox según el índice actual
                switch (indiceImagen)
                {
                    case 1:
                        Parte1.Visible = true;
                        break;

                }

                // Incrementa el contador para mostrar la siguiente imagen en el próximo clic
                indiceImagen++;

                if (indiceImagen >= 2)
                {
                    // Cuando se muestra la última imagen, oculta el botón
                    this.Hide();
                    Menu menu4 = new Menu();
                    menu4.ShowDialog();
                }
            }
        }

        private void Parte1_Click(object sender, EventArgs e)
        {

        }
    }
}
