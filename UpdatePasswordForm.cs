using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class UpdatePasswordForm : Form
    {
        public UpdatePasswordForm()
        {
            InitializeComponent();
            LoadUserNames();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        private void UpdatePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadUserNames()
        {
            up_cmbUsername.DrawMode = DrawMode.OwnerDrawFixed;
            up_cmbUsername.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                e.DrawBackground();

                string text = up_cmbUsername.Items[e.Index].ToString();

                Color color = text == "admin" ? Color.Gray : e.ForeColor;

                using (Brush brush = new SolidBrush(color))
                {
                    e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
                }

                e.DrawFocusRectangle();
            };

            string dbPath = @"login\db.sqlite";
            string connectionString = $"Data Source={dbPath};Version=3;";
            up_cmbUsername.Items.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT username FROM users";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            up_cmbUsername.Items.Add(reader["username"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading usernames: " + ex.Message);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = up_cmbUsername.SelectedItem?.ToString();
            string oldPass = upf_rtbOldPass.Text;
            string newPass = upf_rtbNewPass.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please select a username.");
                return;
            }

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please enter both old and new passwords.");
                return;
            }

            string dbPath = @"login\db.sqlite";
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@oldPass";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        checkCmd.Parameters.AddWithValue("@oldPass", oldPass);
                        long count = (long)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Old password is incorrect.");
                            return;
                        }
                    }

                    string updateQuery = "UPDATE users SET password=@newPass WHERE username=@username";
                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@newPass", newPass);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Password updated successfully!");

                    upf_rtbOldPass.Clear();
                    upf_rtbNewPass.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message);
            }
        }
    }
}
