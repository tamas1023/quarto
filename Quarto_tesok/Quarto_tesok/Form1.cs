using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quarto_tesok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // bábúk osztály, azzal jó lehet
            Babuk [] babu = new Babuk[10];
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text=="Leírás")
            {
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Text = "Vissza";
                label3.Visible = true;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Text = "Leírás";
                label3.Visible = false;
            }
        }
    }
}
