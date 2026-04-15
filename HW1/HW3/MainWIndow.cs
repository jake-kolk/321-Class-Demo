// <copyright file="MainWindow.cs" company="WSU">
// Copyright (c) YourCompanyName. All rights reserved.
// </copyright>
namespace HW3
{
    /// <summary>
    /// Represents the main window of the application.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void LoadText(TextReader reader)
        {
            if (reader == null)
            {
                return;
            }

            this.MainTextBox.Clear();

            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                this.MainTextBox.AppendText(line + Environment.NewLine);
            }
        }

        /// <summary>
        /// This opens file save dialog and saved file.
        /// </summary>
        /// <param name="sender">Frameworkargs.</param>
        /// <param name="e">Framework args.</param>
        private void openFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string? fileName = this.OpenFileDialog.FileName;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    this.LoadText(reader);
                }
            }
        }

        /// <summary>
        /// Reads the first 50 fib numbers.
        /// </summary>
        /// <param name="sender">sends args.</param>
        /// <param name="e">Event Args.</param>
        private void first50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FibonacciTextReader reader = new FibonacciTextReader(50))
            {
                this.LoadText(reader);
            }
        }

        /// <summary>
        /// Reads the first 100 fib numbers.
        /// </summary>
        /// <param name="sender">sends args.</param>
        /// <param name="e">Event Args.</param>
        private void first100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FibonacciTextReader reader = new FibonacciTextReader(100))
            {
                this.LoadText(reader);
            }
        }

        /// <summary>
        /// This funtion saved the current text box into a file.
        /// </summary>
        /// <param name="sender"> Caller.</param>
        /// <param name="e">Event args.</param>
        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.Title = "Save your file";
                dialog.DefaultExt = "txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = dialog.FileName;

                    File.WriteAllText(fileName, this.MainTextBox.Text);
                }
            }
        }
    }
}