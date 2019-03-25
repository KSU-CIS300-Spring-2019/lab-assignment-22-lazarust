/* TrieWithOneChild.cs
 * Author: Thomas Lazarus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Bool if the trie contains the string
        /// </summary>
        private bool _contains;

        /// <summary>
        /// The only child
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// Child's label
        /// </summary>
        private char _label;

        public TrieWithOneChild(string s, bool empty)
        {
            if (s == "" || s[0] <'a' || s[0] >'z')
            {
                throw new ArgumentException();
            }

            _contains = empty;
            _label = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }

        /// <summary>
        /// Add Method
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _contains = true;
            }
            else if (s[0].Equals(_label))
            {
                _child = _child.Add(s.Substring(1));
                return this;
            } else
            {
                return new TrieWithManyChildren(s,_contains,_label,_child);
            }
            return this;
            
        }

        public bool Contains(string s)
        {
            if (s == "" )
            {
                return _contains; 
            }
            else if (s[0].Equals(_label))
            {
                return _child.Contains(s.Substring(1));
                
            }
            else
            {
                return false; 
            }
        }
    }
}
