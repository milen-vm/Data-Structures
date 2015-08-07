using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class EscapeFromLabyrinth
{
    const char VisitedCell = 's';

    static int width = 9;
    static int height = 7;
    static char[,] labirint = 
    {
        {'*', '*', '*', '*', '*', '*', '*', '*', '*'},
        {'*', '-', '-', '-', '-', '*', '*', '-', '-'},
        {'*', '*', '-', '*', '-', '-', '-', '-', '*'},
        {'*', '-', '-', '*', '-', '*', '-', '*', '*'},
        {'*', 's', '*', '-', '-', '*', '-', '*', '*'},
        {'*', '*', '-', '-', '-', '-', '-', '-', '*'},
        {'*', '*', '*', '*', '*', '*', '*', '-', '*'}
    };

    public static void Main()
    {
        string shortestPathToExit = FindShortestPathToExit();
        if (shortestPathToExit == null)
        {
            Console.WriteLine("No exit");
        }
        else if (shortestPathToExit == "")
        {
            Console.WriteLine("Start is at the exit");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortestPathToExit);
        }
    }

    static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();
        if (startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);
        while (queue.Count > 0)
        {
            var curentCell = queue.Dequeue();
            if (IsExit(curentCell))
            {
                return TracePathBack(curentCell);
            }

            TryDirection(queue, curentCell, "U", 0, -1);
            TryDirection(queue, curentCell, "R", 1, 0);
            TryDirection(queue, curentCell, "D", 0, 1);
            TryDirection(queue, curentCell, "L", -1, 0);
        }

        return null;
    }

    static Point FindStartPosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (labirint[y, x] == VisitedCell)
                {
                    return new Point() { X = x, Y = y };
                }
            }
        }

        return null;
    }

    static bool IsExit(Point currentCell)
    {
        bool isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
        bool isOnBorderY = currentCell.Y == 0 || currentCell.Y == height - 1;

        return isOnBorderX || isOnBorderY;
    }

    static void TryDirection(Queue<Point> queue, Point currentCell, 
        string direction, int deltaX, int deltaY)
    {
        int newX = currentCell.X + deltaX;
        int newY = currentCell.Y + deltaY;
        if (newX >= 0 && newX < width && newY >= 0 && newY < height && labirint[newY, newX] == '-') {
            labirint[newY, newX] = VisitedCell;
            var nextCell = new Point()
            {
                X = newX,
                Y = newX,
                Direction = direction,
                PreviousPoint = currentCell
            };

            queue.Enqueue(nextCell);
        }
    }

    static string TracePathBack(Point currentCell)
    {
        var path = new StringBuilder();
        while (currentCell.PreviousPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PreviousPoint;
        }

        var pathReversed = new StringBuilder();
        for (int i = path.Length - 1; i >= 0; i--)
        {
            pathReversed.Append(path[i]);
        }

        return pathReversed.ToString();
    }
}
