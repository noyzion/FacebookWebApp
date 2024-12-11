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
        public List<KeyValuePairWrapper> WishlistValues { get; set; }
        public WishlistManager()
        {
            WishlistValues = new List<KeyValuePairWrapper>();
        }
        public void AddWishToWishlistValues(string i_Category, ListObject i_ItemToAdd)
        {
            KeyValuePairWrapper existingCategoryList = WishlistValues.FirstOrDefault(kvp => kvp.Key == i_Category);

            if (existingCategoryList == null)
            {
                WishlistValues.Add(new KeyValuePairWrapper(i_Category, new List<ListObject> { i_ItemToAdd }));
            }
            else
            {
                if (!existingCategoryList.Value.Contains(i_ItemToAdd))
                {
                    existingCategoryList.Value.Add(i_ItemToAdd);
                }
                else
                {
                    throw new Exception("You can't add two items with the same name to the same list!");
                }
            }
        }
        public void RemoveWishFromWishlistValues(string i_Category, ListObject i_ItemToAdd)
        {
            KeyValuePairWrapper existingCategory = WishlistValues.FirstOrDefault(kvp => kvp.Key == i_Category);

            if (existingCategory.Key != null)
            {
                existingCategory.Value.Remove(i_ItemToAdd);
                if (existingCategory.Value.Count == 0)
                {
                    WishlistValues.Remove(existingCategory);
                }
            }
        }
        public string ShareWishlist(CheckedListBox i_FoodListBox, CheckedListBox i_ActivitiesListBox,
                                    CheckedListBox i_PetsListBox, CheckedListBox i_ShoppingListBox)
        {
            string wishlistString;

            try
            {
                wishlistString = displayCombinedWishlist(i_FoodListBox, i_ActivitiesListBox, i_PetsListBox, i_ShoppingListBox);

                displayCombinedWishlistPopup(i_FoodListBox, i_ActivitiesListBox, i_PetsListBox, i_ShoppingListBox);

            }
            catch (Exception ex)
            {
                wishlistString = $"Error sharing wishlist: {ex.Message}";
            }

            return wishlistString;
        }
        private string displayCombinedWishlist(CheckedListBox foodListBox, CheckedListBox activitiesListBox,
                                                CheckedListBox petsListBox, CheckedListBox shoppingListBox)
        {
            StringBuilder wishlistSummary = new StringBuilder();

            wishlistSummary.AppendLine($@"My Wishlist:
Food:{getCategoryItemsAsString(foodListBox)}
Activities:{getCategoryItemsAsString(activitiesListBox)}
Pets:{getCategoryItemsAsString(petsListBox)}
Shopping:{getCategoryItemsAsString(shoppingListBox)}");

            return wishlistSummary.ToString();
        }
        private string getCategoryItemsAsString(CheckedListBox listBox)
        {
            StringBuilder categoryItems = new StringBuilder();

            foreach (ListObject item in listBox.Items)
            {
                categoryItems.AppendLine($"- {item.Text}" + (item.m_Checked ? " (Achieved ✅)" : ""));
            }

            return categoryItems.ToString();
        }
        private void displayCombinedWishlistPopup(CheckedListBox foodListBox, CheckedListBox activitiesListBox,
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

            mainPanel.Controls.Add(createCategoryPanel("Food", foodListBox));
            mainPanel.Controls.Add(createCategoryPanel("Activities", activitiesListBox));
            mainPanel.Controls.Add(createCategoryPanel("Pets", petsListBox));
            mainPanel.Controls.Add(createCategoryPanel("Shopping", shoppingListBox));
            popupForm.Controls.Add(mainPanel);
            popupForm.ShowDialog();
        }
        private Panel createCategoryPanel(string categoryName, CheckedListBox checkedListBox)
        {
            FlowLayoutPanel categoryPanel = createCategoryPanelLayout();
            Label categoryLabel = createCategoryLabel(categoryName);

            categoryPanel.Controls.Add(categoryLabel);
            if (checkedListBox.Items.Count > 0)
            {
                foreach (ListObject item in checkedListBox.Items)
                {
                    Panel itemPanel = createItemPanel(item);
                    categoryPanel.Controls.Add(itemPanel);
                }
            }
            else
            {
                Label emptyMessage = createEmptyMessageLabel();
                categoryPanel.Controls.Add(emptyMessage);
            }

            return categoryPanel;
        }
        private FlowLayoutPanel createCategoryPanelLayout()
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
        private Label createCategoryLabel(string categoryName)
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
        private Panel createItemPanel(ListObject item)
        {
            Panel itemPanel = new Panel
            {
                Size = new Size(180, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label labelWishlistItem = createItemLabel(item);
            PictureBox pictureBoxWishlistItem = createItemPictureBox(item);

            itemPanel.Controls.Add(labelWishlistItem);
            itemPanel.Controls.Add(pictureBoxWishlistItem);

            return itemPanel;
        }
        private Label createItemLabel(ListObject item)
        {
            return new Label
            {
                Text = $"{item.Text}" + (item.m_Checked ? " (Achieved ✅)" : ""),
                AutoSize = true,
                Location = new Point(5, 5),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
        }
        private PictureBox createItemPictureBox(ListObject item)
        {
            PictureBox pictureBoxItem = new PictureBox
            {
                Size = new Size(60, 60),
                Location = new Point(5, 30),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            if (!string.IsNullOrEmpty(item.PhotoUrl) && File.Exists(item.PhotoUrl))
            {
                pictureBoxItem.Image = Image.FromFile(item.PhotoUrl);
            }
            else
            {
                pictureBoxItem.Image = null;
            }

            return pictureBoxItem;
        }
        private Label createEmptyMessageLabel()
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
        public void LoadImageForPictureBoxInList(ListObject listObject, PictureBox pictureBox)
        {
            if (listObject != null && listObject.PhotoUrl != null)
            {
                try
                {
                    pictureBox.Image = Image.FromFile(listObject.PhotoUrl);
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
        public void DeleteWishFromListBox(CheckedListBox checkedListBox, EWishlistCategories category)
        {
            ListObject selectedItem = (ListObject)checkedListBox.Items[checkedListBox.SelectedIndex];

            checkedListBox.Items.RemoveAt(checkedListBox.SelectedIndex);
            RemoveWishFromWishlistValues(category.ToString(), selectedItem);
        }
        public void ResetWishlistUI(CheckedListBox listBoxFood, CheckedListBox listBoxPets,
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



