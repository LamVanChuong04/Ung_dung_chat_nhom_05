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


        string constring = "Data Source=DESKTOP-V1Q8O89\\MSSQLSERVER01;Initial Catalog=chat;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

       


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
            {
                label2.Text = dataReader["email"].ToString();
                textBox1.Text = dataReader["firstname"].ToString();
                textBox5.Text = dataReader["firstname"].ToString();

                textBox2.Text = dataReader["lastname"].ToString();
                textBox6.Text = dataReader["lastname"].ToString();
                textBox3.Text = dataReader["email"].ToString();
                textBox7.Text = dataReader["email"].ToString();

                textBox4.Text = dataReader["password"].ToString();
                
            }
                

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

        // code gặp vấn đề ở phần này 56-86

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

        // ////////

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
      

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //test commit
        private void button6_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void showprofile()
        {
            label2.Text = emailname;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from login WHERE email = '" + textBox7.Text + "'";

            SqlCommand cmd = new SqlCommand(q, con);

            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                label2.Text = dataReader["email"].ToString();
                textBox1.Text = dataReader["firstname"].ToString();
                textBox5.Text = dataReader["firstname"].ToString();

                textBox2.Text = dataReader["lastname"].ToString();
                textBox6.Text = dataReader["lastname"].ToString();

                textBox3.Text = dataReader["email"].ToString();
                textBox7.Text = dataReader["email"].ToString();

                textBox4.Text = dataReader["password"].ToString();

            }


            con.Close();
        }

        // Hàm Save
        private void button7_Click(object sender, EventArgs e)
        {

            





            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = " UPDATE Login SET password = '" + textBox4.Text + "',firstname=@fname, lastname=@lname,email=@email";
            

            //-> dòng này code ảnh mà ko dùng nên ko code  

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@fname", textBox5.Text);
            cmd.Parameters.AddWithValue("@lname", textBox6.Text);
            cmd.Parameters.AddWithValue("@email", textBox7.Text);

            cmd.ExecuteNonQuery();
           
            con.Close() ;
            MessageBox.Show("Profile is update");
            showprofile();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (check)
            {

                panel7.Height += 10;
                if (panel7.Size == panel7.MaximumSize)
                {
                    
                    timer2.Stop();
                    check = false;
                    button10.Image = Resources.muiten_lenxuong;
                }
            }
            else
            {

                panel7.Height -= 10;
                if (panel7.Size == panel7.MinimumSize)
                {
                    
                    timer2.Stop();
                    check = true;
                    button10.Image = Resources.muiten_lenxuong;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer2.Start(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel6.BringToFront();
            if (panel6.Visible == false)
            {
                panel6.Visible = true;
            }
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
        }
        // SAVE update password
        private void button11_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string query = "UPDATE login SET Password = @newPassword WHERE email = @Email AND Password = @oldPassword";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@newPassword", textBox9.Text);
                    cmd.Parameters.AddWithValue("@Email", label2.Text);
                    cmd.Parameters.AddWithValue("@oldPassword", textBox8.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password has been changed.");
                    }
                    else
                    {
                        MessageBox.Show("No matching record found or password not changed.");
                    }
                }
            }
        }
        // update password
        private void button9_Click(object sender, EventArgs e)
        {

            panel8.BringToFront();
            if (panel8.Visible == false && panel6.Visible == false)
            {
                panel8.Visible = true;
                panel6.Visible = true;
            }
            if (panel6.Visible == true)
            {
                panel8.Visible = true;
            }
            if (panel9.Visible == true)
            {
                panel8.Visible = false;
                panel6.Visible = true;
            }
        }
        

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox8.PasswordChar == '*' && textBox9.PasswordChar == '*' && textBox10.PasswordChar == '*')
            {
                textBox8.PasswordChar = '\0';
                textBox9.PasswordChar = '\0';
                textBox10.PasswordChar = '\0';
            }
            else
            {
                textBox8.PasswordChar = '*';
                textBox9.PasswordChar = '*';
                textBox10.PasswordChar = '*';
            }
        }
        // chat
        private void button3_Click(object sender, EventArgs e)
        {
            UserItem();
            panel9.BringToFront();
            if (panel9.Visible == false && panel8.Visible == false && panel6.Visible == false) {
                panel6.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;


            }
            if (panel8.Visible == true)
            {
                panel6.Visible = false;
                panel9.Visible = true;
            }
            if (panel6.Visible == true)
            {
                panel6.Visible= false;
                panel8.Visible = true; 
                panel9.Visible = true;
            }
        }
        // home
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true || panel8.Visible == true || panel9.Visible == true)
            {
                panel6.Visible = false; 
                panel9.Visible = false;
                panel8.Visible = false;

            }
        }

        // 

        private void UserItem()
        {
            flowLayoutPanel1.Controls.Clear();
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter("select * from login", constring);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table != null)
            {
                UserControl1[] userControls = new UserControl1[table.Rows.Count];
                for (int i = 0; i<1; i++)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        userControls[i] = new UserControl1();
                        userControls[i].Title = row["firstname"].ToString();
                        if (userControls[i].Title == label1.Text)
                        {
                            flowLayoutPanel1.Controls.Remove(userControls[i]);
                        }
                        else
                        {
                            flowLayoutPanel1.Controls.Add(userControls[i]);
                        }
                        userControls[i].Click += new System.EventHandler(this.button3_Click);
                    }
                }
            }

        }
    }
}
