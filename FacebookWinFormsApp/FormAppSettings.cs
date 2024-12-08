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
            foreach (var permission in appSettings.s_Permissions)
            {
                int index = listBoxPermissions.Items.IndexOf(permission);
                listBoxPermissions.SetItemChecked(index,true);
            }
            int appIDIndex = comboAppID.Items.IndexOf(appSettings
                .s_AppID);
            comboAppID.SelectedIndex = appIDIndex;
        }

        StringBuilder m_PermissionsStringBuilder = new StringBuilder();

        private void buttonAddAppID_Click(object sender, EventArgs e)
        {
            comboAppID.Items.Insert(0, textBoxAppID.Text);
            comboAppID.SelectedIndex = 0;
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (comboAppID.SelectedIndex == -1)
            {
                comboAppID.SelectedIndex = 0;
            }
            appSettings.s_AppID = comboAppID.SelectedItem.ToString();
            appSettings.s_Permissions = new string[listBoxPermissions.CheckedItems.Count];
            listBoxPermissions.CheckedItems.CopyTo(appSettings.s_Permissions, 0);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAddPermission_Click(object sender, EventArgs e)
        {
            listBoxPermissions.Items.Add(textBoxPermissionsToAdd.Text);
        }

        private void listBoxPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboAppID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
