using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodeGenerator
{
    public partial class QRcode : Form
    {
        public QRcode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
               
                    QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                    string name = textBoxName.Text;
                    string password = textBoxPss.Text;
                    string value = "WIFI:T:" + eccryption + ";S:" + name + ";P:" + password + ";H:;";
                    textBox1.Text = value;
                    var data = QG.CreateQrCode(value, QRCoder.QRCodeGenerator.ECCLevel.H);
                    var code = new QRCoder.QRCode(data);
                    pictureBox1.Image = code.GetGraphic(50);
            }
            else
            {
                MessageBox.Show("Textbox in empty");
            }
            
        }
        string eccryption;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (comboBox1.Text == "None")
                {
                    eccryption = "nopass";
                    textBoxPss.Hide();
                }
                else if (comboBox1.Text == "WAP/WPA2")
                {
                    eccryption = "WPA";
                }
                else if (comboBox1.Text == "WEP")
                {
                    eccryption = "WEP";
                }
            }
            else { MessageBox.Show("Choose one eccryption"); }
        }
    }
}
