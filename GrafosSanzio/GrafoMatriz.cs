using GrafosSanzio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrafos
{
    class GrafoMatriz : IGrafo
    {
        private int[,] _matrizGrafo;

        public GrafoMatriz(int vertices) { _matrizGrafo = new int[vertices, vertices]; }

        public GrafoMatriz(int vertices, List<List<int>> listaArestas)
        {
            int[,] matrizAdjacencia = new int[vertices, vertices];

            foreach (List<int> aresta in listaArestas)
            {
                matrizAdjacencia[aresta[0] - 1, aresta[1] - 1] = aresta[2];
            }
            _matrizGrafo = matrizAdjacencia;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _matrizGrafo.GetLength(0); i++)
            {
                sb.Append("[");
                for (int j = 0; j < _matrizGrafo.GetLength(1); j++)
                {
                    if (_matrizGrafo[i, j] == 0) { sb.Append($"  " + _matrizGrafo[i, j] + $" ,"); }
                    else if (_matrizGrafo[i, j] > 0) { sb.Append($" +" + _matrizGrafo[i, j] + $" ,"); }
                    else { sb.Append($" " + _matrizGrafo[i, j] + $" ,"); }
                }
                sb.Append("]\n");
            }
            return sb.ToString();
        }
    }
}

