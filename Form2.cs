﻿using Guna.UI2.WinForms;
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

namespace UngDungChat1_1
{
    
    public partial class Form2 : Form
    {
        public string emailname { set; get; }
        public Form2()
        {
            InitializeComponent();
        }

        string constring = "Data Source=DESKTOP-IRECBMN\\SQLEXPRESS;Initial Catalog=dd;Integrated Security=True;Trust Server Certificate=True";

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = "Email Name";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from Login WHERE email = '" + label2.Text + "'";

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
    }
}
