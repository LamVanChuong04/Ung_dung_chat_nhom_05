using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungChat1_1.Properties;

namespace UngDungChat1_1
{
    
    public partial class Form2 : Form
    {
        public string emailname { set; get; }
        public Form2()
        {
            InitializeComponent();
        }

        string constring = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=dd;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = emailname;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from login WHERE email = '" + label2.Text + "'";

            SqlCommand cmd = new SqlCommand(q, con);

            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
                label2.Text = dataReader[0].ToString();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f1 = new Form();
            this.Hide();
            f1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private bool check;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {

                panel1.Width += 10;
                if (panel1.Size == panel1.MaximumSize)
                {
                    pictureBox1.Left += 350;
                    timer1.Stop();
                    check = false;
                    pictureBox1.Image = Resources.quaylai;
                }
            }
            else
            {

                panel1.Width -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    pictureBox1.Left += 100;
                    timer1.Stop();
                    check = true;
                    pictureBox1.Image = Resources.menu;
                }
            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (panel4.Visible == false)
            {
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
            }
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {

        }
        private void guna2Button6_Click_(object sender, EventArgs e)
        {
           
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
