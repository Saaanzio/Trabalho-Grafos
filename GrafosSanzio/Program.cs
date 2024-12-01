using GrafosSanzio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            start();
        }

        public static void start()
        {
            int codigo;
            do
            {
                try
                {
                    Console.WriteLine(menuInicial());
                    codigo = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (codigo)
                    {
                        case 1:
                            criarGrafo();
                            break;
                        case 0:
                            Console.WriteLine("Adeus!");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    codigo = -1;
                }
            } while (codigo != 0);
        }

        public static string menuInicial()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Bem vindo ao sistema de Grafos!");
            stringBuilder.AppendLine("1) Criar grafo");
            stringBuilder.AppendLine("0) Sair");
            return stringBuilder.ToString();
        }



        public static void criarGrafo() 
        {
            StringBuilder stringBuilder = new StringBuilder();

            Console.WriteLine("Informe a quantidade de vertices");
            int numVertices = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a quantidade de arestas");
            int numArestas = int.Parse(Console.ReadLine());

            List<List<int>>  dimic = criarDimic(numVertices, numArestas);

            IGrafo grafo;

            if (calcularDensidade(numVertices, numArestas) >= 0.5)
            {
                grafo = new GrafoLista(numVertices, dimic);//GrafoMatriz(numVertices,dimic);
            }
            else
            {
                grafo = new GrafoLista(numVertices,dimic);
            }

            Console.Clear();
            Console.WriteLine("Grafo criado :D");
            menuGrafo(grafo);
        }

        public static double calcularDensidade(int numVertices, int numArestas)
        {
            double densidade = (2 * numArestas) / (numVertices * (numVertices - 1));
            return densidade;
        }

        public static List<List<int>> criarDimic(int numVertices, int numArestas)
        {
            List<List<int>> dimic = new List<List<int>>();

            for (int i = 1; i <= numArestas; i++)
            {
                Console.WriteLine($"Informe o vértice de origem da aresta {i}:");
                int verticeOrigem = int.Parse(Console.ReadLine());

                Console.WriteLine($"Informe o vértice de destino da aresta {i}:");
                int verticeDestino = int.Parse(Console.ReadLine());

                Console.WriteLine($"Informe o peso da aresta {i}:");
                int peso = int.Parse(Console.ReadLine());


                dimic.Add(new List<int> { verticeOrigem, verticeDestino, peso });
            }

            return dimic;
        }

        public static void menuGrafo(IGrafo grafo)
        {
            bool repetidor = true;
            while (repetidor)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Adicionar vértice");
                Console.WriteLine("2. Adicionar aresta");
                Console.WriteLine("3. Listar grafo");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        //addVertice(grafo);
                        Console.WriteLine("Estamos trabalhando nesta implementação");
                        break;
                    case 2:
                        addAresta(grafo);
                        break;
                    case 3:
                        listarGrafo(grafo);
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Saindo...");
                        repetidor = false;
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        /* Iremos adicionar vertices?
        public static bool addVertice(IGrafo grafo)
        {
            Console.WriteLine("Insira o número do vertice");
            int vertice = int.Parse(Console.ReadLine());
            if (grafo.AdicionarVertice(vertice) && vertice > 0)
            {
                Console.Clear();
                Console.WriteLine("Adicionado com sucesso");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vertice nao existe");
                return false;
            }
            return true;
        }
        */

        public static bool addAresta(IGrafo grafo)
        {
            Console.WriteLine("Insira o número do vertice de origem");
            int verticeOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o número do vertice de destino");
            int verticeDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o peso da aresta");
            int peso = int.Parse(Console.ReadLine());

            if (grafo.AdicionarAresta(verticeOrigem, verticeDestino, peso)){ 
                Console.Clear();
                Console.WriteLine("Aresta adicionada com sucesso");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Um ou os dois vértices não existem");
                return false;
            }
            return true;
        }

        public static void listarGrafo(IGrafo grafo)
        {
            Console.WriteLine(grafo.ToString());
        }

    }
    
}