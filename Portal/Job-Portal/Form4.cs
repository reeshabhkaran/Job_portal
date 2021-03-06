﻿using System;
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
    public partial class Form4 : Form
    {
        connectio ca = new connectio();
        connectio co = new connectio();

        public Form4()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select username,password from consultant where username=@username and password=@password";
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Connection = ca.getConnection();


                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    if (co.OpenConnection())
                    {
                        MySqlCommand cmd1 = new MySqlCommand();

                        cmd1.CommandText = "select c_id from consultant where username='" + user + "' and password='" + pass + "'";                        
                        cmd1.Connection = co.getConnection();
                        MySqlDataReader reader = cmd1.ExecuteReader();
                        reader.Read();
                        label6.Text = reader["c_id"].ToString();

                        reader.Close();
                    }
                    co.CloseConnection();

                    Form7 f7 = new Form7(label6.Text);
                    f7.Show();
                    this.Hide();
                }

                else
                    label5.Text = "Invalid credentials !!!";

                ca.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}