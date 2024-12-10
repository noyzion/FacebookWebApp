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

        public KeyValuePairWrapper(string key, List<ListObject> value)
        {
            Key = key;
            Value = value;
        }
    }
}
