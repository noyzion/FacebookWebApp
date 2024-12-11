using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IWishlistManager
    {
        void AddWishToWishlistValues(string i_category, ListObject i_item);
        void RemoveWishFromWishlistValues(string i_category, ListObject i_item);
        string ShareWishlist(CheckedListBox i_foodListBox, CheckedListBox i_activitiesListBox,
                             CheckedListBox i_petsListBox, CheckedListBox i_shoppingListBox);
        void LoadImageForPictureBoxInList(ListObject i_listObject, PictureBox i_pictureBox);
        void DeleteWishFromListBox(CheckedListBox i_checkedListBox, EWishlistCategories i_category);
        void UpdateCheckedListBox(CheckedListBox i_foodList, CheckedListBox i_petsList,
                                   CheckedListBox i_activitiesList, CheckedListBox i_shoppingList,
                                   string i_category, ListObject i_item);
        void ResetWishlistUI(CheckedListBox o_listBoxFood, CheckedListBox o_listBoxPets,
                             CheckedListBox o_listBoxActivities, CheckedListBox o_listBoxShopping);
    }
}
