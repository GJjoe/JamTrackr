using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using System.IO;
using System.Reflection;
using System.Threading;

namespace jamTrackr
{
    public partial class Form1 : Form
    {

        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;
        DataGridView dg;
        double end;
            public Form1()
        {
            
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            string path = "/Music";
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            



            dataGridView1.DataSource = new DirectoryInfo(executableLocation + "/Music").GetFiles("*.mp3", SearchOption.AllDirectories);


        }

        public void playMP3()
        {
            if (waveOutDevice == null & textBox1.Text != "")
            {
                if (textBox2 != null )
                {
                    int start = Int32.Parse(textBox2.Text);
                    audioFileReader.CurrentTime = TimeSpan.FromSeconds(start);
                    // System.TimeSpan current = audioFileReader.CurrentTime;
                }

                waveOutDevice = new WaveOut();





                waveOutDevice.Init(audioFileReader);


               

                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 1000;//5 minutes
                timer1.Tick += new System.EventHandler(getPosition);
                timer1.Start();
                waveOutDevice.Play();
                double end = 60;
                double curr = audioFileReader.CurrentTime.TotalSeconds;

                if (curr > end)
                {
                    Console.WriteLine("stop");
                }


              
                System.TimeSpan current = audioFileReader.CurrentTime;
                Console.WriteLine(current);

            }
        }

        public void getPosition(object sender, EventArgs e)
        {

            string current = audioFileReader.CurrentTime.TotalSeconds.ToString();
            Console.WriteLine(current);


            double end = Int32.Parse(textBox3.Text);
            double curr = audioFileReader.CurrentTime.TotalSeconds;

            updateTime();

            if (curr > end & end !=0)
            {
                Console.WriteLine("stop");
                CloseWaveOut();

                if (checkBox1.Checked)
                {
                    playMP3();

                }

            }

        
        }

    


        private void CloseWaveOut()
        {

           // System.TimeSpan current = audioFileReader.CurrentTime;
            //Console.WriteLine(current);

            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
            }
          
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playMP3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseWaveOut();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //audioFileReader = new AudioFileReader("Music/ " + "helloworld.mp3");
           textBox1.Text = dataGridView1.ToString();

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            string a = Convert.ToString(selectedRow.Cells["Name1"].Value);

            textBox1.Text = a;

            audioFileReader = new AudioFileReader("Music/" + a);

            Console.WriteLine(a);
            playMP3();
        }

        public double getCURRTIME()
        {
            double currentTime;
            
            if (audioFileReader != null)
            {
                currentTime = audioFileReader.CurrentTime.TotalSeconds;
                return currentTime;

            }
            else
            {
                currentTime = 0;
                return currentTime;

            } 

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            double time = getCURRTIME();
            textBox2.Text = time.ToString();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            double time = getCURRTIME();
            textBox3.Text = time.ToString();
        }

        private void timeDisplay_Click(object sender, EventArgs e)
        {

        }

        public void updateTime(){

            string curTimeString = audioFileReader.CurrentTime.ToString("mm\\:ss");
            timeDisplay.Text = curTimeString;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        string filename;
        string filename2;
        private void button3_Click(object sender, EventArgs e)

        { 
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetFullPath(openFileDialog1.FileName).ToString();
                filename2 = System.IO.Path.GetFileName(openFileDialog1.FileName).ToString();
            }

            string destDIR = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string destDIR2 = destDIR + "\\Music\\" + filename2;

            Console.WriteLine(filename);
            Console.WriteLine(filename2);
            Console.WriteLine(destDIR2);

             System.IO.File.Copy(filename, destDIR2, true);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        public double getStart()
        {
            double starttime = 0;
            return starttime;
        }

        public double getEnd()
        {
            double endtime = 0;
            return endtime;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            playMP3();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CloseWaveOut();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
