using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Node
    {
        public String Name;
        public String Color;
        public int Distance;
        public Node Parent;
        public List<String> Movies;
    }
    class Program
    {
        public static bool containsList( List<Node>L1,  String x)
        {
            try
            {
                foreach (Node i in L1)
                {
                    if (i.Name.Equals(x))
                    {
                        return true;
                    }

                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public static void AddEdge(ref Dictionary<String, List<Node>> Graph, ref String  U, ref String  V, ref Dictionary<Tuple<String, String>, int> Frequency)
        {
            if (Graph.ContainsKey(U)&&Graph.ContainsKey(V))                    // if Both Nodes exist
            {
                List<Node> x = Graph[U];
                
              
                    if (containsList(Graph[U],V))             // if Connected
                    {
                    Tuple<String, String> y = new Tuple<string, string>(U, V);
                    Tuple<String, String> z = new Tuple<string, string>(V, U);
                    if (Frequency.ContainsKey(y))
                    {
                        Frequency[y]++;
                    }
                    else if (Frequency.ContainsKey(z))
                    {
                        Frequency[z]++;
                    }

                    }
                    else                                                          // if not connected
                    {
                    Node uNeigh = new Node();
                    uNeigh.Name = V;
                    Graph[U].Add(uNeigh);

                    Node vNeigh = new Node();
                    vNeigh.Name = U;
                      
                        Graph[V].Add(vNeigh);
                        Tuple<String, String> freq = new Tuple<String, String>(U, V);
                        Frequency.Add(freq, 1);
                    }

                }
            

            else if (Graph.ContainsKey(U)&&!Graph.ContainsKey(V))                              // if U exists and V is not existed
            {
                List<Node> Vneigh = new List<Node>();         // List for V neighbours

                Node u = new Node();
                u.Name = U;
                Vneigh.Add(u);

                Graph.Add(V, Vneigh);

                Node v = new Node();
                v.Name = V;
                Graph[U].Add(v);


                Tuple<String, String> freq = new Tuple<string, string>(U, V);

               
                Frequency.Add(freq, 1);
            }
            else if (!Graph.ContainsKey(U) && Graph.ContainsKey(V))                                     // if U is not existed and V exists
            {
                List<Node> uNeigh = new List<Node>();

                Node v = new Node();
                v.Name = V;
                uNeigh.Add(v);
                Graph.Add(U, uNeigh);

                Node u = new Node();
                u.Name = U;
                Graph[V].Add(u);

                Tuple<String, String> freq = new Tuple<string, string>(U, V);
                Frequency.Add(freq, 1);
            }
            else                                                                                         // if Both U and V are not existed
            {
                Node u = new Node();
                u.Name = U;
                Node v = new Node();
                v.Name = V;

                List<Node> uNeigh = new List<Node>();
                uNeigh.Add(v);
                List<Node> vNeigh = new List<Node>();
                vNeigh.Add(u);

                Graph.Add(U, uNeigh);
                Graph.Add(V, vNeigh);

                Tuple<String, String> freq = new Tuple<string, string>(U, V);
                Frequency.Add(freq, 1);

            }


        }
    
        //public static void init(ref Dictionary<Node, List<Node>> Graph)
        //{

        //    for (int i = 0; i < Graph.Keys.Count; i++)
        //    {

        //        List<Node> currentNodes = Graph[Graph.Keys.ElementAt(i)];

        //        for (int j = 0; j < currentNodes.Count; j++)
        //        {
        //            Node currNode = currentNodes[j];
        //            currNode.Color = "white";
        //            currNode.Distance = int.MaxValue;

        //            //        currentNodes[j] = currNode;
        //        }
        //        //  Graph[Graph.Keys.ElementAt(i)] = currentNodes;
        //    }
        //}

      public static void init(ref Dictionary<String, List<Node>> Graph, ref String source)
        {
            foreach (String i in Graph.Keys)
            {
                foreach(Node j in Graph[i])
                {
                    if (j.Name.Equals(source))
                    {
                        j.Color = "gray";
                        j.Distance = 0;
                        j.Parent = null;
                    }
                    else
                    {
                        j.Color = "white";
                        j.Distance = -1;
                    }
                }
            }


        }

        public static void BFS(ref Dictionary<String, List<Node>> Graph,  ref String source,ref  String destination)
        {
            init(ref Graph, ref source);
            Queue<String> keyString = new Queue<string>();
            Queue<Node> Q = new Queue<Node>();

            keyString.Enqueue(source);       // push source in the Queue
            while(keyString.Count!=0)
            {
                String U = keyString.ElementAt(0); 
                keyString.Dequeue();
                
                foreach(Node v in Graph[U])                // Loop for each adjacent node to U
                {
                   if(v.Color=="white")
                    {
                        v.Color = "gray";
                        //v.Distance = U.d;
                        v.Parent.Name = U;
                    }
                }
            }
            

        }



        static void Main(string[] args)
        {

            Dictionary<String, List<Node>> Graph = new Dictionary<String, List<Node>>();
            Dictionary<Tuple<String, String>, int> Frequency = new Dictionary<Tuple<String, String>, int>();


            //Dictionary<int, Tuple<Node, List<Node>>> Graph2 = new Dictionary<int, Tuple<Node, List<Node>>>();







            Console.WriteLine("INPUT: ");
            //List<Node> NodeList = new List<Node>();
            for (int i = 0; i < 5; i++)   // Number of Edges
            {
               
                String u, v;
                String line;

                line = Console.ReadLine();
                String[] arr = new string[2];
                arr = line.Split(' ');
                u = arr[0];
                v = arr[1];
               
                AddEdge(ref Graph, ref u, ref v, ref Frequency);



            }
            Console.WriteLine();
            Console.WriteLine("OUTPUT ");

            foreach (String i in Graph.Keys)
            {
                Console.Write("Neighbors of " + i + ": ");

                foreach (Node j in Graph[i])
                {
                    Console.Write(j.Name + " ");
                }
                Console.WriteLine();
            }
            foreach (Tuple<String, String> i in Frequency.Keys)
            {
                Console.Write("Frequency of( " + i.Item1 + " , " + i.Item2 + ") : ");
                //foreach(int j in Frequency.Values)
                //{
                //    Console.Write(j);
                //}
                Console.WriteLine(Frequency[i]);
            }

            Console.WriteLine(Graph.Count);
        }
    }
}
