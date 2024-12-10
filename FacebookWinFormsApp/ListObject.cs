using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            ListObject other = (ListObject)obj;

            return m_Text == other.m_Text;
        }

    
    }
}
    