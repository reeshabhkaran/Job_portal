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
    public partial class Form8 : Form
    {
        connectio ca = new connectio();
        string co_id;
        MySqlDataAdapter sda;
        //MySqlCommandBuilder scb;
        DataTable dt;

        public Form8(string co_id)
        {
            InitializeComponent();
            this.co_id = co_id;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ca.OpenConnection())
            {
                int j_id = int.Parse(textBox1.Text);
                string description = textBox2.Text;
                string designation = comboBox1.Text;
                string department = comboBox2.Text;
                double salary = double.Parse(textBox3.Text);
                string qualification = comboBox3.Text;
                int year = int.Parse(numericUpDown1.Text);

                int id = int.Parse(co_id);

                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO job VALUES('" + j_id + "','" + co_id + "','" + description + "','" + designation + "','" + salary + "','" + department + "','" + qualification + "','" + year + "');";
                cmd.Connection = ca.getConnection();

                //Execute command
                cmd.ExecuteReader();

                MessageBox.Show("Successfully submitted !!!");
                textBox1.Text = comboBox3.Text = comboBox2.Text = textBox2.Text = comboBox1.Text = numericUpDown1.Text = textBox3.Text = "";


                //close connection
                ca.CloseConnection();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string u_id = textBox6.Text;
            string j_id = textBox7.Text;
            string cp = textBox8.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into company_accepted values('" + co_id + "','" + u_id + "','" + j_id + "','" + cp + "');";
                cmd.Connection = ca.getConnection();
                cmd.ExecuteNonQuery();

                ca.CloseConnection();
            }
            MessageBox.Show("Applicants approved !!!");

            textBox6.Text = textBox7.Text = textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select u_id as User_Id,name as Name,j_id as Job_Id,email as Email_Id from user natural join accepted_job where co_id ='"+co_id+"'";


            if (ca.OpenConnection())
            {
                sda = new MySqlDataAdapter(query, ca.getConnection());
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                ca.CloseConnection();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string u_id = textBox9.Text;
            string name = textBox5.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select u_id,name from user where u_id=@u_id and name=@name";
                cmd.Parameters.AddWithValue("@u_id", textBox9.Text);
                cmd.Parameters.AddWithValue("@name", textBox5.Text);
                cmd.Connection = ca.getConnection();


                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    Form13 f13 = new Form13(u_id);
                    f13.Show();
                    this.Hide();
                }
                else
                    label21.Text = "User ID or Name did not match. Try Again !!!";

                ca.CloseConnection();
            }
        }       
    }
}