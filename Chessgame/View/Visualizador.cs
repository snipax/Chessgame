using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessgame.Model;
using Chessgame.Model.Pecas;

namespace Chessgame.View
{
    // Responsável pela saída no console (tabuleiro e movimentos).
    internal class Visualizador
    {
        private readonly Tabuleiro tabuleiro;

        public Visualizador(Tabuleiro tabuleiro)
        {
            this.tabuleiro = tabuleiro;
        }

        // Imprime o tabuleiro atual no console.
        public void imprimirTabuleiro()
        {
            for (int y = 7; y >= 0; y--)
            {
                Console.Write(y + 1 + " ");
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
            Console.WriteLine("  A B C D E F G H");
        }

        
        // Mostra os movimentos possíveis com '*' e a peça selecionada.
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
        // Imprime a lista de movimentos possíveis (debug).
        public void imprimirListaPosicoes(Peca pSelecionada)
        {
            foreach (var pos in pSelecionada.possiveisMovimentos)
            {
                Console.WriteLine($"(X:{pos.x} Y:{pos.y})");
            }
        }
    }
}
