using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using windows_forums_main1.Properties;
using System.Diagnostics;


namespace windows_forums_main1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Валидация
            this.textBox7.Validating += new CancelEventHandler(Verti);
            //При голям екран да не се разхвърля.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

           
        //Метод за затаряне с даден бутон и звук при натискане.
        private void button5_Click(object sender, EventArgs e)
        {
            Console.Beep();
            Close();
        }

   

        //Метод за ограничаване на въвеждането.
        private void Verti(object sender, CancelEventArgs e)
        {
            //Ограничава символите които могат да се използват.

            string reg_name = "^[A-Z]{1}[a-z]{1,9}$";
            Regex reg = new Regex(reg_name);
            TextBox tb = (TextBox)sender;

            if (reg.IsMatch(tb.Text))
            {
                //MessageBox.Show("OK!!!");
                //Достъпваме и ако е true да излезе зелен цвят.
                this.textBox7.Tag = true;
                ForeColor = Color.Green;
                 Text = "Name is OK!";
            }
            else
            {
                //MessageBox.Show("Wrong name!!!");
                this.textBox7.Tag = false;
                ForeColor = Color.Red;
                Text = "Name is wrong!";
            }
            

        }

        //Метод за зареждане на снимка.
        

        private void button2_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                

                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    imageLocation = dialog.FileName;
                    //Достъпваме изображението по локацията.
                    pictureBox1.ImageLocation = imageLocation;


                }

            }
            catch (Exception)
            {

                MessageBox.Show("An Error Ocured","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }


        }

        //Метод за отваряне на хиперлинка.
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Да зареди линка в скобите.
            Process.Start("https://www.unibit.bg/");
        }

        //Метод за  известяване  при минимизирането на форума .
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "The form is minimized";
                notifyIcon1.ShowBalloonTip(1000);

            }
            else if(this.WindowState == FormWindowState.Normal)
            {
                notifyIcon1.BalloonTipText = "Normal mode";
                notifyIcon1.ShowBalloonTip(1000);

            }



        }
    }
}
