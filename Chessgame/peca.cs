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
            foreach (Peca p in JT)
            {
                if (p.corrente.x == ptemp.x && p.corrente.y == ptemp.y)
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
                if (verificaPosicao(minhaspecas, direita) || direita.x < 0 || direita.y < 0 || direita.x > 7 || direita.y > 7) break;
                possiveisMovimentos.Add(direita);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao esquerda = new() { x = corrente.x - i, y = corrente.y };
                if (verificaPosicao(minhaspecas, esquerda) || esquerda.x < 0 || esquerda.y < 0 || esquerda.x > 7 || esquerda.y > 7) break;
                possiveisMovimentos.Add(esquerda);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao cima = new() { x = corrente.x, y = corrente.y + i };
                if (verificaPosicao(minhaspecas, cima) || cima.x < 0 || cima.y < 0 || cima.x > 7 || cima.y > 7) break;
                possiveisMovimentos.Add(cima);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao baixo = new() { x = corrente.x, y = corrente.y - i };
                if (verificaPosicao(minhaspecas, baixo) || baixo.x < 0 || baixo.y < 0 || baixo.x > 7 || baixo.y > 7) break;
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
                if (!verificaPosicao(minhaspecas, destino) && destino.x >= 0 && destino.y >= 0 && destino.x <= 7 && destino.y <= 7)
                    possiveisMovimentos.Add(destino);
            }
        }
    }

    internal class Bispo : Peca
    {
        public override void preencheListaPos(List<Peca> minhaspecas, List<Peca> outras)
        {
            for (int i = 1; i < 8; i++)
            {
                Posicao NW = new() { x = corrente.x - i, y = corrente.y + i };
                if (verificaPosicao(minhaspecas, NW) || NW.x < 0 || NW.y < 0 || NW.x > 7 || NW.y > 7) break;
                possiveisMovimentos.Add(NW);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao NE = new() { x = corrente.x + i, y = corrente.y + i };
                if (verificaPosicao(minhaspecas, NE) || NE.x < 0 || NE.y < 0 || NE.x > 7 || NE.y > 7) break;
                possiveisMovimentos.Add(NE);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao SW = new() { x = corrente.x - i, y = corrente.y - i };
                if (verificaPosicao(minhaspecas, SW) || SW.x < 0 || SW.y < 0 || SW.x > 7 || SW.y > 7) break;
                possiveisMovimentos.Add(SW);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao SE = new() { x = corrente.x + i, y = corrente.y - i };
                if (verificaPosicao(minhaspecas, SE) || SE.x < 0 || SE.y < 0 || SE.x > 7 || SE.y > 7) break;
                possiveisMovimentos.Add(SE);
            }
        }
    }

    internal class Rainha : Peca
    {
        public override void preencheListaPos(List<Peca> minhaspecas, List<Peca> outras)
        {
            for (int i = 1; i < 8; i++)
            {
                Posicao NW = new() { x = corrente.x - i, y = corrente.y + i };
                if (verificaPosicao(minhaspecas, NW) || NW.x < 0 || NW.y < 0 || NW.x > 7 || NW.y > 7) break;
                possiveisMovimentos.Add(NW);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao NE = new() { x = corrente.x + i, y = corrente.y + i };
                if (verificaPosicao(minhaspecas, NE) || NE.x < 0 || NE.y < 0 || NE.x > 7 || NE.y > 7) break;
                possiveisMovimentos.Add(NE);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao SW = new() { x = corrente.x - i, y = corrente.y - i };
                if (verificaPosicao(minhaspecas, SW) || SW.x < 0 || SW.y < 0 || SW.x > 7 || SW.y > 7) break;
                possiveisMovimentos.Add(SW);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao SE = new() { x = corrente.x + i, y = corrente.y - i };
                if (verificaPosicao(minhaspecas, SE) || SE.x < 0 || SE.y < 0 || SE.x > 7 || SE.y > 7) break;
                possiveisMovimentos.Add(SE);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao direita = new() { x = corrente.x + i, y = corrente.y };
                if (verificaPosicao(minhaspecas, direita) || direita.x < 0 || direita.y < 0 || direita.x > 7 || direita.y > 7) break;
                possiveisMovimentos.Add(direita);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao esquerda = new() { x = corrente.x - i, y = corrente.y };
                if (verificaPosicao(minhaspecas, esquerda) || esquerda.x < 0 || esquerda.y < 0 || esquerda.x > 7 || esquerda.y > 7) break;
                possiveisMovimentos.Add(esquerda);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao cima = new() { x = corrente.x, y = corrente.y + i };
                if (verificaPosicao(minhaspecas, cima) || cima.x < 0 || cima.y < 0 || cima.x > 7 || cima.y > 7) break;
                possiveisMovimentos.Add(cima);
            }
            for (int i = 1; i < 8; i++)
            {
                Posicao baixo = new() { x = corrente.x, y = corrente.y - i };
                if (verificaPosicao(minhaspecas, baixo) || baixo.x < 0 || baixo.y < 0 || baixo.x > 7 || baixo.y > 7) break;
                possiveisMovimentos.Add(baixo);
            }
        }
    }










}