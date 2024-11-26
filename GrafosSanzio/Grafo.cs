using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosSanzio
{
    class GrafoLista //implements Grafo
    {
        private List<Aresta>[] listaAdj;
        public GrafoLista(int vertices)
        {
            listaAdj = new List<Aresta>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                listaAdj[i] = new List<Aresta>();
            }
        }
        public GrafoLista(int vertices, List<List<int>> dimic)
        {
            listaAdj = new List<Aresta>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                listaAdj[i] = new List<Aresta>();
            }

            foreach (List<int> lista in dimic)
            {
                AdicionarAresta(lista[0], lista[1], lista[2]);
            }
        }
        public bool AdicionarAresta(int vertice, int destino, int peso)
        {
            if (vertice <= listaAdj.Length && vertice > 0)
            {
                Aresta aresta = new Aresta(vertice,destino, peso);
                listaAdj[vertice].Add(aresta);
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < listaAdj.Length; i++)
            {
                sb.Append(i + " -> ");
                foreach (Aresta aresta in listaAdj[i])
                {
                    sb.Append(aresta.getDestino() + " Peso: " + aresta.getPeso());
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
