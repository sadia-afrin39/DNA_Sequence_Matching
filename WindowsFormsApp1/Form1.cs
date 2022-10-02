using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int[,] a;
        public int[,] b;
       

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            String first = firstseq.Text;
            String second = secondseq.Text;
            var output = LCS(first, second);
           result.Text=BackTrack(output, first, second, first.Length, second.Length); //out
         

            Console.ReadLine();

            int[,] LCS(string s1, string s2)
            {
                int[,] c = new int[s1.Length + 1, s2.Length + 1];
                for (int i = 1; i <= s1.Length; i++)
                    for (int j = 1; j <= s2.Length; j++)
                    {
                        if (s1[i - 1] == s2[j - 1])
                            c[i, j] = c[i - 1, j - 1] + 1;
                        else
                            c[i, j] = c[i - 1, j] > c[i, j - 1] ? c[i - 1, j] : c[i, j - 1];
                    }
                return c;
            }

           string BackTrack(int[,] c, string s1, string s2, int i, int j)
            {
                if (i == 0 || j == 0)
                    return "";
                else if (s1[i - 1] == s2[j - 1])
                    return BackTrack(c, s1, s2, i - 1, j - 1) + s1[i - 1];
                else if (c[i, j - 1] > c[i - 1, j])
                    return BackTrack(c, s1, s2, i, j - 1);
                else
                    return BackTrack(c, s1, s2, i - 1, j);
            }


        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            firstseq.Clear();
            secondseq.Clear();
            result.Clear();
            cmntTxt.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String s1 = firstseq.Text;
            Double s1len = (Double)s1.Length;

            String s3 = result.Text;
            Double s3len =(Double) s3.Length;

            Double percent = ((s3len/ s1len) * 100.00);

            cmntTxt.Text =percent.ToString();
             
           if(percent==0.00)
            {
                cmntTxt.Text = "There is no possibility to have a relationship between the DNA sequence holders.The percentage of having relationship is 0%.";
            }

           else if (percent>0.00 && percent<=30.00)
           {
                cmntTxt.Text = "THere is a very low posibility to have a relationship between the DNA sequence holders.The percentage of having relationship is "+percent.ToString()+ "%."; 
            }

            else if (percent > 30.00 && percent <=60.00)
            {
                cmntTxt.Text = "THere is a midium posibility to have a relationship between the DNA sequence holders.The percentage of having relationship is " +percent.ToString() +"%.";
            }

            else if (percent > 60.00 && percent <= 80.00)
            {
                cmntTxt.Text = "THere is a very high posibility to have a relationship between the DNA sequence holders.The percentage of having relationship is " +percent.ToString() + "%";
            }
            else
           {
                cmntTxt.Text = "WOW!!! That's great....It looks like, both of them have a strong relationship. THere is a very high posibility to have a relationship between the DNA sequence holders.The percentage of having relationship is " +percent.ToString()+ "%.";
            }
        }
    }

}
