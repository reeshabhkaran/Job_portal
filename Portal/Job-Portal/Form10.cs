using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Job_Portal
{
    public partial class Form10 : Form
    {
        connectio ca = new connectio();
        string u_id;

        public Form10(string u_id)
        {
            InitializeComponent();
            this.u_id = u_id;
            display();
            
        }

        public void display()
        {
            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = "select name,email,age,gender,phone from user where u_id='" + u_id + "'";
                cmd.Connection = ca.getConnection();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                    label8.Text = reader["name"].ToString();        
                    label9.Text = reader["email"].ToString();       
                    label10.Text = reader["age"].ToString();
                    label11.Text = reader["gender"].ToString();
                    label12.Text = reader["phone"].ToString();

                }
               
                ca.CloseConnection(); 
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(u_id);
            f6.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(u_id);
            f11.Show();
            this.Hide();
        }

       
    }
}
