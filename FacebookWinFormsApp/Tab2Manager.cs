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



        public void ShareWishlist(CheckedListBox foodListBox, CheckedListBox activitiesListBox, CheckedListBox petsListBox, CheckedListBox shoppingListBox)
        {
            try
            {
                StringBuilder wishlist = new StringBuilder("My Wishlist:\n");

                wishlist.Append("Food:\n" + getCheckedItemsAsString(foodListBox));
                wishlist.Append("\nActivities:\n" + getCheckedItemsAsString(activitiesListBox));
                wishlist.Append("\nPets:\n" + getCheckedItemsAsString(petsListBox));
                wishlist.Append("\nShopping:\n" + getCheckedItemsAsString(shoppingListBox));

                MessageBox.Show(wishlist.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sharing wishlist: {ex.Message}");
            }
        }

        private string getCheckedItemsAsString(CheckedListBox checkedListBox)
        {
            List<string> checkedItems = new List<string>();
            foreach (var item in checkedListBox.CheckedItems)
            {
                checkedItems.Add(item.ToString());
            }
            return string.Join(", ", checkedItems);
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
                        listObject.m_Checked = true;
                        return listObject;
                    }
                }
            }
            return null;
        }
    }
}



