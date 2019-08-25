using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tree.spec
{
    [TestClass]
    public class TreeV_Spec
    {
        [TestMethod]
        public void reftype_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<string>();
            var tree2 = new nutility.Tree<string>();

            //Act
            tree1.Value = "2";
            tree1.Add(new nutility.Tree<string> { Value = "1" });
            tree1.Add(new nutility.Tree<string> { Value = "3" });
            tree1.Add(new nutility.Tree<string> { Value = null });
            tree2.Value = "2";
            tree2.Add(new nutility.Tree<string> { Value = "1" });
            tree2.Add(new nutility.Tree<string> { Value = "3" });
            tree2.Add(new nutility.Tree<string> { Value = null });

            //Assert
            Assert.AreEqual(tree1, tree2);
        }

        [TestMethod]
        public void reftype_not_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<string>();
            var tree2 = new nutility.Tree<string>();

            //Act
            tree1.Value = "2";
            tree1.Add(new nutility.Tree<string> { Value = "1" });
            tree1.Add(new nutility.Tree<string> { Value = "3" });
            tree1.Add(new nutility.Tree<string> { Value = "2" });
            tree2.Value = "2";
            tree2.Add(new nutility.Tree<string> { Value = "1" });
            tree2.Add(new nutility.Tree<string> { Value = "3" });
            tree2.Add(new nutility.Tree<string> { Value = null });

            //Assert
            Assert.AreNotEqual(tree1, tree2);
        }

        [TestMethod]
        public void valuetype_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int>();
            var tree2 = new nutility.Tree<int>();

            //Act
            tree1.Value = 2;
            tree1.Add(new nutility.Tree<int> { Value = 1 });
            tree1.Add(new nutility.Tree<int> { Value = 3 });
            tree1.Add(new nutility.Tree<int> { Value = 0 });
            tree2.Value = 2;
            tree2.Add(new nutility.Tree<int> { Value = 1 });
            tree2.Add(new nutility.Tree<int> { Value = 3 });
            tree2.Add(new nutility.Tree<int> { Value = 0 });

            //Assert
            Assert.AreEqual(tree1, tree2);
        }

        [TestMethod]
        public void valuetype_not_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int>();
            var tree2 = new nutility.Tree<int>();

            //Act
            tree1.Value = 2;
            tree1.Add(new nutility.Tree<int> { Value = 1 });
            tree1.Add(new nutility.Tree<int> { Value = 3 });
            tree1.Add(new nutility.Tree<int> { Value = 0 });
            tree2.Value = 2;
            tree2.Add(new nutility.Tree<int> { Value = 1 });
            tree2.Add(new nutility.Tree<int> { Value = 3 });
            tree2.Add(new nutility.Tree<int> { Value = 2 });

            //Assert
            Assert.AreNotEqual(tree1, tree2);
            Assert.AreEqual("<tree value=\"2\">\r\n  <tree value=\"1\" />\r\n  <tree value=\"3\" />\r\n  <tree value=\"0\" />\r\n</tree>", $"{tree1}");
            Assert.AreEqual("<tree value=\"2\">\r\n  <tree value=\"1\" />\r\n  <tree value=\"3\" />\r\n  <tree value=\"2\" />\r\n</tree>", $"{tree2}");
        }

        [TestMethod]
        public void nullable_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int?>();
            var tree2 = new nutility.Tree<int?>();

            //Act
            tree1.Value = 2;
            tree1.Add(new nutility.Tree<int?> { Value = 1 });
            tree1.Add(new nutility.Tree<int?> { Value = 3 });
            tree1.Add(new nutility.Tree<int?> { Value = null });
            tree2.Value = 2;
            tree2.Add(new nutility.Tree<int?> { Value = 1 });
            tree2.Add(new nutility.Tree<int?> { Value = 3 });
            tree2.Add(new nutility.Tree<int?> { Value = null });

            //Assert
            Assert.AreEqual(tree1, tree2);
        }

        [TestMethod]
        public void nullable_not_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int?>();
            var tree2 = new nutility.Tree<int?>();

            //Act
            tree1.Value = 2;
            tree1.Add(new nutility.Tree<int?> { Value = 1 });
            tree1.Add(new nutility.Tree<int?> { Value = 3 });
            tree1.Add(new nutility.Tree<int?> { Value = null });
            tree2.Value = 2;
            tree2.Add(new nutility.Tree<int?> { Value = 1 });
            tree2.Add(new nutility.Tree<int?> { Value = 3 });
            tree2.Add(new nutility.Tree<int?> { Value = 1 });

            //Assert
            Assert.AreNotEqual(tree1.GetHashCode(), tree2.GetHashCode());
            Assert.AreNotEqual(tree1, tree2);
            Assert.IsFalse(tree1.Equals(tree2));
        }

        [TestMethod]
        public void nullable_char_not_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<char?>();
            var tree2 = new nutility.Tree<char?>();

            //Act
            tree1.Value = '2';
            tree1.Add(new nutility.Tree<char?> { Value = '1' });
            tree1.Add(new nutility.Tree<char?> { Value = '3' });
            tree1.Add(new nutility.Tree<char?> { Value = null });
            tree2.Value = '2';
            tree2.Add(new nutility.Tree<char?> { Value = '1' });
            tree2.Add(new nutility.Tree<char?> { Value = '3' });
            tree2.Add(new nutility.Tree<char?> { Value = '1' });

            //Assert
            Assert.AreNotEqual(tree1.GetHashCode(), tree2.GetHashCode());
            Assert.AreNotEqual(tree1, tree2);
            Assert.IsFalse(tree1.Equals(tree2));
        }

        [TestMethod]
        public void serialized()
        {
            //Arrange
            var tree = new nutility.Tree<string> { Value = "2" };
            tree.Add(new nutility.Tree<string> { Value = "1" });
            tree.Add(new nutility.Tree<string> { Value = "3" });
            string expected = "<tree value='2'><tree value='1' /><tree value='3' /></tree>";
            var expected_result = System.Xml.Linq.XDocument.Parse(expected);

            //Act
            var actual_result = System.Xml.Linq.XDocument.Parse($"{tree}");

            //Assert
            Assert.AreEqual($"{expected_result}", $"{actual_result}");
        }

        [TestMethod]
        public void is_binary_tree()
        {
            //Arrange
            bool is_binary_tree(nutility.Tree<string> _tree)
            {
                bool _result = false;
                if (_tree != null)
                {
                    _result = _tree.Count == 0 || _tree.Count == 2;
                    var k = _tree.GetEnumerator();
                    while (_result == true && k.MoveNext())
                    {
                        _result = is_binary_tree(k.Current);
                    }
                }
                return _result;
            }

            var tree = new nutility.Tree<string> { Value = "2" };
            tree.Add(new nutility.Tree<string> { Value = "1" });
            tree.Add(new nutility.Tree<string> { Value = "3" });

            //Act
            var result = is_binary_tree(tree);

            //Assert
            Assert.IsTrue(result);
        }
    }
}