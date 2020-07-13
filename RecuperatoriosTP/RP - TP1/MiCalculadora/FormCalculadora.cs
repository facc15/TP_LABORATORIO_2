using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor por defecto del Formulario. Carga los items del comboBox.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }
        #endregion

        #region Manejadores de evento

        /// <summary>
        /// Manejador del evento Click del botón limpiar. Llama al método que limpia los controles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Manejador del evento Clic del botón Operar. Invoca al método de clase Operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = (string)this.cmbOperador.SelectedItem;

            if (this.txtNumero1.Text != "" && this.txtNumero2.Text != "")
            {
                this.btnConvertirABinario.Enabled = true;
                double resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, operador);

                lblResultado.Text = resultado.ToString();

            }

        }

        /// <summary>
        /// Manejador del evento click del botón Cerrar. Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
             
            this.Close();
        }

        /// <summary>
        /// Manejador del evento Click del botón Convertir a Binario. Invoca al método DecimalBinario de la clase Numero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();

            if (this.lblResultado.Text != "")
            {
                this.lblResultado.Text = n.DecimalBinario(this.lblResultado.Text);
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = true;

            }
        }

        /// <summary>
        /// Manejador del evento Click del botón Convertir a Decimal. Invoca al método BinarioDecimal de la clase Numero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();

            if (this.lblResultado.Text != "")
            {
                this.lblResultado.Text = n.BinarioDecimal(this.lblResultado.Text);
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = true;
            }

        }

        /// <summary>
        /// Manejador del evento FormClosing. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
        /// Método de clase que invoca al método de clase de Calculadora para realizar las operaciones.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1,string numero2,string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operador);

        }

    
         /// <summary>
         /// Método limpiar que limpia los controles del formulario.
         /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text="";
            this.cmbOperador.SelectedIndex = 0;
            this.cmbOperador.Text = "";
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
           
        }




        #endregion

       
    }
}
