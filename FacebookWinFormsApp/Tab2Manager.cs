using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public class ListObject
    {
        public string m_Text { get; set; }
        public string m_PhotoUrl { get; set; }

        public bool m_Checked;

        public ListObject() { }

        public ListObject(string text, string photoUrl)
        {
            m_Text = text;
            m_PhotoUrl = photoUrl;
        }

        public ListObject(string text)
        {
            m_Text = text;
            m_PhotoUrl = null;
        }
    }

    public class KeyValuePairWrapper
    {
        public string Key { get; set; }
        public List<ListObject> Value { get; set; }

        public KeyValuePairWrapper() { }

        public KeyValuePairWrapper(string key, List<ListObject> value)
        {
            Key = key;
            Value = value;
        }
    }

    public class Tab2Manager
    {
        public List<KeyValuePairWrapper> m_WishlistValues { get; set; }

        public Tab2Manager()
        {
            m_WishlistValues = new List<KeyValuePairWrapper>();
        }

        public void AddToWishlist(string category, ListObject item)
        {
            var existingCategory = m_WishlistValues.FirstOrDefault(kvp => kvp.Key == category);

            if (existingCategory == null)
            {
                m_WishlistValues.Add(new KeyValuePairWrapper(category, new List<ListObject> { item }));
            }
            else
            {
                existingCategory.Value.Add(item);
            }
        }


        public void ShareWishlist(
           CheckedListBox foodListBox,
           CheckedListBox activitiesListBox,
           CheckedListBox petsListBox,
           CheckedListBox shoppingListBox)
        {
            try
            {
                DisplayCombinedWishlistPopup(foodListBox, activitiesListBox, petsListBox, shoppingListBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sharing wishlist: {ex.Message}");
            }
        }

        private void DisplayCombinedWishlistPopup(
     CheckedListBox foodListBox,
     CheckedListBox activitiesListBox,
     CheckedListBox petsListBox,
     CheckedListBox shoppingListBox)
        {
            Form popupForm = new Form
            {
                Text = "My Wishlist",
                Size = new Size(870, 580),
                StartPosition = FormStartPosition.CenterScreen,
                AutoScroll = true
            };

            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(10)
            };

            mainPanel.Controls.Add(CreateCategoryPanel("Food", foodListBox));
            mainPanel.Controls.Add(CreateCategoryPanel("Activities", activitiesListBox));
            mainPanel.Controls.Add(CreateCategoryPanel("Pets", petsListBox));
            mainPanel.Controls.Add(CreateCategoryPanel("Shopping", shoppingListBox));

            popupForm.Controls.Add(mainPanel);

            popupForm.ShowDialog();
        }

        private Panel CreateCategoryPanel(string categoryName, CheckedListBox checkedListBox)
        {
            FlowLayoutPanel categoryPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Size = new Size(200, 500),
                Padding = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label categoryLabel = new Label
            {
                Text = categoryName,
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Margin = new Padding(5)
            };
            categoryPanel.Controls.Add(categoryLabel);

            if (checkedListBox.Items.Count > 0)
            {
                foreach (ListObject item in checkedListBox.Items)
                {
                    Panel itemPanel = new Panel
                    {
                        Size = new Size(180, 100),
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(5)
                    };

                    Label label = new Label
                    {
                        Text = $"{item.m_Text}" + (item.m_Checked ? " (Achieved ✅)" : ""),
                        AutoSize = true,
                        Location = new Point(5, 5),
                        Font = new Font("Arial", 10, FontStyle.Regular)
                    };

                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(60, 60),
                        Location = new Point(5, 30),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    if (!string.IsNullOrEmpty(item.m_PhotoUrl) && File.Exists(item.m_PhotoUrl))
                    {
                        pictureBox.Image = Image.FromFile(item.m_PhotoUrl);
                    }
                    else
                    {
                        pictureBox.Image = null;
                    }

                    itemPanel.Controls.Add(label);
                    itemPanel.Controls.Add(pictureBox);

                    categoryPanel.Controls.Add(itemPanel);
                }
            }
            else
            {
                Label emptyMessage = new Label
                {
                    Text = "No items in this category.",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Margin = new Padding(5)
                };

                categoryPanel.Controls.Add(emptyMessage);
            }

            return categoryPanel;
        }

        public void loadImageForPictureBoxInList(CheckedListBox list, PictureBox pictureBox)
        {
            string selectedItemName = list.Text;

            ListObject listObject = FindListObjectByName(selectedItemName);

            if (listObject != null && listObject.m_PhotoUrl != null)
            {
                try
                {
                    pictureBox.Image = Image.FromFile(listObject.m_PhotoUrl);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
        }
        public ListObject FindListObjectByName(string itemName)
        {
            foreach (var kvp in m_WishlistValues)
            {
                foreach (var listObject in kvp.Value)
                {
                    if (listObject.m_Text == itemName)
                    {
                        return listObject;
                    }
                }
            }
            return null;
        }
    }
}



