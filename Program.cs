using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public static void AddEdge(Dictionary<string, List<String>> Graph, String U, String V, Dictionary<Tuple<String, String>, int> Frequency)
        {
            if(Graph.ContainsKey(U)&&Graph.ContainsKey(V))                    // if Both Nodes exist
            {
                if (Graph.ContainsKey(U) && Graph[U].Contains(V))             // if Connected
                {
                    Tuple<String, String> x = new Tuple<String, String>(U, V);
                    Tuple<String, String> y = new Tuple<String, String>(V, U);
                    if (Frequency.ContainsKey(x))
                    {
                        Frequency[x]++;
                    }
                    else if (Frequency.ContainsKey(y))
                    {
                        Frequency[y]++;
                    }



                }
                else                                                          // if not connected
                {
                    Graph[U].Add(V);
                    Graph[V].Add(U);
                    Tuple<String, String> x = new Tuple<String, String>(U, V);
                    Frequency.Add(x, 1);
                }

            }
            
            else if(Graph.ContainsKey(U) && !Graph.ContainsKey(V))                              // if U exists and V is not existed
            {
                List<String> Vneigh = new List<string>();         // List for V neighbours
                Vneigh.Add(U);

                Graph.Add(V, Vneigh);
                Graph[U].Add(V);
                Tuple<String, String> tup = new Tuple<string, string>(U, V);
                Frequency.Add(tup, 1);
            }
            else if(!Graph.ContainsKey(U) &&Graph.ContainsKey(V))                                     // if V is not existed and U exists
            {
                List<String> Uneigh = new List<string>();         // List for U neighbours
                Uneigh.Add(V);
                Graph.Add(U, Uneigh);
                Graph[V].Add(U);
                Tuple<String, String> tup = new Tuple<string, string>(U, V);
                Frequency.Add(tup, 1);
            }
            else                                                                                         // if Both U and V are not existed
            {
                List<String> Uneigh = new List<String>();
                Uneigh.Add(V);
                List<String> Vneigh = new List<string>();
                Vneigh.Add(U);
                Graph.Add(U, Uneigh);
                Graph.Add(V, Vneigh);
                Tuple<String, String> x = new Tuple<String, String>(U,V);
                Frequency.Add(x, 1);
            }


        }



        static void Main(string[] args)
        {
            Dictionary<string, List<String>> Graph = new Dictionary<string , List<string>>();
            Dictionary<Tuple<String, String>, int> Frequency = new Dictionary<Tuple<string, string>, int>();
            Console.WriteLine("INPUT: ");
           for(int i=0;i<5;i++)
            {
                String line, u, v;
                String[] arr = new string[2];
                line = Console.ReadLine();
                arr = line.Split(' ');
                u=arr[0];
                v = arr[1];
                AddEdge(Graph, u, v, Frequency);

            }
            Console.WriteLine();
            Console.WriteLine("OUTPUT ");

            foreach (String i in Graph.Keys)
            {
                Console.Write("Neighbors of " + i + ": ");
               foreach(String j in Graph[i])
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            foreach (Tuple <String,String>i in Frequency.Keys)
            {
                Console.Write("Frequency of " + i + ": ");
                //foreach(int j in Frequency.Values)
                //{
                //    Console.Write(j);
                //}
                Console.WriteLine(Frequency[i]);
            }


        }
    }
}
