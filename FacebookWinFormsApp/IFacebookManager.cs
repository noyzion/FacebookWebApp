using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IFacebookManager
    {
        void fetchGroups(ListBox DataListBox);
         void fetchAlbums(ListBox DataListBox);
         void fetchFriends(ListBox DataListBox);
         void fetchPosts(ListBox DataListBox);
         void fetchLiked(ListBox DataListBox);
         void fetchEvents(ListBox DataListBox);

         void post(string message, TextBox statusTextBox);

         string addPhoto();

         string SelectVideoFile();

         Post PostVideo(string filePath);


    }
}
