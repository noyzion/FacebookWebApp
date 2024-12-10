using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class ListObject
    {
        public string Text { get; set; }
        public string PhotoUrl { get; set; }
        public bool m_Checked;
        public ListObject() { }
        public ListObject(string text, string photoUrl)
        {
            Text = text;
            PhotoUrl = photoUrl;
        }
        public ListObject(string text)
        {
            Text = text;
            PhotoUrl = null;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            ListObject other = (ListObject)obj;

            return Text == other.Text;
        }
        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }
    }
}
