using System;
using System.Linq;
using System.Collections.Generic;

namespace nutility
{
    public class Tree<V> : HashSet<Tree<V>>
    {
        public Tree() { }
        public Tree(IEnumerable<Tree<V>> collection) : base(collection) { }
        public Tree(IEnumerable<Tree<V>> collection, IEqualityComparer<Tree<V>> comparer) : base(collection, comparer) { }
        public Tree(IEqualityComparer<Tree<V>> comparer) : base(comparer) { }
        public Tree(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public V Value { get; set; }
        public Tree<V> Parent { get; set; }

        public override string ToString()
        {
            string value = $"{Value}";
            var result = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement("tree", new System.Xml.Linq.XAttribute("value", value)));
            this.Aggregate(result, (whole, next) =>
            {
                var xml = next?.ToString();
                if (!string.IsNullOrWhiteSpace(xml))
                {
                    whole.Root.Add(System.Xml.Linq.XElement.Parse(xml));
                }
                return whole;
            });
            return result.ToString();
        }

        #region Identity and Equality
        public override bool Equals(object other) => (other as Tree<V>)?.GetHashCode() == GetHashCode();
        public override int GetHashCode() => ToString().GetHashCode();
        #endregion
    }
}