using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_APP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Students (Name, Grade, Subject, Marks) VALUES (@Name, @Grade, @Subject, @Marks)", con);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Grade", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Subject", textBox3.Text);
            cmd.Parameters.AddWithValue("@Marks", textBox4.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully Inserted!");

        }

        private void button4_Click(object sender, EventArgs e)
        {

           
             SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True");

                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from dbo.Students", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

            con.Close();

        }



        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("delete dbo.Students where Name=@Name", con);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully Deleted!");

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("Update dbo.Students set Name=@Name,Grade=@Grade, Subject=@Subject where Marks=@Marks ", con);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Grade", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Subject", textBox3.Text);
            cmd.Parameters.AddWithValue("@Marks", textBox4.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Updated Successfully!");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

   

