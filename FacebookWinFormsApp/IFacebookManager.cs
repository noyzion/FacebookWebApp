using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IFacebookManager
    {
        void FetchGroups(ListBox DataListBox);
         void FetchAlbums(ListBox DataListBox);
         void FetchFriends(ListBox DataListBox);
         void FetchPosts(ListBox DataListBox);
         void FetchLikedPages(ListBox DataListBox);
         void FetchEvents(ListBox DataListBox);
         void Post(string message, TextBox statusTextBox);
         string AddPhoto();
         string SelectVideoFile();
         Post PostVideo(string filePath);
    }
}
