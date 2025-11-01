using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessgame.Model.Pecas
{
    internal class Peao : Peca
    {
        public Peao(CorPeca cor) : base(cor)
        {
        }
        public override string Simbolo => Cor == CorPeca.Branco ? "P" : "p";

        public override void preencheListaPos(Tabuleiro tabuleiro)
        {
            int direcao = Cor == CorPeca.Branco ? 1 : -1;
            Posicao p1 = new Posicao(corrente.x, corrente.y + direcao);
            Peca pecaNaPosicao = tabuleiro.getPeca(p1);
            if (pecaNaPosicao == null)
            {
                possiveisMovimentos.Add(p1);
                if (!JaMoveu)
                {
                    Posicao p2 = new Posicao(corrente.x, corrente.y + 2 * direcao);
                    Peca pecaNaPosicao = tabuleiro.getPeca(p2);
                    if (pecaNaPosicao == null)
                    {
                        possiveisMovimentos.Add(p2);
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
                Posicao capEsq = new Posicao(corrente.x - 1, corrente.y + direcao );

                Posicao capDir = new Posicao(corrente.x + 1, corrente.y + direcao );


                Peca pecaCapEsq = tabuleiro.getPeca(capEsq);
                Peca pecaCapDir = tabuleiro.getPeca(capDir);
                if (pecaCapEsq != null && pecaCapEsq.Cor != this.Cor)
                {
                    possiveisMovimentos.Add(capEsq);
                }
                if (pecaCapDir != null && pecaCapDir.Cor != this.Cor)
                {
                    possiveisMovimentos.Add(capDir);
                }

            
        }
    }
}
