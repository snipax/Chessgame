using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessGame
{
    internal class Game
    {
        public List<Peca> pecas = new();

        public void imprimirTabuleiro()
        {
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    Peca? pecaNaPosicao = pecas.Find(p => p.corrente.x == x && p.corrente.y == y);

                    if (pecaNaPosicao != null)
                    {
                        Console.Write(getSimbolo(pecaNaPosicao) + " ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }

        private string getSimbolo(Peca p)
        {
            if (p is Rei) return "R";
            if (p is Torre) return "T";
            if (p is Cavalo) return "C";
            return "?";
        }
    }
}