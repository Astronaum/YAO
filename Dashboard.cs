using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace newYAO
{
    public partial class Dashboard : Form
    {
        Image avatarImage;
        int id_user;
        string userName;

        public Dashboard(string username)
        {

            userName = username;
            InitializeComponent();
            helloBanner.Text = "Welcome back " + username + " !";
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT id,image FROM [user] WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    byte[] imageData = (byte[])reader["image"];
                    Image image = Image.FromStream(new MemoryStream(imageData));
                    avatarBox.Image = image;
                    avatarImage = image;

                    id_user = (int)reader["id"];
                }

                reader.Close();
            }
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }

            Button btnPrio0 = this.Controls.Find("btnPrio0", true).FirstOrDefault() as Button;
            if (btnPrio0 != null)
            {
                btnPrio0.Visible = false;
            }
            Button btnPrio1 = this.Controls.Find("btnPrio1", true).FirstOrDefault() as Button;
            if (btnPrio1 != null)
            {
                btnPrio1.Visible = false;
            }
            Button btnPrio2 = this.Controls.Find("btnPrio2", true).FirstOrDefault() as Button;
            if (btnPrio2 != null)
            {
                btnPrio2.Visible = false;
            }

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                int task_id = id_user;
                int count = 0;

                SqlCommand command = new SqlCommand("SELECT * FROM task WHERE id_user = @id_user AND status = 0", connection);
                command.Parameters.AddWithValue("@id_user", id_user);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    if ((int)reader["status"] == 0)
                    {
                        count++;
                    }
                }

                nbrTasks.Text = count.ToString();
            }

        }

        public string GetTaskCount()
        {
            return nbrTasks.Text;
        }

        public void UpdateTaskCount(int count)
        {
            nbrTasks.Text = count.ToString();
        }


        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void btnTasks_Click(object sender, EventArgs e)
        {
            Image backgroundImage1 = Properties.Resources.btnindigo;
            btnTasks.BackgroundImage = backgroundImage1;

            Image backgroundImage2 = Properties.Resources.backsmalleft2;
            btnImpo.BackgroundImage = backgroundImage2;
            btnImpo.BackgroundImageLayout = ImageLayout.Stretch;

            Image backgroundImage3 = Properties.Resources.backsmalleft2;
            btnCompleted.BackgroundImage = backgroundImage3;
            
            Image backgroundImage4 = Properties.Resources.backsmalleft2;
            btnAllTasks.BackgroundImage = backgroundImage4;


            Image backgroundImage5 = Properties.Resources.backsmalleft2;
            btnUncompleted.BackgroundImage = backgroundImage5;

            pictureBox5.BackColor = Color.Indigo;

            pictureBox3.BackColor = Color.FromArgb(255, 255, 255) ;
            pictureBox4.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox6.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox7.BackColor = Color.FromArgb(255, 255, 255);


            btnTasks.ForeColor = Color.White;
            btnCompleted.ForeColor = Color.FromArgb(127, 124, 146);
            btnAllTasks.ForeColor = Color.FromArgb(127, 124, 146);
            btnUncompleted.ForeColor = Color.FromArgb(127, 124, 146);
            btnImpo.ForeColor = Color.FromArgb(127, 124, 146);

            cardsLocation.Controls.Clear();
            Button btnPrio0 = this.Controls.Find("btnPrio0", true).FirstOrDefault() as Button;
            if (btnPrio0 != null)
            {
                btnPrio0.Visible = false;
            }
            Button btnPrio1 = this.Controls.Find("btnPrio1", true).FirstOrDefault() as Button;
            if (btnPrio1 != null)
            {
                btnPrio1.Visible = false;
            }
            Button btnPrio2 = this.Controls.Find("btnPrio2", true).FirstOrDefault() as Button;
            if (btnPrio2 != null)
            {
                btnPrio2.Visible = false;
            }

            Button work = this.Controls.Find("work", true).FirstOrDefault() as Button;
            if (work != null)
            {
                work.Visible = false;
            }
            Button school = this.Controls.Find("school", true).FirstOrDefault() as Button;
            if (school != null)
            {
                school.Visible = false;
            }
            Button hobbie = this.Controls.Find("hobbie", true).FirstOrDefault() as Button;
            if (hobbie != null)
            {
                hobbie.Visible = false;
            }

            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                DateTime date = DateTime.Today;

                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND deadline >= @date AND deadline < @nextDate", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                command2.Parameters.AddWithValue("@date", date);

                command2.Parameters.AddWithValue("@nextDate", date.AddDays(1));

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    DateTime taskDeadline = reader.GetDateTime(reader.GetOrdinal("deadline"));

                    if (taskDeadline.Date == date)
                    {
                        int id = (int)reader["id"];

                        viewTask card = new viewTask(id);

                        card.IdTask = (int)reader["id"];

                        card.Title = (string)reader["title"];

                        card.Description = (string)reader["description"];

                        DateTime deadline = (DateTime)reader["deadline"];

                        card.Date = deadline.ToString("yyyy-MM-dd");

                        int priority = (int)reader["priority"];

                        if (priority == 0)
                        {
                            card.Priority = null;
                        }
                        else if (priority == 1)
                        {
                            card.Priority = null;
                        }
                        else
                        {
                            card.Priority = null;
                        }

                        card.Category = (string)reader["category"];

                        int Status = (int)reader["status"];

                        if (Status == 0)
                        {
                            card.ImageOKVisible = false;
                        }
                        else
                        {
                            card.ImageOKVisible = true;
                        }
                        cardsLocation.Controls.Add(card);

                    }


                }
            }

        }

        private void cardsLocation_Paint(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)sender;

            if (flowLayoutPanel.Controls.Count == 0)
            {
                // FlowLayoutPanel is empty, add a PictureBox with the image
                Image image = Image.FromFile("C:\\Users\\astro\\Desktop\\YAO\\Assets\\Imagesnotask.png"); // Replace with the actual image path

                PictureBox pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.AutoSize
                };

                flowLayoutPanel.Controls.Add(pictureBox);
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblTabTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void AddNewTask_Click(object sender, EventArgs e)
        {
            Form mainForm = new FormAddTask(id_user);
            mainForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
            Form mainForm = new FormLogin();
            mainForm.Show();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Form mainForm = new FormUpdateProfil(avatarImage, id_user);
            mainForm.Show();
            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT id,image FROM [user] WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", userName);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    byte[] imageData = (byte[])reader["image"];
                    Image image = Image.FromStream(new MemoryStream(imageData));
                    avatarBox.Image = image;
                    avatarImage = image;

                    id_user = (int)reader["id"];
                }

                reader.Close();
            }

        }

        private void btnImpo_Click(object sender, EventArgs e)
        {

            Image backgroundImage1 = Properties.Resources.backsmalleft2;
            btnTasks.BackgroundImage = backgroundImage1;

            Image backgroundImage2 = Properties.Resources.btnindigo;
            btnImpo.BackgroundImage = backgroundImage2;

            Image backgroundImage3 = Properties.Resources.backsmalleft2;
            btnCompleted.BackgroundImage = backgroundImage3;

            Image backgroundImage4 = Properties.Resources.backsmalleft2;
            btnAllTasks.BackgroundImage = backgroundImage4;


            Image backgroundImage5 = Properties.Resources.backsmalleft2;
            btnUncompleted.BackgroundImage = backgroundImage5;

            pictureBox4.BackColor = Color.Indigo;
            pictureBox3.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox5.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox6.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox7.BackColor = Color.FromArgb(255, 255, 255);


            btnImpo.ForeColor = Color.White;
            btnCompleted.ForeColor = Color.FromArgb(127, 124, 146);
            btnAllTasks.ForeColor = Color.FromArgb(127, 124, 146);
            btnUncompleted.ForeColor = Color.FromArgb(127, 124, 146);
            btnTasks.ForeColor = Color.FromArgb(127, 124, 146);

            Button btnPrio0 = this.Controls.Find("btnPrio0", true).FirstOrDefault() as Button;
            if (btnPrio0 != null)
            {
                btnPrio0.Visible = true;
            }
            Button btnPrio1 = this.Controls.Find("btnPrio1", true).FirstOrDefault() as Button;
            if (btnPrio1 != null)
            {
                btnPrio1.Visible = true;
            }
            Button btnPrio2 = this.Controls.Find("btnPrio2", true).FirstOrDefault() as Button;
            if (btnPrio2 != null)
            {
                btnPrio2.Visible = true;
            }

            Button work = this.Controls.Find("work", true).FirstOrDefault() as Button;
            if (work != null)
            {
                work.Visible = false;
            }
            Button school = this.Controls.Find("school", true).FirstOrDefault() as Button;
            if (school != null)
            {
                school.Visible = false;
            }
            Button hobbie = this.Controls.Find("hobbie", true).FirstOrDefault() as Button;
            if (hobbie != null)
            {
                hobbie.Visible = false;
            }

            btnPrio0.Click += new EventHandler(btnPrio0_Click);

            btnPrio1.Click += new EventHandler(btnPrio1_Click);

            btnPrio2.Click += new EventHandler(btnPrio2_Click);



            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND status = 0 AND priority = 2", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
        

    }
        
    

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAllTasks_Click(object sender, EventArgs e)
        {

            Image backgroundImage1 = Properties.Resources.backsmalleft2;
            btnTasks.BackgroundImage = backgroundImage1;

            Image backgroundImage2 = Properties.Resources.backsmalleft2;
            btnImpo.BackgroundImage = backgroundImage2;
            btnImpo.BackgroundImageLayout = ImageLayout.Stretch;

            Image backgroundImage3 = Properties.Resources.backsmalleft2;
            btnCompleted.BackgroundImage = backgroundImage3;

            Image backgroundImage4 = Properties.Resources.btnindigo;
            btnAllTasks.BackgroundImage = backgroundImage4;


            Image backgroundImage5 = Properties.Resources.backsmalleft2;
            btnUncompleted.BackgroundImage = backgroundImage5;

            pictureBox7.BackColor = Color.Indigo;
            pictureBox3.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox5.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox4.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox6.BackColor = Color.FromArgb(255, 255, 255);

            btnAllTasks.ForeColor = Color.White;
            btnCompleted.ForeColor = Color.FromArgb(127, 124, 146);
            btnTasks.ForeColor = Color.FromArgb(127, 124, 146);
            btnImpo.ForeColor = Color.FromArgb(127, 124, 146);
            btnUncompleted.ForeColor = Color.FromArgb(127, 124, 146);


            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }


            Button btnPrio0 = this.Controls.Find("btnPrio0", true).FirstOrDefault() as Button;
            if (btnPrio0 != null)
            {
                btnPrio0.Visible = false;
            }
            Button btnPrio1 = this.Controls.Find("btnPrio1", true).FirstOrDefault() as Button;
            if (btnPrio1 != null)
            {
                btnPrio1.Visible = false;
            }
            Button btnPrio2 = this.Controls.Find("btnPrio2", true).FirstOrDefault() as Button;
            if (btnPrio2 != null)
            {
                btnPrio2.Visible = false;
            }

            Button work = this.Controls.Find("work", true).FirstOrDefault() as Button;
            if (work != null)
            {
                work.Visible = true;
            }
            Button school = this.Controls.Find("school", true).FirstOrDefault() as Button;
            if (school != null)
            {
                school.Visible = true;
            }
            Button hobbie = this.Controls.Find("hobbie", true).FirstOrDefault() as Button;
            if (hobbie != null)
            {
                hobbie.Visible = true;
            }

            work.Click += new EventHandler(work_Click);

            school.Click += new EventHandler(school_Click);

            hobbie.Click += new EventHandler(hobbie_Click);
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            Image backgroundImage1 = Properties.Resources.backsmalleft2;
            btnTasks.BackgroundImage = backgroundImage1;

            Image backgroundImage2 = Properties.Resources.backsmalleft2;
            btnImpo.BackgroundImage = backgroundImage2;

            Image backgroundImage3 = Properties.Resources.btnindigo;
            btnCompleted.BackgroundImage = backgroundImage3;

            Image backgroundImage4 = Properties.Resources.backsmalleft2;
            btnAllTasks.BackgroundImage = backgroundImage4;


            Image backgroundImage5 = Properties.Resources.backsmalleft2;
            btnUncompleted.BackgroundImage = backgroundImage5;

            pictureBox3.BackColor = Color.Indigo;
            pictureBox4.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox5.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox6.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox7.BackColor = Color.FromArgb(255, 255, 255);

            btnCompleted.ForeColor = Color.White;
            btnTasks.ForeColor = Color.FromArgb(127, 124, 146);
            btnAllTasks.ForeColor = Color.FromArgb(127, 124, 146);
            btnImpo.ForeColor = Color.FromArgb(127, 124, 146);
            btnUncompleted.ForeColor = Color.FromArgb(127, 124, 146);


            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND status = 1", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
            
            Button btnPrio0 = this.Controls.Find("btnPrio0", true).FirstOrDefault() as Button;
            if (btnPrio0 != null)
            {
                btnPrio0.Visible = false;
            }
            Button btnPrio1 = this.Controls.Find("btnPrio1", true).FirstOrDefault() as Button;
            if (btnPrio1 != null)
            {
                btnPrio1.Visible = false;
            }
            Button btnPrio2 = this.Controls.Find("btnPrio2", true).FirstOrDefault() as Button;
            if (btnPrio2 != null)
            {
                btnPrio2.Visible = false;
            }

            Button work = this.Controls.Find("work", true).FirstOrDefault() as Button;
            if (work != null)
            {
                work.Visible = false;
            }
            Button school = this.Controls.Find("school", true).FirstOrDefault() as Button;
            if (school != null)
            {
                school.Visible = false;
            }
            Button hobbie = this.Controls.Find("hobbie", true).FirstOrDefault() as Button;
            if (hobbie != null)
            {
                hobbie.Visible = false;
            }
        }

        private void btnUncompleted_Click(object sender, EventArgs e)
        {
            Image backgroundImage1 = Properties.Resources.backsmalleft2;
            btnTasks.BackgroundImage = backgroundImage1;

            Image backgroundImage2 = Properties.Resources.backsmalleft2;
            btnImpo.BackgroundImage = backgroundImage2;
            btnImpo.BackgroundImageLayout = ImageLayout.Stretch;

            Image backgroundImage3 = Properties.Resources.backsmalleft2;
            btnCompleted.BackgroundImage = backgroundImage3;

            Image backgroundImage4 = Properties.Resources.backsmalleft2;
            btnAllTasks.BackgroundImage = backgroundImage4;


            Image backgroundImage5 = Properties.Resources.btnindigo;
            btnUncompleted.BackgroundImage = backgroundImage5;

            pictureBox6.BackColor = Color.Indigo;
            pictureBox3.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox5.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox7.BackColor = Color.FromArgb(255, 255, 255);
            pictureBox4.BackColor = Color.FromArgb(255, 255, 255);

            btnUncompleted.ForeColor = Color.White;
            btnCompleted.ForeColor = Color.FromArgb(127, 124, 146);
            btnAllTasks.ForeColor = Color.FromArgb(127, 124, 146);
            btnImpo.ForeColor = Color.FromArgb(127, 124, 146);
            btnTasks.ForeColor = Color.FromArgb(127, 124, 146);

            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND status = 0", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
            
            Button btnPrio0 = this.Controls.Find("btnPrio0", true).FirstOrDefault() as Button;
            if (btnPrio0 != null)
            {
                btnPrio0.Visible = false;
            }
            Button btnPrio1 = this.Controls.Find("btnPrio1", true).FirstOrDefault() as Button;
            if (btnPrio1 != null)
            {
                btnPrio1.Visible = false;
            }
            Button btnPrio2 = this.Controls.Find("btnPrio2", true).FirstOrDefault() as Button;
            if (btnPrio2 != null)
            {
                btnPrio2.Visible = false;
            }

            Button work = this.Controls.Find("work", true).FirstOrDefault() as Button;
            if (work != null)
            {
                work.Visible = false;
            }
            Button school = this.Controls.Find("school", true).FirstOrDefault() as Button;
            if (school != null)
            {
                school.Visible = false;
            }
            Button hobbie = this.Controls.Find("hobbie", true).FirstOrDefault() as Button;
            if (hobbie != null)
            {
                hobbie.Visible = false;
            }
        }

        private void btnPrio0_Click(object sender, EventArgs e)
        {
            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND status = 0 AND priority = 0", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
        }

        private void btnPrio1_Click(object sender, EventArgs e)
        {
            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND status = 0 AND priority = 1", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
        }

        private void btnPrio2_Click(object sender, EventArgs e)
        {
            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND status = 0 AND priority = 2", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {
            UpdateQuote();

        }

        List<string> quotes = new List<string> {
            "The only way to do great work is to love what you do. - Steve Jobs",
            "Success is not final, failure is not fatal: It is the courage to continue that counts. - Winston Churchill",
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "I have not failed. I've just found 10,000 ways that won't work. - Thomas A. Edison",
            "The best way to predict the future is to invent it. - Alan Kay"
        };

        private void UpdateQuote()
        {
            Random random = new Random();
            int index = random.Next(quotes.Count);
            string quote2 = quotes[index];
            quote.Text = quote2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQuote();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            UpdateQuote();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTasks_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void work_Click(object sender, EventArgs e)
        {
            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND category = @work", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);
                command2.Parameters.AddWithValue("@work", "Work");

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
        }

        private void school_Click(object sender, EventArgs e)
        {
            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND category = @School", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);
                command2.Parameters.AddWithValue("@School", "School");

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
        }

        private void hobbie_Click(object sender, EventArgs e)
        {
            cardsLocation.Controls.Clear();

            using (SqlConnection connection = DBManager.DBManager.GetConnection())
            {
                connection.Open();

                SqlCommand command2 = new SqlCommand("SELECT * FROM [task] WHERE id_user = @id_user AND category = @Hobbies", connection);

                command2.Parameters.AddWithValue("@id_user", id_user);
                command2.Parameters.AddWithValue("@Hobbies", "Hobbies");

                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    notask.Visible = false;
                    cardsLocation.Show();
                }
                else
                {
                    cardsLocation.Hide();
                    notask.Visible = true;
                }

                while (reader.Read())
                {
                    int id = (int)reader["id"];

                    viewTask card = new viewTask(id);

                    card.IdTask = (int)reader["id"];

                    card.Title = (string)reader["title"];

                    card.Description = (string)reader["description"];

                    DateTime deadline = (DateTime)reader["deadline"];

                    card.Date = deadline.ToString("yyyy-MM-dd");

                    int priority = (int)reader["priority"];

                    if (priority == 0)
                    {
                        card.Priority = null;
                    }
                    else if (priority == 1)
                    {
                        card.Priority = null;
                    }
                    else
                    {
                        card.Priority = null;
                    }

                    card.Category = (string)reader["category"];

                    int Status = (int)reader["status"];

                    if (Status == 0)
                    {
                        card.ImageOKVisible = false;
                    }
                    else
                    {
                        card.ImageOKVisible = true;
                    }
                    cardsLocation.Controls.Add(card);


                }
            }
        }
    }
}

