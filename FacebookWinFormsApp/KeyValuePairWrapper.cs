using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class KeyValuePairWrapper
    {
        public string Key { get; set; }
        public List<WishListItem> Value { get; set; }
        public KeyValuePairWrapper() { }
        public KeyValuePairWrapper(string i_Key, List<WishListItem> i_Value)
        {
            Key = i_Key;
            Value = i_Value;
        }
    }
}
