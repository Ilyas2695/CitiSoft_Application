﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CitiSoft
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(DataBaseManager.functionalityConnectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error" + ex.ToString());
                throw;
            }


            string query = "SELECT email,password,uType FROM User WHERE email='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            //int result = Convert.ToInt32(cmd.ExecuteScalar());
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                this.Hide();
                if (dt.Rows[0][2].ToString() == "admin")
                {
                    MainUI form = new MainUI();
                    form.Show();
                }
                else if (dt.Rows[0][2].ToString() == "manager")
                {
                    MainUI form2 = new MainUI();
                    form2.Show();
                }
                else if (dt.Rows[0][2].ToString() == "user")
                {
                    MainUI form2 = new MainUI();
                    form2.Show();
                }


            }
            else
            {
                MessageBox.Show("USER OR PASSWORD ARE INCORRECT");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
