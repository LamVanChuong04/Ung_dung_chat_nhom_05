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

        string constring = "Data Source=DESKTOP-V1Q8O89\\MSSQLSERVER01;Initial Catalog=chat;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        


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
            if (!ValidateInput()) return;

            if (passwordText.Text != confirmText.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            RegisterUser();
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(firstnameText.Text.Trim()))
            {
                errorProvider1.SetError(firstnameText, "Firstname is required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(firstnameText, string.Empty);
            }

            if (string.IsNullOrEmpty(lastnameText.Text.Trim()))
            {
                errorProvider1.SetError(lastnameText, "Lastname is required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(lastnameText, string.Empty);
            }

            if (string.IsNullOrEmpty(emailText.Text.Trim()))
            {
                errorProvider1.SetError(emailText, "Email is required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(emailText, string.Empty);
            }

            if (string.IsNullOrEmpty(passwordText.Text.Trim()))
            {
                errorProvider1.SetError(passwordText, "Password is required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(passwordText, string.Empty);
            }

            if (string.IsNullOrEmpty(confirmText.Text.Trim()))
            {
                errorProvider1.SetError(confirmText, "Confirm password is required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(confirmText, string.Empty);
            }

            return isValid;
        }

        private void RegisterUser()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string q = "INSERT INTO login(firstname, lastname, email, password, confirmpass) VALUES (@firstname, @lastname, @email, @password, @confirmpass)";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    // Consider hashing the password here
                    cmd.Parameters.AddWithValue("@firstname", firstnameText.Text);
                    cmd.Parameters.AddWithValue("@lastname", lastnameText.Text);
                    cmd.Parameters.AddWithValue("@email", emailText.Text);
                    cmd.Parameters.AddWithValue("@password", passwordText.Text); // Hash this
                    cmd.Parameters.AddWithValue("@confirmpass", confirmText.Text); // Hash this
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            MessageBox.Show("Registration successfully.");
            ClearFields();
        }

        private void ClearFields()
        {
            firstnameText.Clear();
            lastnameText.Clear();
            emailText.Clear();
            passwordText.Clear();
            confirmText.Clear();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailloginText.Text.Trim()))
            {
                errorProvider1.SetError(emailloginText, "Email is required");
                return;
            }
            else
            {
                errorProvider1.SetError(emailloginText, string.Empty);
            }

            if (string.IsNullOrEmpty(passwordloginText.Text.Trim()))
            {
                errorProvider1.SetError(passwordloginText, "Password is required");
                return;
            }
            else
            {
                errorProvider1.SetError(passwordloginText, string.Empty);
            }

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string q = "SELECT * FROM Login WHERE email = @Email AND password = @Password";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@Email", emailloginText.Text);
                    cmd.Parameters.AddWithValue("@Password", passwordloginText.Text);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            panel1.BringToFront();
                            timer1.Start();
                        }
                        else
                        {
                            MessageBox.Show("Please check your email and password");
                        }
                    }
                }
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void lastnameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailloginText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailloginText.Text.Trim()))
            {
                errorProvider1.SetError(emailloginText, "Email is required");
                return;
            }
            else
            {
                errorProvider1.SetError(emailloginText, string.Empty);
            }

            if (string.IsNullOrEmpty(passwordloginText.Text.Trim()))
            {
                errorProvider1.SetError(passwordloginText, "Password is required");
                return;
            }
            else
            {
                errorProvider1.SetError(passwordloginText, string.Empty);
            }

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string q = "SELECT * FROM Login WHERE email = @Email AND password = @Password";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@Email", emailloginText.Text);
                    cmd.Parameters.AddWithValue("@Password", passwordloginText.Text);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            panel1.BringToFront();
                            timer1.Start();
                        }
                        else
                        {
                            MessageBox.Show("Please check your email and password");
                        }
                    }
                }
            }
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordloginText.PasswordChar == '*')
            {
                passwordloginText.PasswordChar = '\0';
            }
            else
            {
                passwordloginText.PasswordChar = '*';
            }
        }
    }
}
