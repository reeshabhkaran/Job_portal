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
    public partial class Form12 : Form
    {
        connectio ca = new connectio();
        string u_id;

        public Form12(string u_id)
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

                cmd.CommandText = "select name,email,age,gender,objective,department,designation,year,qualification,interest from user natural join resume where u_id='" + u_id + "'";
                cmd.Connection = ca.getConnection();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    label11.Text = reader["name"].ToString();
                    label12.Text = reader["email"].ToString();
                    label13.Text = reader["age"].ToString();
                    label14.Text = reader["gender"].ToString();
                    label15.Text = reader["objective"].ToString();
                    label20.Text = reader["department"].ToString();
                    label21.Text = reader["designation"].ToString();
                    label23.Text = reader["year"].ToString();
                    label17.Text = reader["qualification"].ToString();
                    label18.Text = reader["interest"].ToString();
                }

                ca.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(u_id);            
            f7.Show();
            this.Hide();
        }
    }
}
