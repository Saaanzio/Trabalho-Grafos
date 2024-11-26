using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrafos
{
    internal class Aresta
    {
        private int origem;
        private int destino;
        private int peso;
        public Aresta(int origem, int destino, int peso)
        {
            this.origem = origem;
            this.destino = destino;
            this.peso = peso;
        }
        public int getDestino()
        {
            return destino;
        }
        public int getPeso()
        {
            return peso;
        }
    }
}
