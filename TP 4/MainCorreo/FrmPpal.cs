using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Atributos
        /// <summary>
        /// Atributo privado de tipo Correo.
        /// </summary>
        private Correo correo;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto que inicializa el correo y los componentes del formulario.
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();

        }

        #endregion

        #region Eventos
        /// <summary>
        /// Manejador del evento en el boton Agregar. Crea una instancia de Paquete enviando como parámetro
        /// la información recuperada de los TextBox. Asocia al evento InformaEstado el método paq_InformaEstado.
        /// Luego agrega el objeto Paquete al Correo. Lanzará una excepción si hubo un error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                paquete.InformaEstado += this.paq_InformaEstado;

                this.correo += paquete;

            
            }
            catch (TrackingIdRepetidoException ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        /// <summary>
        /// Manejador del evento en el boton MostrarTodos. Se invoca al método MostrarInformación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }


        /// <summary>
        /// Manejador del evento al apretar boton derecho en el ListBox de Entregado.
        /// Invoca al MostrarInformación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Manejador del evento FormClosing. Se llama al método FinEntregas de correo para cerrar los hilos
        /// abiertos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();

            DialogResult rta = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;

            }


        }

        #endregion

        #region Métodos
        /// <summary>
        /// Si se encuentra en un subproceso el InvokeRequired es true.   
        /// Se crea un delegado, se hace un Invoke y se le pasa al delegado que cede la ejecución de su código.
        /// Vuelve a invocarse al método, como es del hilo principal InvokedRequired es false 
        /// y se actualizan los estados de los ListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });

            }
            else
            {
                this.ActualizarEstado();
            }
        }

        /// <summary>
        /// Método que limpia los ListBox, recorre la lista de paquete y los agrega depende el estado.
        /// </summary>
        private void ActualizarEstado()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;

                }
            }
        }

        /// <summary>
        /// Método que muestra los datos en el RichTextBox y se guarda en el archivo de texto.
        /// Muestra un MessageBox si no pudo guardarse.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception)
                {

                    MessageBox.Show("No se pudo guardar el archivo");
                }
            }
        }

        #endregion
    }
}
