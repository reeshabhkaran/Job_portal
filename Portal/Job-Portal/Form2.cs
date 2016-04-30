using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Job_Portal
{
    public partial class Form2 : Form
    {
        connectio ca = new connectio();
               
        public Form2()
        {
            InitializeComponent();
            textBox7.PasswordChar = '*';
        }

        private int numberpass(String pass)
        {
            int num = 0;

            foreach (char ch in pass)
            {
                if (char.IsDigit(ch))
                {
                    num++;
                }
            }
            return num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string g;

                if (radioButton1.Checked)
                    g = "Male";
                else g = "Female";

                string name = textBox1.Text;
                string email = textBox2.Text;

                string phone = textBox5.Text;
                string username = textBox6.Text;
                string password = textBox7.Text;

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);


                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false) || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                {
                    label10.Text = "Kindly fill all the details";
                }
                else if (phone.Length < 10)
                {
                    label10.Text = "Enter phone number again (10 digits)";
                }
                else if (numberpass(password) < 1)
                {
                    label10.Text = "Password should contain atleast one number (alphanumeric)";
                }
                else if (match.Success == false)
                {
                    label10.Text = "Invalid email id format";
                }
                else
                {
                    label10.Text = "";
                    int age = int.Parse(textBox3.Text);

                    string query = "INSERT INTO user(name,email,age,gender,phone,username,password) VALUES('" + name + "','" + email + "','" + age + "','" + g + "','" + phone + "','" + username + "','" + password + "');";

                    //open connection
                    if (ca.OpenConnection())
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, ca.getConnection());

                        //Execute command
                        cmd.ExecuteReader();

                        //close connection
                        ca.CloseConnection();
                    }

                    MessageBox.Show("You have been successfully registered !!!");

                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                label10.Text = "Enter valid age";
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
