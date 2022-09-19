using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replacingBooksPrototype
{
    public class CallNumber : IComparable<CallNumber>
    {
        public string Index { get; set; }
        public string Value { get; set; }

        public CallNumber(string index, string value)
        { 
            this.Index = index;
            this.Value = value;
        }

        public override string ToString()
        {
            return "\n   " + Value;
        }

        public int CompareTo(CallNumber other)
        {
            //Compare by the call number (value)
            var index = this.Value.CompareTo(other.Value);
            if (index == 0)
            {
                return index;
            }
            return index;
        }
    }
}
