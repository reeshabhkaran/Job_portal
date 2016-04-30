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
    public partial class Form7 : Form
    {
        connectio ca = new connectio();
        string c_id;
        MySqlDataAdapter sda;
        //MySqlCommandBuilder scb;
        DataTable dt;

        public Form7(string c_id)
        {
            InitializeComponent();
            this.c_id = c_id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string u_id = textBox2.Text;
            string name = textBox3.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select u_id,name from user where u_id=@u_id and name=@name";
                cmd.Parameters.AddWithValue("@u_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.Connection = ca.getConnection();


                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    Form12 f12 = new Form12(u_id);
                    f12.Show();
                    this.Hide();
                }
                else
                    label21.Text = "User ID or Name did not match. Try Again !!!";

                ca.CloseConnection();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string u_id = textBox4.Text;
            string j_id = textBox5.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into consultant_suggestion values('" + u_id + "','" + c_id + "','" + j_id + "');";
                cmd.Connection = ca.getConnection();
                cmd.ExecuteNonQuery();

                ca.CloseConnection();
            }
            MessageBox.Show("Successfully suggested !!!");

            textBox5.Text = textBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string co_id = textBox6.Text;
            string u_id = textBox7.Text;
            string j_id = textBox8.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into accepted_job values('" + co_id + "','" + u_id + "','" + j_id + "');";
                cmd.Connection = ca.getConnection();
                cmd.ExecuteNonQuery();

                ca.CloseConnection();
            }
            MessageBox.Show("Details successfully forwarded !!!!");

            textBox8.Text = textBox7.Text = textBox6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select u_id as User_Id,co_id as Company_Id,j_id as Job_Id from user_apply";


            if (ca.OpenConnection())
            {
                sda = new MySqlDataAdapter(query, ca.getConnection());
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView3.DataSource = dt;

                ca.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {              
                string query = "select co_id as Company_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where qualification = '" + comboBox6.Text + "'";

                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;                   

                    ca.CloseConnection();
                }
            }
            else if (radioButton2.Checked)
            {
                string query = "select co_id as Company_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where department = '" + comboBox1.Text + "'";

                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    ca.CloseConnection();
                }
            }
            else if (radioButton3.Checked)
            {
                string query = "select co_id as Comapny_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where designation = '" + comboBox5.Text + "'";

                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    ca.CloseConnection();
                }
            }
            else if (radioButton4.Checked)
            {
                string query = "select co_id as Company_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where year = '" + numericUpDown2.Text + "'";
            
                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    ca.CloseConnection();
                }
            }
            else
            {
                string query = "select co_id as Comapny_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job";

                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    ca.CloseConnection();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                string query = "select u_id as User_Id,name as Name,qualification as Qualification,department as Department,designation as Designation,year as Experience,email as Email_Id from user natural join resume where qualification = '" + comboBox3.Text + "'";

                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;

                    ca.CloseConnection();
                }
            }
            else if (radioButton6.Checked)
            {
                string query = "select u_id as User_Id,name as Name,qualification as Qualification,department as Department,designation as Designation,year as Experience,email as Email_Id from user natural join resume where department = '" + comboBox4.Text + "'";
                
                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;

                    ca.CloseConnection();
                }
            }
            else if (radioButton7.Checked)
            {
                string query = "select u_id as User_Id,name as Name,qualification as Qualification,department as Department,designation as Designation,year as Experience,email as Email_Id from user natural join resume where designation = '" + comboBox2.Text + "'";
                
                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;

                    ca.CloseConnection();
                }
            }
            else if (radioButton8.Checked)
            {
                string query = "select u_id as User_Id,name as Name,qualification as Qualification,department as Department,designation as Designation,year as Experience,email as Email_Id from user natural join resume where year = '" + numericUpDown1.Text + "'";
                
                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;

                    ca.CloseConnection();
                }
            }
            else
            {
                string query = "select u_id as User_Id,name as Name,qualification as Qualification,department as Department,designation as Designation,year as Experience,email as Email_Id from user natural join resume";
                
                if (ca.OpenConnection())
                {
                    sda = new MySqlDataAdapter(query, ca.getConnection());
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;

                    ca.CloseConnection();
                }
            }
        }
    }
}