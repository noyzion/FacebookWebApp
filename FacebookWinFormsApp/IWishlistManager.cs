using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IWishlistManager
    {
        void AddWishToWishlistValues(string category, ListObject item);
        void RemoveWishFromWishlistValues(string category, ListObject item);
        string ShareWishlist(CheckedListBox foodListBox, CheckedListBox activitiesListBox,
                                   CheckedListBox petsListBox, CheckedListBox shoppingListBox);

        void loadImageForPictureBoxInList(ListObject listObject, PictureBox pictureBox);

        void deleteWishFromListBox(CheckedListBox checkedListBox, EWishlistCategories category);

        void UpdateCheckedListBox(CheckedListBox foodList, CheckedListBox petsList,
                                    CheckedListBox activitiesList, CheckedListBox shoppingList,
                                    string category, ListObject item);

        void resetWishlistUI(CheckedListBox listBoxFood, CheckedListBox listBoxPets,
                                   CheckedListBox listBoxActivities, CheckedListBox listBoxShopping);
    }
}
