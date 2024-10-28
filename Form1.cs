using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Guna.UI2.WinForms;

namespace UngDungChat1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string constring = "Data Source=DESKTOP-IRECBMN\\SQLEXPRESS;Initial Catalog=dd;Integrated Security=True;Trust Server Certificate=True";

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
           
            
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonLogin.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstnameText.Text.Trim()))
            {
                errorProvider1.SetError(firstnameText, "firstname is required");
                return;
            }
            else
            {
                errorProvider1.SetError(firstnameText, string.Empty);
            }
            if (string.IsNullOrEmpty(lastnameText.Text.Trim()))
            {
                errorProvider1.SetError(lastnameText, "lastname is required");
                return;
            }
            else
            {
                errorProvider1.SetError(lastnameText, string.Empty);
            }
            if (string.IsNullOrEmpty(emailText.Text.Trim()))
            {
                errorProvider1.SetError(emailText, "email is required");
                return;
            }
            else
            {
                errorProvider1.SetError(emailText, string.Empty);
            }
            if (string.IsNullOrEmpty(passwordText.Text.Trim()))
            {
                errorProvider1.SetError(passwordText, "password is required");
                return;
            }
            else
            {
                errorProvider1.SetError(passwordText, string.Empty);
            }
            if (string.IsNullOrEmpty(confirmText.Text.Trim()))
            {
                errorProvider1.SetError(confirmText, "firstname is required");
                return;
            }
            else
            {
                errorProvider1.SetError(confirmText, string.Empty);
            }

            if (passwordText.Text != confirmText.Text)
                MessageBox.Show("password not equal");
            else
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                string q = "insert into Login(firstname, lastname, email, password, confirmpass, image)values(@firstname,@lastname,@email, @password, @confirmpass, @image)";
                SqlCommand cmd = new SqlCommand(q, con);
                MemoryStream me = new MemoryStream();
                cmd.Parameters.AddWithValue("firstname", firstnameText.Text);
                cmd.Parameters.AddWithValue("lastname", lastnameText.Text);
                cmd.Parameters.AddWithValue("email", emailText.Text);
                cmd.Parameters.AddWithValue("password", passwordText.Text);
                cmd.Parameters.AddWithValue("confirmpass", confirmText.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registration successfully. .... ");
                firstnameText.Clear();
                lastnameText.Clear();
                emailText.Clear();
                passwordText.Clear();
                confirmText.Clear();
                con.Close();
            }
            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailloginText.Text.Trim()))
            {
                errorProvider1.SetError(emailloginText, "email is required");
                return;
            }
            else
                errorProvider1.SetError(emailloginText, string.Empty);

            if (string.IsNullOrEmpty(passwordloginText.Text.Trim()))
            {
                errorProvider1.SetError(passwordloginText, "password is required");
                return;
            }
            else
            {
                errorProvider1.SetError(passwordloginText, string.Empty);
            }
            SqlConnection con = new SqlConnection(constring);
            string q = "select * from Login WHERE login = '" + emailloginText.Text + "'AND password = '" + passwordloginText.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows == true)
            {
                panel1.BringToFront();
                timer1.Start();
            }
                
            else
                MessageBox.Show("please check your email and password");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
                progressBar1.Value += 2;
            else
            {
                timer1.Stop();
                Form2 f2 = new Form2();
                f2.emailname = emailloginText.Text;
                this.Hide();
                f2.Show();
            }  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
