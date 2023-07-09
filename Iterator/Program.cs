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

var root2 = new Iterator.PreOrder.Node<int>(1,
              new Iterator.PreOrder.Node<int>(2), new Iterator.PreOrder.Node<int>(3));

foreach (var node in root2)
     WriteLine(node.Value);