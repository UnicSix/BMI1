using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI1
{
    public partial class BMI_title : Form
    {
        
        public BMI_title()
        {
            string inputFile = "BodyInfo1.txt";
            InitializeComponent();
            System.IO.StreamReader inputData = new System.IO.StreamReader(inputFile);
            string line = "";
            string[] split_line = new string[4];

            line = inputData.ReadLine();
            int index = 0;
            int bmi = 0;
            while (line != null)
            {
                
                split_line = line.Split(',');
                BMI_data.Rows.Add(split_line);
                bmi = BMI(split_line[0], split_line[1]);
                BMI_data.Rows[index].Cells[2].Value = bmi;
                BMI_data.Rows[index].Cells[3].Value = BodyStat(bmi);
                line = inputData.ReadLine();
                index++;
            }
        }

        public int BMI(string h, string w)
        {
            float hei = float.Parse(h)/100;
            float wei = float.Parse(w);
            int BMI = (int)(wei / (hei * hei));
            return BMI;
        }

        public string BodyStat(int bmi)
        {
            if(bmi < 20)
            {
                return "過輕";
            }
            else if(bmi >= 20 && bmi <= 25)
            {
                return "適中";
            }
            else
            {
                return "過重";
            }
        }

        private void BMI_title_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
