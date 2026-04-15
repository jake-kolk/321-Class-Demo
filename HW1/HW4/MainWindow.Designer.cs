namespace HW4
{
    partial class MainWindow
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
            Grid = new DataGridView();
            Q = new DataGridViewTextBoxColumn();
            button1 = new Button();
            UndoButton = new Button();
            RedoButton = new Button();
            MenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            UndoToolStripMenuItem = new ToolStripMenuItem();
            RedoToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Grid
            // 
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.Columns.AddRange(new DataGridViewColumn[] { Q });
            Grid.Location = new Point(4, 40);
            Grid.Margin = new Padding(2);
            Grid.Name = "Grid";
            Grid.RowHeadersWidth = 82;
            Grid.RowTemplate.Height = 41;
            Grid.Size = new Size(1126, 604);
            Grid.TabIndex = 0;
            Grid.MouseClick += Grid_MouseClick;
            // 
            // Q
            // 
            Q.HeaderText = "Q";
            Q.MinimumWidth = 10;
            Q.Name = "Q";
            Q.Width = 200;
            // 
            // button1
            // 
            button1.Location = new Point(4, 598);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(1126, 48);
            button1.TabIndex = 1;
            button1.Text = "Demo Button";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // UndoButton
            // 
            UndoButton.Location = new Point(994, 1);
            UndoButton.Name = "UndoButton";
            UndoButton.Size = new Size(68, 34);
            UndoButton.TabIndex = 2;
            UndoButton.Text = "Undo";
            UndoButton.UseVisualStyleBackColor = true;
            UndoButton.Click += UndoButton_Click;
            // 
            // RedoButton
            // 
            RedoButton.Location = new Point(1068, 1);
            RedoButton.Name = "RedoButton";
            RedoButton.Size = new Size(62, 34);
            RedoButton.TabIndex = 3;
            RedoButton.Text = "Redo";
            RedoButton.UseVisualStyleBackColor = true;
            RedoButton.Click += RedoButton_Click;
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new Size(24, 24);
            MenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(1132, 33);
            MenuStrip.TabIndex = 4;
            MenuStrip.Text = "menuStrip1";
            MenuStrip.ItemClicked += MenuStrip_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(148, 34);
            quitToolStripMenuItem.Text = "Quit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { UndoToolStripMenuItem, RedoToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(58, 29);
            editToolStripMenuItem.Text = "Edit";
            // 
            // UndoToolStripMenuItem
            // 
            UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            UndoToolStripMenuItem.Size = new Size(158, 34);
            UndoToolStripMenuItem.Text = "Undo";
            UndoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            // 
            // RedoToolStripMenuItem
            // 
            RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            RedoToolStripMenuItem.Size = new Size(158, 34);
            RedoToolStripMenuItem.Text = "Redo";
            RedoToolStripMenuItem.Click += RedoToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 655);
            Controls.Add(RedoButton);
            Controls.Add(UndoButton);
            Controls.Add(button1);
            Controls.Add(Grid);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Margin = new Padding(2);
            Name = "MainWindow";
            Text = "321 Spreadsheet";
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Grid;
        private Button button1;
        private DataGridViewTextBoxColumn Q;
        private Button UndoButton;
        private Button RedoButton;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem UndoToolStripMenuItem;
        private ToolStripMenuItem RedoToolStripMenuItem;
    }
}