using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tree.spec
{
    [TestClass]
    public class TreeKV_Spec
    {
        [TestMethod]
        public void value_ref_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int, string>();
            var tree2 = new nutility.Tree<int, string>();

            //Act
            tree1.Value = "R";
            tree1[1] = new nutility.Tree<int, string> { Value = "2" };
            tree1.Add(2, new nutility.Tree<int, string> { Value = "3" });
            tree1[3] = new nutility.Tree<int, string> { Value = null };
            tree2.Value = "R";
            tree2.Add(1, new nutility.Tree<int, string> { Value = "2" });
            tree2[2] = new nutility.Tree<int, string> { Value = "3" };
            tree2[3] = new nutility.Tree<int, string> { Value = null };

            //Assert
            Assert.AreEqual(tree1, tree2);
        }

        [TestMethod]
        public void value_ref_not_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int, string>();
            var tree2 = new nutility.Tree<int, string>();

            //Act
            tree1.Value = "R";
            tree1[1] = new nutility.Tree<int, string> { Value = "2" };
            tree1.Add(2, new nutility.Tree<int, string> { Value = "3" });
            tree1[3] = new nutility.Tree<int, string> { Value = null };
            tree2.Value = "R";
            tree2.Add(1, new nutility.Tree<int, string> { Value = "2" });
            tree2[2] = new nutility.Tree<int, string> { Value = "4" };
            tree2[3] = new nutility.Tree<int, string> { Value = null };

            //Assert
            Assert.AreNotEqual(tree1, tree2);
        }

        [TestMethod]
        public void ref_ref_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<string, string>();
            var tree2 = new nutility.Tree<string, string>();

            //Act
            tree1.Value = "R";
            tree1["1"] = new nutility.Tree<string, string> { Value = "2" };
            tree1.Add("2", new nutility.Tree<string, string> { Value = "3" });
            tree1["3"] = new nutility.Tree<string, string> { Value = null };
            tree2.Value = "R";
            tree2.Add("1", new nutility.Tree<string, string> { Value = "2" });
            tree2["2"] = new nutility.Tree<string, string> { Value = "3" };
            tree2["3"] = new nutility.Tree<string, string> { Value = null };

            //Assert
            Assert.AreEqual(tree1, tree2);
        }

        [TestMethod]
        public void ref_ref_not_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<string, string>();
            var tree2 = new nutility.Tree<string, string>();

            //Act
            tree1.Value = "R";
            tree1["1"] = new nutility.Tree<string, string> { Value = "2" };
            tree1.Add("2", new nutility.Tree<string, string> { Value = "3" });
            tree1["3"] = new nutility.Tree<string, string> { Value = null };
            tree2.Value = "R";
            tree2.Add("1", new nutility.Tree<string, string> { Value = "2" });
            tree2["2"] = new nutility.Tree<string, string> { Value = "4" };
            tree2["3"] = new nutility.Tree<string, string> { Value = null };

            //Assert
            Assert.AreNotEqual(tree1, tree2);
        }

        [TestMethod]
        public void valuetype_nullable_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int, int?>();
            var tree2 = new nutility.Tree<int, int?>();

            //Act
            tree1.Value = 1;
            tree1[1] = new nutility.Tree<int, int?> { Value = 11 };
            tree1.Add(2, new nutility.Tree<int, int?> { Value = 12 });
            tree1[3] = new nutility.Tree<int, int?> { Value = null };
            tree2.Value = 1;
            tree2.Add(1, new nutility.Tree<int, int?> { Value = 11 });
            tree2[2] = new nutility.Tree<int, int?> { Value = 12 };
            tree2[3] = new nutility.Tree<int, int?> { Value = null };

            //Assert
            Assert.AreEqual(tree1, tree2);
        }

        [TestMethod]
        public void valuetype_nullable_not_equal()
        {
            //Arrange
            var tree1 = new nutility.Tree<int, int?>();
            var tree2 = new nutility.Tree<int, int?>();

            //Act
            tree1.Value = 1;
            tree1[1] = new nutility.Tree<int, int?> { Value = 11 };
            tree1.Add(2, new nutility.Tree<int, int?> { Value = 12 });
            tree1[3] = new nutility.Tree<int, int?> { Value = null };
            tree2.Value = 1;
            tree2.Add(1, new nutility.Tree<int, int?> { Value = 11 });
            tree2[2] = new nutility.Tree<int, int?> { Value = 13 };
            tree2[3] = new nutility.Tree<int, int?> { Value = null };

            //Assert
            Assert.AreNotEqual(tree1, tree2);
        }

        [TestMethod]
        public void serialized()
        {
            //Arrange
            var tree = new nutility.Tree<int, string>();
            tree.Value = "R";
            tree[1] = new nutility.Tree<int, string> { Value = "R1" };
            tree.Add(2, new nutility.Tree<int, string> { Value = "R2" });
            string expected = "<tree value='R'><tree key='1'><tree value='R1' /></tree><tree key='2'><tree value='R2' /></tree></tree>";
            var expected_result = System.Xml.Linq.XDocument.Parse(expected);

            //Act
            var actual_result= System.Xml.Linq.XDocument.Parse($"{tree}");

            //Assert
            Assert.AreEqual($"{expected_result}", $"{actual_result}");
        }
    }
}