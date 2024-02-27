using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBManager;

namespace newYAO
{
    public partial class FormAddTask : Form
    {
        int current_Id;
        public FormAddTask(int id_user)
        {
            InitializeComponent();
            string[] items = new string[] { "1", "2", "3" };

            // Add the items to the ListBox
            Priority.Items.AddRange(items);

            string[] items2 = new string[] { "Work", "School", "Hobbies" };

            // Add the items to the ListBox
            Category.Items.AddRange(items2);

            current_Id= id_user;

        }

        private void FormAddTask_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO task (title, description, deadline, priority, category, id_user, status) VALUES (@Title, @Description, @Deadline, @Priority, @Category, @IdUser, @Status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title.Text);
                command.Parameters.AddWithValue("@Description", description.Text);
                command.Parameters.AddWithValue("@Deadline", date.Value);
                command.Parameters.AddWithValue("@Priority", Priority.SelectedIndex);
                command.Parameters.AddWithValue("@Category", Category.SelectedItem.ToString());
                command.Parameters.AddWithValue("@IdUser", current_Id);
                command.Parameters.AddWithValue("@Status", 0);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Task added successfully!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to add task password.");
                }

                connection.Close();
            }

            Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];

            int currentCount = int.Parse(dashboard.GetTaskCount());
            int newCount = currentCount + 1;
            dashboard.UpdateTaskCount(newCount);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void title_TextChanged(object sender, EventArgs e)
        {

        }

        private void Priority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
