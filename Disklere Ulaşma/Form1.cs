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

namespace Disklere_Ulaşma
{
    public partial class Form1 : Form
    {
        DriveInfo[] diskler = DriveInfo.GetDrives();

        long diskb, diskt, diskk;

        int a;

        public void diskkontrol(string sürücüadı2)
        {
            a = 0;

            foreach (DriveInfo disk in diskler)
            {
                if (disk.IsReady==true && sürücüadı2==disk.Name)
                {
                   
                    diskb = disk.TotalFreeSpace;
                    diskt = disk.TotalSize;
                    diskk = diskt-diskb;
                    


                    label4.Text = sürücüadı2;
                    label6.Text = (diskt / (1024*1024*1024))+" GB".ToString();
                    label8.Text = (diskk / (1024 * 1024 * 1024))+" GB".ToString();
                    label10.Text = (diskb / (1024 * 1024 * 1024))+" GB".ToString();
                    a++;

                }

                if (a==0)
                {
                    label4.Text = "";
                    label6.Text = "";
                    label8.Text = "";
                    label10.Text = "";
                    label11.Text = "Böyle bir disk yoktur.";
                }

                else
                {
                    label11.Text = "";
                }
               
            }


        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            diskkontrol(sürücü);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string harf = "ABCDEFGHIİJKLMNOÖPRSŞTUÜVYZQWX";

            foreach (char harf2 in harf)
            {
                string sürücüadı = harf2 + ":\\";
                comboBox1.Items.Add(sürücüadı);
            }
        }

        string sürücü;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sürücü = comboBox1.SelectedItem.ToString();
        }
    }
}
