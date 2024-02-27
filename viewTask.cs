using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBManager;

namespace newYAO
{
    public partial class viewTask : UserControl
    {
        public viewTask(int id)
        {
            InitializeComponent();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                int task_id = id;

                SqlCommand command = new SqlCommand("SELECT status FROM task WHERE Id = @task_id", connection);
                
                command.Parameters.AddWithValue("@task_id", task_id);

                object result = command.ExecuteScalar();

                if (result != null && !Convert.IsDBNull(result))
                {
                    int status = Convert.ToInt32(result);

                    if (status == 1)
                    {
                        Button btncompl = this.Controls.Find("btncompl", true).FirstOrDefault() as Button;
                        if (btncompl != null)
                        {
                            btncompl.Visible = false;
                        }
                    }
                }
            }
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                int task_id = id;

                SqlCommand command = new SqlCommand("SELECT priority FROM task WHERE Id = @task_id", connection);

                command.Parameters.AddWithValue("@task_id", task_id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int priorityy = (int)reader["priority"];

                    if (priorityy == 0)
                    {
                        panel1.BackColor = Color.FromArgb(192, 255, 192);
                    }
                    if (priorityy == 1)
                    {

                        panel1.BackColor = Color.FromArgb(255, 224, 192);
                    }

                    if (priorityy == 2)
                    {
                        panel1.BackColor = Color.FromArgb(255, 192, 192);
                    }
                }
            }

            
        }
        public int IdTask { get; set; }

        public string Title
        {
            get { return title.Text; }
            set { title.Text = value; }
        }
        public string Description
        {
            get { return description.Text; }
            set { description.Text = "  " + value; }
        }
        public string Date
        {
            get { return date.Text; }
            set { date.Text = value; }
        }
        public Image Priority
        {
            get { return priority.Image; }
            set { priority.Image = value; }
        }
        public Image Status
        {
            get { return statusnon.Image; }
            set { statusnon.Image = value; }
        }

        public string Category
        {
            get { return category.Text; }
            set { category.Text = value; }
        }

        public Image ImageOK
        {
            get { return statusok.Image; }
            set { statusok.Image = value; }
        }
        public bool ImageOKVisible
        {
            get { return statusok.Visible; }
            set { statusok.Visible = value; }
        }

        private void bin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                int task_id = this.IdTask;

                string sql = "DELETE FROM task WHERE Id = @taskId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@taskId", task_id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task deleted successfully!");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Task not found.");
                    }
                }
            }

        }

        private void btncompl_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                int task_id = this.IdTask;

                int newstatus = 1;

                SqlCommand command = new SqlCommand("UPDATE task SET status = @newstatus WHERE Id = @task_id", connection);

                command.Parameters.AddWithValue("@newstatus", newstatus);

                command.Parameters.AddWithValue("@task_id", task_id);
                
                int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task is completed!");

                        this.Hide();

                        Button btncompl = this.Controls.Find("btncompl", true).FirstOrDefault() as Button;
                        if (btncompl != null)
                        {
                        btncompl.Visible = false;
                        }
                }
                    else
                    {
                        MessageBox.Show("Task not found.");
                    }
                }

            Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];

            int currentCount = int.Parse(dashboard.GetTaskCount());
            int newCount = currentCount - 1;
            dashboard.UpdateTaskCount(newCount);



        }

        private void viewTask_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                int task_id = this.IdTask;

                string sql = "DELETE FROM task WHERE Id = @taskId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@taskId", task_id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task deleted successfully!");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Task not found.");
                    }
                }
            }
        }

        private void updateDES_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                int task_id = this.IdTask;

                string desc = description.Text;

                SqlCommand command = new SqlCommand("UPDATE task SET description = @desc WHERE Id = @task_id", connection);

                command.Parameters.AddWithValue("@desc", desc);

                command.Parameters.AddWithValue("@task_id", task_id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Task is updated!");
                    

                }
                else
                {
                    MessageBox.Show("Task not updated correctly.");
                }
            }
        }
    }
}
        
