using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _stored;


        public ITrie Add(string s)
        {
            if (s == "")
            {
                _stored = true;
            } else
            {
                return new TrieWithOneChild(s, _stored);
            }
            return this;
        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _stored;
            }
            else
            {
                return false;
            }
        }
    }
}
