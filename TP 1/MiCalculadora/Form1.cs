using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Mi Calculadora -  Facundo Rocha  2ºA";          
        }

        /// <summary>
        /// cierro el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boton_Cerrar(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro desea cerrar el programa?","Cierre del programa", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Close();
                
            }          
        }

        /// <summary>
        /// llama al metodo limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// metodo que vacia las cajas de texto.
        /// </summary>
        private void Limpiar()
        {
            textNumero1.Text = "";
            textNumero2.Text = "";
            lblResultado.Text = "";
            comboOperador.Text = "";
        }

        /// <summary>
        /// boton que llama al metodo operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {   
            double resultado;
            switch(comboOperador.Text)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                         resultado = Operar(textNumero1.Text, textNumero2.Text, comboOperador.Text);
                         lblResultado.Text = resultado.ToString();
                    break;
                default:
                    lblResultado.Text = "Falta operador";
                    break;
               
            }           
        }


        /// <summary>
        /// Usa el metodo operar de calculadora para realizar la operacion.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>el resultado de tipo double</returns>
        private static double Operar(string numero1,string numero2,string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            double resultado = Calculadora.Operar(num1, num2, operador);           
            return resultado;
        }

        /// <summary>
        /// boton que llama al metodo que convierte a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero();
            lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);    
        }

        /// <summary>
        /// boton que llama al metodo que convierte a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero();
            lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text);
        }
    }
}
