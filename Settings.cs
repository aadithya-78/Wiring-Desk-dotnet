using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wiring_Desk;

namespace Wiring_Desk
{
    public partial class Settings : UserControl 
    {
        private Panel parentPanel;
        private Panel panelConfig;
        private Panel panelToolbar;
        private Panel panelFooter;
        private Panel panelPicConfig;

        public Settings(Panel panel, Panel _panelConfig, Panel _panelToolbar, Panel _panelFooter, Panel _panelPicConfig)
        {
            InitializeComponent();
            parentPanel = panel;
            panelConfig = _panelConfig;
            panelToolbar = _panelToolbar;
            panelFooter = _panelFooter;
            panelPicConfig = _panelPicConfig;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (parentPanel == null)
                    throw new Exception("Parent panel reference missing.");

                parentPanel.Controls.Clear();
                ImageWrapper imageWrapperPage = new ImageWrapper();
                imageWrapperPage.Dock = DockStyle.Fill;
                parentPanel.Controls.Add(imageWrapperPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error: " + ex.Message);
                Application.Exit();
            }
        }

       private void btnConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelConfig == null)
                    throw new Exception("Parent panel reference missing.");
                panelPicConfig.Controls.Clear();
                panelPicConfig.BringToFront();
                panelConfig.SendToBack();
                parentPanel.Visible = false;
                panelToolbar.Visible = false;

                Configuration configurationPage = new Configuration(parentPanel,panelConfig, panelToolbar,panelFooter,panelPicConfig);
                configurationPage.Dock = DockStyle.Fill;
                panelPicConfig.Controls.Add(configurationPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error: " + ex.Message);
                Application.Exit();
            }

        }

        private void btnPictureConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelConfig == null)
                    throw new Exception("Parent panel reference missing.");

                panelPicConfig.Controls.Clear();
                panelPicConfig.BringToFront();
                panelConfig.SendToBack();
                panelFooter.SendToBack();
                parentPanel.Visible = false;
                panelToolbar.Visible = false;
                Picture_Config pictureConfig = new Picture_Config(parentPanel, panelConfig, panelToolbar,panelFooter,panelPicConfig);
                pictureConfig.Dock = DockStyle.Fill;
                panelPicConfig.Controls.Add(pictureConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error: " + ex.Message);
                Application.Exit();
            }
        }
    }
}
