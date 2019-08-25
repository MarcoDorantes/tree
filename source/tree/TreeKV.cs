using System.Linq;
using System.Collections.Generic;

namespace nutility
{
    public class Tree<K, V> : Dictionary<K, Tree<K, V>>
    {
        public Tree() { }
        public Tree(int capacity) : base(capacity) { }
        public Tree(IEqualityComparer<K> comparer) : base(comparer) { }
        public Tree(IDictionary<K, Tree<K, V>> dictionary) : base(dictionary) { }
        public Tree(int capacity, IEqualityComparer<K> comparer) : base(capacity, comparer) { }
        public Tree(IDictionary<K, Tree<K, V>> dictionary, IEqualityComparer<K> comparer) : base(dictionary, comparer) { }
        public Tree(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public V Value { get; set; }

        public override string ToString()
        {
            string value = $"{Value}";
            var result = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement("tree", new System.Xml.Linq.XAttribute("value", value)));
            this.Aggregate(result, (whole, next) =>
            {
                var subtree = new System.Xml.Linq.XElement("tree", new System.Xml.Linq.XAttribute("key", next.Key));
                subtree.Add(System.Xml.Linq.XElement.Parse(next.Value.ToString()));
                whole.Root.Add(subtree);
                return whole;
            });
            return result.ToString();
        }

        #region Identity and Equality
        public override bool Equals(object other) => (other as Tree<K, V>)?.GetHashCode() == GetHashCode();
        public override int GetHashCode() => ToString().GetHashCode();
        #endregion
    }
}