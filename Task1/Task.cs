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
        public string NameInputFile;
        public string NameOutputFile;

        public int N;
        public int[] V;
        BinaryTree<int> BinaryTree;

        public Task(string nameInputFile, string nameOutputFile)
        {
            NameInputFile = nameInputFile;
            NameOutputFile = nameOutputFile;
            ReadInputFile();
            CreateBinaryTree();

            var lines = TreeToLine();
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

        public string[][] TreeToLine()
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
            string[][] ret = bt.Select(mass => mass.Select(tree => tree?.ToString()).ToArray()).ToArray();
            return ret;
        }
    }
}
