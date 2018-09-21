using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DatabaseConnector;

namespace SS_group
{
    public partial class ROBOMAZE : Form
    {
        private short _minutes, _seconds;
        public ROBOMAZE()
        {
            InitializeComponent();
        }       

        private void timer1_Tick(object sender, EventArgs e)
        {
            IncreaseSeconds();
            ShowTime();
        }

        private void IncreaseSeconds()
        {
            if (_seconds == 59)
            {
                _seconds = 0;
                IncreaseMinutes();
            }
            else
            {
                _seconds++;
                label2.Text = secondsText.Text;
            }
        }
        private void IncreaseMinutes()
        {
            if (_minutes == 59)
            {
                _minutes = 0;
            }
            else
            {
                _minutes++;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnStop1.Visible = true;
            timer1.Enabled = true;            

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                timer1.Enabled = false;
                MessageBox.Show("Voer s.v.p. een naam in!");
                btnStart.Enabled = true;
            }
            if (textBox1.Text == "VOER JE NAAM HIER IN")
            {
                timer1.Enabled = false;
                MessageBox.Show("Voer s.v.p. een naam in!");
                btnStart.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _minutes = 0;
            _seconds = 0;

            ShowTime();

            btnStart.Visible = true;
            btnStop1.Visible = false;
            timer1.Enabled = false;
            label2.Text = "";

            dataGridView1.Rows.Clear();
            pictureBox5.Visible = false;
        }

        private void ShowTime()
        {
            minutesText.Text = _minutes.ToString("00");
            secondsText.Text = _seconds.ToString("00");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.exitb2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }      

        private void click(object sender, MouseEventArgs e)
        {
            btnStart.Image = Properties.Resources.knopdruk_1;
        }

        private void EropE(object sender, EventArgs e)
        {
            btnStart.Image = Properties.Resources.knopdruk2;
        }

        private void ErafE(object sender, EventArgs e)
        {
            btnStart.Image = Properties.Resources.startb2;
        }

        private void leavings(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.exitb;
        }

        private void test(object sender, PaintEventArgs e)
        {
            
        }

        private void ROBOMAZE_Load(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void BackgrPaint(object sender, PaintEventArgs e)
        {

        }

        private void timingS(object sender, PaintEventArgs e)
        {
            
        }
        
        private void timingM(object sender, PaintEventArgs e)
        {
        }

        private void janutochwelvraagteken(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Consolas", 58);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(-7);
            e.Graphics.DrawString(minutesText.Text + ":" + secondsText.Text, myfont, mybrush, 0, 0);
        }

        private void Minutentochwel(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Consolas", 54);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(-7);
            e.Graphics.DrawString(minutesText.Text, myfont, mybrush, 0, 0);
        }

        private void dubbelpuntisht(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Consolas", 54);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(-7);
            e.Graphics.DrawString(secondsText.Text, myfont, mybrush, 0, 0);
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnStart.Visible = true;
            btnStop1.Visible = false;
            pictureBox5.Visible = true;
            label2.Text = "";
            pictureBox7.Visible = true;

           int val1 = Convert.ToInt16(minutesText.Text + secondsText.Text);
            int seconds = Convert.ToInt32(secondsText.Text);
            int minutes = Convert.ToInt32(minutesText.Text);
            int val2 = 3;
            int val3 = val1 * val2;
            TimeSpan time = TimeSpan.FromSeconds( minutes * 60 + seconds);

            dataGridView1.Rows.Add(textBox1.Text, minutesText.Text + ":" + secondsText.Text, val1 * val2);
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);

            _minutes = 0;
            _seconds = 0;

            ShowTime();

            var db = new DBConnection("139.162.169.28", "robomaze", "robomaze", "0HRPdPVVM5flg5Zt");

            db.insertHighscore(textBox1.Text, "", val3, time);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            _minutes = 0;
            _seconds = 0;

            ShowTime();

            btnStart.Visible = true;
            btnStop1.Visible = false;
            timer1.Enabled = false;
            label2.Text = "";
            pictureBox7.Visible = false;

            dataGridView1.Rows.Clear();
            pictureBox5.Visible = false;
        }
    }
}
