using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    class State
    {
        public int ID { get; set; }
        public bool IsFinal { get; set; }
        public string MatchedSymbol { get; set; }

        public override bool Equals(object obj)
        {
            return this.ID.Equals((obj as State).ID);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
