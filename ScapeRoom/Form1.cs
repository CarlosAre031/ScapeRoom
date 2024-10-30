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
    public partial class imgMesa : Form
    {
        private int imgMAdelanteX = 357;
        private int imgMAdelanteY = 410;
        private int imgMAtrasX = 357;
        private int imgMAtrasY = 410;
        private int imgMIzquierdaX = 357;
        private int imgMIzquierdaY = 410;
        private int imgMderechaX = 357;
        private int imgMderechaY = 410;

        private TimeSpan tiempoRestante;
        private Timer temporizador = new Timer();



        public imgMesa()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            imgbombillo.Visible = false;
            imgMiniCompu.Visible = false;
            //------------------------------------------------
            temporizador.Interval = 1000; // Intervalo en milisegundos (1 segundo)
            temporizador.Tick += Temporizador_Tick;
            tiempoRestante = new TimeSpan(0, 5, 0); // 5 minutos
            lblTemporizador.Text = "Timer: 00:00"; // Inicializar el label del temporizador
            lblTemporizador.Visible = true;
            temporizador.Start(); // Iniciar el temporiza

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int velocidadMovimiento = 5;

            // Límites de movimiento
            int limiteXMin = 146;
            int limiteXMax = 450;
            int limiteYMin = 250;
            int limiteYMax = 446;

            // Coordenadas de imgpista1
            int pista1X = imgpista1.Left;
            int pista1Y = imgpista1.Top;
            int pista1Ancho = imgpista1.Width;
            int pista1Alto = imgpista1.Height;

            // Coordenadas de imgComputador
            int compuX = imgComputador.Left;
            int compuY = imgComputador.Top;
            int compuAncho = imgComputador.Width;
            int compuAlto = imgComputador.Height;

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

            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

            if (imgMAdelante.Bounds.IntersectsWith(imgMueble.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMueble.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMueble.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMueble.Bounds))
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
            //Mueble 1--------------------------------------------------------------------------------------------
            //EL CODIGO PARA LOS MUEBLES-----------------------------------------------------------------------------------------

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
            //-----------------------------------------------------------------------------------------------------------------
            if (imgMAdelante.Bounds.IntersectsWith(imgMuble2.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgMuble2.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgMuble2.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgMuble2.Bounds))
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
            //Mueble 3----------------------------------------------------------------------------------------------------------
            if (imgMAdelante.Bounds.IntersectsWith(imgmueble3.Bounds) ||
               imgMAtras.Bounds.IntersectsWith(imgmueble3.Bounds) ||
               imgMIzquierda.Bounds.IntersectsWith(imgmueble3.Bounds) ||
               imgMderecha.Bounds.IntersectsWith(imgmueble3.Bounds))
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

            // pista 1----------------------------------------------------------------------------------------------------------
            bool colisionPista1 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgpista1.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgpista1.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgpista1.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgpista1.Bounds))
            {
                colisionPista1 = true;
            }
            imgbombillo.Visible = colisionPista1;

            if (imgbombillo.Visible && e.KeyCode == Keys.Enter)
            {

                // Crear una nueva ventana emergente personalizada
                using (Form dialog = new Form())
                {
                    dialog.Text = "Pregunta";
                    dialog.StartPosition = FormStartPosition.CenterScreen;
                    dialog.Size = new Size(320, 120);
                    dialog.FormBorderStyle = FormBorderStyle.FixedDialog;

                    // Agregar etiqueta con la pregunta
                    Label label = new Label();
                    label.Text = "Soy el número de bits en un byte. ¿Quién soy? (Posicion 2)";
                    label.Location = new Point(10, 10);
                    label.AutoSize = true;
                    dialog.Controls.Add(label);

                    // Agregar botones
                    Button btnCinco = new Button();
                    btnCinco.Text = "5";
                    btnCinco.Location = new Point(30, 50);
                    btnCinco.Click += (senderBtn, eBtn) =>
                    {
                        // Verificar si el botón "5" fue presionado
                        if (((Button)senderBtn).Text == "5")
                        {
                            MessageBox.Show("Respuesta incorrecta. Inténtalo de nuevo.");
                        }
                    };
                    dialog.Controls.Add(btnCinco);

                    Button btnOcho = new Button();
                    btnOcho.Text = "8";
                    btnOcho.Location = new Point(120, 50);
                    btnOcho.Click += (senderBtn, eBtn) =>
                    {
                        // Verificar si el botón "8" fue presionado
                        if (((Button)senderBtn).Text == "8")
                        {
                            MessageBox.Show("¡Correcto! Soy el número de bits en un byte.");
                            dialog.Close();
                        }
                    };
                    dialog.Controls.Add(btnOcho);

                    Button btnDos = new Button();
                    btnDos.Text = "2";
                    btnDos.Location = new Point(210, 50);
                    btnDos.Click += (senderBtn, eBtn) =>
                    {
                        // Verificar si el botón "2" fue presionado
                        if (((Button)senderBtn).Text == "2")
                        {
                            MessageBox.Show("Respuesta incorrecta. Inténtalo de nuevo.");
                        }
                    };
                    dialog.Controls.Add(btnDos);

                    dialog.ShowDialog();
                }
            }

            // Comprobar colisión con imgComputador-----------------------------------------------------------------------------------------
            bool colisionComputador = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgComputador.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgComputador.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgComputador.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgComputador.Bounds))
            {
                colisionComputador = true;
            }

            // Si hay colisión con imgpista1, mostrar imgbombillo
            imgbombillo.Visible = colisionPista1;

            // Si hay colisión con imgComputador, mostrar imgMiniCompu
            if (colisionComputador)
            {
                imgMiniCompu.Visible = true;

                // Si imgMiniCompu es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgMiniCompu.Visible && e.KeyCode == Keys.Enter)
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
                            // Verificar si se ingresaron los dígitos correctos (1863)
                            if (textBox.Text == "1863")
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
                            if (imgLlave.Visible == true)
                            {
                                imgPuerta.Visible = false;
                            }
                        };
                        dialog.Controls.Add(btnVerificar);

                        dialog.ShowDialog();
                    }
                }
            }
            else
            {
                imgMiniCompu.Visible = false;

            }
            // Pista 2----------------------------------------------------
            bool colisionPista2 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPista3.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPista3.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPista3.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPista3.Bounds))
            {
                colisionPista2 = true;
            }

            // Si hay colisión con imgpista1, mostrar imgbombillo
            imgbombillo.Visible = colisionPista1;

            // Si hay colisión con imgComputador, mostrar imgMiniCompu
            if (colisionPista2)
            {
                imgbombillo.Visible = true;


                // Si imgMiniCompu es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgbombillo.Visible && e.KeyCode == Keys.Enter)
                {
                    imgPista2.Visible = true;
                    imgEstatica.Visible = false;
                    

                }

            }
            if (colisionPista2 == false)
            {
                imgEstatica.Visible = true;
                imgPista2.Visible = false;
            }
            //Pista 4 -------------------------------------------------------------------------------------------------
            bool colisionPista4 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPista4.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPista4.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPista4.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPista4.Bounds))
            {
                colisionPista4 = true;
            }

            // Si hay colisión con imgpista1, mostrar imgbombillo
            imgbombillo2.Visible = colisionPista1;


            // Si hay colisión con imgComputador, mostrar imgMiniCompu
            if (colisionPista4)
            {
                imgbombillo2.Visible = true;

                // Si imgMiniCompu es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgbombillo2.Visible && e.KeyCode == Keys.Enter)
                {
                    imgCuadro1.Visible = true;
                    imgCuadro2.Visible = true;
                    imgCuadro3.Visible = true;


                }

            }
            else
            {
                imgCuadro1.Visible = false;
                imgCuadro2.Visible = false;
                imgCuadro3.Visible = false;

            }

            //PISTA2---------------------------------------------------------------------------------------------------------------------------
            bool colisionPista5 = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPista5.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPista5.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPista5.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPista5.Bounds))
            {
                colisionPista5 = true;
            }

            // Si hay colisión con imgpista1, mostrar imgbombillo
            imgbombillo3.Visible = colisionPista1;


            // Si hay colisión con imgComputador, mostrar imgMiniCompu
            if (colisionPista5)
            {
                imgbombillo3.Visible = true;

                // Si imgMiniCompu es visible y se presiona Enter, mostrar cuadro de diálogo
                if (imgbombillo3.Visible && e.KeyCode == Keys.Enter)
                {
                    imgLibros.Visible = true;



                }

            }
            else
            {
                imgLibros.Visible = false;

            }

            //PORTAL SALIDA----------------------------------------------------------

            bool colisionPortal = false;

            if (imgMAdelante.Bounds.IntersectsWith(imgPortal.Bounds) ||
                imgMAtras.Bounds.IntersectsWith(imgPortal.Bounds) ||
                imgMIzquierda.Bounds.IntersectsWith(imgPortal.Bounds) ||
                imgMderecha.Bounds.IntersectsWith(imgPortal.Bounds))
            {
                colisionPortal = true;
            }

            // Si hay colisión con imgpista1, mostrar imgbombillo
            imgIconoPortal.Visible = colisionPortal;


            // Si imgMiniCompu es visible y se presiona Enter, mostrar cuadro de diálogo
            if (imgIconoPortal.Visible && e.KeyCode == Keys.Enter && imgLlave.Visible == true)
            {
                imgLibros.Visible = true;
                this.Hide();
                Historia2 Parte2 = new Historia2();
                Parte2.ShowDialog();


            }
            else { }
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
                imgPuerta.Visible = false;
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

                        // Cerrar el juego
                        this.Hide();
                        Menu Menu2 = new Menu();
                        Menu2.ShowDialog();
                    };
                    ocultarGolpeTimer.Start(); // Iniciar el temporizador para ocultar imgGolpe
                };
                ocultarSecuestradorTimer.Start(); // Iniciar el temporizador para ocultar imgSecuestrador
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void imgMAtras_Click(object sender, EventArgs e)
        {

        }

        private void imgPista4_Click(object sender, EventArgs e)
        {

        }

        private void imgGolpe_Click(object sender, EventArgs e)
        {

        }

        private void Temporizador_Tick_1(object sender, EventArgs e)
        {

        }
    }
}

