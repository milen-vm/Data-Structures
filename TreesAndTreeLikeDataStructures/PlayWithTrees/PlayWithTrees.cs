namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PlayWithTrees
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        static void Main()
        {
            Console.Write("Enter node count: ");
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            var rootNode = FindRootNode();
            Console.WriteLine("Root node: " + rootNode.Value);

            var leafValues = FindLeafNodes().Select(node => node.Value)
                .OrderBy(value => value)
                .ToList();
            Console.WriteLine("Leaf nodes: " + string.Join(", ", leafValues));

            var middleValues = FindMiddleNodes().Select(node => node.Value)
                .OrderBy(value => value)
                .ToList();
            Console.WriteLine("Middle nodes: " + string.Join(", ", middleValues));

            var longestPath = FindLongestPath(rootNode).Select(node => node.Value)
                .Reverse()
                .ToList();
            Console.WriteLine("Longest path: {0} (length = {1})",
                string.Join(" -> ", longestPath), longestPath.Count);
        }

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (! nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values
                .FirstOrDefault(node => node.Parent == null);

            return rootNode;
        }

        static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(node => node.Children.Count == 0)
                .ToList();

            return leafNodes;
        }

        static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(node => node.Children.Count > 0 &&
                    node.Parent != null)
                .ToList();

            return middleNodes;
        }

        static IList<Tree<int>> FindLongestPath(Tree<int> treeNode)
        {
            IList<Tree<int>> longestPath = new List<Tree<int>>();
            foreach (var child in treeNode.Children)
            {
                var currentPath = FindLongestPath(child);
                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            longestPath.Add(treeNode);

            return longestPath;
        }

        static List<List<Tree<int>>> FindPathsOfSum(Tree<int> treeNode, int sum)
        {
            List<List<Tree<int>>> paths = new List<List<Tree<int>>>();
            foreach (var child in treeNode.Children)
            {

            }

            return paths;
        }
    }
}
