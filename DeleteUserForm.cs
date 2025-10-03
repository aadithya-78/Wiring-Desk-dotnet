using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Wiring_Desk
{
    public partial class DeleteUserForm : Form
    {
        public DeleteUserForm()
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

        private void DeleteUserForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadUserNames()
        {
            du_cmbUsername.DrawMode = DrawMode.OwnerDrawFixed;
            du_cmbUsername.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                e.DrawBackground();

                string text = du_cmbUsername.Items[e.Index].ToString();

                Color color = text == "admin" ? Color.Gray : e.ForeColor;

                using (Brush brush = new SolidBrush(color))
                {
                    e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
                }

                e.DrawFocusRectangle();
            };

            string dbPath = @"login\db.sqlite";
            string connectionString = $"Data Source={dbPath};Version=3;";
            du_cmbUsername.Items.Clear();

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
                            du_cmbUsername.Items.Add(reader["username"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading usernames: " + ex.Message);
                }
            }

            du_cmbUsername.SelectedIndexChanged += (s, e) =>
            {
                if (du_cmbUsername.SelectedItem != null && du_cmbUsername.SelectedItem.ToString() == "admin")
                {
                    du_cmbUsername.SelectedIndex = -1; 
                }
            };
        }


        private void du_cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
