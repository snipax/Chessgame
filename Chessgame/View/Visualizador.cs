using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessgame.Model;
using Chessgame.Model.Pecas;

namespace Chessgame.View
{
    internal class Visualizador
    {
        private readonly Tabuleiro tabuleiro;

        public Visualizador(Tabuleiro tabuleiro)
        {
            this.tabuleiro = tabuleiro;
        }

        public void imprimirTabuleiro()
        {
            for (int y = 7; y >= 0; y--)
            {
                Console.Write(y + " ");
                for (int x = 0; x < 8; x++)
                {
                    Peca? pecaNaPosicao = tabuleiro.GetPeca(new Posicao(x, y));

                    if (pecaNaPosicao != null)
                    {
                        Console.Write(pecaNaPosicao.Simbolo + " ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  0 1 2 3 4 5 6 7");
        }

        
        public void mostrarMovimentos(Peca pSelecionada)
        {
            pSelecionada.possiveisMovimentos.Clear();
            pSelecionada.preencheListaPos(tabuleiro);

            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {

                    if (pSelecionada.corrente.x == x && pSelecionada.corrente.y == y)
                    {
                        Console.Write(pSelecionada.Simbolo + " ");
                    }

                    else if (pSelecionada.possiveisMovimentos.Any(pos => pos.x == x && pos.y == y))
                    {
                        Console.Write("* ");
                    }

                    else
                    {
                        Peca outra = tabuleiro.GetPeca(new Posicao(x, y));
                        if (outra != null)
                            Console.Write((outra.Simbolo) + " ");
                        else
                            Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }
        public void imprimirListaPosicoes(Peca pSelecionada)
        {
            foreach (var pos in pSelecionada.possiveisMovimentos)
            {
                Console.WriteLine($"(X:{pos.x} Y:{pos.y})");
            }
        }
    }
}
