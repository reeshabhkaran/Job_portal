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
    public partial class Form11 : Form
    {
        connectio ca = new connectio();
        string u_id;

        public Form11(string u_id)
        {
            InitializeComponent();
            this.u_id = u_id;
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(u_id);
            f6.Show();
            this.Hide();
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

                    textBox1.Text = reader["name"].ToString();
                    textBox2.Text = reader["email"].ToString();
                    textBox3.Text = reader["age"].ToString();
                    textBox4.Text = reader["gender"].ToString();
                    textBox5.Text = reader["phone"].ToString();

                }

                ca.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            int age = int.Parse(textBox3.Text);
            string gender = textBox4.Text;
            string phone = textBox5.Text;

            if (ca.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = "update user set name='"+name+"',email='"+email+"',age='"+age+"',gender='"+gender+"',phone='"+phone+"' where u_id='" + u_id + "'";
                cmd.Connection = ca.getConnection();

                cmd.ExecuteNonQuery();

                ca.CloseConnection();
            }
            MessageBox.Show("Information successfully updated !!!!");
        }
    }
}
