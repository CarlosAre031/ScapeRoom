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
    public partial class HistoriaInicio : Form
    {
        private int indiceImagen = 1;

        public HistoriaInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parte1.Visible = false;
            Parte2.Visible = false;
            Parte3.Visible = false;
            Parte4.Visible = false;
            Parte5.Visible = false;
            if (indiceImagen < 6)
            {
                // Actualiza la imagen en el PictureBox según el índice actual
                switch (indiceImagen)
                    {
                    case 0:
                        Parte2.Visible = true;
                        break;
                    case 1:
                        Parte1.Visible = true;
                        break;
                    case 2:
                        Parte3.Visible = true;
                        break;
                    case 3:
                        Parte4.Visible = true;
                        break;
                    case 4:
                        Parte5.Visible = true;
                        break;
                }

    // Incrementa el contador para mostrar la siguiente imagen en el próximo clic
                    indiceImagen++;

                    if (indiceImagen >= 6)
                    {
                    // Cuando se muestra la última imagen, oculta el botón
                    this.Hide();
                    imgMesa scape1 = new imgMesa();
                    scape1.ShowDialog();
                }
}
        }
    }
    }

