﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// jhasbfjigdurqebgjbfugherugbjebvihbguhebgjbgihjerfvuowdbvn  fhdsfgu   w8bfejsbfwgbu8obfeehf sh ffdvbufhuwvfhwvfu8wfge befvuydvfufv
namespace UngDungChat1_1
{   
    //UserControl
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private string _tittle;
        public string Title
        { 
            get { return _tittle; } 
            set {  _tittle = value;
                label1.Text = value;
                } 
        
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
