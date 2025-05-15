using System;
using System.Collections.Generic;

namespace chessGame
{
    internal class Posicao
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    internal abstract class Peca
    {
        public Posicao corrente = new();
        public List<Posicao> possiveisMovimentos = new();
        public bool statusPeça;

        public void atualizaPosicao(int proxPos)
        {
            corrente = possiveisMovimentos[proxPos - 1];
        }

        public void atualizaStatus(bool novoStatus)
        {
            statusPeça = novoStatus;
        }

        protected bool verificaPosicao(List<Peca> JT, Posicao ptemp)
        {
            for (int i = 0; i < JT.Count; i++)
            {
                if (JT[i].corrente == ptemp)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void preencheListaPos(List<Peca> minhaspecas, List<Peca> outras);

        public void imprimirListaPosicoes()
        {
            foreach (var pos in possiveisMovimentos)
            {
                Console.WriteLine($"(X:{pos.x} Y:{pos.y})");
            }
        }
    }

    internal class Rei : Peca
    {
        public override void preencheListaPos(List<Peca> minhaspecas, List<Peca> outras)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                Posicao p = new() { x = corrente.x + dx[i], y = corrente.y + dy[i] };
                if (!verificaPosicao(minhaspecas, p) && p.x >= 0 && p.y >= 0 && p.x <= 7 && p.y <= 7)
                    possiveisMovimentos.Add(p);
            }
        }
    }

    internal class Torre : Peca
    {
        public override void preencheListaPos(List<Peca> minhaspecas, List<Peca> outras)
        {
            for (int i = 1; i < 8; i++)
            {
                Posicao direita = new() { x = corrente.x + i, y = corrente.y };
                if (verificaPosicao(minhaspecas, direita) && p.x >= 0 && p.y >= 0 && p.x <= 7 && p.y <= 7) break;
                possiveisMovimentos.Add(direita);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao esquerda = new() { x = corrente.x - i, y = corrente.y };
                if (verificaPosicao(minhaspecas, esquerda) && p.x >= 0 && p.y >= 0 && p.x <= 7 && p.y <= 7) break;
                possiveisMovimentos.Add(esquerda);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao cima = new() { x = corrente.x, y = corrente.y + i };
                if (verificaPosicao(minhaspecas, cima) && p.x >= 0 && p.y >= 0 && p.x <= 7 && p.y <= 7) break;
                possiveisMovimentos.Add(cima);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao baixo = new() { x = corrente.x, y = corrente.y - i };
                if (verificaPosicao(minhaspecas, baixo) && p.x >= 0 && p.y >= 0 && p.x <= 7 && p.y <= 7) break;
                possiveisMovimentos.Add(baixo);
            }
        }
    }

    internal class Cavalo : Peca
    {
        public override void preencheListaPos(List<Peca> minhaspecas, List<Peca> outras)
        {
            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                Posicao destino = new() { x = corrente.x + dx[i], y = corrente.y + dy[i] };
                if (!verificaPosicao(minhaspecas, destino) && p.x >= 0 && p.y >= 0 && p.x <= 7 && p.y <= 7)
                    possiveisMovimentos.Add(destino);
            }
        }
    }









}