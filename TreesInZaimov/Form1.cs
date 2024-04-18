using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreesInZaimov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string conectionString = "server=192.168.1.38;" +
                "user=PC1;" +
                "password=1111;" +
                "port=3306;" +
                "database=trees_zaimov";

            MySqlConnection connect = new MySqlConnection(conectionString);
            if (connect.State == 0)
            {
                connect.Open();
            }
            MessageBox.Show("imash vruzka s Belezirava HeidiSQL");

            string insertQueryText = "INSERT INTO trees_zaimov.class " +
                "(`name`, `name_bg` ) " +
                "VALUES " +
                "(@name, @name_bg)";

            MySqlCommand query = new MySqlCommand(insertQueryText, connect);
            query.Parameters.AddWithValue("@name", txtbox.Text);
            query.Parameters.AddWithValue("@name_bg", txtbox2.Text);


            int result = query.ExecuteNonQuery();
            if (result != 0)
            {
                MessageBox.Show($"dobavi {result} records!");
            }

            connect.Close();
        }
    }
}
