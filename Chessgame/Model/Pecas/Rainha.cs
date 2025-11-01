using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessgame.Model.Pecas
{
    internal class Rainha : Peca
    {
        public Rainha(CorPeca cor) : base(cor)
        {
        }
        public override string Simbolo => Cor == CorPeca.Branco ? "Q" : "q";
        public override void preencheListaPos(Tabuleiro tabuleiro)
        {
            for (int i = 1; i < 8; i++)
            {
                Posicao NW = new Posicao(corrente.x - i, corrente.y + i);

                Peca pecaNaPosicao = tabuleiro.getPeca(NW);
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

                Peca pecaNaPosicao = tabuleiro.getPeca(NE);
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

                Peca pecaNaPosicao = tabuleiro.getPeca(SW);
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

                Peca pecaNaPosicao = tabuleiro.getPeca(SE);
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
            for (int i = 1; i < 8; i++)
            {
                Posicao W = new Posicao(corrente.x - i, corrente.y);

                Peca pecaNaPosicao = tabuleiro.getPeca(W);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(W);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(W);
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
                Posicao E = new Posicao(corrente.x + i, corrente.y);

                Peca pecaNaPosicao = tabuleiro.getPeca(E);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(E);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(E);
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
                Posicao N = new Posicao(corrente.x, corrente.y + i);

                Peca pecaNaPosicao = tabuleiro.getPeca(N);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(N);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(N);
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
                Posicao S = new Posicao(corrente.x, corrente.y - i);

                Peca pecaNaPosicao = tabuleiro.getPeca(S);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(S);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(S);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
