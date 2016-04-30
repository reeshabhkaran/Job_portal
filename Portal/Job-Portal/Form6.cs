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
    public partial class Form6 : Form
    {
        connectio ca = new connectio();
        string u_id;
        MySqlDataAdapter sda;        
        DataTable dt;

        public Form6(string u_id)
        {                  
            InitializeComponent();
            this.u_id = u_id;
        }

        public Form6()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9(u_id);
            f9.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10(u_id);
            f10.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string objective = textBox1.Text;
            string department = comboBox3.Text;
            string designation = comboBox6.Text;            
            int year = int.Parse(numericUpDown2.Text);
            string qualification = comboBox4.Text;
            string interest = textBox4.Text;  
                        
            //open connection
            if (ca.OpenConnection())
            {
                int id = int.Parse(u_id);    
                
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO resume VALUES('" + id + "','" + objective + "','" + department + "','" + designation + "','" + year + "','" + qualification + "','" + interest + "');";
                cmd.Connection = ca.getConnection();

                //Execute command
                cmd.ExecuteReader();

                MessageBox.Show("Successfully submitted !!!");
                textBox1.Text = comboBox3.Text = comboBox6.Text = numericUpDown2.Text = comboBox4.Text = textBox4.Text = "";
                

                //close connection
                ca.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox3.Text = comboBox6.Text = numericUpDown2.Text = comboBox4.Text = textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string query = "select co_id as Company_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where qualification = '" + comboBox1.Text + "'";


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
                string query = "select co_id as Comapany_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where department = '" + comboBox2.Text + "'";


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
                string query = "select co_id as Comapany_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where designation = '" + comboBox5.Text + "'";


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
                string query = "select co_id as Company_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job where year = '" + numericUpDown1.Text + "'";


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
                string query = "select co_id as Company_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from job";


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

        private void button4_Click(object sender, EventArgs e)
        {
            string co_id = textBox5.Text;
            string j_id = textBox6.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into user_apply values ('"+co_id+"','"+u_id+"','"+j_id+"');";
                
                cmd.Connection = ca.getConnection();
                cmd.ExecuteReader();

                ca.CloseConnection();
            }
            MessageBox.Show("Successfully applied. Check response in'Accepted Job' tab.");

            textBox5.Text = textBox6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select co_id as User_Id,j_id as Job_Id,description as Description,designation as Designation,department as Department,qualification as Qualification,year as Experience from consultant_suggestion natural join job where u_id = '" + u_id + "'";


            if (ca.OpenConnection())
            {
                sda = new MySqlDataAdapter(query, ca.getConnection());
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;

                ca.CloseConnection();
            }
            else
                MessageBox.Show("No recommendations for now. Please wait !!!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "select name as Name,j_id as Job_Id,description as Description,designation as Designation,contact as Contact_Person from company natural join job natural join company_accepted where u_id = '"+u_id+"'";

            if (ca.OpenConnection())
            {
                sda = new MySqlDataAdapter(query, ca.getConnection());
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView3.DataSource = dt;

                ca.CloseConnection();
            }  
        }
    }
}
