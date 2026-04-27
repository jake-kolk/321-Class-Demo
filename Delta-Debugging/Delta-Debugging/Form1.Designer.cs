namespace Delta_Debugging
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblScore1 = new Label();
            txtScore1 = new TextBox();
            lblScore2 = new Label();
            txtScore2 = new TextBox();
            lblScore3 = new Label();
            txtScore3 = new TextBox();
            btnAddStudent = new Button();
            lstStudents = new ListBox();
            lblClassAverage = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 15);
            lblName.Name = "lblName";
            lblName.Size = new Size(83, 32);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(105, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 39);
            txtName.TabIndex = 1;
            // 
            // lblScore1
            // 
            lblScore1.AutoSize = true;
            lblScore1.Location = new Point(12, 45);
            lblScore1.Name = "lblScore1";
            lblScore1.Size = new Size(98, 32);
            lblScore1.TabIndex = 2;
            lblScore1.Text = "Score 1:";
            // 
            // txtScore1
            // 
            txtScore1.Location = new Point(105, 33);
            txtScore1.Name = "txtScore1";
            txtScore1.Size = new Size(200, 39);
            txtScore1.TabIndex = 3;
            // 
            // lblScore2
            // 
            lblScore2.AutoSize = true;
            lblScore2.Location = new Point(12, 75);
            lblScore2.Name = "lblScore2";
            lblScore2.Size = new Size(98, 32);
            lblScore2.TabIndex = 4;
            lblScore2.Text = "Score 2:";
            // 
            // txtScore2
            // 
            txtScore2.Location = new Point(105, 63);
            txtScore2.Name = "txtScore2";
            txtScore2.Size = new Size(200, 39);
            txtScore2.TabIndex = 5;
            // 
            // lblScore3
            // 
            lblScore3.AutoSize = true;
            lblScore3.Location = new Point(12, 105);
            lblScore3.Name = "lblScore3";
            lblScore3.Size = new Size(98, 32);
            lblScore3.TabIndex = 6;
            lblScore3.Text = "Score 3:";
            // 
            // txtScore3
            // 
            txtScore3.Location = new Point(105, 93);
            txtScore3.Name = "txtScore3";
            txtScore3.Size = new Size(200, 39);
            txtScore3.TabIndex = 7;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(12, 138);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(200, 47);
            btnAddStudent.TabIndex = 8;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // lstStudents
            // 
            lstStudents.FormattingEnabled = true;
            lstStudents.Location = new Point(12, 191);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(248, 68);
            lstStudents.TabIndex = 9;
            // 
            // lblClassAverage
            // 
            lblClassAverage.AutoSize = true;
            lblClassAverage.Location = new Point(12, 280);
            lblClassAverage.Name = "lblClassAverage";
            lblClassAverage.Size = new Size(186, 32);
            lblClassAverage.TabIndex = 10;
            lblClassAverage.Text = "Class Average: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblClassAverage);
            Controls.Add(lstStudents);
            Controls.Add(btnAddStudent);
            Controls.Add(txtScore3);
            Controls.Add(lblScore3);
            Controls.Add(txtScore2);
            Controls.Add(lblScore2);
            Controls.Add(txtScore1);
            Controls.Add(lblScore1);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Name = "Form1";
            Text = "Student Grade Tracker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblScore1;
        private System.Windows.Forms.TextBox txtScore1;
        private System.Windows.Forms.Label lblScore2;
        private System.Windows.Forms.TextBox txtScore2;
        private System.Windows.Forms.Label lblScore3;
        private System.Windows.Forms.TextBox txtScore3;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.ListBox lstStudents;
        private System.Windows.Forms.Label lblClassAverage;
    }
}
