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
            LimparMovimentos();

            int direcao = Cor == CorPeca.Branco ? 1 : -1;

            Posicao p1 = new Posicao(corrente.x, corrente.y + direcao);
            if (tabuleiro.EstaNoLimite(p1))
            {
                Peca pecaP1 = tabuleiro.GetPeca(p1);
                if (pecaP1 == null)
                {
                    possiveisMovimentos.Add(p1);

                    if (!JaMoveu)
                    {
                        Posicao p2 = new Posicao(corrente.x, corrente.y + 2 * direcao);
                        if (tabuleiro.EstaNoLimite(p2))
                        {
                            Peca pecaP2 = tabuleiro.GetPeca(p2);
                            if (pecaP2 == null)
                            {
                                possiveisMovimentos.Add(p2);
                            }
                        }
                    }
                }
            }

            Posicao capEsq = new Posicao(corrente.x - 1, corrente.y + direcao);
            if (tabuleiro.EstaNoLimite(capEsq))
            {
                Peca pecaCapEsq = tabuleiro.GetPeca(capEsq);
                if (pecaCapEsq != null && pecaCapEsq.Cor != this.Cor)
                {
                    possiveisMovimentos.Add(capEsq);
                }
            }

            Posicao capDir = new Posicao(corrente.x + 1, corrente.y + direcao);
            if (tabuleiro.EstaNoLimite(capDir))
            {
                Peca pecaCapDir = tabuleiro.GetPeca(capDir);
                if (pecaCapDir != null && pecaCapDir.Cor != this.Cor)
                {
                    possiveisMovimentos.Add(capDir);
                }
            }
        }

        public override Peca Clone()
        {
            Peao clone = new Peao(this.Cor);
            clone.corrente = new Posicao(this.corrente.x, this.corrente.y);
            return clone;
        }
    }
}
