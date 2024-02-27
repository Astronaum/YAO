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
using DBManager;

namespace newYAO
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
            passwordConfirmation.UseSystemPasswordChar = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            Close();
            Form mainForm = new FormLogin();
            mainForm.Show();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                avatarBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = null;
            if (avatarBox.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    avatarBox.Image.Save(ms, ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
            }


            if (password.Text == passwordConfirmation.Text)
            {
                using (SqlConnection connection = DBManager.DBManager.GetConnection())
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO [user] (username, password, image) VALUES (@username, @password, @image)", connection);
                    command.Parameters.AddWithValue("@username", username.Text);
                    command.Parameters.AddWithValue("@password", password.Text);
                    command.Parameters.AddWithValue("@image", imageBytes);

                    int rowsAffected = command.ExecuteNonQuery();
                    string user = username.Text;

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful!");
                        Close();
                        Form mainForm = new Dashboard(user);
                        mainForm.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords aren't matching!");
                Close();
                Form mainForm = new FormRegister();
                mainForm.Show();

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Show password
                password.UseSystemPasswordChar = false;
                passwordConfirmation.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                password.UseSystemPasswordChar = true;
                passwordConfirmation.UseSystemPasswordChar = true;
            }
        }
    }
}
