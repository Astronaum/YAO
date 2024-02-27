using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace newYAO
{
    public partial class FormUpdateProfil : Form
    {
        int current_user;
        public FormUpdateProfil(Image avatarImage, int id_user)
        {
            InitializeComponent();
            pictureBox1.Image = avatarImage;
            current_user = id_user;
            newPassword.UseSystemPasswordChar = true;
            newPasswordConfirmation.UseSystemPasswordChar = true;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.jpeg, *.gif)|*.jpg;*.png;*.jpeg;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection connection = DBManager.DBManager.GetConnection())
                    {
                        connection.Open();

                        byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);

                        SqlCommand command = new SqlCommand("UPDATE [user] SET image = @image WHERE id = @id", connection);
                        command.Parameters.AddWithValue("@image", imageData);
                        command.Parameters.AddWithValue("@id", current_user);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Image uploaded successfully!");
                            Close();
                        }

                        else
                        {
                            MessageBox.Show("Error uploading image.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading image: " + ex.Message);
                }
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateUsername_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                string query = "UPDATE [user] SET username = @newUsername WHERE id = @userId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newUsername", usernameField.Text);
                command.Parameters.AddWithValue("@userId", current_user);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Username updated successfully
                    MessageBox.Show("Username updated successfully!");
                    Close();
                    
                }
                else
                {
                    // Unable to update username
                    MessageBox.Show("Unable to update username.");

                }
            }

        }

        private void updatePassword_Click(object sender, EventArgs e)
        {
            string newPasswordF = newPassword.Text;
            string confirmNewPassword = newPasswordConfirmation.Text;

            if (newPasswordF == confirmNewPassword)
            {
                using (SqlConnection connection = DBManager.DBManager.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE [user] SET password = @newPassword WHERE id = @userId", connection);
                    command.Parameters.AddWithValue("@newPassword", newPasswordF);
                    command.Parameters.AddWithValue("@userId", current_user);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Password updated successfully!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please try again.");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void newPasswordConfirmation_Click(object sender, EventArgs e)
        {

        }
    }
}