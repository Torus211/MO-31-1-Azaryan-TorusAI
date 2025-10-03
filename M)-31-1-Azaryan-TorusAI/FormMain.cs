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

namespace M__31_1_Azaryan_TorusAI
{
    public partial class FormMain : Form
    {
        private double[] m_inputPixels;

        public FormMain()
        {
            m_inputPixels = new double[15];

            InitializeComponent();
        }

        private void OnPixelButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Black;
                m_inputPixels[button.TabIndex] = 1;
            }
            else
            {
                button.BackColor = Color.White;
                m_inputPixels[button.TabIndex] = 0;
            }
        }


        //сохранить в файл ОБУЧАЮЩИЙ пример 
        private void button_SaveTrainSample_Click(object sender, EventArgs e) {
            string path = AppDomain.CurrentDomain.BaseDirectory + "train.txt";
            string tmpStr = NecessaryOutput.Value.ToString();

            for (int i = 0; i < m_inputPixels.Length; i++)
            {
                tmpStr += " " + m_inputPixels[i].ToString();
            }
            tmpStr += "\n";
            File.AppendAllText(path, tmpStr);

        }



        //сохранить в файл Тестовый пример 
        private void button_SaveTestSample_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "test.txt";
            string tmpStr = NecessaryOutput.Value.ToString();

            for (int i = 0; i < m_inputPixels.Length; i++)
            {
                tmpStr += " " + m_inputPixels[i].ToString();
            }
            tmpStr += "\n";
            File.AppendAllText(path, tmpStr);

        }



    }

}
