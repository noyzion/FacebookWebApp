using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
     public partial class FormAppSettings : Form
    {
        public AppSettings appSettings;
        public FormAppSettings(AppSettings appSettings)
        {
            InitializeComponent();
            this.appSettings = appSettings;
            foreach (var permission in appSettings.Permissions)
            {
                int index = listBoxPermissions.Items.IndexOf(permission);
                listBoxPermissions.SetItemChecked(index,true);
            }
            int appIDIndex = comboBoxAppID.Items.IndexOf(appSettings
                .AppID);
            comboBoxAppID.SelectedIndex = appIDIndex;
        }

        StringBuilder m_PermissionsStringBuilder = new StringBuilder();

        private void buttonAddAppID_Click(object sender, EventArgs e)
        {
            comboBoxAppID.Items.Insert(0, textBoxAppID.Text);
            comboBoxAppID.SelectedIndex = 0;
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (comboBoxAppID.SelectedIndex == -1)
            {
                comboBoxAppID.SelectedIndex = 0;
            }
            appSettings.AppID = comboBoxAppID.SelectedItem.ToString();
            appSettings.Permissions = new string[listBoxPermissions.CheckedItems.Count];
            listBoxPermissions.CheckedItems.CopyTo(appSettings.Permissions, 0);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAddPermission_Click(object sender, EventArgs e)
        {
            listBoxPermissions.Items.Add(textBoxPermissionsToAdd.Text);
        }

    }
}
