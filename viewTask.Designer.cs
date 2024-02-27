namespace newYAO
{
    partial class viewTask
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewTask));
            this.title = new MetroFramework.Controls.MetroLabel();
            this.date = new MetroFramework.Controls.MetroLabel();
            this.description = new System.Windows.Forms.TextBox();
            this.statusnon = new System.Windows.Forms.PictureBox();
            this.priority = new System.Windows.Forms.PictureBox();
            this.category = new MetroFramework.Controls.MetroLabel();
            this.statusok = new System.Windows.Forms.PictureBox();
            this.btncompl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.updateDES = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusnon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusok)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.White;
            this.title.CustomBackground = true;
            this.title.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.title.ForeColor = System.Drawing.Color.DarkGray;
            this.title.Location = new System.Drawing.Point(31, 48);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(98, 20);
            this.title.Style = MetroFramework.MetroColorStyle.Purple;
            this.title.TabIndex = 0;
            this.title.Text = "metroLabel1";
            this.title.Theme = MetroFramework.MetroThemeStyle.Light;
            this.title.UseStyleColors = true;
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.BackColor = System.Drawing.Color.White;
            this.date.CustomBackground = true;
            this.date.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.date.ForeColor = System.Drawing.Color.Black;
            this.date.Location = new System.Drawing.Point(154, 280);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(98, 20);
            this.date.Style = MetroFramework.MetroColorStyle.Purple;
            this.date.TabIndex = 1;
            this.date.Text = "metroLabel2";
            this.date.Theme = MetroFramework.MetroThemeStyle.Light;
            this.date.UseStyleColors = true;
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.description.Location = new System.Drawing.Point(40, 122);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(215, 155);
            this.description.TabIndex = 2;
            // 
            // statusnon
            // 
            this.statusnon.BackColor = System.Drawing.Color.White;
            this.statusnon.Image = ((System.Drawing.Image)(resources.GetObject("statusnon.Image")));
            this.statusnon.Location = new System.Drawing.Point(237, 47);
            this.statusnon.Name = "statusnon";
            this.statusnon.Size = new System.Drawing.Size(26, 18);
            this.statusnon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statusnon.TabIndex = 3;
            this.statusnon.TabStop = false;
            // 
            // priority
            // 
            this.priority.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.priority.Location = new System.Drawing.Point(0, 1);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(266, 30);
            this.priority.TabIndex = 5;
            this.priority.TabStop = false;
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.category.CustomBackground = true;
            this.category.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.category.Location = new System.Drawing.Point(13, 10);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(93, 20);
            this.category.Style = MetroFramework.MetroColorStyle.Purple;
            this.category.TabIndex = 6;
            this.category.Text = "metroLabel1";
            this.category.Theme = MetroFramework.MetroThemeStyle.Light;
            this.category.UseStyleColors = true;
            // 
            // statusok
            // 
            this.statusok.BackColor = System.Drawing.Color.White;
            this.statusok.Image = ((System.Drawing.Image)(resources.GetObject("statusok.Image")));
            this.statusok.Location = new System.Drawing.Point(237, 47);
            this.statusok.Name = "statusok";
            this.statusok.Size = new System.Drawing.Size(26, 21);
            this.statusok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statusok.TabIndex = 7;
            this.statusok.TabStop = false;
            // 
            // btncompl
            // 
            this.btncompl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btncompl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncompl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.btncompl.Location = new System.Drawing.Point(31, 348);
            this.btncompl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btncompl.Name = "btncompl";
            this.btncompl.Size = new System.Drawing.Size(142, 29);
            this.btncompl.TabIndex = 8;
            this.btncompl.Text = "Complete Task";
            this.btncompl.UseVisualStyleBackColor = false;
            this.btncompl.Click += new System.EventHandler(this.btncompl_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.priority);
            this.panel1.Location = new System.Drawing.Point(15, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 30);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(220, 348);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::newYAO.Properties.Resources.mini_card;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.category);
            this.panel2.Location = new System.Drawing.Point(154, 77);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(109, 39);
            this.panel2.TabIndex = 11;
            // 
            // updateDES
            // 
            this.updateDES.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.updateDES.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateDES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.updateDES.Location = new System.Drawing.Point(31, 315);
            this.updateDES.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateDES.Name = "updateDES";
            this.updateDES.Size = new System.Drawing.Size(142, 29);
            this.updateDES.TabIndex = 12;
            this.updateDES.Text = "Update task";
            this.updateDES.UseVisualStyleBackColor = false;
            this.updateDES.Click += new System.EventHandler(this.updateDES_Click);
            // 
            // viewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.updateDES);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btncompl);
            this.Controls.Add(this.statusok);
            this.Controls.Add(this.statusnon);
            this.Controls.Add(this.description);
            this.Controls.Add(this.date);
            this.Controls.Add(this.title);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Snow;
            this.Name = "viewTask";
            this.Size = new System.Drawing.Size(300, 400);
            this.Load += new System.EventHandler(this.viewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusnon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusok)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel title;
        private MetroFramework.Controls.MetroLabel date;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.PictureBox statusnon;
        private System.Windows.Forms.PictureBox priority;
        private MetroFramework.Controls.MetroLabel category;
        private System.Windows.Forms.PictureBox statusok;
        private System.Windows.Forms.Button btncompl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button updateDES;
    }
}
