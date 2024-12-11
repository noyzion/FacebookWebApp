using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IWishlistManager 
    {
        void AddWishToWishlistValues(string i_Category, WishListItem i_ItemToAdd);
        void RemoveWishFromWishlistValues(string i_Category, WishListItem i_ItemToAdd);
        string ShareWishlist(CheckedListBox i_FoodListBox, CheckedListBox i_ActivitiesListBox,
                             CheckedListBox i_PetsListBox, CheckedListBox i_ShoppingListBox);
        void LoadImageForPictureBoxInList(WishListItem i_WishlistItem, PictureBox i_ItemPictureBox);
        void DeleteWishFromListBox(CheckedListBox i_CheckedListBox, EWishlistCategories i_Category);
        void UpdateCheckedListBox(CheckedListBox i_FoodListBox, CheckedListBox i_PetsListBox,
                                   CheckedListBox i_ActivitiesListBox, CheckedListBox i_ShoppingListBox,
                                   string i_Category, WishListItem i_WishlistItem);
        void ResetWishlistUI(CheckedListBox i_FoodListBox, CheckedListBox i_PetsListBox,
                             CheckedListBox i_ActivitiesListBox, CheckedListBox i_ShoppingListBox);
    }
}
