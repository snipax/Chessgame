using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessgame.Model.Pecas
{
    internal class Bispo : Peca
    {
        public Bispo(CorPeca cor) : base(cor)
        {
        }
        public override string Simbolo => Cor == CorPeca.Branco ? "B" : "b";
        public override void preencheListaPos(Tabuleiro tabuleiro)
        {
            for (int i = 1; i < 8; i++)
            {
                Posicao NW = new Posicao(corrente.x - i, corrente.y + i);
                if (!tabuleiro.EstaNoLimite(NW))
                { 
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(NW);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(NW);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(NW);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < 8; i++)
            {
                Posicao NE = new Posicao(corrente.x + i, corrente.y + i);
                if (!tabuleiro.EstaNoLimite(NE))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(NE);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(NE);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(NE);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < 8; i++)
            {
                Posicao SW = new Posicao(corrente.x - i, corrente.y - i);
                if (!tabuleiro.EstaNoLimite(SW))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(SW);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(SW);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(SW);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < 8; i++)
            {
                Posicao SE = new Posicao(corrente.x + i, corrente.y - i);
                if (!tabuleiro.EstaNoLimite(SE))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(SE);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(SE);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(SE);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public override Peca Clone()
        {
            Bispo clone = new Bispo(this.Cor);
            clone.corrente = new Posicao(this.corrente.x, this.corrente.y);
            return clone;
        }
    }
}
