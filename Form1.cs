﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trisClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.setInitial();
        }

        protected void setInitial()
        {
            clockLabel.Text = DateTime.Now.ToString("hh") + ":" + DateTime.Now.ToString("mm") + ":" + DateTime.Now.ToString("ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] time = this.clockLabel.Text.Split(':');
            int tick = Convert.ToInt16(time[2]) + 1;
            time[2] = tick.ToString();
            this.clockLabel.Text = string.Join(":", time);

            countingTime(time);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] time = this.clockLabel.Text.Split(':');

            int sec = (this.addScTextbox.Text == "") ?
                Convert.ToInt32(time[2]) : Convert.ToInt16(time[2]) + Convert.ToInt16(this.addScTextbox.Text);
            int min = (this.AddMtTextbox.Text == "") ?
                Convert.ToInt32(time[1]) : Convert.ToInt16(time[1]) + Convert.ToInt16(this.AddMtTextbox.Text);
            int hr = (this.addHrTextBox.Text == "") ?
                Convert.ToInt32(time[0]) : Convert.ToInt16(time[0]) + Convert.ToInt16(this.addHrTextBox.Text);

            this.clockLabel.Text = hr.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
            countingTime(this.clockLabel.Text.Split(':'));
        }

        protected void countingTime(string[] time)
        {
            double sec = Convert.ToInt32(time[2]);
            double min = Convert.ToInt32(time[1]);
            double hr = Convert.ToInt32(time[0]);

            if (sec > 59)
            {
                min = min + Convert.ToInt16(sec / 60);
                sec = sec - (int)(sec / 60 * 60);
            }
            if (min > 59)
            {
                hr = hr + Convert.ToInt16(min / 60);
                min = min - (int)(min / 60 * 60);
            }

            if (hr > 23)
                hr = hr - (int)(hr / 24 * 24);

            this.clockLabel.Text = hr.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
        }
    }
}
