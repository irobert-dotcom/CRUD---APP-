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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void logButton_Click(object sender, EventArgs e)
        {
            String username, password;

            username = txt_username.Text;
            password = txt_password.Text;

                try
                {
                    con.Open();

                    String query = "SELECT * FROM [dbo].[Users] WHERE username = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@username", txt_username.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txt_password.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login Credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_username.Clear();
                        txt_password.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_Show_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1_Show.Checked)
            {

                txt_password.UseSystemPasswordChar = true;


            }
            else
            {
                txt_password.UseSystemPasswordChar = false;

            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
