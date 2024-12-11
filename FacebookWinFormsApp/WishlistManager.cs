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
        private string displayCombinedWishlist(CheckedListBox i_FoodListBox, CheckedListBox i_ActivitiesListBox,
                                               CheckedListBox i_PetsListBox, CheckedListBox i_ShoppingListBox)
        {
            StringBuilder wishlistSummary = new StringBuilder();

            wishlistSummary.AppendLine($@"My Wishlist:
Food:{getCategoryItemsAsString(i_FoodListBox)}
Activities:{getCategoryItemsAsString(i_ActivitiesListBox)}
Pets:{getCategoryItemsAsString(i_PetsListBox)}
Shopping:{getCategoryItemsAsString(i_ShoppingListBox)}");

            return wishlistSummary.ToString();
        }
        private string getCategoryItemsAsString(CheckedListBox i_ListBox)
        {
            StringBuilder categoryItems = new StringBuilder();

            foreach (ListObject item in i_ListBox.Items)
            {
                categoryItems.AppendLine($"- {item.Text}" + (item.Checked ? " (Achieved ✅)" : ""));
            }

            return categoryItems.ToString();
        }
        private void displayCombinedWishlistPopup(CheckedListBox i_FoodListBox, CheckedListBox i_ActivitiesListBox,
                                                 CheckedListBox i_PetsListBox, CheckedListBox i_ShoppingListBox)
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
            
            mainPanel.Controls.Add(createCategoryPanel("Food", i_FoodListBox));
            mainPanel.Controls.Add(createCategoryPanel("Activities", i_ActivitiesListBox));
            mainPanel.Controls.Add(createCategoryPanel("Pets", i_PetsListBox));
            mainPanel.Controls.Add(createCategoryPanel("Shopping", i_ShoppingListBox));
            popupForm.Controls.Add(mainPanel);
            popupForm.ShowDialog();
        }
        private Panel createCategoryPanel(string i_Category, CheckedListBox i_CheckedListBox)
        {
            FlowLayoutPanel categoryPanel = createCategoryPanelLayout();
            Label categoryLabel = createCategoryLabel(i_Category);

            categoryPanel.Controls.Add(categoryLabel);
            if (i_CheckedListBox.Items.Count > 0)
            {
                foreach (ListObject item in i_CheckedListBox.Items)
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
        private Label createCategoryLabel(string i_Category)
        {
            return new Label
            {
                Text = i_Category,
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Margin = new Padding(5)
            };
        }
        private Panel createItemPanel(ListObject i_WishlistItem)
        {
            Panel itemPanel = new Panel
            {
                Size = new Size(180, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label labelWishlistItem = createItemLabel(i_WishlistItem);
            PictureBox pictureBoxWishlistItem = createItemPictureBox(i_WishlistItem);

            itemPanel.Controls.Add(labelWishlistItem);
            itemPanel.Controls.Add(pictureBoxWishlistItem);

            return itemPanel;
        }
        private Label createItemLabel(ListObject i_WishlistItem)
        {
            return new Label
            {
                Text = $"{i_WishlistItem.Text}" + (i_WishlistItem.Checked ? " (Achieved ✅)" : ""),
                AutoSize = true,
                Location = new Point(5, 5),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
        }
        private PictureBox createItemPictureBox(ListObject i_WishlistItem)
        {
            PictureBox pictureBoxItem = new PictureBox
            {
                Size = new Size(60, 60),
                Location = new Point(5, 30),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            if (!string.IsNullOrEmpty(i_WishlistItem.PhotoUrl) && File.Exists(i_WishlistItem.PhotoUrl))
            {
                pictureBoxItem.Image = Image.FromFile(i_WishlistItem.PhotoUrl);
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
        public void LoadImageForPictureBoxInList(ListObject i_WishlistItem, PictureBox i_ItemPictureBox)
        {
            if (i_WishlistItem != null && i_WishlistItem.PhotoUrl != null)
            {
                try
                {
                    i_ItemPictureBox.Image = Image.FromFile(i_WishlistItem.PhotoUrl);
                    i_ItemPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
            else
            {
                i_ItemPictureBox.Image = null;
            }
        }
        public void DeleteWishFromListBox(CheckedListBox i_CheckedListBox, EWishlistCategories i_Category)
        {
            ListObject selectedItem = (ListObject)i_CheckedListBox.Items[i_CheckedListBox.SelectedIndex];

            i_CheckedListBox.Items.RemoveAt(i_CheckedListBox.SelectedIndex);
            RemoveWishFromWishlistValues(i_Category.ToString(), selectedItem);
        }
        public void ResetWishlistUI(CheckedListBox i_FoodListBox, CheckedListBox i_PetsListBox,
                                    CheckedListBox i_ActivitiesListBox, CheckedListBox i_ShoppingListBox)
        {
            i_FoodListBox.Items.Clear();
            i_PetsListBox.Items.Clear();
            i_ActivitiesListBox.Items.Clear();
            i_ShoppingListBox.Items.Clear();
        }
        public void UpdateCheckedListBox(CheckedListBox i_FoodListBox, CheckedListBox i_PetsListBox,
                                         CheckedListBox i_ActivitiesListBox, CheckedListBox i_ShoppingListBox,
                                         string i_Category, ListObject i_WishlistItem)
        {
            try
            {
                switch (i_Category)
                {
                    case nameof(EWishlistCategories.Food):
                        i_FoodListBox.Items.Add(i_WishlistItem);
                        break;
                    case nameof(EWishlistCategories.Shopping):
                        i_ShoppingListBox.Items.Add(i_WishlistItem);
                        break;
                    case nameof(EWishlistCategories.Activities):
                        i_ActivitiesListBox.Items.Add(i_WishlistItem);
                        break;
                    case nameof(EWishlistCategories.Pets):
                        i_PetsListBox.Items.Add(i_WishlistItem);
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



