using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 개인적으로 작업하고 있는 익스텐션
/// </summary>
public static class Extension
{
    public static int GetPrimeNumberCount(int maxN)
    {
        int answer = 0;
        bool[] table = new bool[maxN];


        for (double i = 2; i <= maxN; i++)
        {
            if (table[(int)i] == false)
            {
                answer++;

                for (double j = i * i; j <= maxN; j += i)
                {
                    table[(int)j] = true;
                }

            }
        }


        table.PrintArray();

        return 0;

    }

    public static IEnumerable<T> SpiralOrder<T>(this T[,] array)
    {
        int x = array.GetLength(1);
        int y = array.GetLength(0);

        int deltaX = 1; int deltaY = 0;
        int rightX = x; int rightY = y;
        int leftX = -1; int leftY = -1;
        int curX = 0; int curY = 0;

        for (int i = 0; i < x * y; i++)
        {
            yield return array[curY, curX];

            if (curX + deltaX == rightX && deltaY == 0)
            {
                deltaX = 0;
                deltaY = 1;
                leftY++;
            }
            else if (curX + deltaX == leftX && deltaY == 0)
            {
                deltaX = 0;
                deltaY = -1;
                rightY--;
            }
            else if (curY + deltaY == rightY && deltaX == 0)
            {
                deltaY = 0;
                deltaX = -1;
                rightX--;
            }
            else if (curY + deltaY == leftY && deltaX == 0)
            {
                deltaY = 0;
                deltaX = 1;
                leftX++;
            }

            curX += deltaX;
            curY += deltaY;
        }
    }

    public static IEnumerable<T> SpiralOrder<T>(T[][] matrix)
    {
        int left = 0;
        int right = matrix[0].Length;
        int top = 0;
        int bottom = matrix.Length;
        while (left < right && top < bottom)
        {
            for (int i = left; i < right; i++)
            {
                yield return matrix[top][i];
            }
            top++;

            for (int i = top; i < bottom; i++)
            {
                yield return matrix[i][right - 1];
            }
            right--;
            if (left >= right || top >= bottom) break;

            for (int i = right - 1; i > left - 1; i--)
            {
                yield return matrix[bottom - 1][i];
            }
            bottom--;

            for (int i = bottom - 1; i > top - 1; i--)
            {
                yield return matrix[i][left];
            }
            left++;
        }
    }

    public static IEnumerable<T[,]> GetWindows<T>(this T[,] array, int windowWidth, int windowHeight)
    {
        var slice = new T[windowWidth, windowHeight];
        var xlength = array.GetLength(1);
        var ylength = array.GetLength(0);


        for (int x = 0; x <= xlength - windowWidth; x++)
        {
            for (int y = 0; y <= ylength - windowHeight; y++)
            {
                for (int i = 0; i < windowHeight; i++)
                {
                    for (int j = 0; j < windowWidth; j++)
                    {
                        if (x + j >= ylength || y + i >= xlength) continue;

                        slice[j, i] = array[x + j, y + i];
                    }
                }
                yield return slice;
            }
        }
    }

    public static int[,] MakeSpiralMatrix(int n)
    {
        return MakeSpiralMatrix(n, n);
    }

    public static int[,] MakeSpiralMatrix(int x, int y)
    {
        var result = new int[y, x];

        int deltaX = 1;
        int deltaY = 0;
        int rightX = x;
        int rightY = y;
        int leftX = -1;
        int leftY = -1;
        int curX = 0;
        int curY = 0;

        for (int i = 0; i < x * y; i++)
        {
            result[curY, curX] = (i + 1);

            if (curX + deltaX == rightX && deltaY == 0)
            {
                deltaX = 0;
                deltaY = 1;
                leftY++;
            }
            else if (curX + deltaX == leftX && deltaY == 0)
            {
                deltaX = 0;
                deltaY = -1;
                rightY--;
            }
            else if (curY + deltaY == rightY && deltaX == 0)
            {
                deltaY = 0;
                deltaX = -1;
                rightX--;
            }
            else if (curY + deltaY == leftY && deltaX == 0)
            {
                deltaY = 0;
                deltaX = 1;
                leftX++;
            }

            curX += deltaX;
            curY += deltaY;
        }

        result.PrintMatrix();

        return result;
    }

    public static void PrintMatrix(this int[,] matrix)
    {
        int mapSizeX = matrix.GetLength(1);
        int mapSizeY = matrix.GetLength(0);

        for (int y = 0; y < mapSizeY; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                Console.Write($"{matrix[y, x]:00} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void PrintArray<T>(this T[] arry)
    {
        int mapSizeX = arry.Length;

        for (int x = 0; x < mapSizeX; x++)
        {
            Console.Write($"{arry[x]:00} ");
        }
        Console.WriteLine();
    }

    public static void PrintArray<T>(this List<T> arry)
    {
        int mapSizeX = arry.Count;

        for (int x = 0; x < mapSizeX; x++)
        {
            Console.Write($"{arry[x]:00} ");
        }
        Console.WriteLine();
    }
}