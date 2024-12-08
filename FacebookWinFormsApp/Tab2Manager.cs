

using FacebookWrapper;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures
{
    internal class Tab2Manager
    {
        public string m_Text { get; set; }
        public string m_PhotoUrl { get; set; }
       
        private LoginResult m_LoginResult;

        public Tab2Manager(LoginResult loginResult)
        {
            m_LoginResult = loginResult;
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

                var postedStatus = m_LoginResult.LoggedInUser.PostStatus(wishlist.ToString());
                MessageBox.Show($"Wishlist shared successfully! Post ID: {postedStatus.Id}");
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

        

        /*
        public void FetchRecommendations(string category, ListBox recommendationListBox)
        {
            try
            {
                recommendationListBox.Items.Clear();

                var recommendations = m_LoginResult.LoggedInUser.Groups
                    .Where(group => group.Name.Contains(category, StringComparison.OrdinalIgnoreCase));

                foreach (var group in recommendations)
                {
                    recommendationListBox.Items.Add(group.Name);
                }

                if (recommendationListBox.Items.Count == 0)
                {
                    MessageBox.Show($"No recommendations found for category '{category}'.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching recommendations: {ex.Message}");
            }
        }
        */
    }
}
