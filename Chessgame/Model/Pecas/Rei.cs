using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessgame.Model.Pecas
{
    internal class Rei : Peca
    {
        public Rei(CorPeca cor) : base(cor)
        {
        }
        public override string Simbolo => Cor == CorPeca.Branco ? "K" : "k";
        public override void preencheListaPos(Tabuleiro tabuleiro)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                Posicao p = new Posicao(corrente.x + dx[i], corrente.y + dy[i]);
                    Peca pecaNaPosicao = tabuleiro.getPeca(p);
                    if (pecaNaPosicao == null)
                    {
                        possiveisMovimentos.Add(p);
                    }
                    else
                    {
                        if (pecaNaPosicao.Cor != this.Cor)
                        {
                            possiveisMovimentos.Add(p);
                        }
                        else
                        {
                        }
                    }
            }
        }
    }
}
