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
    public partial class Form2 : Form
    {
        private int imgMAdelanteX = 411;
        private int imgMAdelanteY = 389;
        private int imgMAtrasX = 411;
        private int imgMAtrasY = 389;
        private int imgMIzquierdaX = 411;
        private int imgMIzquierdaY = 389;
        private int imgMderechaX = 411;
        private int imgMderechaY = 389;


        private TimeSpan tiempoRestante;
        private Timer temporizador = new Timer();

        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            imgbombillo.Visible = false;
            imgBombillo2.Visible = false;
            imgMiniCF.Visible = false;
            //------------------------------------------------
            temporizador.Interval = 1000; // Intervalo en milisegundos (1 segundo)
            temporizador.Tick += Temporizador_Tick;
            tiempoRestante = new TimeSpan(0, 5, 0); // 3 minutos
            lblTemporizador.Text = "Timer: 00:00"; // Inicializar el label del temporizador
            lblTemporizador.Visible = true;
            temporizador.Start(); // Iniciar el temporiza


        }

        private void Room2_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int velocidadMovimiento = 5;

            // Límites de movimiento
            int limiteXMin = 130;
            int limiteXMax = 510;
            int limiteYMin = 130;
            int limiteYMax = 480;

            // Ocultar todas las imágenes


            // Actualizar coordenadas según la tecla presionada
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (imgMIzquierdaX > limiteXMin)
                    {
                        imgMIzquierdaX -= velocidadMovimiento;
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;

                    }
                    imgMAdelante.Visible = false;
                    imgMAtras.Visible = false;
                    imgMderecha.Visible = false;
                    imgMIzquierda.Visible = true;
                    break;
                case Keys.Right:
                    if (imgMderechaX < limiteXMax)
                    {
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        imgMIzquierdaX += velocidadMovimiento;
                    }
                    imgMAdelante.Visible = false;
                    imgMAtras.Visible = false;
                    imgMIzquierda.Visible = false;
                    imgMderecha.Visible = true;
                    break;
                case Keys.Up:
                    if (imgMAtrasY > limiteYMin)
                    {
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        imgMAdelanteY -= velocidadMovimiento;
                    }
                    imgMAdelante.Visible = false;
                    imgMIzquierda.Visible = false;
                    imgMderecha.Visible = false;
                    imgMAtras.Visible = true;
                    break;
                case Keys.Down:
                    if (imgMAdelanteY < limiteYMax)
                    {
                        imgMAdelanteY += velocidadMovimiento;
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                    }
                    imgMAtras.Visible = false;
                    imgMIzquierda.Visible = false;
                    imgMderecha.Visible = false;
                    imgMAdelante.Visible = true;
                    break;
            }
            // Aplicar las nuevas coordenadas a las imágenes
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble1.Bounds) ||
               imgMAtras.Bounds.IntersectsWith(imgMueble1.Bounds) ||
               imgMIzquierda.Bounds.IntersectsWith(imgMueble1.Bounds) ||
               imgMderecha.Bounds.IntersectsWith(imgMueble1.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble2.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble2.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble2.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble2.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble3.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble3.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble3.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble3.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble4.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble4.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble4.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble4.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble6.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble6.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble6.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble6.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble7.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble7.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble7.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble7.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble5.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble5.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble5.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble5.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);

            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble4.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble4.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble4.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble4.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble8.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble8.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble8.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble8.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble9.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble9.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble9.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble9.Bounds))
            {
                // Deshacer el movimiento que causó la colisión
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        imgMIzquierdaX += velocidadMovimiento;
                        imgMderechaX += velocidadMovimiento;
                        imgMAtrasX += velocidadMovimiento;
                        imgMAdelanteX += velocidadMovimiento;
                        break;
                    case Keys.Right:
                        imgMderechaX -= velocidadMovimiento;
                        imgMAtrasX -= velocidadMovimiento;
                        imgMAdelanteX -= velocidadMovimiento;
                        imgMIzquierdaX -= velocidadMovimiento;
                        break;
                    case Keys.Up:
                        imgMAtrasY += velocidadMovimiento;
                        imgMIzquierdaY += velocidadMovimiento;
                        imgMderechaY += velocidadMovimiento;
                        imgMAdelanteY += velocidadMovimiento;
                        break;
                    case Keys.Down:
                        imgMAdelanteY -= velocidadMovimiento;
                        imgMAtrasY -= velocidadMovimiento;
                        imgMIzquierdaY -= velocidadMovimiento;
                        imgMderechaY -= velocidadMovimiento;
                        break;
                }
            }

            // Luego de verificar la colisión y, si es necesario, deshacer el movimiento,
            // aplicamos las nuevas coordenadas a las imágenes.
            imgMAdelante.Location = new System.Drawing.Point(imgMAdelanteX, imgMAdelanteY);
            imgMAtras.Location = new System.Drawing.Point(imgMAtrasX, imgMAtrasY);
            imgMIzquierda.Location = new System.Drawing.Point(imgMIzquierdaX, imgMIzquierdaY);
            imgMderecha.Location = new System.Drawing.Point(imgMderechaX, imgMderechaY);
            // CAJA FUERTE ------------------------------------------

            bool colisionCajaFuerte = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPisoCF.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPisoCF.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPisoCF.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPisoCF.Bounds))
            {
                colisionCajaFuerte = true;
            }

            // Si hay colisión con imgpista1, mostrar imgbombillo
            imgMiniCF.Visible = colisionCajaFuerte;

            // Si hay colisión con imgComputador, mostrar imgMiniCompu
            if (colisionCajaFuerte)
            {
                imgMiniCF.Visible = true;

                // Si imgMiniCompu es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgMiniCF.Visible && e.KeyCode == Keys.Enter)
                {
                    using (Form dialog = new Form())
                    {
                        dialog.Text = "Ingresa 4 dígitos";
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.Size = new Size(320, 120);
                        dialog.FormBorderStyle = FormBorderStyle.FixedDialog;

                        // Agregar etiqueta
                        Label label = new Label();
                        label.Text = "Ingresa los 4 dígitos:";
                        label.Location = new Point(10, 10);
                        label.AutoSize = true;
                        dialog.Controls.Add(label);

                        // Agregar cuadro de texto
                        TextBox textBox = new TextBox();
                        textBox.Location = new Point(160, 10);
                        textBox.Size = new Size(100, 20);
                        dialog.Controls.Add(textBox);

                        // Agregar botón para verificar los dígitos
                        Button btnVerificar = new Button();
                        btnVerificar.Text = "Verificar";
                        btnVerificar.Location = new Point(30, 50);
                        btnVerificar.Click += (senderBtn, eBtn) =>
                        {
                            // Verificar si se ingresaron los dígitos correctos (8314)
                            if (textBox.Text == "8314")
                            {
                                MessageBox.Show("¡Felicidades! Has ingresado los 4 dígitos correctos.");
                                dialog.Close();
                                imgLlave.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Sigue intentando. Los dígitos ingresados no son correctos.");
                                textBox.Clear();
                            }
                        };
                        dialog.Controls.Add(btnVerificar);

                        dialog.ShowDialog();
                    }
                }
            }
            else
            {
                imgMiniCF.Visible = false;
            }

            // PISTA 1 ---------------------------------------------------------------------
            bool colisionPista1 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPista1.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPista1.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPista1.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPista1.Bounds))
            {
                colisionPista1 = true;
            }

            // Si hay colisión con imgpista1, mostrar imgbombillo
            imgbombillo.Visible = colisionPista1;

            // Si hay colisión con imgComputador, mostrar imgMiniCompu
            if (colisionPista1)
            {
                imgbombillo.Visible = true;

                // Si imgMiniCompu es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgbombillo.Visible && e.KeyCode == Keys.Enter)
                {
                    imgQR.Visible = true;
                }
            }
            else
            {
                imgQR.Visible = false;
            }

            // PISTA 2 ---------------------------------------------------------------------
            bool colisionPista2 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPiso2.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPiso2.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPiso2.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPiso2.Bounds))
            {
                colisionPista2 = true;
            }

            // Si hay colisión con imgpista2, mostrar imgBombillo2
            imgBombillo2.Visible = colisionPista2;

            // Si hay colisión con imgBombillo2, mostrar imgTV
            if (colisionPista2)
            {
                imgBombillo2.Visible = true;

                // Si imgTV es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgBombillo2.Visible && e.KeyCode == Keys.Enter)
                {
                    imgTV.Visible = true;
                }
            }
            else
            {
                imgTV.Visible = false;
            }

            // PISTA 3 ---------------------------------------------------------------------
            bool colisionPista3 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPiso3.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPiso3.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPiso3.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPiso3.Bounds))
            {
                colisionPista3 = true;
            }

            // Si hay colisión con imgPista3, mostrar imgBombillo3
            imgBombillo3.Visible = colisionPista3;

            // Si hay colisión con imgBombillo3, mostrar imgPista3
            if (colisionPista3)
            {
                imgBombillo3.Visible = true;

                // Si imgPista3 es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgBombillo3.Visible && e.KeyCode == Keys.Enter)
                {
                    imgPista3.Visible = true;
                }
            }
            else
            {
                imgPista3.Visible = false;
            }

            // PISTA 4 ---------------------------------------------------------------------
            bool colisionPista4 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPiso4.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPiso4.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPiso4.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPiso4.Bounds))
            {
                colisionPista4 = true;
            }

            // Si hay colisión con imgPista3, mostrar imgBombillo3
            imgBombillo4.Visible = colisionPista4;

            // Si hay colisión con imgBombillo3, mostrar imgPista3
            if (colisionPista4)
            {
                imgBombillo4.Visible = true;

                // Si imgPista3 es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgBombillo4.Visible && e.KeyCode == Keys.Enter)
                {
                    imgPista4.Visible = true;
                }
            }
            else
            {
                imgPista4.Visible = false;
            }

            // PISOPUERTA ---------------------------------------------------------------------
            bool colisionPista5 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPisoPuerta.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPisoPuerta.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPisoPuerta.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPisoPuerta.Bounds))
            {
                colisionPista5 = true;
            }

            // Si hay colisión con imgPista3, mostrar imgBombillo3
            imgIconoPortal.Visible = colisionPista5;

            // Si hay colisión con imgBombillo3, mostrar imgPista3
            if (colisionPista5)
            {
                imgIconoPortal.Visible = true;

                // Si imgPista3 es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgIconoPortal.Visible && e.KeyCode == Keys.Enter && imgLlave.Visible == true)
                {
                    imgPuerta.Visible = true;
                    this.Hide();
                    Historia3 Parte3 = new Historia3();
                    Parte3.ShowDialog();
                }
            }
            else
            {
                imgPuerta.Visible = false;
            }
        }

        // Controlador de eventos para el movimiento del mouse en imgLinterna
        private void imgLinterna_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            // Actualizar el tiempo restante
            tiempoRestante = tiempoRestante.Subtract(TimeSpan.FromSeconds(1));

            // Actualizar el label del temporizador
            lblTemporizador.Text = "Timer " + tiempoRestante.ToString("mm\\:ss");

            // Verificar si se alcanzó el tiempo límite (0 segundos)
            if (tiempoRestante.TotalSeconds <= 0)
            {
                temporizador.Stop(); // Detener el temporizador
                lblTemporizador.Visible = false; // Ocultar el temporizador
                imgSecuestrador.Visible = true; // Mostrar imgSecuestrador
                imgPuerta.Visible = true;
                // Configurar un temporizador para ocultar imgSecuestrador después de 2 segundos
                Timer ocultarSecuestradorTimer = new Timer();
                ocultarSecuestradorTimer.Interval = 2000; // 2 segundos
                ocultarSecuestradorTimer.Tick += (s, ev) =>
                {
                    imgSecuestrador.Visible = false; // Ocultar imgSecuestrador
                    ocultarSecuestradorTimer.Stop(); // Detener el temporizador
                    imgGolpe.Visible = true;

                    // Configurar un temporizador para ocultar imgGolpe después de 2 segundos
                    Timer ocultarGolpeTimer = new Timer();
                    ocultarGolpeTimer.Interval = 2000; // 2 segundos
                    ocultarGolpeTimer.Tick += (s2, ev2) =>
                    {
                        imgGolpe.Visible = false; // Ocultar imgGolpe
                        ocultarGolpeTimer.Stop(); // Detener el temporizador

                        this.Hide();
                        Menu Menu3 = new Menu();
                        Menu3.ShowDialog();
                    };
                    ocultarGolpeTimer.Start(); // Iniciar el temporizador para ocultar imgGolpe
                };
                ocultarSecuestradorTimer.Start(); // Iniciar el temporizador para ocultar imgSecuestrador
            }
        }

        private void imgPuerta_Click(object sender, EventArgs e)
        {


        }
    }
}
