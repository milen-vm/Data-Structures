using System;
using System.Collections.Generic;

public class GraphConnectedComponents
{
    static List<int>[] graph = new List<int>[]
    {
        new List<int>() { 3, 6 },
        new List<int>() {3, 4, 5, 6 },
        new List<int>() { 8 },
        new List<int>() { 0, 1, 5 },
        new List<int>() { 1, 6 },
        new List<int>() { 1, 3 },
        new List<int>() { 0, 1, 4 },
        new List<int>() {},
        new List<int>() { 2 },
    };

    static bool[] visited;

    public static void Main()
    {
        
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var childNode in graph[node])
            {
                DFS(childNode);
            }

            Console.Write(" " + node);
        }
    }

    static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];
        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component:");
                DFS(startNode);
                Console.WriteLine();
            }
        }
    }

    static List<int>[] ReadGraph()
    {
        int graphSize = int.Parse(Console.ReadLine());
        var graph = new List<int>[graphSize];
        visited = new bool[graphSize];
        for (int row = 0; row < graphSize; row++)
        {
            graph[row] = new List<int>();
            string neighboursLine = Console.ReadLine();
            string[] neighboursSplit = neighboursLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < neighboursSplit.Length; i++)
            {
                graph[row].Add(int.Parse(neighboursSplit[i]));
            }
        }

        return graph;
    }
}
