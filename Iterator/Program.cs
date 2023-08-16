using Iterator;
using static System.Console;

//var root = new Node<int>(1,
//              new Node<int>(2), new Node<int>(3));

//// C++ style
//var it = new InOrderIterator<int>(root);

//while (it.MoveNext())
//{
//    Write(it.Current.Value);
//    Write(',');
//}
//WriteLine();

//// C# style
//var tree = new BinaryTree<int>(root);

//WriteLine(string.Join(",", tree.NaturalInOrder.Select(x => x.Value)));

//// duck typing!
//foreach (var node in tree)
//    WriteLine(node.Value);

var left = new Iterator.PreOrder.Node<int>(2,
              new Iterator.PreOrder.Node<int>(3), new Iterator.PreOrder.Node<int>(4));
var right = new Iterator.PreOrder.Node<int>(5,
              new Iterator.PreOrder.Node<int>(6), new Iterator.PreOrder.Node<int>(7));

var root2 = new Iterator.PreOrder.Node<int>(1, left, right);

foreach (var val in root2)
     WriteLine(val);