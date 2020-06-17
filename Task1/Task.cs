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

            WriteToFile();

        }

        private void WriteToFile()
        {
            var str = ToLineString(false);
            using (StreamWriter sw = new StreamWriter(NameOutputFile))
            {
                foreach (var item in str)
                {
                    sw.WriteLine(item);
                }
            }
        }

        private string[] ToLineString(bool isMax = true)
        {
            var lines = TreeToLine();
            int maxLen = (int)lines.Max(x => x?.Max(y => y?.Length));
            var str = new List<List<string>>();
            var mas = new int?[(int)Math.Pow(2, lines.Length)-1];
            int z = 0;
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                
                var temp = new List<string>();
                for (int k = 0; k < z; k++)
                {
                    temp.Add("");
                }
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (j != 0)
                    {
                        for (int k = 0; k < 2 * z + 1; k++)
                        {
                            temp.Add("");
                        }
                    }
                    if (lines[i][j] == null) 
                    {
                        mas[temp.Count] = null;
                        temp.Add("");
                    }
                    else
                    {
                        mas[temp.Count] = lines.Length - str.Count;
                        temp.Add(lines[i][j]);
                    }
                }
                for (int k = 0; k < z; k++)
                {
                    temp.Add("");
                }
                str.Add(temp);
                z = 2 * z + 1;
            }
            var zz = mas.Where(x => x != null).ToArray();
            str.Reverse();

            var res = new List<string>();

            foreach (var mass in str)
            {
                Console.WriteLine();
                var temp = "";
                for (int i = 0; i < mass.Count; i++)
                {
                    
                    var item = mass[i];
                    if (isMax || mas[i]!=null)
                    {
                        temp += item.ToString().PadRight(maxLen);
                    }
                }
                res.Add(temp);
            }
            return res.ToArray();
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
                        //temp.Add("-");
                    }
                    temp.Add(item?.ToString());
                }
                ret.Add(temp.ToArray());
            }
            return ret.ToArray();
        }
    }
}
