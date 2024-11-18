using System;


namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 50, 30, 70, 20, 40, 60, 80 };

            BinarySearchTree bst = new BinarySearchTree();
            bst.BuildFromArray(array);

            Console.WriteLine("Бинарное дерево поиска создано.");
            bst.InOrderTraversal();

            Console.Write("Введите число для поиска: ");
            int target = int.Parse(Console.ReadLine());

            if (bst.Search(target))
                Console.WriteLine($"Число {target} найдено в дереве.");
            else
                Console.WriteLine($"Число {target} отсутствует в дереве.");
        }
    }

    class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    class BinarySearchTree
    {
        public Node Root;

        public void Insert(int value)
        {
            Root = InsertRecursively(Root, value);
        }

        private Node InsertRecursively(Node node, int value)
        {
            if (node == null)
                return new Node(value);

            if (value < node.Value)
                node.Left = InsertRecursively(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRecursively(node.Right, value);

            return node;
        }

        public void BuildFromArray(int[] array)
        {
            foreach (var value in array)
                Insert(value);
        }

        public bool Search(int value)
        {
            return SearchRecursively(Root, value);
        }

        private bool SearchRecursively(Node node, int value)
        {
            if (node == null)
                return false;

            if (node.Value == value)
                return true;

            if (value < node.Value)
                return SearchRecursively(node.Left, value);

            return SearchRecursively(node.Right, value);
        }

        public void InOrderTraversal()
        {
            Console.WriteLine("Обход дерева (InOrder):");
            InOrderTraversal(Root);
            Console.WriteLine();
        }

        private void InOrderTraversal(Node node)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversal(node.Right);
        }
    }
}
