using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chessgame.Model.Pecas
{
    internal class Cavalo : Peca
    {
        public Cavalo(CorPeca cor) : base(cor)
        {
        }
        public override string Simbolo => Cor == CorPeca.Branco ? "C" : "c";
        public override void preencheListaPos(Tabuleiro tabuleiro)
        {
            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                Posicao destino = new Posicao(corrente.x + dx[i], corrente.y + dy[i]);
                if (!tabuleiro.EstaNoLimite(destino))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(destino);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(destino);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(destino);
                    }
                    else
                    {
                    }
                }
            }



        }


        public override Peca Clone()
        {
            Cavalo clone = new Cavalo(this.Cor);
            clone.corrente = new Posicao(this.corrente.x, this.corrente.y);
            return clone;
        }
    }
}
