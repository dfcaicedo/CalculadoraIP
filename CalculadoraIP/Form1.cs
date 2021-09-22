using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public String DecimalaBinario(long decimales) // es como si recibiera el trapecio de entrada y la variables
            //es decimales
        {
            String resp = "";
            while (decimales > 0)
            {
                Int16 residuo;
                residuo = Convert.ToInt16(decimales % 2);
                resp = residuo.ToString() + resp;
                decimales = (decimales - residuo) / 2;
            }
            while (resp.Length < 8)
                resp = "0" + resp;
            return resp;
        }

      
        public String multi(String a,String b)
        {
            String resultado="";
            while (a.Length > 0)
            {
                Int16 ultimoa;
                Int16 ultimob;
                ultimoa = Convert.ToInt16(a.Substring(a.Length - 1, 1));
                ultimob = Convert.ToInt16(b.Substring(b.Length - 1, 1));
                resultado = (ultimoa * ultimob).ToString() + resultado;
                a = a.Substring(0, a.Length - 1); //Quitando el último carácter
                b = b.Substring(0, b.Length - 1);
            }
            return resultado;
        }
        public string invertirnumero(String a)
        {
            a = a.Replace("1", "3");
            a = a.Replace("0", "1");
            a = a.Replace("3", "0");
            return a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String n1 = this.textBox10.Text; // Trapecio
            this.textBox25.Text = DecimalaBinario(Convert.ToInt64(n1));
            String n2 = this.textBox11.Text;
            this.textBox24.Text = DecimalaBinario(Convert.ToInt64(n2));
            String n3 = this.textBox12.Text;
            this.textBox23.Text = DecimalaBinario(Convert.ToInt64(n3));
            String n4 = this.textBox13.Text;
            this.textBox22.Text = DecimalaBinario(Convert.ToInt64(n4));
            String mascara = "";
            for (int a = 1; a <= numericUpDown1.Value; a++)
            {
                mascara += "1";
            }
            while (mascara.Length < 32)
            {
                mascara = mascara + "0";
            }
            this.textBox21.Text = mascara.Substring(0, 8);
            this.textBox20.Text = mascara.Substring(8, 8);
            this.textBox19.Text = mascara.Substring(16, 8);
            this.textBox18.Text = mascara.Substring(24, 8);
            textBox17.Text = BinarioaDecimal(textBox21.Text).ToString() ;
            textBox16.Text = BinarioaDecimal(textBox20.Text).ToString();
            textBox15.Text = BinarioaDecimal(textBox19.Text).ToString();
            textBox14.Text = BinarioaDecimal(textBox18.Text).ToString();
        }
        public Int32 BinarioaDecimal(String valor)
        {
            int acu=0;
            for (int a = 0; a < 8; a++)
            {
                int nume = Convert.ToInt32(valor.Substring((7 - a), 1));
                acu = acu + nume * Convert.ToInt32(Math.Pow(2, a));
            }
            return acu;
        }
    }
}
