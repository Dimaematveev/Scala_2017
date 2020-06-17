using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Task
    {
        string NameInputFile;
        string NameOutputFile;

        public int N;
        public int[] V;
        BinaryTree<int> BinaryTree;

        public Task(string nameInputFile, string nameOutputFile)
        {
            NameInputFile = nameInputFile;
            NameOutputFile = nameOutputFile;
            ReadInputFile();
            CreateBinaryTree();

            ToConsole();


        }
        public void ToConsole()
        {
            var lines = TreeToLine();
            int maxLen = (int)lines.Max(x => x?.Max(y => y?.Length));
            for (int i = 0; i < lines.Length; i++)
            {
                var mass = lines[i];
                int maxxx = (int)(Math.Pow(2, lines.Length - i - 1)*1.5);
                Console.WriteLine();
                for (int j=0;j<mass.Length;j++)
                {
                    var item = mass[j];
                    if (j%2==1)
                    {
                        Console.Write($"|{new string('-', maxLen)}|");
                    }
                    int allLen = maxxx * (maxLen + 2);
                    if (item==null)
                    {
                        Console.Write($"|{new string(' ', allLen-2)}|");
                    }
                    else
                    {
                        //int len = item.Length;
                       
                        //item = new string(' ', (allLen-len)/2) + item;

                        Console.Write($"|{item.PadRight(allLen-2)}|");
                    }
                }
            }
        }

        private void ReadInputFile()
        {
            
            using (StreamReader sr = new StreamReader(NameInputFile))
            {
                N = Convert.ToInt32(sr.ReadLine());
                V = new int[N];
                for (int i = 0; i < N; i++)
                {
                    V[i] = Convert.ToInt32(sr.ReadLine());
                }
            }
            V = V.Distinct().ToArray();
            N = V.Length;
        }


        private void CreateBinaryTree()
        {
            BinaryTree = new BinaryTree<int>(V[0], null);
            for (int i = 1; i < N; i++)
            {
                BinaryTree.add(V[i]);
            }            
        }

        private string[][] TreeToLine()
        {
            var bt = new List<BinaryTree<int>[]>();
            bt.Add(new BinaryTree<int>[] { BinaryTree });
            while (true)
            {
                bool nul = true;
                var btLast = bt.Last();
                var btM = new BinaryTree<int>[btLast.Length * 2];
                for (int i = 0; i < btLast.Length; i++)
                {
                    if (btLast[i] == null)
                    {
                        btM[i * 2] = null;
                        btM[i * 2 + 1] = null;
                    }
                    else
                    {
                        btM[i * 2] = btLast[i].left;
                        btM[i * 2 + 1] = btLast[i].right;
                        if (nul && (btLast[i].left != null || btLast[i].right != null))
                        {
                            nul = false;
                        }
                    }
                }
                if (nul)
                {
                    break;
                }
                bt.Add(btM);
            }
            //string[][] ret = bt.Select(mass => mass.Select(tree => tree?.ToString()).ToArray()).ToArray();
            List<string[]> ret = new List<string[]>();
            for (int i = 0; i < bt.Count; i++)
            {
                var mass = bt[i];

                List<string> temp = new List<string>();
                for (int j = 0; j < mass.Length; j++)
                {
                    var item = mass[j];

                    if (j%2==1)
                    {
                        temp.Add("-");
                    }
                    temp.Add(item?.ToString());
                }
                ret.Add(temp.ToArray());
            }
            return ret.ToArray();
        }
    }
}
