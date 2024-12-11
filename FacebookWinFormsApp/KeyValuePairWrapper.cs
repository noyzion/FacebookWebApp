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
        public List<ListObject> Value { get; set; }
        public KeyValuePairWrapper() { }
        public KeyValuePairWrapper(string i_Key, List<ListObject> i_Value)
        {
            Key = i_Key;
            Value = i_Value;
        }
    }
}
