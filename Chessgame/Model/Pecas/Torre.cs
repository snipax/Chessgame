using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessgame.Model.Pecas
{
    internal class Torre : Peca
    {
        public Torre(CorPeca cor) : base(cor)
        {
        }
        public override string Simbolo => Cor == CorPeca.Branco ? "T" : "t";
        public override void preencheListaPos(Tabuleiro tabuleiro)
        {
            for (int i = 1; i < 8; i++)
            {
                Posicao direita = new Posicao(corrente.x + i, corrente.y);
                if (!tabuleiro.EstaNoLimite(direita))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(direita);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(direita);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                        {
                        possiveisMovimentos.Add(direita);
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
                Posicao esquerda = new Posicao(corrente.x + i, corrente.y);
                if (!tabuleiro.EstaNoLimite(esquerda))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(esquerda);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(esquerda);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(esquerda);
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
                Posicao cima = new Posicao(corrente.x + i, corrente.y);
                if (!tabuleiro.EstaNoLimite(cima))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(cima);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(cima);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(cima);
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
                Posicao baixo = new Posicao(corrente.x + i, corrente.y);
                if (!tabuleiro.EstaNoLimite(baixo))
                {
                    break;
                }
                Peca pecaNaPosicao = tabuleiro.GetPeca(baixo);
                if (pecaNaPosicao == null)
                {
                    possiveisMovimentos.Add(baixo);
                }
                else
                {
                    if (pecaNaPosicao.Cor != this.Cor)
                    {
                        possiveisMovimentos.Add(baixo);
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
            Torre clone = new Torre(this.Cor);
            clone.corrente = new Posicao(this.corrente.x, this.corrente.y);
            return clone;
        }   
    }
}
