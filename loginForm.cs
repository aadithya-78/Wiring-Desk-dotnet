using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class loginForm : Form
    {
        private Process oskProcess = null;
        public string Username { get; private set; }

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowOSK()
        {
            string oskPath = @"C:\Program Files (x86)\Phoeneix Process Automation\Wiring Desk Setup\OnScreenKeyboard.exe";

            if (!File.Exists(oskPath))
            {
                MessageBox.Show(
                    "OnScreenKeyboard.exe not found in the setup folder.",
                    "Wiring Desk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (oskProcess == null || oskProcess.HasExited)
            {
                oskProcess = new Process();
                oskProcess.StartInfo.FileName = oskPath;
                oskProcess.Start();
            }
        }

        private void CloseOSK()
        {
            if (oskProcess != null && !oskProcess.HasExited)
            {
                oskProcess.Kill();
                oskProcess.Dispose();
                oskProcess = null;
            }
        }


        private void btnLoginPage_Click(object sender, EventArgs e)
        {
            CloseOSK();
            string username = tbUsername.Text.Trim();
            string password = realPassword;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string dbPath = @"login\db.sqlite";
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM users WHERE username=@username AND password=@password";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            this.Username = username;
                            this.DialogResult = DialogResult.OK;
                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking login: " + ex.Message);
                }
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoginPage.PerformClick(); 
                e.SuppressKeyPress = true;
            }
        }
        private string realPassword = "";
        private bool isUpdating = false;
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            isUpdating = true;

            int selStart = tbPassword.SelectionStart;

            if (tbPassword.Text.Length > realPassword.Length)
            {
               
                int addedCount = tbPassword.Text.Length - realPassword.Length;
                string addedText = tbPassword.Text.Substring(selStart - addedCount, addedCount);
                realPassword = realPassword.Insert(selStart - addedCount, addedText);
            }
            else if (tbPassword.Text.Length < realPassword.Length)
            {
                int removedCount = realPassword.Length - tbPassword.Text.Length;
                realPassword = realPassword.Remove(selStart, removedCount);
            }

            tbPassword.Text = new string('•', realPassword.Length);

            tbPassword.SelectionStart = selStart;
            isUpdating = false;
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            ShowOSK();
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            ShowOSK();
        }

        private void loginForm_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
