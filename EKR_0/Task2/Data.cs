using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Data
    {
        public int[] V;

        public double M => V.Sum() / (double) V.Length;

        public double D => V.Sum(i => Math.Pow(i - M, 2)) / V.Length;

        public double Z => V.Sum(i => Math.Abs(i - M)) / V.Length;

        private int N => V.Length;

        public Data(string s)
        {
            string[] ss = Regex.Split(s, "\\s+");
            V = new int[ss.Length];

            for (int i = 0; i < V.Length; i++)
            {
                V[i] = (int) double.Parse(ss[i]);
            }
            
        }

        public override string ToString()
        {
            string ans = "";
            for (int i = 0; i < V.Length; i++)
            {
                ans += $"{V[i]}\t";
            }
//            foreach (int i in V)
//            {
//                ans += $"{i}\t";
//            }

            return ans;
        }
    }
}