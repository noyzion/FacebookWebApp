using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IFacebookManager
    {
        void FetchGroups(ListBox i_DataListBox);
        void FetchAlbums(ListBox i_DataListBox);
        void FetchFriends(ListBox i_DataListBox);
        void FetchPosts(ListBox i_DataListBox);
        void FetchLikedPages(ListBox i_DataListBox);
        void FetchEvents(ListBox i_DataListBox);
        void Post(string i_Message, TextBox i_StatusTextBox);
        string AddPhoto();
        string SelectVideoFile();
        Post PostVideo(string i_FilePath);
        void MakeFriendsPanel(ref TableLayoutPanel io_DataPanel, User i_User, PictureBox i_PictureBoxProfile);
        void MakeGroupsPanel(ref TableLayoutPanel io_DataPanel, Group i_Group, PictureBox i_PictureBoxProfile);
        void MakePagePanel(ref TableLayoutPanel io_DataPanel, Page i_Page, PictureBox i_PictureBoxProfile);
        void MakeEventPanel(ref TableLayoutPanel io_DataPanel, Event i_FbEvent);
        void MakeAlbumPanel(ref TableLayoutPanel io_DataPanel, Album i_Album, PictureBox i_PictureBoxProfile);
        void MakePostPanel(ref TableLayoutPanel io_DataPanel, Post i_Post);

    }
}
