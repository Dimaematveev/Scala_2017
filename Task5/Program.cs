using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 10;
            int weight = 10;
            var str = new string[]
            {
                "1 2 3 4 A 6 7 8 9 0",
                "x 2 3 4 5 6 7 8 9 0",
                "1 2 3 4 x 6 7 8 9 0",
                "1 2 3 4 5 6 7 8 9 0",
                "1 2 3 4 5 6 7 8 9 0",
                "1 2 3 4 5 6 7 8 9 0",
                "1 2 3 4 5 6 7 8 9 0",
                "1 2 3 4 5 6 7 8 9 0",
                "1 2 3 4 5 6 7 8 9 0",
                "1 2 3 4 5 6 7 8 9 0",
            };

            Random random = new Random();

            var tempStr = new string[height][];
            for (int i = 0; i < height; i++)
            {
                var temp = new string[weight];
                for (int j = 0; j < weight; j++)
                {
                    temp[j] = $"{random.Next(0, 20)}";
                }
                tempStr[i] = temp;
            }
            int rn = random.Next(0, 30);
            for (int i = 0; i < rn; i++)
            {
                int h = random.Next(0, height - 1);
                int w = random.Next(0, weight - 1);
                tempStr[h][w] = "x";
            }
            int bH = random.Next(0, height - 1);
            int bW = random.Next(0, weight - 1);
            tempStr[bH][bW] = "A";
            do
            {
                int eH = random.Next(0, height - 1);
                int eW = random.Next(0, weight - 1);
                if (eH != bH && eW != bW) 
                {
                    tempStr[eH][eW] = "B";
                    break;
                }
            } while (true);
            str = tempStr.Select(x => x.Aggregate((a1, a2) => a1 + " " + a2)).ToArray();
            foreach (var item in tempStr)
            {
                foreach (var item1 in item)
                {
                    if (item1 == "A" || item1 == "B") 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write($"{item1,5 } ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }

            var terrain = new string[height][];
            Graph.Graph graph = new Graph.Graph();
            string begin="";
            string end="";
            for (int i = 0; i < height; i++)
            {
                terrain[i] = new string[weight];
                var masStr = str[i].Split(' ');
                for (int j = 0; j < weight; j++)
                {
                    terrain[i][j] = masStr[j];
                    if (masStr[j] == "A")
                    {
                        begin = $"H{i}W{j}";
                    }
                    if (masStr[j] == "B")
                    {
                        end = $"H{i}W{j}";
                    }
                    graph.AddVertex($"H{i}W{j}");
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    
                    if (j >= 1)
                    {
                        var wei= GetEdgeWeight(terrain[i][j - 1]);
                        if (wei!=-1)
                        {
                            graph.AddEdge($"H{i}W{j}", $"H{i}W{j - 1}", wei);
                        }
                    }
                    if (j < weight - 1)
                    {
                        var wei = GetEdgeWeight(terrain[i][j + 1]);
                        if (wei != -1)
                        {
                            graph.AddEdge($"H{i}W{j}", $"H{i}W{j + 1}", wei);
                        }
                    }
                    if (i >= 1)
                    {
                        var wei = GetEdgeWeight(terrain[i - 1][j]);
                        if (wei != -1)
                        {
                            graph.AddEdge($"H{i}W{j}", $"H{i - 1}W{j}", wei);
                        }
                    }
                    if (i < height - 1)
                    {
                        var wei = GetEdgeWeight(terrain[i + 1][j]);
                        if (wei != -1)
                        {
                            graph.AddEdge($"H{i}W{j}", $"H{i + 1}W{j}", wei);
                        }
                    }
                }
            }

            var t1 =  graph.FindShortestWay(begin, end);
            if (t1 == null) 
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(t1.CountEdgeWeight);
            }
           

            Console.WriteLine();
            Console.ReadKey();
        }

        private static int GetEdgeWeight(string v)
        {
            int ret = 0;

            if (!int.TryParse(v,out ret))
            {
                switch (v)
                {
                    case "A":
                        ret = -1;
                        break;
                    case "B":
                        ret = 1;
                        break;
                    case " ":
                        ret = 1;
                        break;
                    case "x":
                        ret = -1;
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
            return ret;
        }
    }
}
