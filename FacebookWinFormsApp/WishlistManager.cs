using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public class WishlistManager : IWishlistManager
    {
        public List<KeyValuePairWrapper> m_WishlistValues { get; set; }

        public WishlistManager()
        {
            m_WishlistValues = new List<KeyValuePairWrapper>();
        }

        public void AddWishToWishlistValues(string category, ListObject item)
        {
            KeyValuePairWrapper existingCategoryList = m_WishlistValues.FirstOrDefault(kvp => kvp.Key == category);

            if (existingCategoryList == null)
            {
                m_WishlistValues.Add(new KeyValuePairWrapper(category, new List<ListObject> { item }));
            }
            else
            {
                if (!existingCategoryList.Value.Contains(item))
                {
                    existingCategoryList.Value.Add(item);
                }
                else
                {
                    throw new Exception("You can't add two items with the same name to the same list!");
                }
            }
        }
        public void RemoveWishFromWishlistValues(string category, ListObject item)
        {
            KeyValuePairWrapper existingCategory = m_WishlistValues.FirstOrDefault(kvp => kvp.Key == category);

            if (existingCategory.Key != null)
            {
                existingCategory.Value.Remove(item);
                if (existingCategory.Value.Count == 0)
                {
                    m_WishlistValues.Remove(existingCategory);
                }
            }

        }
        public string ShareWishlist(CheckedListBox foodListBox, CheckedListBox activitiesListBox,
                                    CheckedListBox petsListBox, CheckedListBox shoppingListBox)
        {
            try
            {
                string wishlistString = DisplayCombinedWishlist(foodListBox, activitiesListBox, petsListBox, shoppingListBox);

                DisplayCombinedWishlistPopup(foodListBox, activitiesListBox, petsListBox, shoppingListBox);

                return wishlistString;
            }
            catch (Exception ex)
            {
                return $"Error sharing wishlist: {ex.Message}";
            }
        }

        private string DisplayCombinedWishlist(CheckedListBox foodListBox, CheckedListBox activitiesListBox,
                                                CheckedListBox petsListBox, CheckedListBox shoppingListBox)
        {
            StringBuilder wishlistSummary = new StringBuilder();
            wishlistSummary.AppendLine($@"My Wishlist:
Food:{GetCategoryItemsAsString(foodListBox)}
Activities:{GetCategoryItemsAsString(activitiesListBox)}
Pets:{GetCategoryItemsAsString(petsListBox)}
Shopping:{GetCategoryItemsAsString(shoppingListBox)}");


            return wishlistSummary.ToString();
        }

        private string GetCategoryItemsAsString(CheckedListBox listBox)
        {
            StringBuilder categoryItems = new StringBuilder();

            foreach (ListObject item in listBox.Items)
            {
                categoryItems.AppendLine($"- {item.m_Text}" + (item.m_Checked ? " (Achieved ✅)" : ""));
            }

            return categoryItems.ToString();
        }

        private void DisplayCombinedWishlistPopup(CheckedListBox foodListBox, CheckedListBox activitiesListBox,
                                                  CheckedListBox petsListBox, CheckedListBox shoppingListBox)
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
            FlowLayoutPanel categoryPanel = CreateCategoryPanelLayout();

            Label categoryLabel = CreateCategoryLabel(categoryName);
            categoryPanel.Controls.Add(categoryLabel);

            if (checkedListBox.Items.Count > 0)
            {
                foreach (ListObject item in checkedListBox.Items)
                {
                    Panel itemPanel = CreateItemPanel(item);
                    categoryPanel.Controls.Add(itemPanel);
                }
            }
            else
            {
                Label emptyMessage = CreateEmptyMessageLabel();
                categoryPanel.Controls.Add(emptyMessage);
            }

            return categoryPanel;
        }

        private FlowLayoutPanel CreateCategoryPanelLayout()
        {
            return new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Size = new Size(200, 500),
                Padding = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private Label CreateCategoryLabel(string categoryName)
        {
            return new Label
            {
                Text = categoryName,
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Margin = new Padding(5)
            };
        }

        private Panel CreateItemPanel(ListObject item)
        {
            Panel itemPanel = new Panel
            {
                Size = new Size(180, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label label = CreateItemLabel(item);
            itemPanel.Controls.Add(label);

            PictureBox pictureBox = CreateItemPictureBox(item);
            itemPanel.Controls.Add(pictureBox);

            return itemPanel;
        }

        private Label CreateItemLabel(ListObject item)
        {
            return new Label
            {
                Text = $"{item.m_Text}" + (item.m_Checked ? " (Achieved ✅)" : ""),
                AutoSize = true,
                Location = new Point(5, 5),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
        }

        private PictureBox CreateItemPictureBox(ListObject item)
        {
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

            return pictureBox;
        }

        private Label CreateEmptyMessageLabel()
        {
            return new Label
            {
                Text = "No items in this category.",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                Margin = new Padding(5)
            };
        }

        public void loadImageForPictureBoxInList(ListObject listObject, PictureBox pictureBox)
        {
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
            else
            {
                pictureBox.Image = null;
            }
        }
        public void deleteWishFromListBox(CheckedListBox checkedListBox, EWishlistCategories category)
        {
            ListObject selectedItem = (ListObject)checkedListBox.Items[checkedListBox.SelectedIndex];
            checkedListBox.Items.RemoveAt(checkedListBox.SelectedIndex);
            RemoveWishFromWishlistValues(category.ToString(), selectedItem);
        }

        public void resetWishlistUI(CheckedListBox listBoxFood, CheckedListBox listBoxPets,
                                    CheckedListBox listBoxActivities, CheckedListBox listBoxShopping)
        {
            listBoxFood.Items.Clear();
            listBoxPets.Items.Clear();
            listBoxActivities.Items.Clear();
            listBoxShopping.Items.Clear();
        }

        public void UpdateCheckedListBox(CheckedListBox foodList, CheckedListBox petsList,
                                         CheckedListBox activitiesList, CheckedListBox shoppingList,
                                         string category, ListObject item)
        {
            try
            {
                switch (category)
                {
                    case nameof(EWishlistCategories.food):
                        foodList.Items.Add(item);
                        break;

                    case nameof(EWishlistCategories.shopping):
                        shoppingList.Items.Add(item);
                        break;

                    case nameof(EWishlistCategories.activities):
                        activitiesList.Items.Add(item);
                        break;

                    case nameof(EWishlistCategories.pets):
                        petsList.Items.Add(item);
                        break;

                    default:
                        MessageBox.Show("Invalid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the checked list box: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

    }
}



