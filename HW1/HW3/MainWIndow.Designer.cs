namespace HW3
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
            MainTextBox = new TextBox();
            OpenFileDialog = new OpenFileDialog();
            MenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFromFileToolStripMenuItem = new ToolStripMenuItem();
            openFibonacciNumbersToolStripMenuItem = new ToolStripMenuItem();
            first50ToolStripMenuItem = new ToolStripMenuItem();
            first100ToolStripMenuItem = new ToolStripMenuItem();
            saveToFileToolStripMenuItem = new ToolStripMenuItem();
            SaveFileDialog = new SaveFileDialog();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainTextBox
            // 
            MainTextBox.Location = new Point(5, 53);
            MainTextBox.Multiline = true;
            MainTextBox.Name = "MainTextBox";
            MainTextBox.ScrollBars = ScrollBars.Vertical;
            MainTextBox.Size = new Size(783, 403);
            MainTextBox.TabIndex = 0;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new Size(32, 32);
            MenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(800, 40);
            MenuStrip.TabIndex = 1;
            MenuStrip.Text = "MenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFromFileToolStripMenuItem, openFibonacciNumbersToolStripMenuItem, saveToFileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "File";
            // 
            // openFromFileToolStripMenuItem
            // 
            openFromFileToolStripMenuItem.Name = "openFromFileToolStripMenuItem";
            openFromFileToolStripMenuItem.Size = new Size(418, 44);
            openFromFileToolStripMenuItem.Text = "Open From File...";
            openFromFileToolStripMenuItem.Click += openFromFileToolStripMenuItem_Click;
            // 
            // openFibonacciNumbersToolStripMenuItem
            // 
            openFibonacciNumbersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { first50ToolStripMenuItem, first100ToolStripMenuItem });
            openFibonacciNumbersToolStripMenuItem.Name = "openFibonacciNumbersToolStripMenuItem";
            openFibonacciNumbersToolStripMenuItem.Size = new Size(418, 44);
            openFibonacciNumbersToolStripMenuItem.Text = "Open Fibonacci Numbers";
            // 
            // first50ToolStripMenuItem
            // 
            first50ToolStripMenuItem.Name = "first50ToolStripMenuItem";
            first50ToolStripMenuItem.Size = new Size(252, 44);
            first50ToolStripMenuItem.Text = "First 50...";
            first50ToolStripMenuItem.Click += first50ToolStripMenuItem_Click;
            // 
            // first100ToolStripMenuItem
            // 
            first100ToolStripMenuItem.Name = "first100ToolStripMenuItem";
            first100ToolStripMenuItem.Size = new Size(252, 44);
            first100ToolStripMenuItem.Text = "First 100...";
            first100ToolStripMenuItem.Click += first100ToolStripMenuItem_Click;
            // 
            // saveToFileToolStripMenuItem
            // 
            saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            saveToFileToolStripMenuItem.Size = new Size(418, 44);
            saveToFileToolStripMenuItem.Text = "Save To File...";
            saveToFileToolStripMenuItem.Click += saveToFileToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainTextBox);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Name = "MainWindow";
            Text = "322 Text Editor";
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MainTextBox;
        private OpenFileDialog OpenFileDialog;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFromFileToolStripMenuItem;
        private ToolStripMenuItem openFibonacciNumbersToolStripMenuItem;
        private ToolStripMenuItem first50ToolStripMenuItem;
        private ToolStripMenuItem first100ToolStripMenuItem;
        private ToolStripMenuItem saveToFileToolStripMenuItem;
        private SaveFileDialog SaveFileDialog;
    }
}