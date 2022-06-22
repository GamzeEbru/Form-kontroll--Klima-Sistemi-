using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace gomuluproje
{
    public partial class Form1 : Form
    {
        string data;
        public bool warning;
        int fileNumber;
        string temprature1;
        int tempraturea;


        public Form1()
        {
            InitializeComponent();
            pictureBox2.Visible = false;
        }
       
       
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displayData_event));

        }
        public void displayData_event(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
            try
            {
                string temprature1;
                int tempraturea;


                temprature1 = serialPort1.ReadLine();
                label3.Text = temprature1;
               
                textBox2.Text += DateTime.Now.ToString() + " Sıcaklık Degeri      :   " + temprature1 + "\n";
                textBox2.Text += "------------------------------------------" + "\n";
                tempraturea = Convert.ToInt32(temprature1);
               
                if (tempraturea > 26)
                {
                    label6.Text = ("UYARI" + tempraturea);
                    pictureBox2.Visible = true;
                }
                else
                {
                    pictureBox2.Visible = false;
                }
                if (data.EndsWith("END"))
                {

                    return;
                }

            }
            catch
            {

            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch
            {

            }
        }
        
        public void button2_Click(object sender, EventArgs e)
        {
       
            
            try
            {
                serialPort1.PortName = comboBox2.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                button1.Enabled = true;
                button2.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                fileNumber++;
                string filelocation = @"C:\Users\MSI\GOMULUPROJE\kaydedilen_veriler\";
                string filename = ("data" + fileNumber + ".txt");
                System.IO.File.WriteAllText(filelocation + filename, "Zaman\t\t\tDeğer\n" + textBox2.Text);
                MessageBox.Show("Başarıyla Kaydedildi.");

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Hata!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
                string[] ports = SerialPort.GetPortNames();  //Seri portları elementye ekleme
                foreach (string port in ports)
                    comboBox2.Items.Add(port);               //Seri portları comboBox1'e ekleme
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
            
        }
    }
}
