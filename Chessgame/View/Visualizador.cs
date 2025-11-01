using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessgame.Model.Pecas;

namespace Chessgame.View
{
    internal class Visualizador
    {
        public void imprimirTabuleiro()
        {
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    Peca? pecaNaPosicao = pecas.Find(p => p.corrente.x == x && p.corrente.y == y);

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
        }
        public void mostrarMovimentos(Peca pSelecionada)
        {
            pSelecionada.possiveisMovimentos.Clear();
            pSelecionada.preencheListaPos(pecas, pecas);

            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {

                    if (pSelecionada.corrente.x == x && pSelecionada.corrente.y == y)
                    {
                        Console.Write(getSimbolo(pSelecionada) + " ");
                    }

                    else if (pSelecionada.possiveisMovimentos.Any(pos => pos.x == x && pos.y == y))
                    {
                        Console.Write("* ");
                    }

                    else
                    {
                        Peca outra = pecas.Find(p => p != pSelecionada && p.corrente.x == x && p.corrente.y == y);
                        if (outra != null)
                            Console.Write(getSimbolo(outra) + " ");
                        else
                            Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }
        public void imprimirListaPosicoes()
        {
            foreach (var pos in possiveisMovimentos)
            {
                Console.WriteLine($"(X:{pos.x} Y:{pos.y})");
            }
        }
    }
}
}
}
