using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosSanzio
{
    internal interface IGrafo
    {
        //bool AdicionarVertice();

        /// <summary>
        /// Adiciona uma aresta ao grafo.
        /// </summary>
        /// <param name="vertice">Vértice de origem.</param>
        /// <param name="destino">Vértice de destino.</param>
        /// <param name="peso">Peso da aresta.</param>
        /// <returns>True se a aresta foi adicionada com sucesso, False caso contrário.</returns>
        bool AdicionarAresta(int vertice, int destino, int peso);

        /// <summary>
        /// ToString para o grafo.
        /// </summary>
        /// <returns>String representando o grafo.</returns>
        string ToString();
    }
}
