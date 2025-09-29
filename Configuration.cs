using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class Configuration : UserControl
    {
        private Panel userControlPanel;
        private Panel configPanel;
        private Panel panelToolbar;
        private Panel panelFooter;
        private Panel panelPicConfig;
        public Configuration(Panel panelUserControl, Panel panelConfig, Panel _panelToolbar, Panel _panelFooter, Panel _panelPicConfig)
        {
            InitializeComponent();
            userControlPanel = panelUserControl;
            configPanel = panelConfig;
            panelToolbar = _panelToolbar;
            panelFooter = _panelFooter;
            panelPicConfig = _panelPicConfig;
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            LoadConnectorGrid();
            LoadBinsGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            panelPicConfig.Controls.Clear();
            panelPicConfig.SendToBack();
            configPanel.BringToFront();

            userControlPanel.Visible = true;
            panelToolbar.Visible = true;

            Settings settingsPage = new Settings(userControlPanel, configPanel, panelToolbar,panelFooter, panelPicConfig);
            settingsPage.Dock = DockStyle.Fill;
            userControlPanel.Controls.Add(settingsPage);
        }

        private void LoadConnectorGrid()
        {
            dgViewConnector.Rows.Clear();
            dgViewConnector.Columns.Clear();

            dgViewConnector.RowHeadersVisible = false;

            dgViewConnector.Columns.Add("colSNo", "S.No");
            dgViewConnector.Columns.Add("colConnector", "Connector");
            dgViewConnector.Columns.Add("colID", "ID");
            dgViewConnector.Columns.Add("colTotalPin", "Total Pin");
            dgViewConnector.Columns.Add("colNavigation", "Navigation");

            dgViewConnector.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgViewConnector.Columns[0].Width = (int)(dgViewConnector.Width * 0.15);
            dgViewConnector.Columns[1].Width = (int)(dgViewConnector.Width * 0.35);
            dgViewConnector.Columns[2].Width = (int)(dgViewConnector.Width * 0.15);
            dgViewConnector.Columns[3].Width = (int)(dgViewConnector.Width * 0.15);
            dgViewConnector.Columns[4].Width = (int)(dgViewConnector.Width * 0.20);

            dgViewConnector.EnableHeadersVisualStyles = false;
            dgViewConnector.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkBlue;
            dgViewConnector.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgViewConnector.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            dgViewConnector.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgViewConnector.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgViewConnector.ColumnHeadersHeight = 40;

            dgViewConnector.ReadOnly = true;
            dgViewConnector.AllowUserToAddRows = false;
            dgViewConnector.AllowUserToResizeColumns = false;
            dgViewConnector.AllowUserToResizeRows = false;
            dgViewConnector.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgViewConnector.DefaultCellStyle.SelectionBackColor = dgViewConnector.DefaultCellStyle.BackColor;
            dgViewConnector.DefaultCellStyle.SelectionForeColor = dgViewConnector.DefaultCellStyle.ForeColor;

            foreach (DataGridViewColumn col in dgViewConnector.Columns)
            {
                col.Frozen = false; 
            }

            int serial = 1; // S.No sequence
            for (int i = 3; i < ConfigReader.ConfigCSV.Count; i++)
            {
                var row = ConfigReader.ConfigCSV[i];

                if (row.Count < 5)
                    continue;

                if (string.IsNullOrWhiteSpace(row[0]) ||
                    string.IsNullOrWhiteSpace(row[1]) ||
                    string.IsNullOrWhiteSpace(row[2]))
                    continue;

                string connector = row[1];
                string id = row[2];
                string totalPin = row[3];
                string navigation = row[4];

                dgViewConnector.Rows.Add(serial, connector, id, totalPin, navigation);
                serial++;
            }
        }

        private void LoadBinsGrid()
        {
            // Clear existing rows and columns
            dgViewBin.Rows.Clear();
            dgViewBin.Columns.Clear();

            // Remove row header (no arrows)
            dgViewBin.RowHeadersVisible = false;

            // Add headers
            dgViewBin.Columns.Add("colSNo", "S.No");
            dgViewBin.Columns.Add("colName", "Name");
            dgViewBin.Columns.Add("colCount", "Count");

            dgViewBin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set column widths in percentage
            dgViewBin.Columns[0].Width = (int)(dgViewBin.Width * 0.20); // S.No
            dgViewBin.Columns[1].Width = (int)(dgViewBin.Width * 0.40); // Name
            dgViewBin.Columns[2].Width = (int)(dgViewBin.Width * 0.40); // Count

            // Header style
            dgViewBin.EnableHeadersVisualStyles = false;
            dgViewBin.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkBlue;
            dgViewBin.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgViewBin.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            dgViewBin.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgViewBin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgViewBin.ColumnHeadersHeight = 40;

            // Make grid read-only and static
            dgViewBin.ReadOnly = true;
            dgViewBin.AllowUserToAddRows = false;
            dgViewBin.AllowUserToResizeColumns = false;
            dgViewBin.AllowUserToResizeRows = false;
            dgViewBin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgViewBin.DefaultCellStyle.SelectionBackColor = dgViewBin.DefaultCellStyle.BackColor;
            dgViewBin.DefaultCellStyle.SelectionForeColor = dgViewBin.DefaultCellStyle.ForeColor;

            // Load data from ConfigCSV starting from row index 3 (skip headers)
            int serial = 1; // S.No auto-generated
            for (int i = 3; i < ConfigReader.ConfigCSV.Count; i++)
            {
                var row = ConfigReader.ConfigCSV[i];

                // Skip rows without 7th column (index 6)
                if (row.Count < 7 || string.IsNullOrWhiteSpace(row[6]))
                    continue;

                string name = row[6];
                string count = row.Count > 7 ? row[7] : "";

                dgViewBin.Rows.Add(serial, name, count);
                serial++;
            }
        }



    }
}
