using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DBManager;

namespace newYAO
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            passwordField.UseSystemPasswordChar = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;


            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                // Open the connection
                connection.Open();

                // Create a SQL command to select the user with the given username and password
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [user] WHERE username = @username AND password = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                // Execute the command and get the result
                int result = (int)command.ExecuteScalar();

                // Check if the result is greater than zero
                if (result > 0)
                {
                    // Login successful, close the login form and show the main form
                    this.Hide();
                    Form mainForm = new Dashboard(username);
                    mainForm.Show();

                }
                else
                {
                    // Login failed, show an error message
                    MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void linkRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form mainForm = new FormRegister();
            mainForm.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            passwordField.PasswordChar = '\0';

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Show password
                passwordField.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                passwordField.UseSystemPasswordChar = true;
            }

        }
    }
}
