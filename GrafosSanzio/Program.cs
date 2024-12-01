﻿using GrafosSanzio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrafos
{
    internal class Program
    {
        /// <summary>
        /// Metodo main que inicia a aplicação/sistema
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                start();
            }
            catch (Exception ex) {

                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
            
        }

        /// <summary>
        /// Start para criar o grafo
        /// </summary>
        public static void start()
        {
            int codigoEscolha;
            do
            {
                try
                {
                    Console.WriteLine(menuInicial());
                    if (!int.TryParse(Console.ReadLine(), out codigoEscolha))
                    {
                        Console.Clear();
                        Console.WriteLine("Por favor, insira um número válido.");
                        continue;
                    }
                    Console.Clear();
                    switch (codigoEscolha)
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
                    codigoEscolha = -1;
                }
            } while (codigoEscolha != 0);
        }

        /// <summary>
        /// Menu inicial para crair grafo
        /// </summary>
        /// <returns>Retorna um stringbuilder com o menu inicial</returns>
        public static string menuInicial()
        {
            StringBuilder construtorMenu = new StringBuilder();
            construtorMenu.AppendLine("Bem vindo ao sistema de Grafos!");
            construtorMenu.AppendLine("1) Criar grafo");
            construtorMenu.AppendLine("0) Sair");
            return construtorMenu.ToString();
        }

        /// <summary>
        /// Após escolher criar o grafo, o usuário informa os detalhes para criar o grafo
        /// (numero de vertices, numero de arestas,peso das arestas)
        /// </summary>
        public static void criarGrafo() 
        {
            try
            {
                Console.WriteLine("Informe a quantidade de vértices:");
                if (!int.TryParse(Console.ReadLine(), out int numVertices) || numVertices <= 0)
                {
                    Console.WriteLine("Número de vértices inválido.");
                    return;
                }

                Console.WriteLine("Informe a quantidade de arestas:");
                if (!int.TryParse(Console.ReadLine(), out int numArestas) || numArestas < 0)
                {
                    Console.WriteLine("Número de arestas inválido.");
                    return;
                }

                List<List<int>> dimic = criarDimic(numVertices, numArestas);

                IGrafo grafo;

                if (calcularDensidade(numVertices, numArestas) >= 0.5)
                {
                    grafo = new GrafoMatriz(numVertices, dimic);
                }
                else
                {
                    grafo = new GrafoLista(numVertices, dimic);
                }

                Console.Clear();
                Console.WriteLine("Grafo criado :D");
                menuGrafo(grafo);
            }
            catch (Exception ex) {

                Console.WriteLine($"Erro ao criar grafo: {ex.Message}");
            }
        }

        /// <summary>
        /// Metodo de calcular densidade do grafo
        /// </summary>
        /// <param name="numVertices">Número de vértices</param>
        /// <param name="numArestas">Número de arestas</param>
        /// <returns>Peso do grafo</returns>
        public static double calcularDensidade(int numVertices, int numArestas)
        {
            double densidade = (2 * numArestas) / (numVertices * (numVertices - 1));
            return densidade;
        }

        /// <summary>
        /// Cria as informações do grafo com base no modelo dimic
        /// </summary>
        /// <param name="numVertices">Número de vértices</param>
        /// <param name="numArestas">Número de arestas</param>
        /// <returns>Retorna lista com base no modelo dimic</returns>
        public static List<List<int>> criarDimic(int numVertices, int numArestas)
        {
            List<List<int>> dimic = new List<List<int>>();

            for (int i = 1; i <= numArestas; i++)
            {
                try
                {
                    Console.WriteLine($"Informe o vértice de origem da aresta {i}:");
                    if (!int.TryParse(Console.ReadLine(), out int verticeOrigem) || verticeOrigem < 0 || verticeOrigem >= numVertices)
                    {
                        Console.WriteLine("Vértice de origem inválido.");
                        i--;
                        continue;
                    }

                    Console.WriteLine($"Informe o vértice de destino da aresta {i}:");
                    if (!int.TryParse(Console.ReadLine(), out int verticeDestino) || verticeDestino < 0 || verticeDestino >= numVertices)
                    {
                        Console.WriteLine("Vértice de destino inválido.");
                        i--;
                        continue;
                    }

                    Console.WriteLine($"Informe o peso da aresta {i}:");
                    if (!int.TryParse(Console.ReadLine(), out int peso) || peso < 0)
                    {
                        Console.WriteLine("Peso inválido.");
                        i--;
                        continue;
                    }

                    dimic.Add(new List<int> { verticeOrigem, verticeDestino, peso });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar a aresta {i}: {ex.Message}");
                    i--;
                }
            }

            return dimic;
        }

        /// <summary>
        /// Menu do grafo
        /// </summary>
        /// <param name="grafo">Grafo em forma de lista ou matriz</param>
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

        /// <summary>
        /// Metodo de adicionar aresta no grafo
        /// </summary>
        /// <param name="grafo">Grafo em forma de lista ou matriz</param>
        /// <returns>Retorna true caso adicionar a aresta tenha sido sucesso</returns>
        public static bool addAresta(IGrafo grafo)
        {
            try
            {
                Console.WriteLine("Insira o número do vértice de origem:");
                if (!int.TryParse(Console.ReadLine(), out int verticeOrigem))
                {
                    Console.WriteLine("Vértice de origem inválido.");
                    return false;
                }

                Console.WriteLine("Insira o número do vértice de destino:");
                if (!int.TryParse(Console.ReadLine(), out int verticeDestino))
                {
                    Console.WriteLine("Vértice de destino inválido.");
                    return false;
                }

                Console.WriteLine("Insira o peso da aresta:");
                if (!int.TryParse(Console.ReadLine(), out int peso))
                {
                    Console.WriteLine("Peso inválido.");
                    return false;
                }

                if (grafo.AdicionarAresta(verticeOrigem, verticeDestino, peso))
                {
                    Console.Clear();
                    Console.WriteLine("Aresta adicionada com sucesso.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Erro ao adicionar a aresta. Verifique os vértices.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar aresta: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Metodo de listar o grafo
        /// </summary>
        /// <param name="grafo">Grafo em forma de lista ou matriz</param>
        public static void listarGrafo(IGrafo grafo)
        {
            try
            {
                Console.WriteLine(grafo.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar o grafo: {ex.Message}");
            }
        }

    }
    
}