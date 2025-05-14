using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;// Use System.Data.SQLite for SQLite

public class DatabaseHelper
{
    private string connectionString;

    public DatabaseHelper(string connString)
    {
        connectionString = connString;
    }

    public bool InsertStudent(string name, int grade, string subject, string marks)
    {
        using (SqlConnection conn = new SqlConnection(connectionString)) // Use SQLiteConnection for SQLite
        {
            string query = "INSERT INTO Students (Name, Grade, Subject, Marks) VALUES (@Name, @Grade, @Subject, @Marks)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@Subject", subject);
                cmd.Parameters.AddWithValue("@Marks", marks);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log error or show a message
                    Console.WriteLine("Error inserting student: " + ex.Message);
                    return false;
                }
            }
        }
    }
    public DataTable GetAllStudents()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Students";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching students: " + ex.Message);
                    return null;
                }
            }
        }
    }
    public bool DeleteStudentByFullName(string firstName)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE FirstName = @FirstName"; // Assuming column is FirstName

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true; // Student deleted successfully
                    }
                    else
                    {
                        MessageBox.Show("No student found with the given first name.");
                        return false;
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show("SQL error while deleting student: " + ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unexpected error: " + ex.Message);
            return false;
        }
    }
    public bool UpdateStudent(int id, string name, int grade, string subject, string marks)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "UPDATE Students SET Name = @Name, Grade = @Grade, Subject = @Subject, Marks = @Marks WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@Subject", subject);
                cmd.Parameters.AddWithValue("@Marks", marks);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating student: " + ex.Message);
                    return false;
                }
            }
        }
    }
    public bool DeleteStudentById(int id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Students WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL Error while deleting student: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
