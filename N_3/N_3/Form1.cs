using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace N_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static double[] n = new double[10];
        static char[] op = new char[10];
        static int kostil = 0;
        static int kostil2 = 0;
        static int kostil3 = 0;
        String x = "";
        //циферки
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "1";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "2";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "9";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "0";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "00";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += ",";
        }
        //операции
        void nAdd()
        {
            n[kostil] = double.Parse(richTextBox1.Text.Substring(kostil3, richTextBox1.Text.Length - kostil3));
            kostil3 = richTextBox1.Text.Length + 1;
            kostil++;
            

        }
        private void button13_Click(object sender, EventArgs e)
        {
            nAdd();
            richTextBox1.Text += "+";
            op[kostil2] = '+';
            kostil2++;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text[richTextBox1.Text.Length - 1] != '^') { nAdd(); op[kostil2] = '-'; kostil2++; }

            richTextBox1.Text += "-";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            nAdd();
            richTextBox1.Text += "*";
            op[kostil2] = '*';
            kostil2++;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            nAdd();
            richTextBox1.Text += "^";
            op[kostil2] = '^';
            kostil2++;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            //ckoba
        }
        private void button19_Click(object sender, EventArgs e)
        {
            //ckoba
        }
        private void button20_Click(object sender, EventArgs e)
        {
            nAdd();
            richTextBox1.Text += "/";
            op[kostil2] = '/';
            kostil2++;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            nAdd();
            richTextBox1.Text = AAAA();
            Array.Clear(n, 0, kostil);
            Array.Clear(op, 0, kostil2);
            kostil = 0;
            kostil2 = 0;
            kostil3 = 0;

        }

        private void button21_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Array.Clear(n, 0, kostil);
            Array.Clear(op, 0, kostil2);
            kostil = 0;
            kostil2 = 0;
            kostil3 = 0;
        }
        void Perepisn(double[] x, int index)
        {
            for (int i = index; i < x.Length - 1; i++)
            {
                x[i] = x[i + 1];
            }

        }
        void Perepisop(char[] x, int index)
        {
            for (int i = index; i < x.Length - 1; i++)
            {
                x[i] = x[i + 1];
            }
            x[x.Length-1] = ' ';

        }
        String AAAA()
        {
            double otvet = 0.0;
            x = "Выражение по действиям: \n";
            int k = 0;
            int kostil4 = 1;
            for (int i = 0; i < op.Length; i++)
            {
                if (op[i] == '^')
                {
                    otvet = Math.Pow(n[i], n[i + 1]);
                    x += $"{kostil4}. {n[i]} ^ {n[i + 1]} = {otvet}\n";
                    kostil4++; n[i + 1] = otvet; Perepisn(n, i); Perepisop(op, i);
                }

            }
            for (int i = 0; i < op.Length; i++)
            {
                if (op[i] == '*')
                {
                    otvet = n[i] * n[i + 1];
                    x += $"{kostil4}. {n[i]} * {n[i + 1]} = {otvet}\n";
                    kostil4++; n[i + 1] = otvet; Perepisn(n, i); Perepisop(op, i);
                }
                if (op[i] == '/')
                {
                    otvet = n[i] / n[i + 1];
                    x += $"{kostil4}. {n[i]} / {n[i + 1]} = {otvet}\n";
                    kostil4++; n[i+1] = otvet; Perepisn(n, i); Perepisop(op, i);
                }

            }
            for (int i = 0; i < op.Length; i++)
            {
                if (op[i] == '+')
                {
                    otvet = n[i] + n[i + 1];
                    x += $"{kostil4}. {n[i]} + {n[i + 1]} = {otvet}\n";
                    kostil4++; n[i + 1] = otvet; Perepisn(n, i); Perepisop(op, i);
                }
                if (op[i] == '-')
                {
                    otvet = n[i] - n[i + 1];
                    x += $"{kostil4}. {n[i]} - {n[i + 1]} = {otvet}\n";
                    kostil4++; n[i + 1] = otvet; Perepisn(n, i); Perepisop(op, i);
                }
                //FileStream file1 = new FileStream("d:\\test.txt", FileMode.Create);
                //StreamWriter writer = new StreamWriter(file1); 
                //writer.Write(x); 
                //writer.Close(); 
            }

            return x;
        }
    }
}
