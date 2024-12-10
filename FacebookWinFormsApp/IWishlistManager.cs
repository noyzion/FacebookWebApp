using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IWishlistManager
    {
        void AddWishToWishlistValues(string category, ListObject item);
        void RemoveWishFromWishlistValues(string category, ListObject item);
        string ShareWishlist(CheckedListBox foodListBox, CheckedListBox activitiesListBox,
                                   CheckedListBox petsListBox, CheckedListBox shoppingListBox);
        void LoadImageForPictureBoxInList(ListObject listObject, PictureBox pictureBox);
        void DeleteWishFromListBox(CheckedListBox checkedListBox, EWishlistCategories category);
        void UpdateCheckedListBox(CheckedListBox foodList, CheckedListBox petsList,
                                    CheckedListBox activitiesList, CheckedListBox shoppingList,
                                    string category, ListObject item);
        void ResetWishlistUI(CheckedListBox listBoxFood, CheckedListBox listBoxPets,
                                   CheckedListBox listBoxActivities, CheckedListBox listBoxShopping);
    }
}
