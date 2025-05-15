using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace chessGame
{
    internal class Posicao
    {
        public int x { get; set; }
        public int y { get; set; }

    }

    internal class Peca
    {
        public Posicao corrente = new();
        public List<Posicao> possiveisMovimentos = new();
        public int tipoPeca;
        /* 0 - Rei
         * 1 - Dama
         * 2 - Torre
         * 3 - Bispo
         * 4 - Cavalos 
         * 5 - Peão
         */

        public bool statusPeça;

        public void atualizaPosicao(int proxPos) { 

            corrente = possiveisMovimentos[proxPos-1];
        }
        public void atualizaStatus(bool novoStatus){
            statusPeça = novoStatus;
        }
        public void atualizaTipo(int novoTipo){
            tipoPeca = novoTipo;
        }

        private bool verificaPosicao(List<Peca> JT,Posicao ptemp)
        {
            for(int i = 0; i < JT.Count; i++)
            {
                if (JT[i].corrente == ptemp)
                {
                    return true;
                }
            }
            return false;
        }

        public void preencheListaPos(List<Peca> minhaspecas, List<Peca> outras)
        {
            if (tipoPeca == 0) //rei
            {
                Posicao PPROX = new Posicao();
                PPROX.x = (corrente.x - 1);
                PPROX.y = (corrente.y - 1);
                if(!(verificaPosicao(minhaspecas,PPROX))){
                    possiveisMovimentos.Add(PPROX);
                }
                Posicao PPROX2 = new Posicao();
                PPROX2.x = (corrente.x + 1);
                PPROX2.y = (corrente.y + 1);
                if (!(verificaPosicao(minhaspecas, PPROX2)))
                {
                    possiveisMovimentos.Add(PPROX2);
                }
                Posicao PPROX3 = new Posicao();
                PPROX3.x = (corrente.x - 1);
                PPROX3.y = (corrente.y + 1);
                if (!(verificaPosicao(minhaspecas, PPROX3)))
                {
                    possiveisMovimentos.Add(PPROX3);
                }
                Posicao PPROX4 = new Posicao();
                PPROX4.x = (corrente.x + 1);
                PPROX4.y = (corrente.y - 1);
                if (!(verificaPosicao(minhaspecas, PPROX4)))
                {
                    possiveisMovimentos.Add(PPROX4);
                }
                Posicao PPROX5 = new Posicao();
                PPROX5.x = (corrente.x);
                PPROX5.y = (corrente.y - 1);
                if (!(verificaPosicao(minhaspecas, PPROX5)))
                {
                    possiveisMovimentos.Add(PPROX5);
                }
                Posicao PPROX6 = new Posicao();
                PPROX6.x = (corrente.x);
                PPROX6.y = (corrente.y + 1);
                if (!(verificaPosicao(minhaspecas, PPROX6)))
                {
                    possiveisMovimentos.Add(PPROX6);
                }
                Posicao PPROX7 = new Posicao();
                PPROX7.x = (corrente.x - 1);
                PPROX7.y = (corrente.y);
                if (!(verificaPosicao(minhaspecas, PPROX7)))
                {
                    possiveisMovimentos.Add(PPROX7);
                }
                Posicao PPROX8 = new Posicao();
                PPROX8.x = (corrente.x + 1);
                PPROX8.y = (corrente.y);
                if (!(verificaPosicao(minhaspecas, PPROX8)))
                {
                    possiveisMovimentos.Add(PPROX8);
                }

            }
            else if (tipoPeca == 2) // Torre
            {
                // Direita
                for (int i = 1; i < 8; i++)
                {
                    Posicao destino = new Posicao() { x = corrente.x + i, y = corrente.y };
                    if (verificaPosicao(minhaspecas, destino)) break;
                    possiveisMovimentos.Add(new Posicao() { x = destino.x, y = destino.y });
                }

                // Esquerda
                for (int i = 1; i < 8; i++)
                {
                    Posicao destino = new Posicao() { x = corrente.x - i, y = corrente.y };
                    if (verificaPosicao(minhaspecas, destino)) break;
                    possiveisMovimentos.Add(new Posicao() { x = destino.x, y = destino.y });
                }

                // Cima
                for (int i = 1; i < 8; i++)
                {
                    Posicao destino = new Posicao() { x = corrente.x, y = corrente.y + i };
                    if (verificaPosicao(minhaspecas, destino)) break;
                    possiveisMovimentos.Add(new Posicao() { x = destino.x, y = destino.y });
                }

                // Baixo
                for (int i = 1; i < 8; i++)
                {
                    Posicao destino = new Posicao() { x = corrente.x, y = corrente.y - i };
                    if (verificaPosicao(minhaspecas, destino)) break;
                    possiveisMovimentos.Add(new Posicao() { x = destino.x, y = destino.y });
                }
            }
            else if (tipoPeca == 4) // Cavalo
            {
                int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
                int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

                for (int i = 0; i < 8; i++)
                {
                    Posicao destino = new Posicao()
                    {
                        x = corrente.x + dx[i],
                        y = corrente.y + dy[i]
                    };
                    if (!verificaPosicao(minhaspecas, destino))
                    {
                        possiveisMovimentos.Add(destino);
                    }
                }
            }

        }

        public void imprimirListaPosicoes()
        {
            for(int i = 0;i < possiveisMovimentos.Count; i++)
            {
                Console.WriteLine(possiveisMovimentos[i].x);
                Console.WriteLine(possiveisMovimentos[i].y);

            }
        }


    }
}
